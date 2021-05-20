using System;
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
using System.Globalization;
using System.Threading.Tasks;

namespace WPFCCPereira.UserControls.Renewal
{
    /// <summary>
    /// Interaction logic for ActiveCertificatesUC.xaml
    /// </summary>
    public partial class ActiveCertificatesUC : UserControl
    {
        #region "Referencias"
        private decimal MinActivos;
        private decimal MinEmpleados;
        private DataListViewModel viewModel;
        private Transaction transaction;
        private ObservableCollection<ListEstablecimientos> listEstablecimientos;
        #endregion

        #region "Constructor"
        public ActiveCertificatesUC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            this.viewModel = new DataListViewModel();

            this.viewModel.ViewList = new CollectionViewSource();

            this.listEstablecimientos = new ObservableCollection<ListEstablecimientos>();

            this.MinActivos = Convert.ToDecimal(Utilities.GetConfiguration("MinimoActivos"));

            this.MinEmpleados = Convert.ToInt32(Utilities.GetConfiguration("MinimoEmpleados"));

            ConfigureViewList();
        }
        #endregion

        #region "Métodos"
        private void ConfigureViewList()
        {
            try
            {
                transaction.ExpedientesMercantil.anoporrenovar = transaction.ExpedientesMercantil.ultanorenovado + 1;

                var organizacion = (EOrganizacion)Convert.ToUInt32(transaction.ExpedientesMercantil.organizacion);

                transaction.ExpedientesMercantil.organizacion = organizacion.ToString();

                DateTime dtm;
                DateTime.TryParseExact(transaction.ExpedientesMercantil.fecharenovacion, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);

                transaction.ExpedientesMercantil.fecharenovacion = dtm.ToString("MMMM dd, yyyy");

                this.DataContext = transaction.ExpedientesMercantil;

                foreach (var item in transaction.ExpedientesMercantil.establecimientos)
                {
                    if ((item.ultanorenovado + 1) == DateTime.Now.Year)
                    {
                        item.anoporrenovar = item.ultanorenovado + 1;

                        DateTime.TryParseExact(item.fecharenovacion, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);

                        item.fecharenovacion = dtm.ToString("MMMM dd, yyyy");

                        item.status = true;

                        listEstablecimientos.Add(item);
                    }
                }

                if (listEstablecimientos.Count > 0)
                {
                    grvEstablecimientos.Visibility = Visibility.Visible;
                    lv_data_list.DataContext = listEstablecimientos;
                }
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

                if (transaction.ExpedientesMercantil.numactivos < MinActivos)
                {
                    txtErrorActivos.Text = "Nuevos activos es requerido";
                    bdrActivos.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    state = false;
                }
                else
                if (transaction.ExpedientesMercantil.numactivos < transaction.ExpedientesMercantil.activos)
                {
                    txtErrorActivos.Text = "Los activos deben ser mayor o iguales a los de " + transaction.ExpedientesMercantil.ultanorenovado;
                    bdrActivos.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    state = false;
                }

                if (transaction.ExpedientesMercantil.numempleados < MinEmpleados)
                {
                    txtErrorEmpleados.Text = "Número empleados es requerido";
                    bdrEmpleados.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                    state = false;
                }

                if (listEstablecimientos.Count > 0)
                {
                    decimal amoutEstablecimientos = 0;

                    foreach (var item in listEstablecimientos)
                    {
                        //if (item.numempleados < MinEmpleados)
                        //{
                        //    item.mserrorempleados = "Número empleados es requerido";
                        //    item.bdEmpleados = "Red";
                        //    state = false;
                        //}
                        amoutEstablecimientos += item.numactivos;

                        if (item.numactivos < MinActivos)
                        {
                            item.mserroractivos = "Número activos es requerido";
                            item.bdActivos = "Red";
                            state = false;
                        }
                        else
                        if (item.numactivos < item.valorestablecimiento)
                        {
                            item.mserroractivos = "Los activos deben ser mayor o iguales a los de " + item.ultanorenovado;
                            item.bdActivos = "Red";
                            state = false;
                        }
                    }

                    if (amoutEstablecimientos > transaction.ExpedientesMercantil.numactivos)
                    {
                        txtErrorActivos.Text = "El valor total de los establecimientos supera el valor de la persona";
                        bdrActivos.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                        state = false;
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

        private void SendData()
        {
            try
            {
                TimerService.Stop();

                Task.Run(async () =>
                {
                    RequestLiquidarRenovacionNormal request = new RequestLiquidarRenovacionNormal
                    {
                        idusuario = "USUPUBXX",
                        identificacioncontrol = "123456789",
                        nombrecontrol = "KIOSCOS-PRUEBAS",
                        emailcontrol = "ecitysoftware@gmail.com",
                        celularcontrol = "123456789",
                        personal = transaction.ExpedientesMercantil.numempleados,
                        incluirafiliacion = "N",
                        incluirformulario = "S",
                        incluircertificado = "N",
                        cumple1780 = "N",
                        mantiene1780 = "N",
                        renuncia1780 = "N",
                        matriculas = new List<Matricula>()
                    };

                    request.matriculas.Add(new Matricula
                    {
                        activos = transaction.ExpedientesMercantil.numactivos,
                        anorenovacion = transaction.ExpedientesMercantil.anoporrenovar.ToString(),
                        matricula = transaction.ExpedientesMercantil.matricula
                    });

                    foreach (var item in listEstablecimientos)
                    {
                        request.matriculas.Add(new Matricula
                        {
                            activos = item.numactivos,
                            anorenovacion = item.anoporrenovar.ToString(),
                            matricula = item.matricula
                        });
                    }

                    var response = await AdminPayPlus.ApiIntegration.liquidarRenovacionNormal(request);

                    Utilities.CloseModal();

                    if (response == null)
                    {
                        Utilities.ShowModal("Ha ocurrido un error al procesar la solicitud. Por favor intenta de nuevo.", EModalType.Error);

                        TimerService.Reset();
                    }
                    else 
                    if (response.mensajeerror != string.Empty)
                    {
                        Utilities.ShowModal(string.Concat("Ha ocurrido un error al procesar la solicitud. ",response.mensajeerror ," Por favor intenta de nuevo."), EModalType.Error);

                        TimerService.Reset();
                    }
                    else
                    {
                        transaction.LiquidarRenovacionNormal = response;

                        Utilities.navigator.Navigate(UserControlView.MenuRenovacion, false, transaction);
                    }
                });

                Utilities.ShowModal("Consultando detalles de la liquidación. Regálenos unos segundos.", EModalType.Preload);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }
        #endregion

        #region "Eventos"
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
                SendData();
            }
        }
        #endregion
    }
}
