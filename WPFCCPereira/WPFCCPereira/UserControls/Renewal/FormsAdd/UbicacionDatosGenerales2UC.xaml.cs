using System;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;

namespace WPFCCPereira.UserControls.Renewal.FormsAdd
{
    /// <summary>
    /// Interaction logic for UbicacionDatosGenerales2UC.xaml
    /// </summary>
    public partial class UbicacionDatosGenerales2UC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        private FormularioPpalAux FormAux;
        private string matricula;
        #endregion

        #region "Constructor"
        public UbicacionDatosGenerales2UC(Transaction ts, string mt)
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
        #endregion

        #region "Eventos"
        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Add_ActividadEconomica, data: transaction, complement: matricula);
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Add_Identificacion, data: transaction, complement: matricula);
        }

        private void TextAlfaNumerico_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(false, sender, this);
        }

        private void TextNumerico_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender, this, 800);
        }

        private void btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Main);
        }
        #endregion
    }
}

