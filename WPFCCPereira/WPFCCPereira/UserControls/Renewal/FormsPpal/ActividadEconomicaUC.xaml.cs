﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for ActividadEconomicaUC.xaml
    /// </summary>
    public partial class ActividadEconomicaUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public ActividadEconomicaUC(Transaction ts)
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
                DateTime dtm;
                DateTime.TryParseExact(transaction.FormularioPpal.datos.fechamatricula, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);
                transaction.FormularioPpal.datos.fechamatricula = dtm.ToString("MMMM dd, yyyy");
                
                DateTime.TryParseExact(transaction.FormularioPpal.datos.feciniact1, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);
                transaction.FormularioPpal.datos.feciniact1 = dtm.ToString("MMMM dd, yyyy");

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
            Utilities.navigator.Navigate(UserControlView.Ppal_UbicacionDatosGenerales, data: transaction);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_InformacionFinanciera, data: transaction);
        }
        #endregion
    }
}
