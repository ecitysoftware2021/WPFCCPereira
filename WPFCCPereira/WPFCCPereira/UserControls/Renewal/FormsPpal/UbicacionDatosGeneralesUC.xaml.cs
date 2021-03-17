using System;
using System.Windows;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;

namespace WPFCCPereira.UserControls.Renewal.FormsPpal
{
    /// <summary>
    /// Interaction logic for UbicacionDatosGeneralesUC.xaml
    /// </summary>
    public partial class UbicacionDatosGeneralesUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public UbicacionDatosGeneralesUC(Transaction ts)
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
                

                this.DataContext = transaction;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void ChangeView(int tag)
        {
            try
            {
                if (tag == 1)
                {
                    btnUbicacionComercial.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffff"));
                    btnUbicacionComercial.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));
                    
                    btnUbicacionNotificacion.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));
                    btnUbicacionNotificacion.Background = new SolidColorBrush(Color.FromArgb(127,System.Drawing.Color.Black.R, System.Drawing.Color.Black.G, System.Drawing.Color.Black.B));

                    grvNotificacion.Visibility = Visibility.Hidden;
                    grvComercial.Visibility = Visibility.Visible;
                    grvComercial2.Visibility = Visibility.Visible;
                }
                else
                {
                    btnUbicacionNotificacion.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffff"));
                    btnUbicacionNotificacion.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));

                    btnUbicacionComercial.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));
                    btnUbicacionComercial.Background = new SolidColorBrush(Color.FromArgb(127, System.Drawing.Color.Black.R, System.Drawing.Color.Black.G, System.Drawing.Color.Black.B));

                    grvNotificacion.Visibility = Visibility.Visible;
                    grvComercial.Visibility = Visibility.Hidden;
                    grvComercial2.Visibility = Visibility.Hidden;
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
            Utilities.navigator.Navigate(UserControlView.Ppal_ActividadEconomica, data: transaction);
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_Identificacion, data: transaction);
        }

        private void btnUbicacion_TouchDown(object sender, TouchEventArgs e)
        {
            ChangeView(Convert.ToInt32((sender as TextBlock).Tag));
        }

        private void TextAlfaNumerico_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(false, sender, this);
        }
        
        private void TextNumerico_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender, this);
        }
        #endregion
    }
}
