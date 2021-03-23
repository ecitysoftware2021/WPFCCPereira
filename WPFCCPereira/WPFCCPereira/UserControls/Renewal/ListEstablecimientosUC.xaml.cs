using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.ObjectIntegration;

namespace WPFCCPereira.UserControls.Renewal
{
    /// <summary>
    /// Interaction logic for ListEstablecimientosUC.xaml
    /// </summary>
    public partial class ListEstablecimientosUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        private ObservableCollection<ListEstablecimientos> listEstablecimientos;
        #endregion

        #region "Constructor"
        public ListEstablecimientosUC(Transaction ts)
        {
            InitializeComponent();

            this.listEstablecimientos = new ObservableCollection<ListEstablecimientos>();

            this.transaction = ts;

            ConfigureViewList();
        }
        #endregion

        #region "Métodos"


        private void ConfigureViewList()
        {
            try
            {
                if (transaction.FormularioPpal == null)
                {
                    transaction.FormularioPpal = new FormularioResponse();
                }


                if (!transaction.FormularioPpal.datos.FinishFormPPal)
                {
                    brdPpal.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    transaction.ExpedientesMercantil.IMGgrabado = "/Images/Others/imgGrabado.png";
                }
                else
                {
                    brdPpal.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xFF, 0x00));
                    transaction.ExpedientesMercantil.IMGgrabado = "/Images/Others/imgDigilenciar.png";
                }

                foreach (var item in transaction.ExpedientesMercantil.establecimientos)
                {
                    if ((item.ultanorenovado + 1) == DateTime.Now.Year)
                    {
                        item.anoporrenovar = item.ultanorenovado + 1;

                        DateTime dtm;

                        DateTime.TryParseExact(item.fecharenovacion, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);

                        item.fecharenovacion = dtm.ToString("MMMM dd, yyyy");

                        item.status = true;

                        listEstablecimientos.Add(item);
                    }
                }

                if (listEstablecimientos.Count > 0)
                {
                    lv_data_list.DataContext = listEstablecimientos;
                }

                this.DataContext = transaction.ExpedientesMercantil;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void GetDataForm(UserControlView view, string matricula)
        {
            try
            {
                Task.Run(async () =>
                {
                    var response = await AdminPayPlus.ApiIntegration.GetFormularioRenovacion(new GetFormularioRenovacion 
                    {
                        expediente = matricula,
                        idliquidacion = transaction.LiquidarRenovacionNormal.idliquidacion,
                        numerorecuperacion = transaction.LiquidarRenovacionNormal.numerorecuperacion
                    });

                    Utilities.CloseModal();

                    if (response == null)
                    {
                        Utilities.ShowModal("Ha ocurrido un error al procesar la solicitud. Por favor intenta de nuevo.", EModalType.Error);
                    }
                    else
                    {
                        if (view == UserControlView.Ppal_Identificacion)
                        {
                            transaction.FormularioPpal = response;

                            Utilities.navigator.Navigate(UserControlView.Ppal_Identificacion, data: transaction);
                        }
                        else
                        {

                        }
                    }
                });

                Utilities.ShowModal("Consultando información del formulario. Regálenos unos segundos.", EModalType.Preload);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Menu);
        }

        private void frmPpal_TouchDown(object sender, TouchEventArgs e)
        {
            GetDataForm(UserControlView.Ppal_Identificacion, transaction.ExpedientesMercantil.matricula);
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.MenuRenovacion, data: transaction);
        }
        #endregion

    }
}
