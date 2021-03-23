using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;

namespace WPFCCPereira.UserControls.Renewal.FormsPpal
{
    /// <summary>
    /// Interaction logic for SistemaSeguridadUC.xaml
    /// </summary>
    public partial class SistemaSeguridadUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public SistemaSeguridadUC(Transaction ts)
        {
            InitializeComponent();
            this.transaction = ts;
        }
        #endregion

        #region "Eventos"
        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            transaction.FormularioPpal.datos.FinishFormPPal = true;
            Utilities.navigator.Navigate(UserControlView.Ppal_InformacionFinanciera, data: transaction);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.ListEstablecimientos, data: transaction);
        }
        #endregion
    }
}
