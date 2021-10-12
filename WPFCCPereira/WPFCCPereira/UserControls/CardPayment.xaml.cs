using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using WPFCCPereira.Resources;
using WPFCCPereira.ViewModel;
using WPFCCPereira.Windows.Modals;

namespace WPFCCPereira.UserControls
{
    /// <summary>
    /// Interaction logic for CardPayment.xaml
    /// </summary>
    public partial class CardPayment : UserControl
    {
        #region "References"

        #region "Variables"

        private bool stateUpdate;

        private bool payState;

        private int num = 1;

        string _peticion = string.Empty;

        bool _isCredit = false;

        ModalConfirmation modal;

        private PaymentViewModel paymentViewModel;

        DataCardTransaction _dataCard;

        TPVOperation TPV;

        private Transaction transaction;

        #endregion

        #region Propiedades Tarjeta

        private string TramaCancelar;

        private string TramaInicial;
        private string MensajeDebito { get; set; }
        private string ValorTotal { get; set; }
        private string ValorIVA { get { return "0"; } }
        private string NumeroTransaccion { get; set; }
        private string ValorPropina { get { return "0"; } }
        private string ValorIAC { get { return "0"; } }

        string _Franchise;

        string _LastNumbers;

        string _AutorizationCode;

        string _ReceiptNumber;

        string _RRN;


        #endregion

        #endregion

        #region "Constructor"

        public CardPayment(Transaction transaction, ModalConfirmation modal)
        {
            InitializeComponent();

            this.transaction = transaction;

            this.modal = modal;

            TPV = new TPVOperation();

            Activar();
        }

        #endregion

        #region "Events"

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //============ORIGINAL PROCINAL================================================================================

            //ValorTotal = Utilities.dataTransaction.PayVal.ToString().Split(',')[0];
            //NumeroTransaccion = Utilities.IDTransactionDB.ToString();
            //string Delimitador = Utilities.dataPaypad.PaypadConfiguration.ExtrA_DATA.DataDatafono.Delimitador;

            //TramaInicial =
            //   string.Concat(Utilities.dataPaypad.PaypadConfiguration.ExtrA_DATA.DataDatafono.IdentificadorInicio, Delimitador,
            //    Utilities.dataPaypad.PaypadConfiguration.ExtrA_DATA.DataDatafono.TipoOperacion, Delimitador,
            //    ValorTotal, Delimitador,
            //    ValorIVA, Delimitador,
            //    Utilities.CorrespondentId, Delimitador,
            //    Utilities.CorrespondentId, Delimitador,
            //    NumeroTransaccion, Delimitador,
            //    ValorPropina, Delimitador,
            //    Utilities.dataPaypad.PaypadConfiguration.ExtrA_DATA.DataDatafono.CodigoUnico, Delimitador,
            //    ValorIAC, Delimitador,
            //    Utilities.CorrespondentId, "]");

            //===================================================================================================================
            ValorTotal = "01";
            NumeroTransaccion = transaction.TransactionId.ToString();
            string Delimitador = ",";

            TramaInicial =
                string.Concat("I", Delimitador,
                AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataComplementary.TipoOperacion, Delimitador,
                ValorTotal, Delimitador,
                ValorIVA, Delimitador,
                AdminPayPlus.DataConfiguration.ID_PAYPAD, Delimitador,
                AdminPayPlus.DataConfiguration.ID_PAYPAD, Delimitador,
                NumeroTransaccion, Delimitador,
                ValorPropina, Delimitador,
                AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataComplementary.CodigoUnico, Delimitador,
                ValorIAC, Delimitador,
                AdminPayPlus.DataConfiguration.ID_PAYPAD, "]");

            //Creo el LCR de la peticion a partir de la trama de inicialización del datáfono
            Dispatcher.Invoke((Action)delegate
            {
                lblValorPagar.Content = string.Format("{0:C0}", transaction.Amount);
            });

