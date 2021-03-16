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

                string a = Utilities.EncryptorData("tj4ALHuT2IReSA94TXOTAxGFmbu4ziT+B4mRzsq56RY=",false,"WPFEmpresaEPM");
                string b = Utilities.EncryptorData("Pay+ EPM Punto Facil Rionegro", true, "WPFEmpresaEPM");
                string c = Utilities.EncryptorData("EmpresaPublicadeMedellin2021%",true, "WPFEmpresaEPM");
                string d = Utilities.EncryptorData("Ecitysoftware2019#");
                string e = Utilities.EncryptorData("https://e-citypay.co/");

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
