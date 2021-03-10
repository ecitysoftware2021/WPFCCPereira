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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;

namespace WPFCCPereira.UserControls.Renewal
{
    /// <summary>
    /// Interaction logic for MenuFormsUC.xaml
    /// </summary>
    public partial class MenuFormsUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public MenuFormsUC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            this.DataContext = this.transaction.LiquidarRenovacionNormal;
        }
        #endregion

        #region "Métodos"

        #endregion

        #region "Eventos"
        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Menu);
        }
        #endregion
    }
}
