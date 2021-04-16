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

namespace WPFCCPereira.UserControls.Renewal.FormsPpal
{
    /// <summary>
    /// Interaction logic for InformacionFinancieraUC.xaml
    /// </summary>
    public partial class InformacionFinancieraUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        public InformacionFinancieraUC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_ActividadEconomica, data: transaction);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_SistemaSeguridad, data: transaction);
        }

        private void NuevosActivos_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox text = (TextBox)sender;

                if (text.Text.Length > 13)
                {
                    text.Text = text.Text.Remove(text.Text.Length - 1);
                }

                //if (text.Tag.ToString() == "0")
                //{
                //    txtErrorActivos.Text = string.Empty;
                //    bdrActivos.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                //}
                //else
                //{
                //    var service = text.DataContext as ListEstablecimientos;

                //    service.bdActivos = "Transparent";
                //    service.mserroractivos = string.Empty;
                //}
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void NuevosActivos_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender as TextBox, this);
        }
    }
}
