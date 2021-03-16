﻿using System;
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
              

                //transaction.ExpedientesMercantil.idclaseName = typeIdentification;

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
            Utilities.navigator.Navigate(UserControlView.Ppal_ActividadEconomica, data: transaction);
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_Identificacion, data: transaction);
        }
        #endregion
    }
}
