using System;
using System.Windows;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.ObjectIntegration;

namespace WPFCCPereira.UserControls.Renewal.FormsPpal
{
    /// <summary>
    /// Interaction logic for UbicacionDatosGeneralesUC.xaml
    /// </summary>
    public partial class UbicacionDatosGeneralesUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        private int tag;
        #endregion

        #region "Constructor"
        public UbicacionDatosGeneralesUC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            this.tag = 1;

            ChangeView(tag);
        }
        #endregion

        #region "Métodos"
        private void ChangeView(int num)
        {
            try
            {
                System.Drawing.Color color = System.Drawing.Color.Black;

                if (num == 1)
                {
                    btnUbicacionComercial.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffff"));
                    btnUbicacionComercial.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));

                    btnUbicacionNotificacion.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));
                    btnUbicacionNotificacion.Background = new SolidColorBrush(Color.FromArgb(0, color.R, color.G, color.B));

                    grvComercial1.Visibility = Visibility.Visible;
                    grvComercial2.Visibility = Visibility.Visible;
                    grvNotificacion1.Visibility = Visibility.Hidden;
                    grvNotificacion2.Visibility = Visibility.Hidden;
                }
                else
                {
                    btnUbicacionNotificacion.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffff"));
                    btnUbicacionNotificacion.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));

                    btnUbicacionComercial.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));
                    btnUbicacionComercial.Background = new SolidColorBrush(Color.FromArgb(0, color.R, color.G, color.B));

                    grvComercial1.Visibility = Visibility.Hidden;
                    grvComercial2.Visibility = Visibility.Hidden;
                    grvNotificacion1.Visibility = Visibility.Visible;
                    grvNotificacion2.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void NextView()
        {
            try
            {
                if (tag == 1)
                {
                    transaction.FormularioPpal.datos.dircom = "";
                    transaction.FormularioPpal.datos.muncomnombre = "";
                    transaction.FormularioPpal.datos.barriocom = "";
                    transaction.FormularioPpal.datos.emailcom ="";
                    transaction.FormularioPpal.datos.telcom1 ="";
                    transaction.FormularioPpal.datos.telcom2 = "";
                    transaction.FormularioPpal.datos.numpredial = "";
                }
                else
                {
                    transaction.FormularioPpal.datos.dirnot = "";
                    transaction.FormularioPpal.datos.munnotnombre ="";
                    transaction.FormularioPpal.datos.barrionotnombre = "";
                    transaction.FormularioPpal.datos.emailnot = "";
                    transaction.FormularioPpal.datos.telnot = "";
                    transaction.FormularioPpal.datos.telnot2 = "";
                }

                //cmbxLocal.Text;
                //cmbxSede.Text;
                //cmbxZona.Text;

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
            NextView();
            Utilities.navigator.Navigate(UserControlView.Ppal_ActividadEconomica, data: transaction);
        }

        private void cbxLocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)cbxLocal.SelectedItem;

                if (transaction != null)
                {
                    transaction.FormularioPpal.datos.tipopropiedad = ComboItem.Tag.ToString();
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_Identificacion, data: transaction);
        }

        private void btnUbicacion_TouchDown(object sender, TouchEventArgs e)
        {
            tag = Convert.ToInt32((sender as TextBlock).Tag);
            ChangeView(tag);
        }

        private void TextAlfaNumerico_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(false, sender, this);
        }

        private void TextNumerico_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender, this, 800);
        }
        #endregion
    }
}
