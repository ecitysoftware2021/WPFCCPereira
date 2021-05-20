using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.ObjectIntegration;

namespace WPFCCPereira.UserControls.Renewal.FormsPpal
{
    /// <summary>
    /// Interaction logic for SistemaSeguridadUC.xaml
    /// </summary>
    public partial class SistemaSeguridadUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public SistemaSeguridadUC(Transaction ts)
        {
            InitializeComponent();
            this.transaction = ts;
        }
        #endregion

        #region "Métodos"
        private void GetDataForm()
        {
            try
            {
                Task.Run(async () =>
                {
                    var datos = new System.Collections.Generic.List<Datos>();
                    datos.Add(transaction.FormularioPpal.datos);

                    var response = await AdminPayPlus.ApiIntegration.SetFormularioRenovacion(new SetFormularioRenovacion
                    {
                        expediente = transaction.ExpedientesMercantil.matricula,
                        idliquidacion = transaction.LiquidarRenovacionNormal.idliquidacion,
                        numerorecuperacion = transaction.LiquidarRenovacionNormal.numerorecuperacion,
                        datos = datos
                    });

                    Utilities.CloseModal();

                    //if (response == null || response.datos == null)
                    //{
                    //    Utilities.ShowModal("Ha ocurrido un error al procesar la solicitud. Por favor intenta de nuevo.", EModalType.Error);

                    //    Utilities.navigator.Navigate(UserControlView.ConsultRenovacion, false, transaction);
                    //}
                    //else
                    //{

                        Utilities.navigator.Navigate(UserControlView.ListEstablecimientos, data: transaction);
                        //transaction.FormularioPpal = response;

                        //Utilities.navigator.Navigate(UserControlView.Ppal_Identificacion, data: transaction);

                    //}
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
        private void cbxAportante_Selected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)cbxAportante.SelectedItem;

                if (grvAportante != null)
                {
                    grvAportante.Visibility = ComboItem.Name.ToUpper() == "SI" ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_InformacionFinanciera, data: transaction);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            GetDataForm();
            //transaction.FormularioPpal.datos.FinishFormPPal = true;
            //Utilities.navigator.Navigate(UserControlView.ListEstablecimientos, data: transaction);
        }
        #endregion
    }
}
