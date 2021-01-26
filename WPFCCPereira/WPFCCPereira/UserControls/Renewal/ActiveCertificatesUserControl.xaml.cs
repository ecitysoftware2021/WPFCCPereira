using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
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

            this.viewModel = new DataListViewModel();

            this.viewModel.ViewList = new CollectionViewSource();

            this.DataContext = viewModel;

            lv_data_list.DataContext = viewModel.ViewList;

            ConfigureViewList();
        }

        private void ConfigureViewList()
        {
            try
            {
                viewModel.ViewList.Source = (transaction.File as DataListViewModel).DataList;
                viewModel.ViewList.View.Refresh();
                lv_data_list.Items.Refresh();
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
