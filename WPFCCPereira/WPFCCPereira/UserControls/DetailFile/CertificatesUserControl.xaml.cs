using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;
using WPFCCPereira.ViewModel;

namespace WPFCCPereira.UserControls.DetailFile
{
    /// <summary>
    /// Lógica de interacción para CertificatesUserControl.xaml
    /// </summary>
    public partial class CertificatesUserControl : UserControl
    {
        private Transaction transaction;

        private DataListViewModel viewModel;

        public CertificatesUserControl(Transaction transaction)
        {
            InitializeComponent();

            this.transaction = transaction;

            ConfigurateView();
        }

        private void ConfigurateView()
        {
            try
            {
                viewModel = new DataListViewModel
                {
                    Tittle = "",
                    ViewList = new CollectionViewSource(),
                    DataList = new List<ItemList>()
                };

                foreach (var certificate in transaction.File.certificados)
                {
                    viewModel.DataList.Add(new ItemList {Item1 = certificate.descripcioncertificado, Item6 = 0});
                }

                this.DataContext = viewModel;
                viewModel.ViewList.Source = viewModel.DataList;
                lv_certificates.DataContext = viewModel.ViewList;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void BtnContinue_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void LoadFiles()
        {
            try
            {
                if (AdminPayPlus.PrinterFile.GetStatus())
                {
                    transaction = viewModel.GetListFiles(transaction);
                    if (transaction.Products != null && transaction.Products.Count > 0)
                    {
                        transaction.Amount = viewModel.Amount;

                        Utilities.navigator.Navigate(UserControlView.Payer, true, transaction);
                    }
                    else
                    {
                        Utilities.ShowModal(MessageResource.ErrorCertificate, EModalType.Error);
                    }
                }
                else
                {
                    Utilities.ShowModal(MessageResource.ErrorPrinter, EModalType.Error);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
