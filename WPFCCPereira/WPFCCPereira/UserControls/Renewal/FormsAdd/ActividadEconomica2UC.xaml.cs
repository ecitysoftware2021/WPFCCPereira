using System;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Windows.Modals;

namespace WPFCCPereira.UserControls.Renewal.FormsAdd
{
    /// <summary>
    /// Interaction logic for ActividadEconomica2UC.xaml
    /// </summary>
    public partial class ActividadEconomica2UC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        private string matricula;
        #endregion

        #region "Constructor"
        public ActividadEconomica2UC(Transaction ts, string mt)
        {
            InitializeComponent();

            this.transaction = ts;

            this.matricula = mt;

            LoadView();
        }
        #endregion

        #region "Métodos"
        private void LoadView()
        {
            try
            {
                var result = transaction.FormularioAdd.Where(x => x.datos.matricula == matricula).FirstOrDefault();

                if (result != null)
                {
                    this.DataContext = result.datos;
                }
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
                ModalSearchCiiusW modal = new ModalSearchCiiusW(transaction);
                modal.ShowDialog();

                txtCiiu.Text = modal.CiiuSelect;
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
            Utilities.navigator.Navigate(UserControlView.Add_UbicacionDatosGenerales, data: transaction, complement: matricula);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            //Utilities.navigator.Navigate(UserControlView.Ppal_InformacionFinanciera, data: transaction);
        }
        #endregion
    }
}
