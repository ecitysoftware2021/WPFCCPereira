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
using WPFCCPereira.UserControls.DetailFile;

namespace WPFCCPereira.UserControls
{
    /// <summary>
    /// Lógica de interacción para FileUserControl.xaml
    /// </summary>
    public partial class FileUserControl : UserControl
    {
        private Transaction transaction;

        public FileUserControl(Transaction transaction)
        {
            InitializeComponent();

            this.transaction = transaction;

            LoadView();
        }

        private void LoadView()
        {
            try
            {
                var detailView = new DetailUserControl(transaction.File);
                cc_details.Content = detailView;

                var certificateView = new CertificatesUserControl(transaction);
                cc_certificates.Content = certificateView;
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                Utilities.navigator.Navigate(UserControlView.Consult);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
