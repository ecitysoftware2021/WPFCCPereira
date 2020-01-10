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
        private Transaction transaction;

        private DataListViewModel viewModel;

        public ConsultUserControl()
        {
            InitializeComponent();

            ConfigurateView();
        }

        private void ConfigurateView()
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
                    TypeConsult = EtypeConsult.Id,
                };

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
                    if (viewModel.TypeConsult == EtypeConsult.Id)
                    {
                        SearchData(text_id.Text);
                    }
                    else
                    {
                        SearchData(text_name.Text);
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

                        if (response)
                        {
                            ConfigureViewList();
                        }
                        else
                        {
                            Application.Current.Dispatcher.Invoke(delegate
                            {
                                if (viewModel.TypeConsult == EtypeConsult.Id)
                                {
                                    text_id.Text = string.Empty;
                                }
                                else
                                {
                                    text_name.Text = string.Empty;
                                }
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
                var typeConsul = int.Parse(((Image)sender).Tag.ToString());

                if (typeConsul != (int)viewModel.TypeConsult)
                {
                    if (typeConsul == (int)EtypeConsult.Id)
                    {
                        viewModel.TypeConsult = EtypeConsult.Id;
                        viewModel.VisibilityId = Visibility.Visible;
                        viewModel.VisibilityName = Visibility.Hidden;

                        text_id.Text = "";
                        text_name.Text = "";

                        viewModel.SourceCheckId = ImagesUrlResource.ImageCheckId;
                        viewModel.Tittle = MessageResource.EnterId;
                    }
                    else
                    {
                        viewModel.TypeConsult = EtypeConsult.Name;
                        viewModel.VisibilityId = Visibility.Hidden;
                        viewModel.VisibilityName = Visibility.Visible;

                        text_id.Text = "";
                        text_name.Text = "";

                        viewModel.SourceCheckId = ImagesUrlResource.ImageCheckName;
                        viewModel.Tittle = MessageResource.EnterName;
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
                Utilities.navigator.Navigate(UserControlView.Main);
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

        private void Text_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                ConfigureViewList();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
