using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.ObjectIntegration;
using WPFCCPereira.Windows.Modals;

namespace WPFCCPereira.UserControls.Renewal
{
    /// <summary>
    /// Interaction logic for MenuFormsUC.xaml
    /// </summary>
    public partial class MenuFormsUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public MenuFormsUC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            LoadView();
        }
        #endregion

        #region "Métodos"
        private void LoadView()
        {
            try
            {
                int cant = transaction.LiquidarRenovacionNormal.matriculas.Count();

                if (transaction.FormularioPpal != null && transaction.FormularioPpal.datos != null)
                {
                    if (transaction.FormularioPpal.datos.FinishFormPPal)
                    {
                        btnFirma.IsEnabled = true;
                        btnFirma.Opacity = 1;

                        cant--;
                    }
                    else
                    {
                        btnFirma.IsEnabled = false;
                        btnFirma.Opacity = 0.4;
                    }

                    if (!string.IsNullOrEmpty(transaction.urlFirmaElectronica))
                    {
                        btnFirma.IsEnabled = false;
                        btnFirma.Opacity = 0.4;

                        btnDigilenciar.IsEnabled = false;
                        btnDigilenciar.Opacity = 0.4;

                        btnPago.IsEnabled = true;
                        btnPago.Opacity = 1;
                    }
                }

                transaction.LiquidarRenovacionNormal.CantMatriculas = cant;

                transaction.numeroRecuperacion = transaction.LiquidarRenovacionNormal.numerorecuperacion;

                transaction.idLiquidacion = transaction.LiquidarRenovacionNormal.idliquidacion;

                transaction.payer.ID = string.Concat("(", transaction.payer.IDENTIFICATION, ")");

                this.DataContext = transaction;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void ConsultarLiquidacion()
        {
            try
            {
                Task.Run(async () =>
                {
                    var response = await AdminPayPlus.ApiIntegration.ConsultarLiquidacion(new ConsultarLiquidacion
                    {
                        identificacioncontrol = transaction.payer.IDENTIFICATION,
                        nombrecontrol = transaction.payer.NAME,
                        emailcontrol = transaction.payer.EMAIL,
                        celularcontrol = transaction.payer.PHONE,
                        idliquidacion = transaction.idLiquidacion,
                        numerorecuperacion = transaction.numeroRecuperacion
                    });

                    if (response != null)
                    {
                        //=>19 firmada electronicamente
                        if (response.idestado == "19")
                        {
                            AplicarDescuento();
                        }
                        else
                        {
                            Utilities.CloseModal();
                            Utilities.ShowModal("No se encontró la firma en el sistema. Por favor intenta de nuevo.", EModalType.Error);
                        }
                    }
                    else
                    {
                        Utilities.CloseModal();
                        Utilities.ShowModal("No se encontró la firma en el sistema. Por favor intenta de nuevo.", EModalType.Error);
                    }
                });

                Utilities.ShowModal("Guardando información. Regálenos unos segundos.", EModalType.Preload);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private async void AplicarDescuento()
        {
            try
            {
                var response = await AdminPayPlus.ApiIntegration.AplicarDescuento1756(Convert.ToInt32(transaction.idLiquidacion));

                Utilities.CloseModal();

                if (response != null)
                {
                    if (response.descuentoaplicado > 0)
                    {
                        transaction.Amount = transaction.Amount - response.descuentoaplicado;
                    }

                    SaveTransaction();

                    //Utilities.ShowModal("La firma ha quedado guardada.", EModalType.Error);

                    //Utilities.navigator.Navigate(UserControlView.MenuRenovacion, data: transaction);
                }
                else
                {
                    Utilities.ShowModal("No se pudo validar la ley 1756. Por favor intenta de nuevo.", EModalType.Error);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void SaveTransaction()
        {

        }
        #endregion

        #region "Eventos"
        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Menu);
        }

        private void btnDigilenciar_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.ListEstablecimientos, data: transaction);
        }

        private void ShowDetail_TouchDown(object sender, TouchEventArgs e)
        {
            this.Opacity = 0.3;
            ModalDetailInformationW modal = new ModalDetailInformationW(transaction);
            modal.ShowDialog();
            this.Opacity = 1;
        }

        private void btnFirma_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.DigitalSignature, data: transaction);
        }

        private void btnPago_TouchDown(object sender, TouchEventArgs e)
        {
            ConsultarLiquidacion();
        }
        #endregion
    }
}
