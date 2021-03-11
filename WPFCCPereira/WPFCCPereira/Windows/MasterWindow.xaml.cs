using System;
using System.Reflection;
using System.Windows;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;

namespace WPFCCPereira.Windows
{
    /// <summary>
    /// Lógica de interacción para MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        public MasterWindow()
        {
            InitializeComponent();

            SetUserControl();
        }

        private void SetUserControl()
        {
            try
            {
                WPKeyboard.Keyboard.ConsttrucKeyyboard(WPKeyboard.Keyboard.EStyle.style_2);
                if (Utilities.navigator == null)
                {
                    Utilities.navigator = new Navigation();
                }

                string a = Encryptor.Encrypt("usrapli");
                string b = Encryptor.Encrypt("1Cero12019$/*");
                string c = Encryptor.Encrypt("Ecity.Software");
                string d = Encryptor.Encrypt("Ecitysoftware2019#");
                string e = Encryptor.Encrypt("https://e-citypay.co/");

                Utilities.navigator.Navigate(UserControlView.Config);

                DataContext = Utilities.navigator;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
