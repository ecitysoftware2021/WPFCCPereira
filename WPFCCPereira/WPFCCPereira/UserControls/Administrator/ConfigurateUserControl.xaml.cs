using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFCCPereira.Classes;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;

namespace WPFCCPereira.UserControls.Administrator
{
    /// <summary>
    /// Lógica de interacción para ConfigurateUserControl.xaml
    /// </summary>
    public partial class ConfigurateUserControl : UserControl
    {
        private AdminPayPlus init;

        public ConfigurateUserControl()
        {
            try
            {
                InitializeComponent();

                if (init == null)
                {
                    init = new AdminPayPlus();
                }

                txt_description.DataContext = init;

                ExtraData();
                Initial();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private async void Initial()
        {
            try
            {
                init.callbackResult = result =>
                {
                    ProccesResult(result);
                };

                init.Start();
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private async void ProccesResult(bool result)
        {
            try
            {
                if (AdminPayPlus.DataPayPlus == null)
                {
                    Finish(result);
                }
                if (AdminPayPlus.DataPayPlus.StateUpdate)
                {
                    Utilities.ShowModal(MessageResource.UpdateAplication, EModalType.Error, true);
                    Utilities.UpdateApp();
                }
                else if (AdminPayPlus.DataPayPlus.StateBalanece)
                {
                    AdminPayPlus.SaveLog(new RequestLog
                    {
                        Reference = "",
                        Description = string.Concat(MessageResource.NoGoInitial, " ", MessageResource.ModoAdministrativo),
                        State = 2,
                        Date = DateTime.Now
                    }, ELogType.General);
                }
                else if (AdminPayPlus.DataPayPlus.StateUpload)
                {
                    AdminPayPlus.SaveLog(new RequestLog
                    {
                        Reference = "",
                        Description = string.Concat(MessageResource.NoGoInitial, " ", MessageResource.ModoAdministrativo),
                        State = 2,
                        Date = DateTime.Now
                    }, ELogType.General);
                }
                else
                {
                    Finish(result);
                }
            }
            catch (Exception ex)
            {
                Utilities.ShowModal(string.Concat(init.DescriptionStatusPayPlus, " ", MessageResource.NoService), EModalType.Error, false);
                Initial();
            }
        }

        private void Finish(bool state)
        {
            Task.Run(() =>
            {
                Thread.Sleep(4000);

                if (state)
                {
                    Utilities.navigator.Navigate(UserControlView.Main);
                }
                else
                {
                    if (!string.IsNullOrEmpty(AdminPayPlus.DataPayPlus.Message))
                    {
                        AdminPayPlus.SaveLog(new RequestLog
                        {
                            Reference = "",
                            Description = string.Concat(MessageResource.NoGoInitial, " ", init.DescriptionStatusPayPlus),
                            State = 6,
                            Date = DateTime.Now
                        }, ELogType.General);

                        Utilities.ShowModal(MessageResource.NoService + " " + MessageResource.NoMoneyKiosco, EModalType.Error);
                        Initial();
                    }
                    else
                    {
                        AdminPayPlus.SaveLog(new RequestLog
                        {
                            Reference = "",
                            Description = string.Concat(MessageResource.NoGoInitial, " ", init.DescriptionStatusPayPlus),
                            State = 2,
                            Date = DateTime.Now
                        }, ELogType.General);

                        Utilities.ShowModal(MessageResource.NoService + " " + init.DescriptionStatusPayPlus, EModalType.Error);
                        Initial();
                    }
                }
            });
        }

        private void ExtraData()
        {
            try
            {
                string a = "usrapli", b = "1Cero12019$/*", c = "PayPlus C.C  Pereira Ed. Camara de comercio", d = "CamaradeComerciodePereira2020*";

                ExtraData data = new ExtraData();

                data.dataIntegration = new DataIntegration
                {
                    ambiente = new AMBIENTE
                    {
                        //controlers
                        GetTokenIntegration = "solicitarToken",
                        ConsultFileMercantil = "consultarExpedienteMercantil",
                        LiquidateNormalRenewal = "liquidarRenovacionNormal",
                        SearchFiles = "busquedaExpedientes",
                        SendTransaction = "reportarTransaccion",
                        SendPay = "reportarPago",
                        ConsultSettled = "consultarRadicado",
                        ConsultReceipt = "consultarRecibo",
                        BuyCancel = "CamaraComercio/BuyCancel",
                        //extra...
                        CodeCompany = "27",
                        OperadorControl = "KIOSKO01",
                        EmailControl = "jnietot@gmail.com",
                        IdControl = "79048506",
                        NameControl = "KIOSKO 1 CERO1",
                        PhoneControl = "3106896601",
                        CodificationService = "S",
                        TypeTransaction = "certificadosvirtuales",
                        Proyect = "1",
                        MethodPayment = "01"
                    },
                    desarrollo = new DESARROLLO
                    {
                        basseAddressIntegration = "https://siidesarrollo.confecamaras.co/librerias/wsRestSII/v1/",
                        UserAPI = "1cero1",
                        PassAPI = "1cero1per2020*"
                    },
                    produccion = new PRODUCCION
                    {
                        basseAddressIntegration = "https://siipereira.confecamaras.co/librerias/wsRestSII/v1/",
                        UserAPI = "dispenpant",
                        PassAPI = "E9k58R1ekhjikhyDokR7"
                    }
                };

                data.dataComplementary = new DataComplementary
                {
                    DurationAlert = "10000",
                    NAME_PAYPAD = "Pay+ Pereira",
                    LAST_NAME_PAYPAD = "Pereira",
                    NAME_APLICATION = "WPFPereira.exe",
                    NIT = "891.400.669-6",
                    ProductName = "Certificados Electrónicos",
                    DirectoryFile = "C:/CertificadosElectronicos",
                    CuantityItemsList = "5",
                    IntentsDownload = "3",
                    PrinterName = "Microsoft Print to PDF"
                };

                string json = JsonConvert.SerializeObject(data);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, ex.ToString());
            }
        }
    }
}
