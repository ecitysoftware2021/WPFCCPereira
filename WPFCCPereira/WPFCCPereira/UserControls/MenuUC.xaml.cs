using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Resources;

namespace WPFCCPereira.UserControls
{
    /// <summary>
    /// Lógica de interacción para MenuUC.xaml
    /// </summary>
    public partial class MenuUC : UserControl
    {
        public MenuUC()
        {
            InitializeComponent();
        }

        private void btn_search_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                var tag = int.Parse(((Button)sender).Tag.ToString());
                if (tag > 0)
                {
                    if (tag == (int)ETransactionType.Renovacion)
                    {
                        Utilities.navigator.Navigate(UserControlView.LoginUser, true, tag);
                    }
                    else
                    {
                        Utilities.navigator.Navigate(UserControlView.Consult, true,
                            tag == (int)ETransactionType.PaymentFile ?
                            ETransactionType.PaymentFile : tag == (int)ETransactionType.ConsultName ?
                            ETransactionType.ConsultName : ETransactionType.ConsultTransact);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Main);
        }
    }
}
