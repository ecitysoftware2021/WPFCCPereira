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
                if ((transaction.ExpedientesMercantil.ultanorenovado + 1) == DateTime.Now.Year)
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
                else
                {
                    Utilities.ShowModal("No cuenta con el ultimo año para renovar.", EModalType.Error);
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


                //TODO:validar que numero de empleados no venga vacio y que lo cogamos de la clase no del txt
                if (string.IsNullOrEmpty(txtNewAssets.Text) || Convert.ToDecimal(txtNewAssets.Text) <= 99)
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
                        //personal = transaction.ExpedientesMercantil.,
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
                        activos = 397034000,
                        anorenovacion = "2021",
                        matricula = "8623304"
                    });

                    var token = await AdminPayPlus.ApiIntegration.liquidarRenovacionNormal(request);

                    Utilities.CloseModal();

                    if (token == null)
                    {
                        Utilities.ShowModal("Ha ocurrido un error al procesar la solicitud. Por favor intenta de nuevo.", EModalType.Error);

                        TimerService.Reset();
                    }
                    else
                    {
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
