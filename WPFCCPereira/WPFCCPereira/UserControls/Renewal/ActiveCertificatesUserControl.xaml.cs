using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.ViewModel;
using System.Linq;
using System.Collections.Generic;
using WPFCCPereira.Services.Object;
using System.Globalization;
using WPFCCPereira.Services.ObjectIntegration;

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
        private List<ListEstablecimientos> listEstablecimientos;
        #endregion

        #region "Constructor"
        public ActiveCertificatesUserControl(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;
           
            this.viewModel = new DataListViewModel();

            this.viewModel.ViewList = new CollectionViewSource();

            this.listEstablecimientos = new List<ListEstablecimientos>();

            ConfigureViewList();
        }
        #endregion

        #region "Métodos"
        private void ConfigureViewList()
        {
            try
            {
                grvEstablecimientos.Visibility = System.Windows.Visibility.Hidden;

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
                    grvEstablecimientos.Visibility = System.Windows.Visibility.Visible;
                    viewModel.ViewList.Source = listEstablecimientos;
                    viewModel.ViewList.View.Refresh();
                    lv_data_list.Items.Refresh();
                    lv_data_list.DataContext = viewModel.ViewList;
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
                if (txtNewAssets.Text == string.Empty)
                {
                    txtErrorActivos.Text = "Nuevos activos es requerido";
                    return false;
                }

                if (txtCantEmployees.Text == string.Empty)
                {
                    txtErrorEmpleados.Text = "Número empleados es requerido";
                    return false;
                }

                if (listEstablecimientos.Count > 0)
                {
                    foreach (var item in listEstablecimientos)
                    {
                        if (txtNewAssets.Text == string.Empty || txtCantEmployees.Text == string.Empty)
                        {

                            return false;
                        }
                    }
                }

                return true;
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

                //lblErrorIdentification.Content = string.Empty;
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

                if (text.Text.Length > 4)
                {
                    text.Text = text.Text.Remove(text.Text.Length - 1);
                }

                //lblErrorIdentification.Content = string.Empty;
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
