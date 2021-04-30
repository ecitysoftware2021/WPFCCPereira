using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;

namespace WPFCCPereira.UserControls
{
    /// <summary>
    /// Lógica de interacción para MainUserControl.xaml
    /// </summary>
    public partial class MainUserControl : UserControl
    {
        #region "Referencias"

        private List<string> _images;

        private ImageSleader _imageSleader;

        private bool _validatePaypad;

        #endregion

        #region "Constructor"
        public MainUserControl(bool validatePaypad = true)
        {
            InitializeComponent();

            _validatePaypad = validatePaypad;

            Init();
        }
        #endregion

        #region "Métodos"
        private void Init()
        {
            try
            {
                ConfiguratePublish();
                AdminPayPlus.NotificateInformation();
                //AdminPayPlus.VerifyTransaction();
                InitValidation();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void InitValidation()
        {
            try
            {
                Task.Run(() =>
                {
                    while (_validatePaypad)
                    {
                        AdminPayPlus.ValidatePaypad();

                        if (AdminPayPlus.DataPayPlus.StateUpdate)
                        {
                            Utilities.ShowModal(MessageResource.UpdateAplication, EModalType.Error, true);
                            Utilities.UpdateApp();
                            return;
                        }

                        int sleep = int.Parse(AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataComplementary.DurationAlert);
                        Thread.Sleep(sleep);
                    }
                });
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void ConfiguratePublish()
        {
            try
            {
                if (_imageSleader == null)
                {
                    string folder = string.Concat(AdminPayPlus.DataPayPlus.PayPadConfiguration.imageS_PATH, "Publish");

                    _imageSleader = new ImageSleader((List<String>)AdminPayPlus.DataPayPlus.ListImages, folder);

                    this.DataContext = _imageSleader.imageModel;

                    _imageSleader.time = int.Parse(AdminPayPlus.DataPayPlus.PayPadConfiguration.publicitY_TIMER);

                    _imageSleader.isRotate = true;

                    _imageSleader.Start();
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void ValidateStatus()
        {
            try
            {
                if (!Utilities.IsConnectedToInternet())
                {
                    Utilities.ShowModal(string.Concat(MessageResource.NoService, " Se ha perdido la conexión a internet. Por favor intenta de nuevo."), EModalType.Error, true);
                }
                else
                if (AdminPayPlus.DataPayPlus == null)
                {
                    Utilities.ShowModal(string.Concat(MessageResource.NoService, " No se pudo validar el Payplus. Por favor intenta de nuevo."), EModalType.Error, true);
                }
                else
                if (AdminPayPlus.DataPayPlus.StateBalanece)
                {
                    AdminPayPlus.SaveLog(new RequestLog
                    {
                        Reference = "",
                        Description = string.Concat(MessageResource.NoGoInitial, " ", MessageResource.ModoAdministrativo),
                        State = 2,
                        Date = DateTime.Now
                    }, ELogType.General);

                    Utilities.ShowModal(string.Concat(MessageResource.NoGoInitial, " ", MessageResource.ModoAdministrativo), EModalType.Error, true);
                }
                else
                if (AdminPayPlus.DataPayPlus.StateUpload)
                {
                    AdminPayPlus.SaveLog(new RequestLog
                    {
                        Reference = "",
                        Description = string.Concat(MessageResource.NoGoInitial, " ", MessageResource.ModoAdministrativo),
                        State = 2,
                        Date = DateTime.Now
                    }, ELogType.General);

                    Utilities.ShowModal(string.Concat(MessageResource.NoGoInitial, " ", MessageResource.ModoAdministrativo), EModalType.Error, true);
                }
                else
                if (AdminPayPlus.DataPayPlus.State && AdminPayPlus.DataPayPlus.StateAceptance && AdminPayPlus.DataPayPlus.StateDispenser)
                {
                    Redirect(true);
                }
                else
                {
                    Redirect(false);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }
        #endregion

        private void Grid_TouchDown(object sender, TouchEventArgs e)
        {
            ValidateStatus();
        }


        private void Redirect(bool isSusses)
        {
            try
            {
                if (isSusses)
                {
                    AdminPayPlus.SaveLog(new RequestLog
                    {
                        Reference = "",
                        Description = MessageResource.YesGoInitial,
                        State = 1,
                        Date = DateTime.Now
                    }, ELogType.General);

                    _validatePaypad = false;
                    _imageSleader.Stop();

                    Utilities.navigator.Navigate(UserControlView.Menu, true);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}