            var LCRPeticion = TPV.CalculateLRC(TramaInicial);

            //Envío la trama que intentará activar el datáfono
            var datos = TPV.EnviarPeticion(LCRPeticion);

            TPVOperation.CallBackRespuesta?.Invoke(datos);

            Dispatcher.Invoke((Action)delegate
            {
                modal.Close();
            });
        }
        private void BtnCancelar_TouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                if (Utilities.ShowModal(MessageResource.CancelTransaction, EModalType.Information))
                {
                    Cancelled();
                    Utilities.navigator.Navigate(UserControlView.Main);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ListViewItem_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            OptionsSelect(sender);
        }
        private void OptionsSelect(object sender)
        {
            try
            {
                this.IsEnabled = false;
                btnCancelar.Visibility = Visibility.Hidden;
                //Optengo la data contenida en el elemento seleccionado
                var data = (sender as ListBoxItem).DataContext;

                //Si se trada de una data que setee yo entonces procedo a recorrerla
                if (data is FormaPago)
                {
                    var datos = data as FormaPago;
                    var LRCPeticion = TPV.CalculateLRC(datos.Trama);

                    DataCardTransaction dataCard = new DataCardTransaction
                    {
                        isCredit = false,
                        maxlen = 1,
                        minlen = 1,
                        visible = "Visible"
                    };
                    //Swicheo todas las opciones presentadas por el datáfono para pintarle al usuario las guías correspondientes
                    switch (datos.Forma)
                    {
                        case "DESLIZAR":
                            OptionSelected(datos, LRCPeticion, dataCard, "Desliza tu tarjeta en el datáfono");
                            break;
                        case "INSERTAR":
                            OptionSelected(datos, LRCPeticion, dataCard, "Inserta tu tarjeta en el datáfono");

                            break;
                        case "ACERCAR":
                            OptionSelected(datos, LRCPeticion, dataCard, "Acerca tu tarjeta al datáfono");

                            break;
                        case "QR":
                            OptionSelected(datos, LRCPeticion, dataCard, "Lee el QR en el datáfono");

                            break;
                        case "PAGO MOVIL":
                            OptionSelected(datos, LRCPeticion, dataCard, "Acerca el teléfono al datáfono");
                            break;
                        //case "NFC":
                        //opciones = new Opciones("Acerca el dispositivo NFC al datáfono", peticion: LRCPeticion);
                        //opciones.ShowDialog();
                        //break;
                        case "AHORROS":
                            dataCard.imagen = string.Empty;
                            ActionTPV(LRCPeticion, dataCard, MensajeDebito, "Hidden");
                            break;
                        case "CORRIENTE":
                            dataCard.imagen = "/Images/Gif/clave.Gif";
                            ActionTPV(LRCPeticion, dataCard, MensajeDebito, "Hidden");
                            break;
                        //case "CREDITO":
                        //dataCard.imagen = "/Images/NewDesing/Gif/clave.Gif";
                        //ActionTPV(LRCPeticion, dataCard, "Cuatro últimos dígitos de la tarjeta", "Visible");
                        //break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //LogService.SaveRequestResponse("UCCardPayment>OptionsSelect", JsonConvert.SerializeObject(ex), 1);

            }
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Activa el callback que procesa todas las respuestas del datáfono
        /// </summary>
        private void Activar()
        {
            TPVOperation.CallBackRespuesta = Respuesta =>
            {
                Dispatcher.BeginInvoke((Action)delegate
                {
                    ProcesarRespuesta(Respuesta);
                });
            };
        }

        /// <summary>
        /// Cancelar el pago
        /// </summary>
        private void Cancelled()
        {
            UnlockTPV();
        }

        /// <summary>
        /// Finalizar el pago ante score
        /// </summary>
        private void SavePay()
        {
            Utilities.navigator.Navigate(UserControlView.PrintFile, false, transaction);
            //notificar al ws del client
        }

        #region TransactionalMethods
        //conexion  con datafono
        /// <summary>
        /// Procesa todas las respuestas del datáfono
        /// </summary>
        /// <param name="responseTPV"></param>
        private void ProcesarRespuesta(string responseTPV)
        {
            try
            {
                //LogService.SaveRequestResponse("Respuesta del datáfono", responseTPV, 1);
                //Todas las respuestas correctas tienen mas de 4 caracteres

                if (responseTPV.Length < 4)
                {
                    //Cancelled();

                    var x = TPV;

                    SetMessageAndPutVisibility("Datáfono sin conexión, intente de nuevo.");
                }
                else
                {
                    /**
                     * Tomo los datos que esten dentro de los corchetes
                     * **/
                    var dataSubString = responseTPV.Substring(responseTPV.IndexOf("[") + 1).Split(']')[0];

                    //Divido la respuesta para tomar la trama de la información
                    var dataResponse = dataSubString.Split(',');

                    //Una p en el primer campo significa acción que debe realizar la pantalla
                    if (dataResponse[0].Equals("P"))
                    {
                        //Valido que la respuesta no corresponda a un error
                        if (dataResponse.Length == 4 && !dataResponse[2].ToLower().Equals("error"))
                        {
                            /**
                             * Si la trama contiene 'pin' se trata de la solicitud de la clave
                             * De lo contrario se trata de informacion seleccionable en pantalla
                             */
                            if (dataResponse[3].ToLower().Contains("pin"))
                            {
                                //Utilities.Speack("Digita la clave en el datáfono y presiona el boton verde");
                                MensajeDebito = "Digita la clave en el datáfono y presiona el botón verde";
                                ProcessDebitOperation(MensajeDebito);
                            }
                            else
                            {
                                ProccessPositiveResponse(dataResponse);
                            }
                        }
                        else if (dataResponse[2].ToLower().Equals("error"))
                        {
                            //Procesa  todas las tramas con error del datáfono
                            if (dataResponse[3].ToLower().Contains("pin"))
                            {
                                //Utilities.Speack("Clave incorrecta, intenta nuevamente y presiona el boton verde.");

                                MensajeDebito = "Pin incorrecto, intente nuevamente y presiona el botón verde.";
                                ProcessDebitOperation(MensajeDebito);
                            }
                            else
                            {
                                ProcesarFinalError(dataResponse[3]);
                            }
                        }
                        else
                        {
                            //Procesa todas las tramas operacionales del datafono
                            ProcessOperation(dataResponse);
                        }
                    }
                    else if (dataResponse[0].Equals("F"))
                    {
                        /**
                         * Si la respuesta contiene una F se trata del final de una transacción
                         */
                        ProcesarFinal(dataResponse);
                    }
                    else
                    {
                        this.IsEnabled = true;
                        btnCancelar.Visibility = Visibility.Visible;
                        SetMessageAndPutVisibility("Respuesta del datafono: " + dataResponse[0]);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Procesa todas las tramas transaccionales de tarjeta crédito
        /// </summary>
        /// <param name="response"></param>
        void ProcessOperation(string[] response)
        {
            try
            {
                var dataTransaction = response[3].Split(';');
                //Valido si la respuesta concuerda con una respuesta válida para el sistema
                if (response.Length == 4)
                {
                    this.IsEnabled = true;
                    ProccessPositiveResponse(dataTransaction);
                }
                else if (response.Length > 4)// Si la data supera los 4 espacios se trata de un pago con tarjeta de crétido
                {
                    //Armo la trama necesaria para las tarjetas de crédito
                    string Trama = string.Concat("R,", response[1], ",1,");
                    //Si la trama respondida por el datáfono contiene Ult. se trata de la peticion de los 4 últimos dígitos de la tarjeta al usuario
                    if (response[3].Contains("Ult."))
                    {
                        //Utilities.Speack("Escribe los ultimos cuatro digitos de tu tarjeta.");

                        Dispatcher.BeginInvoke((Action)delegate
                        {
                            this.Opacity = 0.3;
                        });
                        //Se envía un maxlenght para el campo de ingreso de los 4 números, la trama y si es crédito
                        DataCardTransaction dataCard = new DataCardTransaction
                        {
                            imagen = string.Empty,
                            isCredit = true,
                            maxlen = 4,
                            mensaje = "Cuatro últimos dígitos de la tarjeta",
                            minlen = 4,
                            peticion = Trama,
                            visible = "Visible"
                        };
                        Opcions(dataCard);
                        //ModalOpcions = new ModalOpcions(dataCard);
                        //ModalOpcions.ShowDialog();
                    }
                    else if (response[3].Contains("Cuotas"))//Si contiene Cuotas entonces se trata de la solicitud del número de cueotas para la compra al usuario
                    {
                        //Utilities.Speack("Escribe el numero de cuotas para el pago.");

                        Dispatcher.BeginInvoke((Action)delegate
                        {
                            this.Opacity = 0.3;
                        });
                        DataCardTransaction dataCard = new DataCardTransaction
                        {
                            imagen = string.Empty,
                            isCredit = true,
                            maxlen = 2,
                            mensaje = "¿Número de cuotas?",
                            minlen = 1,
                            peticion = Trama,
                            visible = "Visible"
                        };
                        Opcions(dataCard);
                        //ModalOpcions = new ModalOpcions(dataCard);
                        //ModalOpcions.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                //LogService.SaveRequestResponse("UCCardPayment>ProcessOperation", JsonConvert.SerializeObject(ex), 1);
            }
        }

        /// <summary>
        /// Solicita la clave en el datafono
        /// </summary>
        private void ProcessDebitOperation(string message)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                this.Opacity = 0.3;
            });

            lvOpciones.Visibility = Visibility.Hidden;
            DataCardTransaction dataCard = new DataCardTransaction
            {
                imagen = "/Images/Gif/clave.gif",
                isCredit = false,
                maxlen = 1,
                mensaje = message,
                minlen = 1,
                peticion = null,
                visible = "Visible"
            };
            Opcions(dataCard);
            //ModalOpcions = new ModalOpcions(dataCard);
            //ModalOpcions.ShowDialog();
            Dispatcher.BeginInvoke((Action)delegate
            {
                this.Opacity = 1;
            });
        }

        /// <summary>
        /// Procesa la respuesta transaccional positiva
        /// Todas las respuestas del datafono donde se debe habilitar la selección en pantalla
        /// </summary>
        /// <param name="positiveResponse"></param>
        private void ProccessPositiveResponse(string[] positiveResponse)
        {
            try
            {
                //Separo y obtengo las opciones transaccionales que se le presentarán al usuario
                var opcionesTransaccionales = positiveResponse[3].Split(';');
                if (opcionesTransaccionales.Length > 1)
                {

                    lvOpciones.Visibility = Visibility.Visible;
                    //Asigno el título de la operación actual para el usuario
                    txtOpcion.Text = positiveResponse[2];
                    if (positiveResponse[2].Equals("Tipo de Cuenta?"))
                    {
                        GifLoad.Visibility = Visibility.Hidden;
                    }

                    //En esta lista se almanecarán las opciones que se le presentaran en la vista al usuario
                    List<FormaPago> formas = new List<FormaPago>();
                    //Este índice le da a cada opción su valor segun la trama del datáfono
                    int indiceForma = 1;
                    Utilities.Speack("Selecciona una opcion para continuar.");

                    foreach (var item in opcionesTransaccionales)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            if (!item.ToLower().Contains("pago movil")
                                && !item.ToLower().Contains("nfc")
                                && !item.ToLower().Contains("qr"))
                            {
                                formas.Add(new FormaPago
                                {
                                    Forma = item,
                                    Imagen = string.Concat("/Images/Buttons/", item, ".png"),
                                    Trama = string.Concat("R,", positiveResponse[1], ",", indiceForma, "]"),
                                });
                            }
                        }
                        indiceForma++;
                    }

                    TramaCancelar = string.Concat("R,", positiveResponse[1], ",0]");

                    //Se le asigna el modelo a la vista transaccional
                    this.IsEnabled = true;
                    lvOpciones.DataContext = formas;
                }
            }
            catch (Exception ex)
            {
                //LogService.SaveRequestResponse("UCCardPayment>ProccessPositiveResponse", JsonConvert.SerializeObject(ex), 1);

            }
        }

        /// <summary>
        /// Procesa la respuesta final del datáfono a la pantalla
        /// </summary>
        /// <param name="response"></param>
        void ProcesarFinal(string[] response)
        {
            try
            {

                this.IsEnabled = true;
                //Transacción aprobada es igual a 00
                if (response[2].Equals("00"))
                {
                    _Franchise = response[13];
                    _LastNumbers = response[16];
                    _AutorizationCode = response[3];
                    _ReceiptNumber = response[7];
                    _RRN = response[8];
                    OrganizeValues();
                }
                else
                {
                    //Error de tarjeta
                    if (response[2].Equals("02"))
                    {
                        SetMessageAndPutVisibility("Transacción rechazada.");
                    }
                    else if (response[2].Equals("05"))//Error de conexión a puerto (Fisico)
                    {
                        SetMessageAndPutVisibility("Datáfono no disponible.");
                        Task.Run(() =>
                        {
                            //Utilities.SendMailErrores($"Se perdió la conexión del datáfono en la transacción {Utilities.IDTransactionDB}," +
                            //    "Por favor contactar con 1Cero1 para la respectiva validación.");
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                //LogService.SaveRequestResponse("UCCardPayment>ProcesarFinal", JsonConvert.SerializeObject(ex), 1);
            }
        }

        void ProcesarFinalError(string message)
        {
            SetMessageAndPutVisibility(message);
        }

        #endregion

        #region Events

        /// <summary>
        /// Método para cambiar mensaje y ocultar lista de opciones
        /// </summary>
        /// <param name="message"></param>
        void SetMessageAndPutVisibility(string message)
        {
            try
            {
                GC.Collect();
                Opacity = 0.3;
                modal = new ModalConfirmation(transaction);
                message = GetMessageError(message);
                Utilities.ShowModal(message, EModalType.Error);
                lvOpciones.Visibility = Visibility.Hidden;
                Opacity = 1;
                RetryPayment();
                GC.Collect();
            }
            catch (Exception ex)
            {
                //LogService.SaveRequestResponse("UCCardPayment>SetMessageAndPutVisibility", JsonConvert.SerializeObject(ex), 1);

            }
        }

        private void UnlockTPV()
        {
            Task.Run(() =>
            {
                TPV.EnviarPeticion("[R,61,0]38");
            });
        }

        #endregion

        /// <summary>
        /// Evento de lo que selecciona el usuario en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ActionTPV(string LRCPeticion, DataCardTransaction dataCard, string message, string visible)
        {
            dataCard.mensaje = message;
            dataCard.peticion = LRCPeticion;
            dataCard.imagen = string.Empty;
            dataCard.visible = visible;
            Opcions(dataCard);
            //ModalOpcions = new ModalOpcions(dataCard);
            //ModalOpcions.ShowDialog();
        }

        private void OptionSelected(FormaPago datos, string LRCPeticion, DataCardTransaction dataCard, string message)
        {
            dataCard.mensaje = message;
            dataCard.peticion = LRCPeticion;
            dataCard.imagen = string.Concat("/Images/Gif/", datos.Forma, ".Gif");
            this.Opacity = 0.3;
            Opcions(dataCard);
            //ModalOpcions = new ModalOpcions(dataCard);
            //ModalOpcions.ShowDialog();
            this.Opacity = 1;
        }

        private void RetryPayment()
        {
            this.Opacity = 0.3;
            modal.ShowDialog();
        }

        private string GetMessageError(string error)
        {
            if (error.ToLower().Contains("digitos"))
            {
                error = "Señor usuario, los 4 últimos dígitos de su tarjeta no coinciden con los ingresados, por favor intente de nuevo.";
            }
            else if (error.ToLower().Contains("comunicacion"))
            {
                error = "Señor usuario, No hay comunicación con el datáfono.";
                modal.BtnCard.Visibility = Visibility.Hidden;
                Cancelled();

            }
            else if (error.ToLower().Contains("declinada"))
            {
                error = "Señor usuario, su tarjeta fué declinada, intente con otra tarjeta.";
            }
            else if (error.ToLower().Contains("soportada"))
            {
                error = "Señor usuario, transacción no soportada, intente de otro modo.";
                modal.BtnCard.Visibility = Visibility.Hidden;
                Cancelled();
            }
            else if (error.ToLower().Contains("invalida"))
            {
                error = "Señor usuario, transacción inválida, intente nuevamente.";
            }
            else if (error.ToLower().Contains("rechazada"))
            {
                error = "Señor usuario, transacción rechazada, intente nuevamente.";
            }
            else if (error.ToLower().Contains("host"))
            {
                error = "Señor usuario, No hay comunicación con el datáfono.";
                modal.BtnCard.Visibility = Visibility.Hidden;
                Cancelled();
            }
            else if (error.ToLower().Contains("PIN Incorrecto"))
            {
                error = "El pin es incorrecto, intente nuevamente por favor.";
            }
            error = error.Replace(";", " ").ToLower();
            return error;
        }

        private void Opcions(DataCardTransaction dataCard)
        {
            _dataCard = dataCard;
            TPV = new TPVOperation();
            _peticion = dataCard.peticion;
            _isCredit = dataCard.isCredit;
            txtOpcion.Text = dataCard.mensaje;
            GifLoad.Visibility = Visibility.Visible;
            lvOpciones.Visibility = Visibility.Hidden;
            GifLoad.DataContext = _dataCard;

            if (!_isCredit)
            {
                Task.Run(() =>
                {
                    try
                    {
                        if (_peticion != null)
                        {
                            //LogService.SaveRequestResponse("Petición al datáfono", _peticion, 1);
                            var respuestaPeticion = TPV.EnviarPeticion(_peticion);
                            TPVOperation.CallBackRespuesta?.Invoke(respuestaPeticion);
                        }
                        else
                        {
                            var respuestaPeticion = TPV.EnviarPeticionEspera();
                            TPVOperation.CallBackRespuesta?.Invoke(respuestaPeticion);
                        }
                    }
                    catch (Exception ex)
                    {
                        //LogService.SaveRequestResponse("Opciones>Window_Loaded", JsonConvert.SerializeObject(ex), 1);
                    }
                });

            }

        }

        private void OrganizeValues()
        {
            this.paymentViewModel = new PaymentViewModel
            {
                PayValue = transaction.Amount,
                ValorFaltante = 0,
                ImgContinue = Visibility.Hidden,
                ImgCancel = Visibility.Hidden,
                ImgCambio = Visibility.Hidden,
                ValorSobrante = 0,
                ValorIngresado = transaction.Amount,
                viewList = new CollectionViewSource(),
                Denominations = new List<DenominationMoney>(),
                ValorDispensado = 0,
                StatePay = true
            };
            transaction.Payment = paymentViewModel;

            SavePay();
        }

        #endregion
    }
    #region "Class"

    public class FormaPago
    {
        public string Imagen { get; set; }
        public string Forma { get; set; }
        public string Trama { get; set; }
    }

    #endregion
}
