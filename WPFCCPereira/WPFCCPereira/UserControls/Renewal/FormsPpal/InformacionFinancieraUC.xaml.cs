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

namespace WPFCCPereira.UserControls.Renewal.FormsPpal
{
    /// <summary>
    /// Interaction logic for InformacionFinancieraUC.xaml
    /// </summary>
    public partial class InformacionFinancieraUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public InformacionFinancieraUC(Transaction ts)
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
                object 
                 a = transaction.FormularioPpal.datos.anodatos;//Año de los datos
                 a = transaction.FormularioPpal.datos.fechadatos;//Fecha de reporte de los datos

                 a = transaction.FormularioPpal.datos.actcte;//Activos corrientes
                 a = transaction.FormularioPpal.datos.actnocte;//Activos no corrientes
                 a = transaction.FormularioPpal.datos.acttot;//Activos totales
                 
                 a = transaction.FormularioPpal.datos.pascte;//Pasivos corrientes
                 a = transaction.FormularioPpal.datos.paslar;//Pasivos no corrientes o a largo plazo
                 a = transaction.FormularioPpal.datos.pastot;//Pasivos totales
                 a = transaction.FormularioPpal.datos.pattot;//Patrimonio (patrimonio neto)
                 a = transaction.FormularioPpal.datos.paspat;//Pasivos + patrimonios
                 
                 a = transaction.FormularioPpal.datos.ingope;//Ingresos operacionales
                 a = transaction.FormularioPpal.datos.ingnoope;//Otros ingresos o no operacionales
                 a = transaction.FormularioPpal.datos.cosven;//Costo de ventas
                 //a = transaction.FormularioPpal.datos.gasope;//Gastos operacionales o de ventas
                 //a = transaction.FormularioPpal.datos.gasnoope;//Gastos no operacionales(OTROS GASTOS)
                 a = transaction.FormularioPpal.datos.utiope;//Utilidad operacional EJE: PERDIDA = -1000, UTILIDAD=10000
                
                 a = transaction.FormularioPpal.datos.personal;//Personal
                 a = transaction.FormularioPpal.datos.personaltemp;//Porcentaje personal temporal
                 a = transaction.FormularioPpal.datos.gruponiif;//Grupo NIIF

                this.DataContext = this.transaction;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_ActividadEconomica, data: transaction);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e) 
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_SistemaSeguridad, data: transaction);
        }

        private void NuevosActivos_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox text = (TextBox)sender;

                if (text.Text.Length > 13)
                {
                    text.Text = text.Text.Remove(text.Text.Length - 1);
                }

                //if (text.Tag.ToString() == "0")
                //{
                //    txtErrorActivos.Text = string.Empty;
                //    bdrActivos.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                //}
                //else
                //{
                //    var service = text.DataContext as ListEstablecimientos;

                //    service.bdActivos = "Transparent";
                //    service.mserroractivos = string.Empty;
                //}
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void NuevosActivos_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender as TextBox, this);
        }
        #endregion
    }
}
