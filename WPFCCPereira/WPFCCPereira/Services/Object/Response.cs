using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCCPereira.Services.Object
{
    public class Response
    {
        public string codigoerror { get; set; }

        public string mensajeerror { get; set; }
        public decimal descuentoaplicado { get; set; }

        public string token { get; set; }

        public string idliquidacion { get; set; }

        public string numerorecuperacion { get; set; }

        public string numerorecibo { get; set; }

        public object expedientes { get; set; }

        public string numerooperacion { get; set; }

        public string radicacion { get; set; }

        public List<UrlCertificates> certificados { get; set; }

        public string claveusuario { get; set; }

        public string nombres { get; set; }

        public string apellido1 { get; set; }

        public string apellido2 { get; set; }
    }

    public class Noun
    {
        public string mensajeerror { get; set; }

        public string matricula { get; set; }

        public string proponente { get; set; }

        public string nombre { get; set; }

        public string sigla { get; set; }

        public string idclase { get; set; }

        public string identificacion { get; set; }

        public string nit { get; set; }

        public string organizacion { get; set; }

        public string organizaciontextual { get; set; }

        public string categoria { get; set; }

        public string categoriatextual { get; set; }

        public string estadomatricula { get; set; }

        public string estadoproponente { get; set; }

        public string fechamatricula { get; set; }

        public string fecharenovacion { get; set; }

        public string ultanorenovado { get; set; }

        public string afiliado { get; set; }

        public string afiliadotextual { get; set; }

        public decimal saldoafiliado { get; set; }

        public string embargos { get; set; }

        public string direccion { get; set; }

        public string municipio { get; set; }

        public string municipiotextual { get; set; }

        public List<Plant> establecimientos { get; set; }

        public List<Certificates> certificados { get; set; }
    }

    public class Certificates
    {
        public string tipocertificado { get; set; }

        public string descripciontipocertificado { get; set; }

        public string descripcioncertificado { get; set; }

        public string servicio { get; set; }

        public decimal valor { get; set; }

        public string img { get; set; }
    }

    public class UrlCertificates
    {
        public string codigoverificacion { get; set; }

        public string tipocertificado { get; set; }

        public string path { get; set; }

        public int copia { get; set; }
    }

    public class Plant
    {
        public string categoría { get; set; }

        public string matricula { get; set; }

        public string nombre { get; set; }

        public string ultanorenovado { get; set; }

        public string fechamatricula { get; set; }

        public string fecharenovacion { get; set; }

        public decimal valorestablecimiento { get; set; }
    }

    public class ResponseTransact
    {
        public string codigoerror { get; set; }

        public string mensajeerror { get; set; }

        public string radicado { get; set; }

        public string tipotramite { get; set; }

        public string operacion { get; set; }

        public string recibo { get; set; }

        public object fecharadicacion { get; set; }

        public string matricula { get; set; }

        public string proponente { get; set; }

        public string idclase { get; set; }

        public string identificacion { get; set; }

        public string nombres { get; set; }

        public string estadofinal { get; set; }

        public string usuariofinal { get; set; }

        public string fechaestadofinal { get; set; }

        public string horaestadofinal { get; set; }

        public string sucursalfinal { get; set; }

        public string actoreparto { get; set; }

        public string tipodoc { get; set; }

        public string numerodoc { get; set; }

        public string origendoc { get; set; }

        public string fechadoc { get; set; }

        public string municipiodoc { get; set; }

        public List<TransactState> estados { get; set; }


        public string fecha { get; set; }

        public string hora { get; set; }

        public string factura { get; set; }

        public string rutasii { get; set; }

        public string usuario { get; set; }

        public string tipogasto { get; set; }

        public string nombre { get; set; }

        public string direccion { get; set; }

        public string municipio { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public string tiporegistro { get; set; }

        public int valorneto { get; set; }

    }

    public class TransactState 
    {
        public string fecha { get; set; }

        public string hora { get; set; }

        public string estado { get; set; }

        public string usuariofinal { get; set; }
    }


    public class ResponseLiquidateRenewal
    {
        public string codigoerror { get; set; }

        public string mensajeerror { get; set; }

        public string idusuario { get; set; }

        public string identificacioncontrol { get; set; }

        public string nombrecontrol { get; set; }

        public string emailcontrol { get; set; }

        public string celularcontrol { get; set; }

        public string idliquidacion { get; set; }

        public string numerorecuperacion { get; set; }

        public int valorbruto { get; set; }

        public int valorbaseiva { get; set; }

        public int valoriva { get; set; }

        public int valortotal { get; set; }
    }
}
