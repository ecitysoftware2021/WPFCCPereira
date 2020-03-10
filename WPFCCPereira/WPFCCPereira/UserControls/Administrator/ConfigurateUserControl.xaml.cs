using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFCCPereira.Classes;
using WPFCCPereira.KeyboardNew;
using WPFCCPereira.Resources;

namespace WPFCCPereira.UserControls.Administrator
{
    /// <summary>
    /// Lógica de interacción para ConfigurateUserControl.xaml
    /// </summary>
    public partial class ConfigurateUserControl : UserControl
    {
        private AdminPayPlus init;

        public ConfigurateUserControl()
        {
            InitializeComponent();

            if (init == null)
            {
                init = new AdminPayPlus();
            }

            Keyboard2.ConsttrucKeyyboard(Keyboard2.EColor.Azul);

            txt_description.DataContext = init;

            Initial();
        }

        private async void Initial()
        {
            try
            {
                init.callbackResult = result =>
                {
                    ProccesResult(result);
                };

                init.Start();
            }
            catch (Exception ex)
            {
            }
        }

        private async void ProccesResult(bool result)
        {
            try
            {
                if (AdminPayPlus.DataPayPlus.StateBalanece)
                {
                    Utilities.navigator.Navigate(UserControlView.Login, false, 1);
                }
                else if (AdminPayPlus.DataPayPlus.StateUpload)
                {
                    Utilities.navigator.Navigate(UserControlView.Login, false, 2);
                }
                else
                {
                    Finish(result);
                }
            }
            catch (Exception ex)
            {
                Utilities.ShowModal(MessageResource.NoService, EModalType.Error, false);
                Initial();
            }
        }

        private void Finish(bool state)
        {
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                if (state)
                {
                    Utilities.navigator.Navigate(UserControlView.Main);
                }
                else
                {
                    Utilities.ShowModal(string.Concat(init.DescriptionStatusPayPlus, "  ", MessageResource.NoService), EModalType.Error, false);
                    Initial();
                }
            });
        }
    }
}
