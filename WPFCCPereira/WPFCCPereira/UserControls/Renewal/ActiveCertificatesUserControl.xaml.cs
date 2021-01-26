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
    /// Interaction logic for ActiveCertificatesUserControl.xaml
    /// </summary>
    public partial class ActiveCertificatesUserControl : UserControl
    {
        private DataListViewModel viewModel; 
        private Transaction transaction;

        public ActiveCertificatesUserControl(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            this.DataContext = viewModel;

            ConfigureViewList();
        }

        private void ConfigureViewList()
        {
            try
            {
                Dispatcher.BeginInvoke((Action)delegate
                {
                    viewModel.ViewList.Source = (transaction.File as DataListViewModel).DataList;
                    viewModel.ViewList.View.Refresh();
                    lv_data_list.Items.Refresh();
                });
                GC.Collect();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Grid_TouchDown(object sender, TouchEventArgs e)
        {
            if (((Grid)sender).Tag != null)
            {

                //Utilities.navigator.Navigate(UserControlView.Certificates, true, new Transaction
                //{
                //    File = (Noun)((Grid)sender).Tag,
                //    State = ETransactionState.Initial,
                //    Type = viewModel.TypeTransaction
                //});
            }
        }

        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                Utilities.navigator.Navigate(UserControlView.Menu);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
