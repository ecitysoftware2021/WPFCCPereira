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
using WPFCCPereira.ViewModel;

namespace WPFCCPereira.UserControls.Renewal
{
    /// <summary>
    /// Interaction logic for DigitalSignatureUC.xaml
    /// </summary>
    public partial class DigitalSignatureUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public DigitalSignatureUC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            this.transaction.detailViewModel = new DetailViewModel
            {
                VisibleId = Visibility.Visible,
                VisibleInput = Visibility.Hidden,
                Value2 = "/Images/others/passclosed.png"
            };

            this.DataContext = ts;
        }
        #endregion

        #region "Eventos"
        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.MenuRenovacion, data: transaction);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void Btn_show_id_TouchEnter(object sender, TouchEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPassword.Password))
                {
                    transaction.detailViewModel.Value1 = txtPassword.Password;
                    transaction.detailViewModel.VisibleId = Visibility.Hidden;
                    transaction.detailViewModel.VisibleInput = Visibility.Visible;
                    transaction.detailViewModel.Value2 = "/Images/others/passOpen.png";

                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Btn_show_id_TouchLeave(object sender, TouchEventArgs e)
        {
            try
            {
                transaction.detailViewModel.VisibleId = Visibility.Visible;
                transaction.detailViewModel.VisibleInput = Visibility.Hidden;
                transaction.detailViewModel.Value2 = "/Images/others/passclosed.png";
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPassword.Password != null & txtPassword.Password.Length > 10)
                {
                    txtPassword.Password = txtPassword.Password.Substring(0, txtPassword.Password.Length - 1);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void txtPassword_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(false, sender, this);
        }
        #endregion
    }
}
