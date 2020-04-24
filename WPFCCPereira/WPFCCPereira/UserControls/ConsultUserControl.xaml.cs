using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.KeyboardNew;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;
using WPFCCPereira.ViewModel;

namespace WPFCCPereira.UserControls
{
    /// <summary>
    /// Lógica de interacción para ConsultUserControl.xaml
    /// </summary>
    public partial class ConsultUserControl : UserControl
    {

        private DataListViewModel viewModel;

        public ConsultUserControl(ETransactionType type)
        {
            InitializeComponent();

            ConfigurateView(type);
        }

        private void ConfigurateView(ETransactionType type)
        {
            try
            {
                viewModel = new DataListViewModel
                {
                    SourceCheckId = ImagesUrlResource.ImageCheckId,
                    ViewList = new CollectionViewSource(),
                    DataList = new List<ItemList>(),
                    Message = MessageResource.EnterId,
                    VisibilityId = Visibility.Visible,
                    VisibilityName = Visibility.Hidden,
                    VisibleTab = Visibility.Visible,
                    TypeConsult = EtypeConsult.Id,
                    TypeTransaction = type,
                    OptionCheck = EtypeConsult.Id,
                    OptionChecktwo = EtypeConsult.Name,
                    Background = ImagesUrlResource.BackgroundConsult
                };

                if (viewModel.TypeTransaction == ETransactionType.ConsultName)
                {
                    viewModel.VisibleTab = Visibility.Hidden;
                    viewModel.TypeConsult = EtypeConsult.Name;
                    viewModel.VisibilityId = Visibility.Hidden;
                    viewModel.VisibilityName = Visibility.Visible;
                    viewModel.SourceCheckId = "";
                    lbl_tittle.Visibility = Visibility.Hidden;
                    viewModel.Background = ImagesUrlResource.BackgroundConsultName;
                    viewModel.Message = MessageResource.EnterNameConsult;
                }

                if (viewModel.TypeTransaction == ETransactionType.ConsultTransact)
                {
                    viewModel.VisibleTab = Visibility.Visible;
                    viewModel.TypeConsult = EtypeConsult.Settled;
                    viewModel.Background = ImagesUrlResource.BackgroundConsultTransact;
                    viewModel.OptionCheck = EtypeConsult.Receipt;
                    lbl_tittle.Visibility = Visibility.Hidden;
                    viewModel.OptionChecktwo = EtypeConsult.Settled;
                    viewModel.SourceCheckId = ImagesUrlResource.ImageCheckRadicate;
                    viewModel.Message = MessageResource.EnterConsecutive;
                }

                this.DataContext = viewModel;

                lv_data_list.DataContext = viewModel.ViewList;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void ConfigureViewList()
        {
            try
            {
                Dispatcher.BeginInvoke((Action)delegate
                {
                    viewModel.ViewList.Source = viewModel.DataList;
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

        private void BtnConsult_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                if (ValidateDocument())
                {
                    if (viewModel.TypeConsult == EtypeConsult.Name || viewModel.TypeConsult == EtypeConsult.Receipt)
                    {
                        SearchData(text_name.Text);
                    }
                    else
                    {
                        SearchData(text_id.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void SearchData(object reference)
        {
            try
            {
                Task.Run(async () =>
                {
                    try
                    {
                        var response = await viewModel.ConsultConcidences((string)reference, viewModel.TypeConsult);

                        Utilities.CloseModal();

                        if (response != null)
                        {
                            if (viewModel.TypeConsult == EtypeConsult.Receipt || viewModel.TypeConsult == EtypeConsult.Settled)
                            {
                                Utilities.navigator.Navigate(UserControlView.Certificates, true, new Transaction
                                {
                                    File = response,
                                    State = ETransactionState.Initial,
                                    Type = viewModel.TypeTransaction
                                });
                            }
                            else
                            {
                                ConfigureViewList();
                            }
                        }
                        else
                        {
                            Application.Current.Dispatcher.Invoke(delegate
                            {
                                text_id.Text = string.Empty;

                                text_name.Text = string.Empty;
                            });

                            Utilities.ShowModal(MessageResource.ErrorCoincidences, EModalType.Error);

                            //TimerService.Reset();
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.CloseModal();
                        Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
                    }
                });

                Utilities.ShowModal(MessageResource.ConsultingConinsidences, EModalType.Preload);
            }
            catch (Exception ex)
            {
                Utilities.CloseModal();
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void ValidateListView(bool activateList)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    Thread.Sleep(300);
                    this.IsEnabled = activateList;
                });
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private bool ValidateDocument()
        {
            try
            {
                if (viewModel.TypeConsult == EtypeConsult.Id)
                {
                    if (string.IsNullOrEmpty(text_id.Text) || text_id.Text.Length <= 6 || text_id.Text.Length >= 12)
                    {
                        txt_error.Text = MessageResource.ErrorId;
                        return false;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(text_name.Text))
                    {
                        txt_error.Text = MessageResource.ErrorName;
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
                return false;
            }
        }

        private void Lv_data_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = (ItemList)lv_data_list.SelectedItem;
                if (item != null)
                {
                    ValidateListView(false);
                    lv_data_list.SelectedItem = null;

                    Utilities.navigator.Navigate(UserControlView.Certificates, true, new Transaction
                    {
                        File = (Noun)item.Data,
                        State = ETransactionState.Initial,
                        Type = viewModel.TypeTransaction
                    });
                }
            }

            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Select_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                var typeConsul = (EtypeConsult)((Button)sender).Tag;

                if (typeConsul != viewModel.TypeConsult)
                {
                    if (typeConsul == EtypeConsult.Id)
                    {
                        viewModel.TypeConsult = EtypeConsult.Id;
                        viewModel.VisibilityId = Visibility.Visible;
                        viewModel.VisibilityName = Visibility.Hidden;
                        text_id.Text = "";
                        text_name.Text = "";
                        lbl_tittle.Visibility = Visibility.Visible;
                        viewModel.SourceCheckId = ImagesUrlResource.ImageCheckId;
                        viewModel.Message = MessageResource.EnterId;
                    }
                    else if (typeConsul == EtypeConsult.Name)
                    {
                        viewModel.TypeConsult = EtypeConsult.Name;
                        viewModel.VisibilityId = Visibility.Hidden;
                        viewModel.VisibilityName = Visibility.Visible;
                        text_id.Text = "";
                        text_name.Text = "";
                        lbl_tittle.Visibility = Visibility.Hidden;
                        viewModel.SourceCheckId = ImagesUrlResource.ImageCheckName;
                        viewModel.Message = MessageResource.EnterName;
                    }
                    else if (typeConsul == EtypeConsult.Settled)
                    {
                        viewModel.TypeConsult = EtypeConsult.Settled;
                        viewModel.VisibilityId = Visibility.Visible;
                        viewModel.VisibilityName = Visibility.Hidden;
                        text_id.Text = "";
                        text_name.Text = "";
                        lbl_tittle.Visibility = Visibility.Hidden;
                        viewModel.SourceCheckId = ImagesUrlResource.ImageCheckRadicate;
                        viewModel.Message = MessageResource.EnterConsecutive;
                    }
                    else
                    {
                        viewModel.TypeConsult = EtypeConsult.Receipt;
                        viewModel.VisibilityId = Visibility.Hidden;
                        viewModel.VisibilityName = Visibility.Visible;
                        text_id.Text = "";
                        text_name.Text = "";
                        lbl_tittle.Visibility = Visibility.Hidden;
                        viewModel.SourceCheckId = ImagesUrlResource.ImageCheckReceipt;
                        viewModel.Message = MessageResource.EnterConsecutive;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
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

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txt_error.Text = "";
                if (viewModel.TypeConsult == EtypeConsult.Id)
                {
                    if (text_id.Text.Length > 12)
                    {
                        text_id.Text = text_id.Text.Substring(0, (text_id.Text.Length - 1));
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Text_name_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                viewModel.DataList.Clear();
                ConfigureViewList();
                Keyboard2.InitKeyboard((sender as TextBox), this, Keyboard2.EType.Standar);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Text_id_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                viewModel.DataList.Clear();
                ConfigureViewList();
                Keyboard2.InitKeyboard((sender as TextBox), this, Keyboard2.EType.Numeric);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
