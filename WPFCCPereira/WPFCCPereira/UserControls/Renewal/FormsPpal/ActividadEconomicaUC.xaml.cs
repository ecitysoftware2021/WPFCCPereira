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
                if (transaction.FormularioPpal.datos.ciius != null)
                {
                    if (!string.IsNullOrEmpty(transaction.FormularioPpal.datos.ciius._1))
                    {
                        cmbCiius.Items.Add(transaction.FormularioPpal.datos.ciius._1);
                    }

                    if (!string.IsNullOrEmpty(transaction.FormularioPpal.datos.ciius._2))
                    {
                        cmbCiius.Items.Add(transaction.FormularioPpal.datos.ciius._2);
                    }

                    if (!string.IsNullOrEmpty(transaction.FormularioPpal.datos.ciius._3))
                    {
                        cmbCiius.Items.Add(transaction.FormularioPpal.datos.ciius._3);
                    }

                    if (!string.IsNullOrEmpty(transaction.FormularioPpal.datos.ciius._4))
                    {
                        cmbCiius.Items.Add(transaction.FormularioPpal.datos.ciius._4);
                    }
                }

                DateTime dtm;
                transaction.FormularioPpal.datos.fechamatriculaAux = transaction.FormularioPpal.datos.fechamatricula;
                DateTime.TryParseExact(transaction.FormularioPpal.datos.fechamatriculaAux, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);
                transaction.FormularioPpal.datos.fechamatriculaAux = transaction.FormularioPpal.datos.fechamatriculaAux != string.Empty ? dtm.ToString("MMMM dd, yyyy") : string.Empty;
                
              
                if (!string.IsNullOrEmpty(transaction.FormularioPpal.datos.feciniact1))
                {
                    string date = transaction.FormularioPpal.datos.feciniact1;

                    date = date.Insert(4, "-").Insert(7, "-");

                    transaction.FormularioPpal.datos.feciniact1Aux = date;
                }
                
                if (!string.IsNullOrEmpty(transaction.FormularioPpal.datos.feciniact2))
                {
                    string date = transaction.FormularioPpal.datos.feciniact2;

                    date = date.Insert(4, "-").Insert(7, "-");

                    transaction.FormularioPpal.datos.feciniact2Aux = date;
                }

                //transaction.FormularioPpal.datos.feciniact1Aux = transaction.FormularioPpal.datos.feciniact1;
                //DateTime.TryParseExact(transaction.FormularioPpal.datos.feciniact1Aux, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);
                //transaction.FormularioPpal.datos.feciniact1Aux = transaction.FormularioPpal.datos.feciniact1Aux != string.Empty ? dtm.ToString("MMMM dd, yyyy") : string.Empty;


                //transaction.FormularioPpal.datos.feciniact2Aux = transaction.FormularioPpal.datos.feciniact2;
                //DateTime.TryParseExact(transaction.FormularioPpal.datos.feciniact2Aux, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);
                //transaction.FormularioPpal.datos.feciniact2Aux = transaction.FormularioPpal.datos.feciniact2Aux != string.Empty ? dtm.ToString("MMMM dd, yyyy") : string.Empty;

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

                if (!string.IsNullOrEmpty(modal.CiiuSelect))
                {
                    txtCiiu.Text = modal.CiiuSelect;

                    if (cmbCiius.Items.Count < 4)
                    {
                        cmbCiius.Items.Add(modal.CiiuSelect);
                    }
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

        private void txtgirls_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender, this);
        }

        private void txtDescription_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(false, sender, this);
        }
        #endregion

        private void DpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime d = Convert.ToDateTime(DpDate.Text);
                string date = string.Concat(d.Year, d.Month, d.Day);
                transaction.FormularioPpal.datos.feciniact2 = date;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
