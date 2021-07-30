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
using WPFCCPereira.Services.ObjectIntegration;

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

            this.transaction.FormularioPpal.datos.f = new List<Services.ObjectIntegration.ArrayF>();

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

        private void addData()
        {
            try
            {
                transaction.FormularioPpal.datos.f.Add(new ArrayF
                {
                    anodatos = transaction.FormularioPpal.datos.anodatos,
                    fechadatos = string.Concat(DateTime.Now.Year - 1,"1231"),
                    //fechadatos = transaction.FormularioPpal.datos.fechadatos,
                    actcte = transaction.FormularioPpal.datos.actcte,
                    actnocte = transaction.FormularioPpal.datos.actnocte,
                    acttot = transaction.FormularioPpal.datos.acttot,
                    pascte = transaction.FormularioPpal.datos.pascte,
                    paslar = transaction.FormularioPpal.datos.paslar,
                    pastot = transaction.FormularioPpal.datos.pastot,
                    pattot = transaction.FormularioPpal.datos.pattot,
                    paspat = transaction.FormularioPpal.datos.paspat,
                    ingope = transaction.FormularioPpal.datos.ingope,
                    ingnoope = transaction.FormularioPpal.datos.ingnoope,
                    cosven = transaction.FormularioPpal.datos.cosven,
                    utiope = transaction.FormularioPpal.datos.utiope,
                    personal = transaction.FormularioPpal.datos.personal,
                    personaltemp = transaction.FormularioPpal.datos.personaltemp
                });
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

                if ((transaction.FormularioPpal.datos.actnocte + transaction.FormularioPpal.datos.actcte) != transaction.FormularioPpal.datos.acttot)
                {
                    brd_actcte.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    brd_actnocte.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    state = false;
                }

                if (transaction.FormularioPpal.datos.pattot == 0)
                {
                    brd_pattot.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    state = false;
                }

                if (transaction.FormularioPpal.datos.paspat != transaction.FormularioPpal.datos.acttot)
                {
                    brd_paspat.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
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

        private void ChangeUtilPerdi()
        {
            try
            {
                var run1 = txtUtilidadPerdida.Inlines.FirstInline as Run;
                var run2 = txtUtilidadPerdida.Inlines.LastInline as Run;

                run1.FontWeight = run1.FontWeight == FontWeights.Bold ? FontWeights.Normal : FontWeights.Bold;
                run2.FontWeight = run2.FontWeight == FontWeights.Bold ? FontWeights.Normal : FontWeights.Bold;

                imgUtilidadPerdida.Source = run1.FontWeight == FontWeights.Bold ? new BitmapImage(new Uri("pack://application:,,,/Images/Others/sum.png", UriKind.Absolute)) : new BitmapImage(new Uri("pack://application:,,,/Images/Others/subtract.png", UriKind.Absolute));

                transaction.FormularioPpal.datos.utiope *= -1;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Main);
        }

        private void txtUtilidadPerdida_TouchDown(object sender, TouchEventArgs e)
        {
            ChangeUtilPerdi();
        }

        private void imgUtilidadPerdida_TouchDown(object sender, TouchEventArgs e)
        {
            ChangeUtilPerdi();
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_ActividadEconomica, data: transaction);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            if (Validate())
            {
                //LoadView();
                addData();
                Utilities.navigator.Navigate(UserControlView.Ppal_SistemaSeguridad, data: transaction);
            }
        }

        private void Amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox text = (TextBox)sender;

                if (text.Text.Length > 16)
                {
                    text.Text = text.Text.Remove(text.Text.Length - 1);
                }
                else
                if (text.Text.Length < 2)
                {
                    text.Text = "0";
                }

                if (text.Tag != null && text.Tag.ToString() == "u/p")
                {
                    var run2 = txtUtilidadPerdida.Inlines.LastInline as Run;

                    if (transaction.FormularioPpal.datos.utiope > 0 && run2.FontWeight == FontWeights.Bold)
                    {
                        transaction.FormularioPpal.datos.utiope *= -1; 
                    }
                }

                brd_actcte.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                brd_actnocte.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                brd_pattot.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                brd_paspat.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));

                LoadView();
                Validate();
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

        private void cbxNiif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)cbxNiif.SelectedItem;

                if (transaction != null)
                {
                    transaction.FormularioPpal.datos.gruponiif = ComboItem.Tag.ToString();
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }
        #endregion
    }
}
