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

            this.DataContext = this.transaction;

            LoadView();
        }
        #endregion

        #region "Métodos"
        private void LoadView()
        {
            try
            {
                transaction.FormularioPpal.datos.anodatos = DateTime.Now.Year.ToString();
                transaction.FormularioPpal.datos.acttot = transaction.ExpedientesMercantil.numactivos;
                transaction.FormularioPpal.datos.personal = transaction.ExpedientesMercantil.numempleados.ToString();

                transaction.FormularioPpal.datos.pastot = transaction.FormularioPpal.datos.paslar + transaction.FormularioPpal.datos.pascte;
                transaction.FormularioPpal.datos.paspat = transaction.FormularioPpal.datos.pattot + transaction.FormularioPpal.datos.pastot;

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

            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private bool Validate()
        {
            try
            {
                bool state = true;

                //if (transaction.FormularioPpal.datos.actcte == 0)//Activos corrientes
                //{
                //    brd_actcte.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                //    state = false;
                //}
                
                //if (transaction.FormularioPpal.datos.actnocte == 0)//Activos no corrientes
                //{
                //    brd_actnocte.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                //    state = false;
                //}

                if ((transaction.FormularioPpal.datos.actnocte + transaction.FormularioPpal.datos.actcte) != transaction.FormularioPpal.datos.acttot)
                {
                    brd_actcte.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    brd_actnocte.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    state = false;
                }
                
                //if (transaction.ExpedientesMercantil.pascte == 0)//Pasivos corrientes
                //{
                //    brd_pascte.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                //    state = false;
                //}
                
                //if (transaction.ExpedientesMercantil.paslar == 0)//Pasivos no corrientes o a largo plazo
                //{
                //    brd_paslar.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                //    state = false;
                //}

                if (transaction.FormularioPpal.datos.pattot == 0)//Patrimonio (patrimonio neto)
                {
                    brd_pattot.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    state = false;
                }

                return state;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
                return false;
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
            if (Validate())
            {
                Utilities.navigator.Navigate(UserControlView.Ppal_SistemaSeguridad, data: transaction);
            }
        }

        private void Amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox text = (TextBox)sender;

                if (text.Text.Length > 13)
                {
                    text.Text = text.Text.Remove(text.Text.Length - 1);
                }
                else 
                if (text.Text.Length < 2)
                {
                    text.Text = "0";
                }

                brd_actcte.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                brd_actnocte.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                brd_pattot.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));

                Validate();
                LoadView();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void Amount_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender as TextBox, this);
        }
        #endregion

        private void btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Main);
        }
    }
}
