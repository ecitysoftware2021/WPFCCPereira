using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCCPereira.Services.ObjectIntegration
{
    #region "REQUEST-liquidarRenovacionNormal"
    public class Matricula
    {
        public string matricula { get; set; }
        public decimal activos { get; set; }
        public string anorenovacion { get; set; }
    }

    public class Liquidacion
    {
        public string servicio { get; set; }
        public string cc { get; set; }
        public string matricula { get; set; }
        public string nmatricula { get; set; }
        public object anorenovar { get; set; }
        public int cantidad { get; set; }
        public int activos { get; set; }
        public object valor { get; set; }
        public string nservicio { get; set; }
    }

    public class RequestLiquidarRenovacionNormal
    {
        public string codigoempresa { get; set; }
        public string usuariows { get; set; }
        public int personal { get; set; }
        public string token { get; set; }
        public string codigoerror { get; set; }
        public string mensajeerror { get; set; }
        public string idusuario { get; set; }
        public string emailcontrol { get; set; }
        public string celularcontrol { get; set; }
        public string nombrecontrol { get; set; }
        public string identificacioncontrol { get; set; }
        public List<Matricula> matriculas { get; set; }
        public string incluirafiliacion { get; set; }
        public string incluircertificado { get; set; }
        public string incluirformulario { get; set; }
        public string cumple1780 { get; set; }
        public string mantiene1780 { get; set; }
        public string renuncia1780 { get; set; }
        public int idliquidacion { get; set; }
        public string numerorecuperacion { get; set; }
        public List<Liquidacion> liquidacion { get; set; }
        public int valorbruto { get; set; }
        public int valorbaseiva { get; set; }
        public int valoriva { get; set; }
        public int valortotal { get; set; }
    }
    #endregion

    #region "REQUEST-consultarExpedienteMercantil"
    public class RequestFileMercantil
    {
        public string codigoempresa { get; set; }

        public string usuariows { get; set; }

        public string token { get; set; }

        public string matricula { get; set; }

        public string identificacion { get; set; }

        public string tipo { get; set; }
    }
    #endregion

    #region "REQUEST-autenticarUsuarioVerificado"
    public class RequestLogin
    {
        public string codigoempresa { get; set; }
        public string usuariows { get; set; }
        public string token { get; set; }
        public string identificacionusuario { get; set; }
        public string emailusuario { get; set; }
        public string celularusuario { get; set; }
        public string claveusuario { get; set; }
    }
    #endregion
}
