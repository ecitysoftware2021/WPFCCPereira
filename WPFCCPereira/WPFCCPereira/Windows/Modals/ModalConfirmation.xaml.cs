using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        string Amount;
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
            TxtTitle.Text = "Elige un modo de pago.";
            TxtDate.Text = DateTime.Now.Date.ToLongDateString();
            TxtHora.Text = DateTime.Now.ToShortTimeString();
            TxtTotal.Text = string.Format("{0:C0}", ts.Amount);
            HideOrShowButtons();
            Utilities.Speack("Elige el modo como deseas realizar el pago.");
        }

        /// <summary>
        /// Oculta o mustra los botones segun la configuracion
        /// </summary>
        public void HideOrShowButtons()
        {
            try
            {
                //BtnCard.Visibility = Utilities.dataPaypad.PaypadConfiguration.enablE_CARD ? Visibility.Visible : Visibility.Hidden;
                //BtnCash.Visibility = Utilities.dataPaypad.PaypadConfiguration.enablE_VALIDATE_PERIPHERALS ? Visibility.Visible : Visibility.Hidden;
                if (AdminPayPlus.DataPayPlus.PayPadConfiguration.enablE_CARD)
                {
                    BtnCard.Visibility = Visibility.Visible;
                    BtnCash.Visibility = Visibility.Visible;
                }
                else
                {
                    BtnCard.Visibility = Visibility.Hidden;
                    BtnCash.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void HiddenButtons()
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                this.IsEnabled = false;
                BtnCard.Visibility = Visibility.Hidden;
                BtnCash.Visibility = Visibility.Hidden;
                BtnExit.Visibility = Visibility.Hidden;
                TxtWait.Visibility = Visibility.Visible;
                GifLoadder.Visibility = Visibility.Visible;
            });
        }
        #endregion

        #region "Events"
        private void BtnCash_TouchDown(object sender, TouchEventArgs e)
        {
            HiddenButtons();

            Task.Run(() =>
            {
                Thread.Sleep(3000);
                ts.PaymentType = ETypePay.Cash;
                Utilities.navigator.Navigate(UserControlView.Pay, false, ts);
                Dispatcher.BeginInvoke((Action)delegate
                {
                    this.Close();
                });
            });
        }
        private void BtnCard_TouchDown(object sender, TouchEventArgs e)
        {
            HiddenButtons();

            Task.Run(() =>
            {
                Thread.Sleep(3000);
                ts.PaymentType = ETypePay.Card;
                Utilities.navigator.Navigate(UserControlView.CardPay, false, ts, this);
            });
        }

        private void BtnDelete_TouchDown(object sender, TouchEventArgs e)
        {

        }
        private void BtnNo_TouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
            Utilities.navigator.Navigate(UserControlView.Main);
        }
        #endregion
    }
}
