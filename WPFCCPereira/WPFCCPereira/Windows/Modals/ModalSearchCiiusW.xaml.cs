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
using System.Windows.Shapes;
using WPFCCPereira.Classes;
using WPFCCPereira.Resources;

namespace WPFCCPereira.Windows.Modals
{
    /// <summary>
    /// Interaction logic for ModalSearchCiiusW.xaml
    /// </summary>
    public partial class ModalSearchCiiusW : Window
    {
        #region "Referencias"
        public string CiiuSelect;
        #endregion

        #region "Constructor"
        public ModalSearchCiiusW()
        {
            InitializeComponent();

            CiiuSelect = string.Empty;
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
                    txt_error.Text = string.Empty;
                    txtCIIU.Text = txtCIIU.Text.Substring(0, (txtCIIU.Text.Length - 1));
                }
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
