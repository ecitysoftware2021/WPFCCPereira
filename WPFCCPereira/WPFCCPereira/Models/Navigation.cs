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
                        View = data != null ? new MainUserControl((bool)data) : new MainUserControl();
                        break;
                    case UserControlView.Consult:
                        View = new ConsultUserControl((ETransactionType)data);
                        break;
                    //<------------>BEGIN RENOVACION<-------------->
                    case UserControlView.LoginUser:
                        View = new UserControls.Renewal.LoginUC();
                        break;
                    case UserControlView.ConsultRenovacion:
                        View = new UserControls.Renewal.ConsultUC((Transaction)data);
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
                    case UserControlView.DigitalSignature:
                        View = new UserControls.Renewal.DigitalSignatureUC((Transaction)data);
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
                    //<------------>begin Formularios secundarios<-------------->
                    case UserControlView.Add_Identificacion:
                        View = new UserControls.Renewal.FormsAdd.Identificacion2UC((Transaction)data, (string)complement);
                        break;
                    case UserControlView.Add_UbicacionDatosGenerales:
                        View = new UserControls.Renewal.FormsAdd.UbicacionDatosGenerales2UC((Transaction)data, (string)complement);
                        break;
                    case UserControlView.Add_ActividadEconomica:
                        View = new UserControls.Renewal.FormsAdd.ActividadEconomica2UC((Transaction)data, (string)complement);
                        break;
                    case UserControlView.Add_InformacionFinanciera:
                        View = new UserControls.Renewal.FormsAdd.InformacionFinanciera2UC((Transaction)data, (string)complement);
                        break;
                    //<------------>end   Formularios secundarios<-------------->
                    //<------------->END RENOVACION<--------------->

                    case UserControlView.PaySuccess:
                        View = new SussesUserControl((Transaction)data);
                        break;
                    case UserControlView.Pay:
                        View = new PaymentUserControl((Transaction)data);
                        break;
                    case UserControlView.ReturnMony:
                        View = new ReturnMonyUserControl((Transaction)data);
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
                        View = new FileUserControl((Transaction)data);
                        break;
                    case UserControlView.Payer:
                        View = new PayerUserControl((Transaction)data);
                        break;
                    case UserControlView.PrintFile:
                        View = new PrintFileUserControl((Transaction)data);
                        break;
                    case UserControlView.Menu:
                        View = new MenuUserControl();
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
                            View = new MainUserControl();
                            WPKeyboard.Keyboard.CloseKeyboard(View);
                        });
                        GC.Collect();
                    };

                    TimerService.Start(int.Parse(AdminPayPlus.DataPayPlus.PayPadConfiguration.generiC_TIMER));
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