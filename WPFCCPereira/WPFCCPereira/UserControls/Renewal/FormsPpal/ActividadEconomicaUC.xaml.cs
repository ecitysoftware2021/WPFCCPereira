using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Windows.Modals;

namespace WPFCCPereira.UserControls.Renewal.FormsPpal
{
    /// <summary>
    /// Interaction logic for ActividadEconomicaUC.xaml
    /// </summary>
    public partial class ActividadEconomicaUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public ActividadEconomicaUC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            LoadView();
        }
        #endregion

        #region "Métodos"
        private void LoadView()
        {
            try
            {
                DateTime dtm;
                DateTime.TryParseExact(transaction.FormularioPpal.datos.fechamatricula, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);
                transaction.FormularioPpal.datos.fechamatricula = dtm.ToString("MMMM dd, yyyy");
                
                DateTime.TryParseExact(transaction.FormularioPpal.datos.feciniact1, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);
                transaction.FormularioPpal.datos.feciniact1 = dtm.ToString("MMMM dd, yyyy");

                this.DataContext = this.transaction;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void GetCiiu(TextBlock txtCiiu)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCiiu.Text))
                {
                    cmbCiius.Items.Remove(txtCiiu.Text);
                }

                ModalSearchCiiusW modal = new ModalSearchCiiusW(transaction);
                modal.ShowDialog();

                txtCiiu.Text = modal.CiiuSelect;

                if (cmbCiius.Items.Count < 4 && !string.IsNullOrEmpty(txtCiiu.Text))
                {
                    cmbCiius.Items.Add(modal.CiiuSelect);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void TextCIIUS_TouchDown(object sender, TouchEventArgs e)
        {
            GetCiiu(sender as TextBlock);
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_UbicacionDatosGenerales, data: transaction);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_InformacionFinanciera, data: transaction);
        }
        #endregion

    }
}
