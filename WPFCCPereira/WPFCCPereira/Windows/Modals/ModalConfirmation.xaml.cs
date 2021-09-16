using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;

namespace WPFCCPereira.Windows.Modals
{
    /// <summary>
    /// Interaction logic for ModalConfirmation.xaml
    /// </summary>
    public partial class ModalConfirmation : Window
    {
        #region "Referencias"
        Transaction ts;
        #endregion
        #region "Constructor"
        public ModalConfirmation(Transaction ts)
        {
            InitializeComponent();
            this.ts = ts;
            ConfigureView();
        }
        #endregion

        #region "Metodos"

        private void ConfigureView()
        {
            HideOrShowButtons();
            Utilities.Speack("Elige el modo como deseas realizar el pago.");
        }

        /// <summary>
        /// Oculta o mustra los botones segun la configuracion
        /// </summary>
        private void HideOrShowButtons()
        {
            try
            {
                //TODO: Cambiar la configuracion del config cuando se cambie a config y poner en el extra data si se muestra los 2 botones o solo 1
                //BtnCard.Visibility = Utilities.dataPaypad.PaypadConfiguration.enablE_CARD ? Visibility.Visible : Visibility.Hidden;
                //BtnCash.Visibility = Utilities.dataPaypad.PaypadConfiguration.enablE_VALIDATE_PERIPHERALS ? Visibility.Visible : Visibility.Hidden;

                BtnCard.Visibility = Visibility.Visible;
                BtnCash.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region "Events"
        private void BtnCash_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Pay, false, ts);
            this.Close();
        }
        private void BtnCard_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void BtnDelete_TouchDown(object sender, TouchEventArgs e)
        {

        }
        private void BtnNo_TouchDown(object sender, TouchEventArgs e)
        {

        }
        #endregion
    }
}
