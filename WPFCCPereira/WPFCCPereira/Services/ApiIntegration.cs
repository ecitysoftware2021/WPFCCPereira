using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPFCCPereira.Classes;
using WPFCCPereira.DataModel;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;
using WPFCCPereira.Services.ObjectIntegration;

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
            basseAddress = Utilities.GetConfiguration("basseAddressIntegration");

            user = Utilities.GetConfiguration("UserAPI");

            password = Utilities.GetConfiguration("PassAPI");

            code = Utilities.GetConfiguration("CodeCompany");
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
                var url = Utilities.GetConfiguration("GetTokenIntegration");

                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    AdminPayPlus.SaveErrorControl("Error en el serviocio del cliente", response.RequestMessage.ToString(), EError.Customer, ELevelError.Medium);
                    return false;
                }

                var result = await response.Content.ReadAsStringAsync();

                if (result != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<Object.Response>(result);

                    if (requestresponse != null && !string.IsNullOrEmpty(requestresponse.token))
                    {
                        token = requestresponse.token;
                        return true;
                    }
                }

                AdminPayPlus.SaveErrorControl("Error en el serviocio del cliente", "", EError.Customer, ELevelError.Medium);
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, "SecurityToken", ex, MessageResource.StandarError);
            }
            return false;
        }

        public async Task<object> GetData(object requestData, string controller)
        {
            try
            {
                client = new HttpClient();
                var request = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(request, Encoding.UTF8, "Application/json");
                client.BaseAddress = new Uri(basseAddress);
                var url = Utilities.GetConfiguration(controller);

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
            try
            {

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
                    response = await GetData(request, "ConsultSettled");
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
                    response = await GetData(request, "ConsultReceipt");
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
                    idusuario = Utilities.GetConfiguration("OperadorControl"),
                    emailcontrol = Utilities.GetConfiguration("EmailControl"),
                    identificacioncontrol = Utilities.GetConfiguration("IdControl"),
                    nombrecontrol = Utilities.GetConfiguration("NameControl"),
                    celularcontrol = Utilities.GetConfiguration("PhoneControl"),
                    matrucula = transaction.Products
                };

                var response = await GetData(request, "LiquidateNormalRenewal");

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

                var response = await GetData(request, "GetDiscount");

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

        public async Task<List<Noun>> SearchFiles(string reference, EtypeConsult type)
        {
            try
            {
                RequestSearch request = new RequestSearch
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    matriculainicial = 0,
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

                var response = await GetData(request, "SearchFiles");

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<Object.Response>(response.ToString());

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
                        operador = Utilities.GetConfiguration("OperadorControl"),
                        emailcontrol = Utilities.GetConfiguration("EmailControl"),
                        identificacioncontrol = Utilities.GetConfiguration("IdControl"),
                        nombrecontrol = Utilities.GetConfiguration("NameControl"),
                        celularcontrol = Utilities.GetConfiguration("PhoneControl"),
                        codificacionservicios = Utilities.GetConfiguration("CodificationService"),
                        tipoidentificacioncliente = transaction.payer.TYPE_IDENTIFICATION,
                        identificacioncliente = transaction.payer.IDENTIFICATION,
                        razonsocialcliente = transaction.payer.NAME ?? ((Noun)transaction.File).nombre,
                        nombre1cliente = transaction.payer.NAME ?? ((Noun)transaction.File).nombre,
                        nombre2cliente = transaction.payer.NAME ?? string.Empty,
                        apellido1cliente = transaction.payer.LAST_NAME ?? string.Empty,
                        apellido2cliente = transaction.payer.LAST_NAME ?? string.Empty,
                        emailcliente = transaction.payer.EMAIL ?? Utilities.GetConfiguration("EmailControl"),
                        direccioncliente = transaction.payer.ADDRESS ?? ((Noun)transaction.File).direccion,
                        telefonocliente = transaction.payer.PHONE.ToString() ?? Utilities.GetConfiguration("PhoneControl"),
                        celularcliente = transaction.payer.PHONE.ToString() ?? Utilities.GetConfiguration("PhoneControl"),
                        municipiocliente = ((Noun)transaction.File).municipio,
                        valorbruto = 0,
                        Valorbaseiva = 0,
                        Valoriva = 0,
                        valortotal = transaction.Amount,
                        tipotramite = Utilities.GetConfiguration("TypeTransaction"),
                        subtipotramite = Utilities.GetConfiguration("TypeTransaction"),
                        proyecto = Utilities.GetConfiguration("Proyect"),
                        servicios = transaction.Products
                    }, "SendTransaction");

                    if (response != null)
                    {
                        var requestresponse = JsonConvert.DeserializeObject<Object.Response>(response.ToString());

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
                    operador = Utilities.GetConfiguration("OperadorControl"),
                    emailcontrol = Utilities.GetConfiguration("EmailControl"),
                    identificacioncontrol = Utilities.GetConfiguration("IdControl"),
                    nombrecontrol = Utilities.GetConfiguration("NameControl"),
                    celularcontrol = Utilities.GetConfiguration("PhoneControl"),
                    idliquidacion = transaction.consecutive,
                    numerorecuperacion = transaction.reference,
                    valorpagado = Convert.ToInt32(transaction.Amount).ToString(),
                    fechapago = transaction.DateTransaction.ToString("yyyy-MM-dd"),
                    horapago = transaction.DateTransaction.ToString("hh:mm:ss"),
                    formapago = Utilities.GetConfiguration("MethodPayment"),
                    numeroautorizacion = string.Empty,
                    idbanco = string.Empty,
                    idfranquicia = string.Empty,
                    codigofirmapdf = string.Empty
                }, "SendPay");

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<Object.Response>(response.ToString());

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
                            var path = Utilities.SaveFile(nameFile, Utilities.GetConfiguration("DirectoryFile"), response);
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
                            if (countIntents >= int.Parse(Utilities.GetConfiguration("IntentsDownload").ToString()))
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

        //BEGIN RENOVACION 
        public async Task<ResponseLogin> LoginUser(string id, string email, string password, string phone)
        {
            try
            {
                //TODO:Aquí
                RequestLogin request = new RequestLogin
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    celularusuario = phone,
                    claveusuario = password,
                    emailusuario = email,
                    identificacionusuario = id
                };

                RequestLogin request2 = new RequestLogin
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    celularusuario = "3176400841",
                    claveusuario = "5052438",
                    emailusuario = "jufeveos@utp.edu.co",
                    identificacionusuario = "1088285069"
                };

                var response = await GetData(request, "LoginUser");

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<ResponseLogin>(response.ToString());

                    if (requestresponse != null && requestresponse.codigoerror == "0000")
                    {
                        return requestresponse;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<ResponseIntegration> ConsultarExpedienteMercantil(string reference, EtypeConsult etype)
        {
            try
            {
                RequestFileMercantil request = new RequestFileMercantil
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    identificacion = etype == EtypeConsult.Id ? reference : string.Empty,
                    matricula = etype == EtypeConsult.Matricula ? reference : string.Empty,
                    tipo = "T"
                };

                var response = await GetData(request, "ConsultFileMercantil");

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<ResponseIntegration>(response.ToString());

                    if (requestresponse != null && requestresponse.codigoerror == "0000")
                    {
                        return requestresponse;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<LiquidarRenovacionNormalResponse> liquidarRenovacionNormal(RequestLiquidarRenovacionNormal request)
        {
            try
            {
                RequestLiquidarRenovacionNormal Request = request;

                Request.codigoempresa = code;
                Request.usuariows = user;
                Request.token = token;

                var response = await GetData(Request, "RenovacionNormal");

                if (response != null)
                {
                    var data = JsonConvert.DeserializeObject<LiquidarRenovacionNormalResponse>(response.ToString());

                    if (data != null)
                    {
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<FormularioResponse> GetFormularioRenovacion(GetFormularioRenovacion request)
        {
            try
            {
                GetFormularioRenovacion Request = request;

                request.codigoempresa = code;
                request.usuariows = user;
                request.token = token;

                var response = await GetData(Request, "GetFormularioRenovacion");

                if (response != null)
                {
                    var data = JsonConvert.DeserializeObject<FormularioResponse>(response.ToString());

                    if (data != null && data.codigoerror == "0000")
                    {
                        return data;
                    }
                    else
                    if (data != null && data.mensajeerror != string.Empty)
                    {
                        //TODO:guardar error
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<FormularioResponse> SetFormularioRenovacion(SetFormularioRenovacion request)
        {
            try
            {
                SetFormularioRenovacion Request = request;

                request.codigoempresa = code;
                request.usuariows = user;
                request.token = token;

                var response = await GetData(Request, "SetFormularioRenovacion");

                if (response != null)
                {
                    var data = JsonConvert.DeserializeObject<FormularioResponse>(response.ToString());

                    if (data != null && data.codigoerror == "0000")
                    {
                        return data;
                    }
                    else
                    if (data != null && data.mensajeerror != string.Empty)
                    {
                        //TODO:guardar error
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<CIIUS> SearchCiuus(string reference)
        {
            try
            {
                SearchCiuu request = new SearchCiuu
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    palabras = reference
                };

                var response = await GetData(request, "SearchCiuus");

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<CIIUS>(response.ToString());

                    if (requestresponse != null && requestresponse.codigoerror == "0000")
                    {
                        return requestresponse;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<string> FirmaElectronica(FirmaElectronica firma)
        {
            try
            {
                FirmaElectronica request = new FirmaElectronica
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    idusuario = "USUPUBXX",
                    idliquidacion = firma.idliquidacion,
                    identificacioncontrol = firma.identificacioncontrol,
                    emailcontrol = firma.emailcontrol,
                    celularcontrol = firma.celularcontrol,
                    clavefirmado = firma.clavefirmado
                };

                var response = await GetData(request, "FirmaElectronica");

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<RFirmaElectronica>(response.ToString());

                    if (requestresponse != null && requestresponse.codigoerror == "0000")
                    {
                        return requestresponse.url;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return string.Empty;
        }

        public async Task<RConsultarLiquidacion> ConsultarLiquidacion(ConsultarLiquidacion cl)
        {
            try
            {
                ConsultarLiquidacion request = new ConsultarLiquidacion
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    idusuario = "USUPUBXX",
                    identificacioncontrol = cl.identificacioncontrol,
                    nombrecontrol = cl.nombrecontrol,
                    emailcontrol = cl.emailcontrol,
                    celularcontrol = cl.celularcontrol,
                    idliquidacion = cl.idliquidacion,
                    numerorecuperacion = cl.numerorecuperacion
                };

                var response = await GetData(request, "ConsultarLiquidacion");

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<RConsultarLiquidacion>(response.ToString());

                    if (requestresponse != null && requestresponse.codigoerror == "0000")
                    {
                        return requestresponse;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return null;
        }

        public async Task<RAplicarDescuento> AplicarDescuento1756(int idLiquidacion)
        {
            try
            {
                AplicarDescuento request = new AplicarDescuento
                {
                    codigoempresa = code,
                    usuariows = user,
                    token = token,
                    idliquidacion = idLiquidacion
                };

                var response = await GetData(request, "AplicarDescuento");

                if (response != null)
                {
                    var requestresponse = JsonConvert.DeserializeObject<RAplicarDescuento>(response.ToString());

                    if (requestresponse != null && requestresponse.codigoerror == "0000")
                    {
                        return requestresponse;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return null;
        }
        //END RENOVACION 
    }
}
