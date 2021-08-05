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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;

namespace WPFCCPereira.UserControls.Renewal.FormsAdd
{
    /// <summary>
    /// Interaction logic for Identificacion2UC.xaml
    /// </summary>
    public partial class Identificacion2UC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        private string matricula;
        #endregion

        #region "Constructor"
        public Identificacion2UC(Transaction ts, string mt)
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
                    result.datos.FinishFormAdd = false;
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
            Utilities.navigator.Navigate(UserControlView.Add_UbicacionDatosGenerales, data: transaction, complement: matricula);
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.ListEstablecimientos, data: transaction);
        }

        private void btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Main);
        }
        #endregion
    }
}
