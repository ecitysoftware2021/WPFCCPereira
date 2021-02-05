﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.ObjectIntegration;
using WPFCCPereira.ViewModel;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace WPFCCPereira.UserControls.Renewal
{
    /// <summary>
    /// Interaction logic for ActiveCertificatesUserControl.xaml
    /// </summary>
    public partial class ActiveCertificatesUserControl : UserControl
    {
        #region "Referencias"
        private DataListViewModel viewModel;
        private Transaction transaction;
        private ObservableCollection<ListEstablecimientos> listEstablecimientos;
        #endregion

        #region "Constructor"
        public ActiveCertificatesUserControl(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;
           
            this.viewModel = new DataListViewModel();

            this.viewModel.ViewList = new CollectionViewSource();

            this.listEstablecimientos = new ObservableCollection<ListEstablecimientos>();

            ConfigureViewList();
        }
        #endregion

        #region "Métodos"
        private void ConfigureViewList()
        {
            try
            {
                grvEstablecimientos.Visibility = Visibility.Hidden;

                if ((transaction.ExpedientesMercantil.ultanorenovado + 1) == DateTime.Now.Year)
                {
                    transaction.ExpedientesMercantil.anoporrenovar = transaction.ExpedientesMercantil.ultanorenovado + 1;
                }

                foreach (var item in transaction.ExpedientesMercantil.establecimientos)
                {
                    if ((item.ultanorenovado + 1) == DateTime.Now.Year)
                    {
                        item.anoporrenovar = item.ultanorenovado + 1;
                        listEstablecimientos.Add(item);
                    }
                }

                if (listEstablecimientos.Count > 0)
                {
                    grvEstablecimientos.Visibility = Visibility.Visible;
                    //viewModel.ViewList.Source = listEstablecimientos;
                    //viewModel.ViewList.View.Refresh();
                    //lv_data_list.Items.Refresh();
                    lv_data_list.DataContext = listEstablecimientos;
                }

                this.DataContext = transaction.ExpedientesMercantil;
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

                if (txtNewAssets.Text == string.Empty)
                {
                    txtErrorActivos.Text = "Nuevos activos es requerido";
                    bdrActivos.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    state = false;
                }

                if (txtCantEmployees.Text == string.Empty)
                {
                    txtErrorEmpleados.Text = "Número empleados es requerido";
                    bdrEmpleados.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    state = false;
                }

                if (listEstablecimientos.Count > 0)
                {
                    foreach (var item in listEstablecimientos)
                    {
                        if (string.IsNullOrEmpty(item.numempleados))
                        {
                            item.mserrorempleados = "Número empleados es requerido";
                            item.bdEmpleados = "Red"; 
                            state = false;
                        }

                        if (item.numactivos <= 99)
                        {
                            item.mserroractivos = "Número activos es requerido";
                            item.bdActivos = "Red";
                            state = false;
                        }
                    }
                }

                return state;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
                return false;
            }
        }
        #endregion

        #region "Eventos"
        private void Grid_TouchDown(object sender, TouchEventArgs e)
        {
            if (((Grid)sender).Tag != null)
            {

                //Utilities.navigator.Navigate(UserControlView.Certificates, true, new Transaction
                //{
                //    File = (Noun)((Grid)sender).Tag,
                //    State = ETransactionState.Initial,
                //    Type = viewModel.TypeTransaction
                //});
            }
        }

        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Menu);
        }

        private void NuevosActivos_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox text = (TextBox)sender;

                if (text.Text.Length > 13)
                {
                    text.Text = text.Text.Remove(text.Text.Length - 1);
                }

                if (text.Tag.ToString() == "0")
                {
                    txtErrorActivos.Text = string.Empty;
                    bdrActivos.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                }
                else
                {
                    var service = text.DataContext as ListEstablecimientos;

                    service.bdActivos = "Transparent";
                    service.mserroractivos = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void NuevosActivos_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender as TextBox, this);
        }

        private void NumEmpleados_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender as TextBox, this);
        }

        private void NumEmpleados_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox text = (TextBox)sender;

                if (text.Text.Length > 6)
                {
                    text.Text = text.Text.Remove(text.Text.Length - 1);
                }

                if (text.Tag.ToString() == "0")
                {
                    txtErrorEmpleados.Text = string.Empty;
                    bdrEmpleados.BorderBrush = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                }
                else
                {
                    var service = text.DataContext as ListEstablecimientos;

                    service.bdEmpleados = "Transparent";
                    service.mserrorempleados = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }

        private void btnNext_TouchDown(object sender, TouchEventArgs e)
        {
            if (Validate())
            {

            }
        }
        #endregion
    }
}
