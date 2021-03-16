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
    /// Interaction logic for IdentificacionUserControl.xaml
    /// </summary>
    public partial class IdentificacionUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public IdentificacionUC(Transaction ts)
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
                string typeIdentification = string.Empty;

                if (int.TryParse(transaction.ExpedientesMercantil.idclase, out int num))
                {
                    if (num >= 1 && num <= 6)
                    {
                        typeIdentification = ((ETypeIdentification)num).ToString();
                    }
                    else
                    {
                        typeIdentification = string.Empty;
                    }
                }
                else
                if (transaction.ExpedientesMercantil.idclase == "E")
                {
                    typeIdentification = ETypeIdentification.Documento_extranjero.ToString();
                }
                else
                if (transaction.ExpedientesMercantil.idclase == "R")
                {
                    typeIdentification = ETypeIdentification.Registro_Civil.ToString();
                }

                transaction.ExpedientesMercantil.idclaseName = typeIdentification;

                this.DataContext = transaction;
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
            Utilities.navigator.Navigate(UserControlView.Ppal_UbicacionDatosGenerales, data: transaction);
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.ListEstablecimientos, data: transaction);
        }
        #endregion
    }
}
