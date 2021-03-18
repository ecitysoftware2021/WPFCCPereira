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
        private ObservableCollection<CIIUS> ciuus;
        #endregion

        #region "Constructor"
        public ModalSearchCiiusW(Transaction ts)
        {
            InitializeComponent();

            CiiuSelect = string.Empty;

            ciuus = new ObservableCollection<CIIUS>();

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
                }
                else
                {
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

        private void LoadView(CIIUS ciius)
        {
            try
            {
                foreach (var item in ciius.renglones)
                {
                    item.extraData = item.descripcion;
                }

                if (ciius.renglones.Count > 0)
                {
                    lv_data_list.DataContext = ciius.renglones;
                    lv_data_list.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
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

        private void TextBlock_TouchDown(object sender, TouchEventArgs e)
        {
            try
            { //var service = (ProductsState)(sender as ListViewItem).Content;
                var data = (sender as TextBlock).DataContext as Renglone;
                int tag = Convert.ToInt32((sender as TextBlock).Tag);

                if (tag == 1)
                {
                    data.extraData = data.detalle;
                }
                else 
                if (tag == 2)
                {
                    data.extraData = data.incluye;
                }
                else
                {
                    data.extraData = data.excluye;
                }

                lv_data_list.Items.Refresh();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
