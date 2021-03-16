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
using WPFCCPereira.Windows.Modals;

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

            LoadView();
        }
        #endregion

        #region "Métodos"
        private void LoadView()
        {
            try
            {

                transaction.LiquidarRenovacionNormal.CantMatriculas = transaction.LiquidarRenovacionNormal.matriculas.Count();

                transaction.payer.IDENTIFICATION = string.Concat("(", transaction.payer.IDENTIFICATION, ")");

                this.DataContext = transaction;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Menu);
        }

        private void btnDigilenciar_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.ListEstablecimientos, data: transaction);
        }

        private void ShowDetail_TouchDown(object sender, TouchEventArgs e)
        {
            this.Opacity = 0.3;
            ModalDetailInformationW modal = new ModalDetailInformationW(transaction);
            modal.ShowDialog();
            this.Opacity = 1;
        }
        #endregion
    }
}
