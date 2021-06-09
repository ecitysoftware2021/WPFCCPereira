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
using System.Collections.Generic;
using System.Linq;

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
                
                if (transaction.FormularioAdd == null)
                {
                    transaction.FormularioAdd = new List<FormularioResponse>();
                }

                if (transaction.FormularioPpal.datos != null && transaction.FormularioPpal.datos.FinishFormPPal)
                {
                    brdPpal.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xFF, 0x00));
                    transaction.ExpedientesMercantil.IMGgrabado = "/Images/Others/imgGrabado.png";
                }
                else
                {
                    brdPpal.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    transaction.ExpedientesMercantil.IMGgrabado = "/Images/Others/imgDigilenciar.png";
                }

                foreach (var item in transaction.ExpedientesMercantil.establecimientos)
                {
                    if ((item.ultanorenovado + 1) == DateTime.Now.Year)
                    {
                        item.Data = item;

                        item.anoporrenovar = item.ultanorenovado + 1;

                        DateTime dtm;

                        DateTime.TryParseExact(item.fecharenovacion, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);

                        item.fecharenovacion = dtm.ToString("MMMM dd, yyyy");

                        item.status = true;

                        item.imgGrabado = "/Images/Others/imgDigilenciar.png";

                        listEstablecimientos.Add(item);
                    }
                }

                if (listEstablecimientos.Count > 0)
                {
                    lv_data_list.DataContext = listEstablecimientos;
                }

                this.DataContext = transaction.ExpedientesMercantil;

                foreach (var item in transaction.FormularioAdd)
                {
                    if (item.datos != null && item.datos.FinishFormAdd)
                    {
                        item.border.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xFF, 0x00));
                    }
                    else
                    {
                        item.border.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    }
                }

                lv_data_list.Items.Refresh();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void GetDataForm(UserControlView view, string matricula, object sender = null)
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

                    if (response == null || response.datos == null)
                    {
                        Utilities.ShowModal("Ha ocurrido un error al procesar la solicitud. Por favor intenta de nuevo.", EModalType.Error);

                        Utilities.navigator.Navigate(UserControlView.ConsultRenovacion, false, transaction);
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
                            response.border = ((Grid)sender).Parent as Border;

                            transaction.FormularioAdd.Add(response);
                            
                            Utilities.navigator.Navigate(UserControlView.Add_Identificacion, data: transaction, complement: matricula);
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
            try
            {
                if (transaction.FormularioPpal != null && transaction.FormularioPpal.datos != null)
                { 
                    Utilities.navigator.Navigate(UserControlView.Ppal_Identificacion, data: transaction);
                }
                else
                {
                    GetDataForm(UserControlView.Ppal_Identificacion, transaction.ExpedientesMercantil.matricula);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.MenuRenovacion, data: transaction);
        }
        #endregion

        private void frmAdd_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                var data = ((Grid)sender).Tag as ListEstablecimientos;

                if (data != null)
                {
                    var result = transaction.FormularioAdd.Where(x => x.datos.matricula == data.matricula).FirstOrDefault();

                    if (result == null)
                    {
                        GetDataForm(UserControlView.Add_Identificacion, data.matricula, sender);
                    }
                    else
                    {
                        Utilities.navigator.Navigate(UserControlView.Add_Identificacion, data: transaction, complement: data.matricula);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
