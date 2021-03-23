using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.ObjectIntegration;

namespace WPFCCPereira.Windows.Modals
{
    /// <summary>
    /// Interaction logic for ModalSearchCiiusW.xaml
    /// </summary>
    public partial class ModalSearchCiiusW : Window
    {
        #region "Referencias"
        public string CiiuSelect;
        private ObservableCollection<Renglone> ciuus;
        #endregion

        #region "Constructor"
        public ModalSearchCiiusW(Transaction ts)
        {
            InitializeComponent();

            CiiuSelect = string.Empty;

            ciuus = new ObservableCollection<Renglone>();

            this.DataContext = ts;
        }
        #endregion

        #region "Métodos"
        private void SearchCiuu()
        {
            try
            {

                if (string.IsNullOrEmpty(txtCIIU.Text))
                {
                    txt_error.Text = "Debe ingresar una referencia a consultar.";

                    grvExample.Visibility = Visibility.Visible;
                    lv_data_list.Visibility = Visibility.Hidden;
                }
                else
                {
                    grvExample.Visibility = Visibility.Hidden;
                    lv_data_list.Visibility = Visibility.Visible;

                    lv_data_list.DataContext = null;
                    lv_data_list.Items.Refresh();

                    string reference = txtCIIU.Text;

                    Task.Run(async () =>
                    {
                        var response = await AdminPayPlus.ApiIntegration.SearchCiuus(reference);

                        Utilities.CloseModal();

                        if (response != null)
                        {
                            LoadView(response);
                        }
                        else
                        {
                            Utilities.ShowModal("No se encontrarón coincidencias. Por favor intenta de nuevo.", EModalType.Error);
                        }
                    });

                    Utilities.ShowModal("Consultando coincidencias. Regálenos unos segundos.", EModalType.Preload);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void LoadView(CIIUS ciiu)
        {
            try
            {
                Dispatcher.BeginInvoke((Action)delegate
                {
                    foreach (var item in ciiu.renglones)
                    {
                        item.extraData = item.detalle;
                        item.expanded = false;
                        item.title1 = "Bold";
                        item.title2 = "";
                        item.title3 = "";

                        ciuus.Add(item);
                    }

                    if (ciuus.Count > 0)
                    {
                        lv_data_list.DataContext = ciuus;
                        lv_data_list.Items.Refresh();
                    }
                });
                GC.Collect();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void ChangeDescription(object sender)
        {
            try
            { 
                var data = (sender as TextBlock).DataContext as Renglone;
                int tag = Convert.ToInt32((sender as TextBlock).Tag);

                if (tag == 1)
                {
                    data.extraData = data.detalle;
                    data.title1 = "Bold";
                    data.title2 = "";
                    data.title3 = "";
                }
                else
                if (tag == 2)
                {
                    data.extraData = data.incluye;
                    data.title1 = "";
                    data.title2 = "Bold";
                    data.title3 = "";
                }
                else
                {
                    data.extraData = data.excluye;
                    data.title1 = "";
                    data.title2 = "";
                    data.title3 = "Bold";
                }

                lv_data_list.Items.Refresh();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void TextBlock_TouchDown(object sender, TouchEventArgs e)
        {
            ChangeDescription(sender);
        }

        private void Border_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                var data = (sender as Border).DataContext as Renglone;

                //if (data != null && !string.IsNullOrEmpty(data.ciiu))
                //{
                    CiiuSelect = data.ciiu;

                    DialogResult = true;
                //}
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Text_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(false, sender, this);
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtCIIU.Text != null && txtCIIU.Text.Length > 20)
                {
                    txtCIIU.Text = txtCIIU.Text.Substring(0, txtCIIU.Text.Length - 1);
                }

                txt_error.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void BtnConsult_TouchDown(object sender, TouchEventArgs e)
        {
            SearchCiuu();
        }

        private void Image_TouchDown(object sender, TouchEventArgs e)
        {
            DialogResult = false;
        }
        #endregion
    }
}
