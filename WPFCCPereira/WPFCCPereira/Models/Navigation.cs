using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using WPFCCPereira.Classes;
using WPFCCPereira.Services.Object;
using WPFCCPereira.UserControls;
using WPFCCPereira.UserControls.Administrator;

namespace WPFCCPereira.Models
{
    public class Navigation : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private UserControl _view;

        public UserControl View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(View)));
            }
        }

        public void Navigate(UserControlView newWindow, bool initTimer = false, object data = null, object complement = null) => Application.Current.Dispatcher.Invoke((Action)delegate
        {
            try
            {
                switch (newWindow)
                {
                    case UserControlView.Main:
                        View = data != null ? new MainUC((bool)data) : new MainUC();
                        break;
                    case UserControlView.Consult:
                        View = new ConsultUC((ETransactionType)data);
                        break;
                   //<------------>BEGIN RENOVACION<-------------->
                    case UserControlView.LoginUser:
                        View = new UserControls.Renewal.LoginUC((ETransactionType)data);
                        break;
                    case UserControlView.ConsultRenovacion:
                        View = new UserControls.Renewal.ConsultUC((ETransactionType)data, (Transaction)complement);
                        break;
                    case UserControlView.ActiveCertificate:
                        View = new UserControls.Renewal.ActiveCertificatesUC((Transaction)data);
                        break; 
                    case UserControlView.MenuRenovacion:
                        View = new UserControls.Renewal.MenuFormsUC((Transaction)data);
                        break;
                    case UserControlView.ListEstablecimientos:
                        View = new UserControls.Renewal.ListEstablecimientosUC((Transaction)data);
                        break;
                    //<------------>begin Formularios principal<-------------->
                    case UserControlView.Ppal_Identificacion:
                        View = new UserControls.Renewal.FormsPpal.IdentificacionUC((Transaction)data);
                        break;
                    case UserControlView.Ppal_UbicacionDatosGenerales:
                        View = new UserControls.Renewal.FormsPpal.UbicacionDatosGeneralesUC((Transaction)data);
                        break;
                    case UserControlView.Ppal_ActividadEconomica:
                        View = new UserControls.Renewal.FormsPpal.ActividadEconomicaUC((Transaction)data);
                        break;
                    case UserControlView.Ppal_InformacionFinanciera:
                        View = new UserControls.Renewal.FormsPpal.InformacionFinancieraUC((Transaction)data);
                        break;
                    case UserControlView.Ppal_SistemaSeguridad:
                        View = new UserControls.Renewal.FormsPpal.SistemaSeguridadUC((Transaction)data);
                        break;
                    //<------------>end   Formularios principal<-------------->
                    //<------------->END RENOVACION<--------------->


                    case UserControlView.PaySuccess:
                        View = new SussesUC((Transaction)data);
                        break;
                    case UserControlView.Pay:
                        View = new PaymentUC((Transaction)data);
                        break;
                    case UserControlView.ReturnMony:
                        View = new ReturnMonyUC((Transaction)data);
                        break;
                    case UserControlView.Login:
                        View = new LoginAdministratorUserControl((ETypeAdministrator)data);
                        break;
                    case UserControlView.Config:
                        View = new ConfigurateUserControl();
                        break;
                    case UserControlView.Admin:
                        View = new AdministratorUserControl((PaypadOperationControl)data, (ETypeAdministrator)complement);
                        break;
                    case UserControlView.Certificates:
                        View = new FileUC((Transaction)data);
                        break;
                    case UserControlView.Payer:
                        View = new PayerUC((Transaction)data);
                        break;
                    case UserControlView.PrintFile:
                        View = new PrintFileUC((Transaction)data);
                        break;
                    case UserControlView.Menu:
                        View = new MenuUC();
                        break;
                }

                TimerService.Close();
                WPKeyboard.Keyboard.CloseKeyboard(View);

                if (initTimer)
                {
                    TimerService.CallBackTimerOut = response =>
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            View = new MainUC();
                            WPKeyboard.Keyboard.CloseKeyboard(View);
                        });
                        GC.Collect();
                    };

                    TimerService.Start(int.Parse(Utilities.GetConfiguration("DurationView")));
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, "Navigate", ex);
            }
            GC.Collect();
        });
    }
}