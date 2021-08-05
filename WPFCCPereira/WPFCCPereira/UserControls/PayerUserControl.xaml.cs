using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using WPFCCPereira.Classes;
using WPFCCPereira.Classes.UseFull;
using WPFCCPereira.DataModel;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.ViewModel;

namespace WPFCCPereira.UserControls
{
    /// <summary>
    /// Lógica de interacción para PayerUserControl.xaml
    /// </summary>
    public partial class PayerUserControl : UserControl
    {
        private DetailViewModel viewModel;

        private Transaction transaction;

        private ReaderBarCode readerBarCode;

        public PayerUserControl(Transaction transaction) 
        {
            InitializeComponent();

            this.transaction = transaction;

            if (readerBarCode == null)
            {
                readerBarCode = new ReaderBarCode();
            }

            ConfigView();
        }

        private void ConfigView()
        {
            try
            {
                viewModel = new DetailViewModel
                {
                    Row1 = "Identificación *",
                    Row2 = "Nombres *",
                    Row3 = "Celular * ",
                    Row4 = "Apellidos* ",
                    Row5 = "Correo* ",
                    OptionsEntries = new CollectionViewSource(),
                    OptionsList = new List<TypeDocument>(),
                    TypePayer = ETypePayer.Person,
                    LastNameVisible = System.Windows.Visibility.Visible
                };

                viewModel.LoadList();
                cmb_type_id.SelectedIndex = 0;

                this.DataContext = viewModel;

                InicielizeBarcodeReader();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void InicielizeBarcodeReader()
        {
            try
            {
                readerBarCode.callbackOut = data =>
                {
                    if (data != null && viewModel.TypePayer == ETypePayer.Person)
                    {
                        viewModel.Value1 = data.Document;
                        viewModel.Value2 = string.Concat(data.FirstName, " ", data.LastName);
                        viewModel.Value3 = "";
                        viewModel.Value4 = string.Concat(data.SecondName, " ", data.SecondLastName);
                    }
                };

                readerBarCode.callbackError = error =>
                {

                };

                readerBarCode.Start();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Btn_payment_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    if (AdminPayPlus.DataPayPlus.PayPadConfiguration.enablE_VALIDATE_PERIPHERALS)
                    {
                        SaveTransaction(((TypeDocument)cmb_type_id.SelectedItem).Type);
                    }
                    else
                    {
                        Utilities.ShowModal(string.Format("Estimado, los dispositivos no estan habilitados."), EModalType.Error);
                        Utilities.RestartApp();
                    }
                }
                else
                {
                    Utilities.ShowModal(MessageResource.InfoIncorrect, EModalType.Error);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private bool ValidateFields()
        {
            try
            {
                if (viewModel.Value1.Length < 6)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(viewModel.Value2))
                {
                    return false;
                }

                if (viewModel.Value3.Length < 6)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(viewModel.Value4) && viewModel.TypePayer == ETypePayer.Person)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(viewModel.Value5) || viewModel.Value5.Length < 6)
                {
                    return false;
                }
                
                if (!Utilities.IsValidEmailAddress(viewModel.Value5))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
                return false;
            }
        }

        private void SaveTransaction(int typeDocument)
        {
            try
            {
                Task.Run(async () =>
                {
                    try
                    {
                        transaction.payer = new PAYER
                        {
                            IDENTIFICATION = viewModel.Value1,
                            NAME = viewModel.Value2,
                            LAST_NAME = viewModel.Value4,
                            PHONE = viewModel.Value3,
                            EMAIL = viewModel.Value5,
                            TYPE_PAYER = viewModel.TypePayer == ETypePayer.Person ? "Persona" : "Empresa",
                            TYPE_IDENTIFICATION = typeDocument
                        };

                        var response = await AdminPayPlus.ApiIntegration.NotifycTransaction(this.transaction);

                        var amountDiscount = await AdminPayPlus.ApiIntegration.GetDiscount(this.transaction);

                        transaction.Amount = transaction.Amount - amountDiscount;

                        if (response != null && !string.IsNullOrEmpty(response.consecutive) && !string.IsNullOrEmpty(response.reference))
                        {
                            await AdminPayPlus.SaveTransactions(this.transaction);

                            Utilities.CloseModal();
                            readerBarCode.Stop();

                            if (this.transaction.IdTransactionAPi == 0)
                            {
                                Utilities.ShowModal(MessageResource.ErrorTransaction, EModalType.Error);
                                Utilities.navigator.Navigate(UserControlView.Main);
                            }
                            else
                            {
                                Utilities.navigator.Navigate(UserControlView.Pay, false, transaction);
                            }
                        }
                        else
                        {
                            Utilities.CloseModal();
                            readerBarCode.Stop();
                            Utilities.ShowModal(MessageResource.ErrorTransaction, EModalType.Error);
                            Utilities.navigator.Navigate(UserControlView.Main);
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.CloseModal();
                        readerBarCode.Stop();
                        Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
                    }
                });

                Utilities.ShowModal(MessageResource.LoadInformation, EModalType.Preload);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Btn_back_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            try
            {
                readerBarCode.Stop();
                Utilities.navigator.Navigate(UserControlView.Main);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Cmb_type_id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var itemSeleted = (TypeDocument)cmb_type_id.SelectedItem;

                if (itemSeleted.Type != (int)viewModel.TypePayer)
                {
                    if (itemSeleted.Type == (int)ETypePayer.Person)
                    {
                        viewModel.TypePayer = ETypePayer.Person;
                        viewModel.Row2 = "Nombre *";
                        viewModel.LastNameVisible = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        viewModel.TypePayer = ETypePayer.Establishment;
                        viewModel.Row2 = "Razón Social*";
                        viewModel.LastNameVisible = System.Windows.Visibility.Hidden;
                    }

                    viewModel.Value1 = string.Empty;
                    viewModel.Value2 = string.Empty;
                    viewModel.Value3 = string.Empty;
                    viewModel.Value4 = string.Empty;
                    viewModel.Value5 = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void TbxData1_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            try
            {
                Utilities.OpenKeyboard(false, sender, this);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void TbxData2_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            try
            {
                Utilities.OpenKeyboard(true, sender, this);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void TbxIdentification_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            try
            {
                Utilities.OpenKeyboard(true, sender, this);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void TbxData3_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            try
            {
                Utilities.OpenKeyboard(false, sender, this);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
