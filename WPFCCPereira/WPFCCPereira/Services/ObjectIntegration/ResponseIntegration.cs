using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFCCPereira.Services.ObjectIntegration
{
    #region "RESPONSE-autenticarUsuarioVerificado"
    public class ResponseLogin
    {
        public string codigoerror { get; set; }
        public string mensajeerror { get; set; }
        public string nombreusuario { get; set; }
    }
    #endregion

    #region "RESPONSE-consultarExpedienteMercantil"
    public class ResponseIntegration
    {
        public decimal numactivos { get; set; }
        public int numempleados { get; set; }
        public string codigoerror { get; set; }
        public string mensajeerror { get; set; }
        public string matricula { get; set; }
        public string nombre { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string sigla { get; set; }
        public string idclase { get; set; }
        public string identificacion { get; set; }
        public object genero { get; set; }
        public string nit { get; set; }
        public string organizacion { get; set; }
        public string categoria { get; set; }
        public string estado { get; set; }
        public string fechamatricula { get; set; }
        public string fecharenovacion { get; set; }
        public int ultanorenovado { get; set; }
        public int anoporrenovar { get; set; }
        public string fechacancelacion { get; set; }
        public string dircom { get; set; }
        public string muncom { get; set; }
        public string telcom1 { get; set; }
        public string telcom2 { get; set; }
        public string telcom3 { get; set; }
        public string emailcom { get; set; }
        public string urlcom { get; set; }
        public string dirnot { get; set; }
        public string munnot { get; set; }
        public string telnot1 { get; set; }
        public string telnot2 { get; set; }
        public string telnot3 { get; set; }
        public string emailnot { get; set; }
        public string ciiu1 { get; set; }
        public string ciiu2 { get; set; }
        public string ciiu3 { get; set; }
        public string ciiu4 { get; set; }
        public string afiliado { get; set; }
        public int saldoafiliado { get; set; }
        public string anodatos { get; set; }
        public string fechadatos { get; set; }
        public int activos { get; set; }
        public string pasivos { get; set; }
        public string patrimonio { get; set; }
        public string ingresos { get; set; }
        public string gastos { get; set; }
        public string utilidad { get; set; }
        public int personal { get; set; }
        public string beneficio1429 { get; set; }
        public string beneficio1780 { get; set; }
        public string tamanoempresa { get; set; }
        public string fechainicioactividades { get; set; }
        public string regimentributario { get; set; }
        public string idclaserl { get; set; }
        public string identificacionrl { get; set; }
        public string nombrerl { get; set; }
        public string idclasepro { get; set; }
        public string identificacionpro { get; set; }
        public string nombrepro { get; set; }
        public string matriculapro { get; set; }
        public string camarapro { get; set; }
        public string renovacionappaltoimpacto { get; set; }
        public string renovacionappnocomercial { get; set; }
        public string renovacionapp1780 { get; set; }
        public string renovacionappmultavencida { get; set; }
        public object cantidadmujeres { get; set; }
        public object cantidadmujerescargosdirectivos { get; set; }
        public object participacionmujeres { get; set; }
        public string ciiutamanoempresarial { get; set; }
        public string ingresostamanoempresarial { get; set; }
        public string anodatostamanoempresarial { get; set; }
        public string fechadatostamanoempresarial { get; set; }
        public List<ListEstablecimientos> establecimientos { get; set; }
        public string actcte { get; set; }
        public object actnocte { get; set; }
        public string acttot { get; set; }
        public string pascte { get; set; }
        public string paslar { get; set; }
        public string pastot { get; set; }
        public string pattot { get; set; }
        public string paspat { get; set; }
        public object balsoc { get; set; }
        public string ingope { get; set; }
        public string ingnoope { get; set; }
        public object gtoven { get; set; }
        public object gtoadm { get; set; }
        public string cosven { get; set; }
        public string gasint { get; set; }
        public object gasimp { get; set; }
        public string utiope { get; set; }
        public string utinet { get; set; }
        public string actvin { get; set; }
    }

    public class ListEstablecimientos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _numempleados;

        public int numempleados
        {
            get
            {
                return _numempleados;
            }
            set
            {
                if (_numempleados != value)
                {
                    _numempleados = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(numempleados)));
                }
            }
        }

        private decimal _numactivos;
        public decimal numactivos
        {
            get
            {
                return _numactivos;
            }
            set
            {
                if (_numactivos != value)
                {
                    _numactivos = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(numactivos)));
                }
            }
        }

        private string _bdActivos = "Transparent";
        public string bdActivos
        {
            get
            {
                return _bdActivos;
            }
            set
            {
                if (_bdActivos != value)
                {
                    _bdActivos = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(bdActivos)));
                }
            }
        }

        private string _bdEmpleados = "Transparent";
        public string bdEmpleados
        {
            get
            {
                return _bdEmpleados;
            }
            set
            {
                if (_bdEmpleados != value)
                {
                    _bdEmpleados = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(bdEmpleados)));
                }
            }
        }

        private string _mserroractivos;
        public string mserroractivos
        {
            get
            {
                return _mserroractivos;
            }
            set
            {
                if (_mserroractivos != value)
                {
                    _mserroractivos = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(mserroractivos)));
                }
            }
        }

        private string _mserrorempleados;
        public string mserrorempleados
        {
            get
            {
                return _mserrorempleados;
            }
            set
            {
                if (_mserrorempleados != value)
                {
                    _mserrorempleados = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(mserrorempleados)));
                }
            }
        }
        public string categoria { get; set; }
        public string matricula { get; set; }
        public string nombre { get; set; }
        public int ultanorenovado { get; set; }
        public int anoporrenovar { get; set; }
        public string fechamatricula { get; set; }
        public string fecharenovacion { get; set; }
        public decimal valorestablecimiento { get; set; }
        public int latitud { get; set; }
        public int longitud { get; set; }
        public string fechacenso { get; set; }
        public string censo { get; set; }
        public string infografia1 { get; set; }
        public string infografia2 { get; set; }
        public bool status { get; set; } = false;
    }
    #endregion

    #region "RESPONSE-liquidarRenovacionNormal"
    public class MatriculaResponse
    {
        public string matricula { get; set; }
        public int activos { get; set; }
        public string anorenovacion { get; set; }
    }

    public class LiquidacionResponse
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

    public class LiquidarRenovacionNormalResponse
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
        public int CantMatriculas { get; set; }
        public string incluirafiliacion { get; set; }
        public string incluircertificado { get; set; }
        public string incluirformulario { get; set; }
        public string cumple1780 { get; set; }
        public string mantiene1780 { get; set; }
        public string renuncia1780 { get; set; }
        public string idliquidacion { get; set; }
        public string numerorecuperacion { get; set; }
        public List<Liquidacion> liquidacion { get; set; }
        public int valorbruto { get; set; }
        public int valorbaseiva { get; set; }
        public int valoriva { get; set; }
        public int valortotal { get; set; }
    }
    #endregion
}
