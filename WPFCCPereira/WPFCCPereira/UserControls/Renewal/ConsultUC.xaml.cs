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
using WPFCCPereira.ViewModel;

namespace WPFCCPereira.UserControls.Renewal
{
    /// <summary>
    /// Interaction logic for ConsultUC.xaml
    /// </summary>
    public partial class ConsultUC : UserControl
    {
        #region "Referencias"
        private DataListViewModel viewModel;
        private Transaction transaction;
        #endregion

        #region "Constructor"
        public ConsultUC(Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            ConfigurateView();
        }
        #endregion

        #region "Métodos"
        private void ConfigurateView()
        {
            try
            {
                viewModel = new DataListViewModel
                {
                    TypeConsult = EtypeConsult.Matricula,
                    SourceCheckId = "/Images/Others/rbtn-checkmatricula.png",
                    OptionCheck = EtypeConsult.Matricula,
                    OptionChecktwo = EtypeConsult.Id,
                };

                this.DataContext = viewModel;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private bool ValidateDocument()
        {
            try
            {
                if (string.IsNullOrEmpty(txtReferencia.Text))
                {
                    txt_error.Text = "Debe ingresar una referencia a consultar.";
                    return false;
                }
                else
                if (viewModel.TypeConsult == EtypeConsult.Id)
                {
                    if (txtReferencia.Text.Length <= 6 || txtReferencia.Text.Length >= 12)
                    {
                        txt_error.Text = "Debe ingresar una identificación valida.";
                        return false;
                    }
                }
                else
                if (viewModel.TypeConsult == EtypeConsult.Matricula)
                {
                    if (txtReferencia.Text.Length <= 6 || txtReferencia.Text.Length >= 12)
                    {
                        txt_error.Text = "Debe ingresar una matrícula valida.";
                        return false;
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

        private void SearchData(string reference)
        {
            try
            {
                TimerService.Stop();

                Task.Run(async () =>
                {
                    var response = await AdminPayPlus.ApiIntegration.ConsultarExpedienteMercantil(reference, viewModel.TypeConsult);

                    Utilities.CloseModal();

                    if (response != null)
                    {
                        transaction.reference = reference;
                        transaction.File = viewModel;
                        transaction.State = ETransactionState.Initial;
                        transaction.Type = viewModel.TypeTransaction;
                        transaction.ExpedientesMercantil = response;

                        if ((transaction.ExpedientesMercantil.ultanorenovado + 1) == DateTime.Now.Year)
                        {
                            //TODO:aquí
                            if (transaction.ExpedientesMercantil.establecimientos.Count > 0)
                            {
                                Utilities.ShowModal("Por ahora el trámite de renovación esta habilitado solo para personas que no tengan 1 o más establecimientos. Muy pronto estará disponible.", EModalType.Error);
                            }
                            else
                            {
                                Utilities.navigator.Navigate(UserControlView.ActiveCertificate, false, transaction);
                            }
                        }
                        else
                        if (transaction.ExpedientesMercantil.ultanorenovado == DateTime.Now.Year)
                        {
                            string[] type = new string[2];

                            type[0] = "Matrícula";
                            type[1] = "Identificación";

                            string ms = $"La {(viewModel.TypeConsult == EtypeConsult.Matricula ? type[0] : type[1])} No. {reference} " +
                            $"ya esta renovada en el año {DateTime.Now.Year} ";

                            Utilities.ShowModal(ms, EModalType.Error);

                            TimerService.Reset();
                        }
                        else
                        {
                            //18156797
                            //18167255
                            string[] type = new string[2];

                            type[0] = "Matrícula";
                            type[1] = "Identificación";

                            string ms = $"La {(viewModel.TypeConsult == EtypeConsult.Matricula ? type[0] : type[1] )} No. {reference} " +
                            $"tiene más de 1 años por renovar, por lo tanto no puede ser renovada desde el kiosco. Le invitamos a " +
                            $"realizar esta renovación desde el sitio web del SII o acercarse a nuestras oficinas.";

                            Utilities.ShowModal(ms, EModalType.Error);

                            TimerService.Reset();
                        }
                    }
                    else
                    {
                        Utilities.ShowModal(MessageResource.ErrorCoincidences, EModalType.Error);

                        TimerService.Reset();
                    }
                });

                Utilities.ShowModal(MessageResource.ConsultingConinsidences, EModalType.Preload);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Menu);
        }

        private void BtnConsult_TouchDown(object sender, TouchEventArgs e)
        {
            if (ValidateDocument())
            {
                SearchData(txtReferencia.Text);
            }
        }

        private void Select_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                var typeConsul = (EtypeConsult)((Button)sender).Tag;

                if (typeConsul != viewModel.TypeConsult)
                {
                    if (typeConsul == EtypeConsult.Id)
                    {
                        viewModel.TypeConsult = EtypeConsult.Id;
                        viewModel.SourceCheckId = "/Images/Others/rbtn-checkid.png";
                    }
                    else if (typeConsul == EtypeConsult.Matricula)
                    {
                        viewModel.TypeConsult = EtypeConsult.Matricula;
                        viewModel.SourceCheckId = "/Images/Others/rbtn-checkmatricula.png";
                    }

                    txtReferencia.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Text_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender as TextBox, this);
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (viewModel != null && viewModel.TypeConsult == EtypeConsult.Id)
                {
                    if (txtReferencia.Text != null && txtReferencia.Text.Length > 12)
                    {
                        txt_error.Text = "";
                        txtReferencia.Text = txtReferencia.Text.Substring(0, (txtReferencia.Text.Length - 1));
                    }
                }
                else
                {
                    if (txtReferencia.Text != null && txtReferencia.Text.Length > 12)
                    {
                        txt_error.Text = "";
                        txtReferencia.Text = txtReferencia.Text.Substring(0, (txtReferencia.Text.Length - 1));
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion
    }
}
