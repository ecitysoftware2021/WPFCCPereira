using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;

namespace WPFCCPereira.UserControls.Renewal.FormsAdd
{
    /// <summary>
    /// Interaction logic for InformacionFinanciera2UC.xaml
    /// </summary>
    public partial class InformacionFinanciera2UC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public InformacionFinanciera2UC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;
        }
        #endregion

        #region "Eventos"
        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Add_UbicacionDatosGenerales, data: transaction);
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.ListEstablecimientos, data: transaction);
        }

        private void btn_exit_TouchDown(object sender, TouchEventArgs e)
        {

        }
        #endregion
    }
}
