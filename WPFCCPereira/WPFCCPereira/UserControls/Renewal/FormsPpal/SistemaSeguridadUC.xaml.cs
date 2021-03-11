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

namespace WPFCCPereira.UserControls.Renewal.FormsPpal
{
    /// <summary>
    /// Interaction logic for SistemaSeguridadUC.xaml
    /// </summary>
    public partial class SistemaSeguridadUC : UserControl
    {
        public SistemaSeguridadUC()
        {
            InitializeComponent();
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_InformacionFinanciera);
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
        }
    }
}
