using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;
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
                var detailView = new DetailUserControl(transaction.File, transaction.Type);
                cc_details.Content = detailView;

                if (transaction.Type == ETransactionType.ConsultTransact)
                {
                    var certificateView = new DescriptionUserControl((ResponseTransact)transaction.File);
                    cc_certificates.Content = certificateView;
                }
                else if (transaction.Type == ETransactionType.PaymentFile)
                {
                    var certificateView = new CertificatesUserControl(transaction);
                    cc_certificates.Content = certificateView;
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
