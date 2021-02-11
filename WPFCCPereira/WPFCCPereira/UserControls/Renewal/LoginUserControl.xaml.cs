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
using WPFCCPereira.Resources;
using WPFCCPereira.ViewModel;

namespace WPFCCPereira.UserControls.Renewal
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        #region "Referencias"
        private ETransactionType Type;
        private string Id;
        private string Email;
        private string Password;
        private DetailViewModel viewModel;
        #endregion

        #region "Constructor"
        public LoginUserControl(ETransactionType type)
        {
            InitializeComponent();

            Type = type;
            Id = string.Empty;
            Email = string.Empty;
            Password = string.Empty;

            viewModel = new DetailViewModel
            {
                VisibleId = Visibility.Visible,
                VisibleInput = Visibility.Hidden,
                Value2 = "/Images/others/passclosed.png"
            };

            this.DataContext = viewModel;
        }
        #endregion

        #region "Métodos"
        private bool ValidateData()
        {
            try
            {
                //TODO:aqui
                return true;

                string MS = string.Empty;

                if (txtId.Text == string.Empty || txtEmail.Text == string.Empty || txtPassword.Password == string.Empty)
                {
                    MS = "Debe ingresar todos los campos.";
                }
                else 
                if (txtId.Text.Length < 5)
                {
                    MS = "Debe ingresar una identificación valida.";
                }
                else 
                if (!Utilities.IsValidEmailAddress(txtEmail.Text))
                {
                    MS = "Debe ingresar un correo electrónico valido.";
                }
                else 
                if (txtPassword.Password.Length < 3)
                {
                    MS = "Debe ingresar una contraseña valida.";
                }

                if (MS != string.Empty)
                {
                    Utilities.ShowModal(string.Concat(MS, Environment.NewLine, "Por favor intenta de nuevo."), EModalType.Error);
                    return false;
                }

                Id = txtId.Text;
                Email = txtEmail.Text;
                Password = txtPassword.Password;

                return true;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
                return false;
            }
        }

        private void Login()
        {
            try
            {
                TimerService.Stop();

                Task.Run(async () =>
                {
                    var token = await AdminPayPlus.ApiIntegration.SecurityToken();

                    if (!token)
                    {
                        Utilities.CloseModal();

                        Utilities.ShowModal("No hay comunicación con el servicio. Por favor intenta de nuevo.", EModalType.Error);

                        TimerService.Reset();
                    }
                    else
                    {
                        //var response = await AdminPayPlus.ApiIntegration.LoginUser(Id, Email, Password);

                        Utilities.CloseModal();

                        //TODO: aqui
                        //if (response != null)
                        //{
                            Utilities.navigator.Navigate(UserControlView.ConsultRenovacion, false, Type);
                        //}
                        //else
                        //{
                        //    if (response != null && response.codigoerror == "0003")
                        //    {
                        //        Utilities.ShowModal("Clave incorrecta. Por favor vuelva a intentarlo.", EModalType.Error);
                        //    }
                        //    else
                        //    {
                        //        Utilities.ShowModal("No se pudo logear al sistema. Por favor intenta de nuevo.", EModalType.Error);
                        //    }

                        //    TimerService.Reset();
                        //}
                    }
                });

                Utilities.ShowModal("Validando usuario. Regálenos unos segundos.", EModalType.Preload);
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
            Utilities.navigator.Navigate(UserControlView.Main);
        }

        private void btnLogin_TouchDown(object sender, TouchEventArgs e)
        {
            if (ValidateData())
            {
                Login();
            }
        }

        private void txtId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtId.Text.Length > 12)
                {
                    txtId.Text = txtId.Text.Substring(0, txtId.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPassword.Password.Length > 10)
                {
                    txtPassword.Password = txtPassword.Password.Substring(0, txtPassword.Password.Length - 1);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtEmail.Text.Length > 30)
                {
                    txtEmail.Text = txtEmail.Text.Substring(0, txtEmail.Text.Length - 1);
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void txtId_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(true, sender, this);
        }

        private void txtEmail_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(false, sender, this);
        }

        private void txtPassword_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.OpenKeyboard(false, sender, this);
        }

        private void Btn_show_id_TouchEnter(object sender, TouchEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPassword.Password))
                {
                    viewModel.Value1 = txtPassword.Password;
                    viewModel.VisibleId = Visibility.Hidden;
                    viewModel.VisibleInput = Visibility.Visible;
                    viewModel.Value2 = "/Images/others/passOpen.png";

                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Btn_show_id_TouchLeave(object sender, TouchEventArgs e)
        {
            try
            {
                viewModel.VisibleId = Visibility.Visible;
                viewModel.VisibleInput = Visibility.Hidden;
                viewModel.Value2 = "/Images/others/passclosed.png";
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion
    }
}
