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
        #endregion

        #region "Constructor"
        public LoginUserControl(ETransactionType type)
        {
            InitializeComponent();
            Type = type;
            Id = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
        #endregion

        #region "Métodos"
        private bool ValidateData()
        {
            try
            {
                if (txtId.Text == string.Empty || txtEmail.Text == string.Empty || txtPassword.Password == string.Empty)
                {
                    txtError.Text = "¡Mensaje de información!: Debe ingresar todos los campos.";
                    return false;
                }
                else 
                if (txtId.Text.Length < 5)
                {
                    txtError.Text = "¡Mensaje de información!: Debe ingresar una identificación valida.";
                    return false;
                }
                else 
                if (!Utilities.IsValidEmailAddress(txtEmail.Text))
                {
                    txtError.Text = "¡Mensaje de información!: Debe ingresar un correo electrónico valido.";
                    return false;
                }
                else 
                if (txtPassword.Password.Length < 3)
                {
                    txtError.Text = "¡Mensaje de información!: Debe ingresar una contraseña valida.";
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
                load_gif.Visibility = Visibility.Visible;
                btnLogin.Visibility = Visibility.Hidden;
                btnCancell.Visibility = Visibility.Hidden;

                TimerService.Stop();

                Task.Run(async () =>
                {
                    var token = await AdminPayPlus.ApiIntegration.SecurityToken();

                    if (!token)
                    {
                        Application.Current.Dispatcher.Invoke(delegate
                        {
                            load_gif.Visibility = Visibility.Hidden;
                            btnLogin.Visibility = Visibility.Visible;
                            btnCancell.Visibility = Visibility.Visible;
                        });

                        Utilities.CloseModal();

                        Utilities.ShowModal("No hay comunicación con el servicio. Por favor intenta de nuevo.", EModalType.Error);

                        TimerService.Reset();
                    }
                    else
                    {
                        string responseCode = await AdminPayPlus.ApiIntegration.LoginUser(Id, Email, Password);

                        //if (responseCode == "0000")
                        //{
                            Utilities.navigator.Navigate(UserControlView.ConsultRenovacion, false, Type);
                        //}
                        //else
                        //{
                        //    Application.Current.Dispatcher.Invoke(delegate
                        //    {
                        //        load_gif.Visibility = Visibility.Visible;
                        //        btnLogin.Visibility = Visibility.Hidden;
                        //        btnCancell.Visibility = Visibility.Hidden;
                        //    });

                        //    if (responseCode == "0003")
                        //    {
                        //        Utilities.ShowModal("Clave incorrecta. Por favor vuelva a intentarlo.", EModalType.Error);
                        //    }
                        //    else
                        //    {
                        //        Utilities.ShowModal("No se pudo logear al sistema. Por favor intenta más tarde.", EModalType.Error);
                        //    }

                        //    TimerService.Reset();
                        //}
                    }
                });
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void btnCancell_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Menu);
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
                txtError.Text = string.Empty;

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
                txtError.Text = string.Empty;

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
                txtError.Text = string.Empty;

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
        #endregion
    }
}
