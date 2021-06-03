using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;

namespace WPFCCPereira.Services
{
    public class ApiIntegration
    {
        private HttpClient client;

        private string basseAddress;

        private static string password;

        private static string token;

        private static string user;

        private static string code;

        public ApiIntegration()
        {
            basseAddress = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.basseAddressIntegration;

            user = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.UserAPI;

            password = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.PassAPI;

            code = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.CodeCompany;
        }

        public async Task<bool> SecurityToken()
        {
            try
            {
                Request request = new Request
                {
                    usuariows = user,
                    clavews = password,
                    codigoempresa = code
                };

                client = new HttpClient();
                client.BaseAddress = new Uri(basseAddress);

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                var url = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.GetTokenIntegration;

                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    AdminPayPlus.SaveErrorControl("Error en el serviocio del cliente" , response.RequestMessage.ToString(), EError.Customer, ELevelError.Medium);
                    return false;
                }

                var result = await response.Content.ReadAsStringAsync();

                if (result != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<Response>(result);

                    if (requestresponse != null && !string.IsNullOrEmpty(requestresponse.token))
                    {
                        token = requestresponse.token;
                        return true;
                    }
                }

                AdminPayPlus.SaveErrorControl("Error en el serviocio del cliente","", EError.Customer, ELevelError.Medium);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, "SecurityToken", ex, MessageResource.StandarError);
            }
            return false;
        }

        public async Task<object> GetData(object requestData, string url)
        {
            try
            {
                client = new HttpClient();
                var request = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(request, Encoding.UTF8, "Application/json");
                client.BaseAddress = new Uri(basseAddress);

                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    AdminPayPlus.SaveErrorControl("Error en el serviocio del cliente", response.RequestMessage.ToString(), EError.Customer, ELevelError.Medium);
                    return null;
                }

                var result = await response.Content.ReadAsStringAsync();
                if (result != null)
                {
                    return result;
                }

                AdminPayPlus.SaveErrorControl("Error en el serviocio del cliente", "", EError.Customer, ELevelError.Medium);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, "GetData", ex, MessageResource.StandarError);
            }
            return null;
        }

        public async Task<object> ConsultThrough(string reference, EtypeConsult type)
        {
            try { 

                RequestSearch request = new RequestSearch
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token
                };
                
                object response = null;

                if (type == EtypeConsult.Settled)
                {
                    request.radicado = reference;
                    response = await GetData(request, AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.ConsultSettled);
                    if (response != null)
                    {
                        var requestresponse = JsonConvert.DeserializeObject<ResponseTransact>(response.ToString());

                        if (requestresponse != null && requestresponse.codigoerror == "0000")
                        {
                            return requestresponse;
                        }
                    }
                }
                else
                {
                    request.recibo = reference;
                    response = await GetData(request, AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.ConsultReceipt);
                    if (response != null)
                    {
                        var requestresponse = JsonConvert.DeserializeObject<ResponseTransact>(response.ToString());

                        if (requestresponse != null && requestresponse.codigoerror == "0000")
                        {
                            return await ConsultThrough(requestresponse.radicado, EtypeConsult.Settled);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, "GetData", ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<Transaction> Renewal(Transaction transaction, EtypeConsult type)
        {
            try
            {
                RequestLiquidateRenewal request = new RequestLiquidateRenewal
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    idusuario = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.OperadorControl,
                    emailcontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.EmailControl,
                    identificacioncontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.IdControl,
                    nombrecontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.NameControl,
                    celularcontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.PhoneControl,
                    matrucula = transaction.Products
                };

                var response = await GetData(request, AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.LiquidateNormalRenewal);

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<ResponseLiquidateRenewal>(response.ToString());

                    if (requestresponse != null && requestresponse.codigoerror == "0000" && !string.IsNullOrEmpty(requestresponse.idliquidacion) && !string.IsNullOrEmpty(requestresponse.numerorecuperacion))
                    {
                        transaction.consecutive = requestresponse.idliquidacion;
                        transaction.reference = requestresponse.numerorecuperacion;
                        transaction.Amount = requestresponse.valortotal;
                        return transaction;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, "GetData", ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<List<Noun>> SearchFiles(string reference, EtypeConsult type)
        {
            try
            {
                RequestSearch request = new RequestSearch
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    matriculainicial =  0,
                    semilla = "0"
                };

                if (type == EtypeConsult.Id)
                {
                    request.identificacion = reference;
                }
                else
                {
                    request.nombreinicial = reference;
                }

                var response = await GetData(request , AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.SearchFiles);

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<Response>(response.ToString());

                    if (requestresponse != null && requestresponse.codigoerror == "0000" && requestresponse.expedientes != null)
                    {
                        var files = JsonConvert.DeserializeObject<List<Noun>>(requestresponse.expedientes.ToString());
                        if (files.Count > 0)
                        {
                            return files;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, "GetData", ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<Transaction> NotifycTransaction(Transaction transaction)
        {
            try
            {
                if (transaction != null)
                {
                    var response = await GetData(new RequestTransaction
                    {
                        token = token,
                        usuariows = user,
                        codigoempresa = code,
                        operador = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.OperadorControl,
                        emailcontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.EmailControl,
                        identificacioncontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.IdControl,
                        nombrecontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.NameControl,
                        celularcontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.PhoneControl,
                        codificacionservicios = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.CodificationService,
                        tipoidentificacioncliente = transaction.payer.TYPE_IDENTIFICATION,
                        identificacioncliente = transaction.payer.IDENTIFICATION,
                        razonsocialcliente = transaction.payer.NAME ?? ((Noun)transaction.File).nombre,
                        nombre1cliente = transaction.payer.NAME ?? ((Noun)transaction.File).nombre,
                        nombre2cliente = transaction.payer.NAME ?? string.Empty,
                        apellido1cliente = transaction.payer.LAST_NAME ?? string.Empty,
                        apellido2cliente = transaction.payer.LAST_NAME ?? string.Empty,
                        emailcliente = transaction.payer.EMAIL?? AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.EmailControl,
                        direccioncliente = transaction.payer.ADDRESS ?? ((Noun)transaction.File).direccion,
                        telefonocliente = transaction.payer.PHONE.ToString() ?? AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.PhoneControl,
                        celularcliente = transaction.payer.PHONE.ToString() ?? AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.PhoneControl, 
                        municipiocliente = ((Noun)transaction.File).municipio,
                        valorbruto = 0,
                        Valorbaseiva = 0,
                        Valoriva = 0,
                        valortotal = transaction.Amount,
                        tipotramite = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.TypeTransaction,
                        subtipotramite = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.TypeTransaction,
                        proyecto = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.Proyect,
                        servicios = transaction.Products
                    }, AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.SendTransaction);

                    if (response != null)
                    {
                        var requestresponse = JsonConvert.DeserializeObject<Response>(response.ToString());

                        if (requestresponse != null && !string.IsNullOrEmpty(requestresponse.idliquidacion) && !string.IsNullOrEmpty(requestresponse.numerorecuperacion))
                        {
                            transaction.consecutive = requestresponse.idliquidacion;
                            transaction.reference = requestresponse.numerorecuperacion;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
            return transaction;
        }

        public async Task<List<string>> ReportPayment(Transaction transaction)
        {
            try
            {
                List<string> pathCertificates = new List<string>();
                int countCertificates = 0;

                var response = await GetData(new RequestPayment
                {
                    token = token,
                    usuariows = user,
                    codigoempresa = code,
                    operador = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.OperadorControl,
                    emailcontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.EmailControl,
                    identificacioncontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.IdControl,
                    nombrecontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.NameControl,
                    celularcontrol = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.PhoneControl,
                    idliquidacion = transaction.consecutive,
                    numerorecuperacion = transaction.reference,
                    valorpagado = Convert.ToInt32(transaction.Amount).ToString(),
                    fechapago = transaction.DateTransaction.ToString("yyyy-MM-dd"),
                    horapago = transaction.DateTransaction.ToString("hh:mm:ss"),
                    formapago = AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.MethodPayment,
                    numeroautorizacion = string.Empty,
                    idbanco = string.Empty,
                    idfranquicia = string.Empty,
                    codigofirmapdf = string.Empty
                }, AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.SendPay);

                if (response != null)
                {
                    AdminPayPlus.SaveLog(new RequestLog
                    {
                        Reference = "",
                        Description = string.Concat("Respuesta del servicio SendPay: ", response.ToString()),
                        State = 1,
                        Date = DateTime.Now
                    }, ELogType.General);

                    var requestresponse = JsonConvert.DeserializeObject<Response>(response.ToString());

                    if (requestresponse != null && requestresponse.certificados.Count > 0)
                    {
                        foreach (var certificate in requestresponse.certificados)
                        {
                            countCertificates += 1;
                            if (!string.IsNullOrEmpty(certificate.path))
                            {
                                var nameFile = $"{transaction.IdTransactionAPi}-{certificate.codigoverificacion}" +
                                     $"-{transaction.consecutive}-{DateTime.Now.ToString("yyyy-MM-dd")}";
                                string path = DownloadFile(certificate.path, nameFile);
                                if (!string.IsNullOrEmpty(path))
                                {
                                    pathCertificates.Add(path);
                                }
                            }
                        }

                        if (pathCertificates.Count == countCertificates)
                        {
                            return pathCertificates;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
                return null;
            }
        }

        public string DownloadFile(string patchFile, string nameFile)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    bool stateDownload = false;
                    int countIntents = 0;
                    while (!stateDownload)
                    {
                        var response = webClient.DownloadData(patchFile);
                        var contentType = webClient.ResponseHeaders["Content-Type"];

                        if (response != null && contentType != null &&
                            contentType.StartsWith("application/pdf", StringComparison.OrdinalIgnoreCase))
                        {
                            stateDownload = true;
                            var path = Utilities.SaveFile(nameFile, AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataComplementary.DirectoryFile, response);
                            if (!string.IsNullOrEmpty(path))
                            {
                                return path;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            countIntents++;
                            if (countIntents >= int.Parse(AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataComplementary.IntentsDownload))
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
            return string.Empty;
        }

        public async Task<decimal> GetDiscount(Transaction transaction)
        {
            try
            {
                RequestDiscount request = new RequestDiscount
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    idliquidacion = transaction.consecutive
                };

                var response = await GetData(request, AdminPayPlus.DataPayPlus.PayPadConfiguration.ExtrA_DATA.dataIntegration.ambiente.GetDiscount);

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<Object.Response>(response.ToString());

                    if (requestresponse != null && requestresponse.codigoerror == "0000")
                    {
                        return requestresponse.descuentoaplicado;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, "GetData", ex, MessageResource.StandarError);
            }
            return 0;
        }
    }
}
