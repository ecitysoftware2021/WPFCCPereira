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
                        datos = transaction.FormularioPpal.datos
                    });

                    Utilities.CloseModal();

                    if (response == null || response.codigoerror != "0000")
                    {
                        Utilities.ShowModal("Ha ocurrido un error al procesar la solicitud. Por favor intenta de nuevo.", EModalType.Error);

                        Utilities.navigator.Navigate(UserControlView.ConsultRenovacion, false, transaction);
                    }
                    else
                    {
                        transaction.FormularioPpal.datos.FinishFormPPal = true;

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
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                transaction.FormularioPpal.datos.ctrmennot = "S";
                transaction.FormularioPpal.datos.aportantesegsocial = "N";
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void cbxAportante_Selected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)cbxAportante.SelectedItem;

                if (grvAportante != null)
                {
                    grvAportante.Visibility = ComboItem.Name.ToUpper() == "SI" ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
                    
                    if (transaction != null)
                    {
                        transaction.FormularioPpal.datos.aportantesegsocial = ComboItem.Tag.ToString() == "SI" ? "S" : "N";
                        transaction.FormularioPpal.datos.tipoaportantesegsocial = ComboItem.Tag.ToString() == "SI" ? "1" : "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void cbxItemsAportante_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)cbxItemsAportante.SelectedItem;

                if (grvAportante != null)
                {
                    if (transaction != null)
                    {
                        transaction.FormularioPpal.datos.tipoaportantesegsocial = ComboItem.Tag.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void cbxNotifications_Selected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)cbxNotifications.SelectedItem;

                if (transaction != null)
                {
                    transaction.FormularioPpal.datos.ctrmennot = ComboItem.Tag.ToString() == "SI" ? "S" : "N";
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
            SaveDataForm();
        }

        private void btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Main);
        }
        #endregion
    }
}
