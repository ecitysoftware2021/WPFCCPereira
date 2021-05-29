using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public decimal activos { get; set; }
        public decimal valor { get; set; }
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

    #region "REQUEST-recuperarFormularioRenovacion"
    public class GetFormularioRenovacion
    {
        public string codigoempresa { get; set; }
        public string usuariows { get; set; }
        public string token { get; set; }
        public string idliquidacion { get; set; }
        public string numerorecuperacion { get; set; }
        public string expediente { get; set; }
    }
    #endregion 
    
    #region "REQUEST-almacenarFormularioRenovacion"
    public class SetFormularioRenovacion
    {
        public string codigoempresa { get; set; }
        public string usuariows { get; set; }
        public string token { get; set; }
        public string idliquidacion { get; set; }
        public string numerorecuperacion { get; set; }
        public string expediente { get; set; }
        public Datos datos { get; set; }
    }

    public class ArrayF : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //ArrayF(string data)
        //{

        //}

        //JsonPropertyAttribute aaa = new JsonPropertyAttribute(DateTime.Now.Year.ToString());

        //[JsonPropertyAttribute(DateTime.Now.Year.ToString())]
        //public string datos { get; set; }
        public string anodatos { get; set; }
        public string fechadatos { get; set; }
        public string personal { get; set; }
        public string personaltemp { get; set; }
        public decimal actvin { get; set; }
        public decimal actcte { get; set; }
        public decimal actnocte { get; set; }
        public decimal actfij { get; set; }
        public decimal fijnet { get; set; }
        public decimal actotr { get; set; }
        public decimal actval { get; set; }
        public decimal acttot { get; set; }
        public decimal actsinaju { get; set; }
        public decimal invent { get; set; }
        public decimal pascte { get; set; }
        public decimal paslar { get; set; }
        private decimal _pastot;
        public decimal pastot
        {
            get { return _pastot; }
            set
            {
                _pastot = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(pastot)));
            }
        }
        public decimal pattot { get; set; }
        private decimal _paspat;
        public decimal paspat
        {
            get { return _paspat; }
            set
            {
                _paspat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(paspat)));
            }
        }
        public decimal balsoc { get; set; }
        public decimal ingope { get; set; }
        public decimal ingnoope { get; set; }
        public decimal gtoven { get; set; }
        public decimal gtoadm { get; set; }
        public decimal gasope { get; set; }
        public decimal gasnoope { get; set; }
        public decimal cosven { get; set; }
        public decimal gasint { get; set; }
        public decimal gasimp { get; set; }
        public decimal depamo { get; set; }
        public decimal utiope { get; set; }
        public decimal utinet { get; set; }
    }
    #endregion

    #region "REQUEST-consultarCiius"
    public class SearchCiuu
    {
        public string codigoempresa { get; set; }
        public string usuariows { get; set; }
        public string token { get; set; }
        public string palabras { get; set; }
    }
    #endregion

    #region "REQUEST-firmarElectronicamenteTramite"
    public class FirmaElectronica
    {
        public string codigoempresa { get; set; }
        public string usuariows { get; set; }
        public string token { get; set; }
        public string idusuario { get; set; }
        public int idliquidacion { get; set; }
        public string identificacioncontrol { get; set; }
        public string emailcontrol { get; set; }
        public string celularcontrol { get; set; }
        public string clavefirmado { get; set; }
    }
    #endregion

    #region "REQUEST-consultarLiquidacion"
    public class ConsultarLiquidacion
    {
        public string codigoempresa { get; set; }
        public string usuariows { get; set; }
        public string token { get; set; }
        public string idusuario { get; set; }
        public string identificacioncontrol { get; set; }
        public string nombrecontrol { get; set; }
        public string emailcontrol { get; set; }
        public string celularcontrol { get; set; }
        public string idliquidacion { get; set; }
        public string numerorecuperacion { get; set; }
    }
    #endregion

    #region "REQUEST-aplicar1756Liquidacion"
    public class AplicarDescuento
    {
        public string codigoempresa { get; set; }
        public string usuariows { get; set; }
        public string token { get; set; }
        public int idliquidacion { get; set; }
    }
    #endregion
}
