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
        private FormularioPpalAux FormAux;
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

                    grvNotificacion.Visibility = Visibility.Hidden;
                    grvComercial.Visibility = Visibility.Visible;
                    grvComercial2.Visibility = Visibility.Visible;

                    FormAux = new FormularioPpalAux
                    {
                        direccion = transaction.FormularioPpal.datos.dircom,
                        municipio = transaction.FormularioPpal.datos.muncomnombre,
                        barrio = transaction.FormularioPpal.datos.barriocomnombre,
                        correo = transaction.FormularioPpal.datos.emailcom,
                        tel1 = transaction.FormularioPpal.datos.telcom1,
                        tel2 = transaction.FormularioPpal.datos.telcom2,
                        tel3 = string.Empty,
                        numpredial = transaction.FormularioPpal.datos.numpredial,
                    };
                }
                else
                {
                    btnUbicacionNotificacion.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffff"));
                    btnUbicacionNotificacion.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));

                    btnUbicacionComercial.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#014c6c"));
                    btnUbicacionComercial.Background = new SolidColorBrush(Color.FromArgb(0, color.R, color.G, color.B));

                    grvNotificacion.Visibility = Visibility.Visible;
                    grvComercial.Visibility = Visibility.Hidden;
                    grvComercial2.Visibility = Visibility.Hidden;

                    FormAux = new FormularioPpalAux
                    {
                        direccion = transaction.FormularioPpal.datos.dirnot,
                        municipio = transaction.FormularioPpal.datos.munnotnombre,
                        barrio = transaction.FormularioPpal.datos.barrionotnombre,
                        correo = transaction.FormularioPpal.datos.emailnot,
                        tel1 = transaction.FormularioPpal.datos.telnot,
                        tel2 = transaction.FormularioPpal.datos.telnot2,
                        tel3 = string.Empty,
                        numpredial = transaction.FormularioPpal.datos.numpredial,
                    };
                }

                transaction.FormularioPpalAux = FormAux;
                this.DataContext = transaction;
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
                    transaction.FormularioPpal.datos.dircom = transaction.FormularioPpalAux.direccion;
                    transaction.FormularioPpal.datos.muncomnombre = transaction.FormularioPpalAux.municipio;
                    transaction.FormularioPpal.datos.barriocom = transaction.FormularioPpalAux.barrio;
                    transaction.FormularioPpal.datos.emailcom = transaction.FormularioPpalAux.correo;
                    transaction.FormularioPpal.datos.telcom1 = transaction.FormularioPpalAux.tel1;
                    transaction.FormularioPpal.datos.telcom2 = transaction.FormularioPpalAux.tel2;
                    transaction.FormularioPpal.datos.numpredial = transaction.FormularioPpalAux.numpredial;
                }
                else
                {
                    transaction.FormularioPpal.datos.dirnot = transaction.FormularioPpalAux.direccion;
                    transaction.FormularioPpal.datos.munnotnombre = transaction.FormularioPpalAux.municipio;
                    transaction.FormularioPpal.datos.barrionotnombre = transaction.FormularioPpalAux.barrio;
                    transaction.FormularioPpal.datos.emailnot = transaction.FormularioPpalAux.correo;
                    transaction.FormularioPpal.datos.telnot = transaction.FormularioPpalAux.tel1;
                    transaction.FormularioPpal.datos.telnot2 = transaction.FormularioPpalAux.tel2;
                    transaction.FormularioPpal.datos.numpredial = transaction.FormularioPpalAux.numpredial;
                }

                //cmbxLocal.Text;
                //cmbxSede.Text;
                //cmbxZona.Text;

                Utilities.navigator.Navigate(UserControlView.Ppal_ActividadEconomica, data: transaction);
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
