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
        public ConsultUC(ETransactionType type, Transaction ts)
        {
            InitializeComponent();

            this.transaction = ts;

            ConfigurateView(type);
        }
        #endregion

        #region "Métodos"
        private void ConfigurateView(ETransactionType type)
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
                    //reference = "18130990";
                    //reference = "14693801";//persona natural
                    //reference = "8623304";//persona juridica 2 establecimientos

                    var response = await AdminPayPlus.ApiIntegration.ConsultarExpedienteMercantil(reference, viewModel.TypeConsult);

                    Utilities.CloseModal();

                    if (response != null)
                    {
                        transaction.reference = reference;
                        transaction.File = viewModel;
                        transaction.State = ETransactionState.Initial;
                        transaction.Type = viewModel.TypeTransaction;
                        transaction.ExpedientesMercantil = response;

                        //TODO:aquí
                        //if ((transaction.ExpedientesMercantil.ultanorenovado + 1) == DateTime.Now.Year)
                        //{
                            Utilities.navigator.Navigate(UserControlView.ActiveCertificate, false, transaction);
                        //}
                        //else
                        //{
                        //    Utilities.ShowModal("No cuenta con el ultimo año para renovar.", EModalType.Error);

                        //    TimerService.Reset();
                        //}
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

                if (viewModel !=null && viewModel.TypeConsult == EtypeConsult.Id)
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
