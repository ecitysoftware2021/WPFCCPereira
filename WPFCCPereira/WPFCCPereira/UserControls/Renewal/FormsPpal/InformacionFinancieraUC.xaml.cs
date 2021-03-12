﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public InformacionFinancieraUC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_ActividadEconomica, data: transaction);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_SistemaSeguridad, data: transaction);
        }
    }
}