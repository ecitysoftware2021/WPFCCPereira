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
    /// Interaction logic for UbicacionDatosGenerales2UC.xaml
    /// </summary>
    public partial class UbicacionDatosGenerales2UC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        private FormularioPpalAux FormAux;
        private int tag;
        #endregion

        #region "Constructor"
        public UbicacionDatosGenerales2UC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            this.tag = 1;

            ChangeView();
        }
        #endregion

        #region "Métodos"
        private void ChangeView()
        {
            try
            {
                System.Drawing.Color color = System.Drawing.Color.Black;

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
            //NextView();
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Add_Identificacion, data: transaction);
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

