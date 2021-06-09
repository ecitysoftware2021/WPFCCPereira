using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.ObjectIntegration;

namespace WPFCCPereira.UserControls.Renewal.FormsAdd
{
    /// <summary>
    /// Interaction logic for InformacionFinanciera2UC.xaml
    /// </summary>
    public partial class InformacionFinanciera2UC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        private string matricula;
        private FormularioResponse form;
        #endregion

        #region "Constructor"
        public InformacionFinanciera2UC(Transaction ts, string mt)
        {
            InitializeComponent();

            this.transaction = ts;

            this.matricula = mt;

            LoadView();
        }
        #endregion

        #region "Métodos"
        private void LoadView()
        {
            try
            {
                form = transaction.FormularioAdd.Where(x => x.datos.matricula == matricula).FirstOrDefault();

                if (form != null)
                {
                    form.datos.anodatos = DateTime.Now.Year.ToString();

                    var result2 = transaction.LiquidarRenovacionNormal.matriculas.Where(x => x.matricula == matricula).FirstOrDefault();

                    form.datos.actvin = result2.activos;

                    this.DataContext = form.datos;
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void addData()
        {
            try
            {
                form.datos.f = new System.Collections.Generic.List<ArrayF>();

                form.datos.f.Add(new ArrayF
                {
                    anodatos = form.datos.anodatos,
                    fechadatos = string.Concat(DateTime.Now.Year - 1, "1231"),
                    actvin = form.datos.actvin,
                    //fechadatos = transaction.FormularioPpal.datos.fechadatos,
                    actcte =   0,//transaction.FormularioPpal.datos.actcte,
                    actnocte = 0,//transaction.FormularioPpal.datos.actnocte,
                    acttot =   0,//transaction.FormularioPpal.datos.acttot,
                    pascte =   0,//transaction.FormularioPpal.datos.pascte,
                    paslar =   0,//transaction.FormularioPpal.datos.paslar,
                    pastot =   0,//transaction.FormularioPpal.datos.pastot,
                    pattot =   0,//transaction.FormularioPpal.datos.pattot,
                    paspat =   0,//transaction.FormularioPpal.datos.paspat,
                    ingope =   0,//transaction.FormularioPpal.datos.ingope,
                    ingnoope = 0,//transaction.FormularioPpal.datos.ingnoope,
                    cosven =   0,//transaction.FormularioPpal.datos.cosven,
                    utiope =   0,//transaction.FormularioPpal.datos.utiope,
                    personal = form.datos.personal,
                    personaltemp = form.datos.personaltemp
                });

                SaveDataForm();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void SaveDataForm()
        {
            try
            {
                Task.Run(async () =>
                {
                    var response = await AdminPayPlus.ApiIntegration.SetFormularioRenovacion(new SetFormularioRenovacion
                    {
                        expediente = transaction.ExpedientesMercantil.matricula,
                        idliquidacion = transaction.LiquidarRenovacionNormal.idliquidacion,
                        numerorecuperacion = transaction.LiquidarRenovacionNormal.numerorecuperacion,
                        datos = form.datos
                    });

                    Utilities.CloseModal();

                    if (response == null || response.codigoerror != "0000")
                    {
                        Utilities.ShowModal("Ha ocurrido un error al procesar la solicitud. Por favor intenta de nuevo.", EModalType.Error);

                        Utilities.navigator.Navigate(UserControlView.ConsultRenovacion, false, transaction);
                    }
                    else
                    {
                        form.datos.FinishFormAdd = true;
                        Utilities.navigator.Navigate(UserControlView.ListEstablecimientos, data: transaction);
                    }
                });

                Utilities.ShowModal("Guardando información del formulario. Regálenos unos segundos.", EModalType.Preload);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            addData();
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Add_ActividadEconomica, data: transaction, complement: matricula);
        }

        private void btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Main);
        }

        private void TextBox_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender, this);
        }
        #endregion
    }
}
