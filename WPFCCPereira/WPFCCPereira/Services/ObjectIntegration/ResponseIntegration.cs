﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

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
        public string IMGgrabado { get; set; }
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
        public string idclaseName { get; set; }
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
        public decimal actnocte { get; set; }
        public string acttot { get; set; }
        public decimal pascte { get; set; }
        public decimal paslar { get; set; }
        public string pastot { get; set; }
        public decimal pattot { get; set; }
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

        public object Data { get; set; }
        public string imgGrabado { get; set; }
        public string ColorBorder { get; set; }

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

    #region "RESPONSE-recuperarFormularioRenovacion"
    public class Ciius : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string __1;
        [JsonProperty(PropertyName = "1")]
        public string _1
        {
            get { return __1; }
            set
            {
                __1 = value;
                NotifyPropertyChanged("_1");
            }
        }

        private string __2;
        [JsonProperty(PropertyName = "2")]
        public string _2
        {
            get { return __2; }
            set
            {
                __2 = value;
                NotifyPropertyChanged("_2");
            }
        }

        private string __3;
        [JsonProperty(PropertyName = "3")]
        public string _3
        {
            get { return __3; }
            set
            {
                __3 = value;
                NotifyPropertyChanged("_3");
            }
        }

        private string __4;
        [JsonProperty(PropertyName = "4")]
        public string _4
        {
            get { return __4; }
            set
            {
                __4 = value;
                NotifyPropertyChanged("_4");
            }
        }

        private string __5;
        [JsonProperty(PropertyName = "5")]
        public string _5
        {
            get { return __5; }
            set
            {
                __5 = value;
                NotifyPropertyChanged("_5");
            }
        }
    }

    public class _122
    {
        public string anodatos { get; set; }
        public string fechadatos { get; set; }
        public string personal { get; set; }
        public string personaltemp { get; set; }
        public string actvin { get; set; }
        public string actcte { get; set; }
        public string actnocte { get; set; }
        public string actfij { get; set; }
        public string fijnet { get; set; }
        public string actotr { get; set; }
        public string actval { get; set; }
        public string acttot { get; set; }
        public int actsinaju { get; set; }
        public int invent { get; set; }
        public string pascte { get; set; }
        public string paslar { get; set; }
        public string pastot { get; set; }
        public string pattot { get; set; }
        public string paspat { get; set; }
        public string balsoc { get; set; }
        public string ingope { get; set; }
        public string ingnoope { get; set; }
        public string gtoven { get; set; }
        public string gtoadm { get; set; }
        public string cosven { get; set; }
        public int depamo { get; set; }
        public string gasint { get; set; }
        public string gasimp { get; set; }
        public string utiope { get; set; }
        public string utinet { get; set; }
    }

    public class _132
    {
        public string anodatos { get; set; }
        public string fechadatos { get; set; }
        public string personal { get; set; }
        public object personaltemp { get; set; }
        public string actvin { get; set; }
        public object actcte { get; set; }
        public object actnocte { get; set; }
        public object actfij { get; set; }
        public object fijnet { get; set; }
        public object actotr { get; set; }
        public object actval { get; set; }
        public string acttot { get; set; }
        public int actsinaju { get; set; }
        public int invent { get; set; }
        public object pascte { get; set; }
        public object paslar { get; set; }
        public object pastot { get; set; }
        public string pattot { get; set; }
        public string paspat { get; set; }
        public object balsoc { get; set; }
        public object ingope { get; set; }
        public object ingnoope { get; set; }
        public object gtoven { get; set; }
        public object gtoadm { get; set; }
        public object cosven { get; set; }
        public int depamo { get; set; }
        public object gasint { get; set; }
        public object gasimp { get; set; }
        public object utiope { get; set; }
        public object utinet { get; set; }
    }

    public class _142
    {
        public string anodatos { get; set; }
        public string fechadatos { get; set; }
        public string personal { get; set; }
        public string personaltemp { get; set; }
        public string actvin { get; set; }
        public string actcte { get; set; }
        public string actnocte { get; set; }
        public string actfij { get; set; }
        public string fijnet { get; set; }
        public string actotr { get; set; }
        public string actval { get; set; }
        public string acttot { get; set; }
        public int actsinaju { get; set; }
        public int invent { get; set; }
        public string pascte { get; set; }
        public string paslar { get; set; }
        public string pastot { get; set; }
        public string pattot { get; set; }
        public string paspat { get; set; }
        public string balsoc { get; set; }
        public string ingope { get; set; }
        public string ingnoope { get; set; }
        public string gtoven { get; set; }
        public string gtoadm { get; set; }
        public string cosven { get; set; }
        public int depamo { get; set; }
        public string gasint { get; set; }
        public string gasimp { get; set; }
        public string utiope { get; set; }
        public string utinet { get; set; }
    }

    public class Datos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// ///////////////////BEGIN-DATOS-A-UTILIZAR///////////////////////
        /// </summary>
        public bool FinishFormPPal { get; set; } = false;
        public bool FinishFormAdd { get; set; } = false;
        //-------------UbicaciónYDatosGenerales------------
        public string telnot { get; set; }
        public string telnot2 { get; set; }
        public string emailnot { get; set; }
        public string barrionotnombre { get; set; }
        public string munnotnombre { get; set; }
        public string dirnot { get; set; }
        
        private string _emailcom;
        public string emailcom
        {
            get { return _emailcom; }
            set
            {
                _emailcom = value;
                NotifyPropertyChanged("emailcom");
            }
        }

        private string _muncomnombre;
        public string muncomnombre
        {
            get { return _muncomnombre; }
            set
            {
                _muncomnombre = value;
                NotifyPropertyChanged("muncomnombre");
            }
        }

        private string _barriocom;
        public string barriocom
        {
            get { return _barriocom; }
            set
            {
                _barriocom = value;
                NotifyPropertyChanged("barriocom");
            }
        }

        private string _dircom;
        public string dircom
        {
            get { return _dircom; }
            set
            {
                _dircom = value;
                NotifyPropertyChanged("dircom");
            }
        }
        private string _telcom1;
        public string telcom1
        {
            get { return _telcom1; }
            set
            {
                _telcom1 = value;
                NotifyPropertyChanged("telcom1");
            }
        }
        
        private string _telcom2;
        public string telcom2
        {
            get { return _telcom2; }
            set
            {
                _telcom2 = value;
                NotifyPropertyChanged("telcom2");
            }
        }
        public string numpredial { get; set; }
        //-------------ActividadEconomicaClasificacionCIIU------------
        public string versionciiu { get; set; }
        public string fechamatricula { get; set; }
        public string fechamatriculaAux { get; set; }
        private string _cantidadmujeres;
        public string cantidadmujeres
        {
            get { return _cantidadmujeres; }
            set
            {
                _cantidadmujeres = value;
                NotifyPropertyChanged("cantidadmujeres");
            }
        }
        public Ciius ciius { get; set; }
        public string feciniact1 { get; set; }
        public string feciniact1Aux { get; set; }
        /// <summary>
        /// ///////////////////END-DATOS-A-UTILIZAR///////////////////////
        /// </summary>
        public string matricula { get; set; }
        public string proponente { get; set; }
        public string complementorazonsocial { get; set; }
        public string nombre { get; set; }
        public string nuevonombre { get; set; }
        public string ape1 { get; set; }
        public string ape2 { get; set; }
        public string nom1 { get; set; }
        public string nom2 { get; set; }
        public string sigla { get; set; }
        public string tipoidentificacion { get; set; }
        public string identificacion { get; set; }
        public string sexo { get; set; }
        public string idmunidoc { get; set; }
        public string fechanacimiento { get; set; }
        public string fecexpdoc { get; set; }
        public string paisexpdoc { get; set; }
        public string nit { get; set; }
        public string estadonit { get; set; }
        public string admondian { get; set; }
        public string prerut { get; set; }
        public string nacionalidad { get; set; }
        public string idetripaiori { get; set; }
        public string paiori { get; set; }
        public string idetriextep { get; set; }
        public string ideext { get; set; }
        public string fecharenovacion { get; set; }
        public string fecharenovacioninscritos { get; set; }
        public string fechavencimiento { get; set; }
        public string fechavencimiento1 { get; set; }
        public string fechavencimiento2 { get; set; }
        public string fechavencimiento3 { get; set; }
        public string fechavencimiento4 { get; set; }
        public string fechavencimiento5 { get; set; }
        public string fechadisolucioncontrolbeneficios1756 { get; set; }
        public string fechareactivacioncontrolbeneficios1756 { get; set; }
        public string ultanoren { get; set; }
        public string ultanoreninscritos { get; set; }
        public string obligadorenovar { get; set; }
        public string fechaconstitucion { get; set; }
        public string fechadisolucion { get; set; }
        public string fechacancelacion { get; set; }
        public string motivocancelacion { get; set; }
        public string fechaliquidacion { get; set; }
        public string disueltaporvencimiento { get; set; }
        public string disueltaporacto510 { get; set; }
        public string fechaacto510 { get; set; }
        public string fechaacto511 { get; set; }
        public string perdidacalidadcomerciante { get; set; }
        public string fechaperdidacalidadcomerciante { get; set; }
        public string estadotipoliquidacion { get; set; }
        public string empresafamiliar { get; set; }
        public string procesosinnovacion { get; set; }
        public string certificardesde { get; set; }
        public string estadomatricula { get; set; }
        public string estadoactiva { get; set; }
        public string estadopreoperativa { get; set; }
        public string estadoconcordato { get; set; }
        public string estadointervenida { get; set; }
        public string estadodisuelta { get; set; }
        public string estadoreestructuracion { get; set; }
        public string estadodatosmatricula { get; set; }
        public string estadoproponente { get; set; }
        public string estadocapturado { get; set; }
        public string estadocapturadootros { get; set; }
        public int cantest { get; set; }
        public int codigosbarras { get; set; }
        public string pendiente_ajuste_nuevo_formato { get; set; }
        public string fecha_pendiente_ajuste_nuevo_formato { get; set; }
        public int embargos { get; set; }
        public string embargostramite { get; set; }
        public string recursostramite { get; set; }
        public string tamanoempresa { get; set; }
        public string emprendedor28 { get; set; }
        public Nullable<int> pemprendedor28 { get; set; }
        public string organizacion { get; set; }
        public string organizaciontexto { get; set; }
        public string categoria { get; set; }
        public string categoriatexto { get; set; }
        public string naturaleza { get; set; }
        public string imppredil { get; set; }
        public string impexp { get; set; }
        public string tipopropiedad { get; set; }
        public string tipolocal { get; set; }
        public string tipogruemp { get; set; }
        public string nombregruemp { get; set; }
        public string vigilanciasuperfinanciera { get; set; }
        public string vigcontrol { get; set; }
        public string fecperj { get; set; }
        public string idorigenperj { get; set; }
        public string origendocconst { get; set; }
        public string numperj { get; set; }
        public string patrimonio { get; set; }
        public string vigifecini { get; set; }
        public string vigifecfin { get; set; }
        public string clasegenesadl { get; set; }
        public string claseespesadl { get; set; }
        public string claseeconsoli { get; set; }
        public string econmixta { get; set; }
        public string ctrderpub { get; set; }
        public string ctrcodcoop { get; set; }
        public string ctrcodotras { get; set; }
        public string ctresacntasociados { get; set; }
        public string ctresacntmujeres { get; set; }
        public string ctresacnthombres { get; set; }
        public string ctresapertgremio { get; set; }
        public string ctresagremio { get; set; }
        public string ctresaacredita { get; set; }
        public string ctresaivc { get; set; }
        public string ctresainfoivc { get; set; }
        public string ctresaautregistro { get; set; }
        public string ctresaentautoriza { get; set; }
        public string ctresacodnat { get; set; }
        public string ctresadiscap { get; set; }
        public string ctresaetnia { get; set; }
        public string ctresacualetnia { get; set; }
        public string ctresadespvictreins { get; set; }
        public string ctresacualdespvictreins { get; set; }
        public string ctresaindgest { get; set; }
        public string ctresalgbti { get; set; }
        public string fecexafiliacion { get; set; }
        public string afiliado { get; set; }
        public string fechaafiliacion { get; set; }
        public string ultanorenafi { get; set; }
        public string fechaultpagoafi { get; set; }
        public string valorultpagoafi { get; set; }
        public string saldoafiliado { get; set; }
        public string telaflia { get; set; }
        public string diraflia { get; set; }
        public string munaflia { get; set; }
        public string profaflia { get; set; }
        public string contaflia { get; set; }
        public string dircontaflia { get; set; }
        public string muncontaflia { get; set; }
        public string numactaaflia { get; set; }
        public string fecactaaflia { get; set; }
        public string numactaafliacan { get; set; }
        public string fecactaafliacan { get; set; }
        public string lggr { get; set; }
        public string nombrecomercial { get; set; }
        public string dircom_tipovia { get; set; }
        public string dircom_numvia { get; set; }
        public string dircom_apevia { get; set; }
        public string dircom_orivia { get; set; }
        public string dircom_numcruce { get; set; }
        public string dircom_apecruce { get; set; }
        public string dircom_oricruce { get; set; }
        public string dircom_numplaca { get; set; }
        public string dircom_complemento { get; set; }
        public string barriocomnombre { get; set; }
        public string muncom { get; set; }
        public string paicom { get; set; }
        public string celcom { get; set; }
        public string telcomant1 { get; set; }
        public string telcomant2 { get; set; }
        public string telcomant3 { get; set; }
        public string faxcom { get; set; }
        public string aacom { get; set; }
        public string zonapostalcom { get; set; }
        public string emailcom2 { get; set; }
        public string emailcom3 { get; set; }
        public string emailcomant { get; set; }
        public string nombresegundocontacto { get; set; }
        public string cargosegundocontacto { get; set; }
        public string urlcom { get; set; }
        public string codigopostalcom { get; set; }
        public string codigozonacom { get; set; }
        public string dirnot_tipovia { get; set; }
        public string dirnot_numvia { get; set; }
        public string dirnot_apevia { get; set; }
        public string dirnot_orivia { get; set; }
        public string dirnot_numcruce { get; set; }
        public string dirnot_apecruce { get; set; }
        public string dirnot_oricruce { get; set; }
        public string dirnot_numplaca { get; set; }
        public string dirnot_complemento { get; set; }
        public string barrionot { get; set; }
        public string munnot { get; set; }
        public string painot { get; set; }
        public string telnotant1 { get; set; }
        public string telnotant2 { get; set; }
        public string telnotant3 { get; set; }
        public string celnot { get; set; }
        public string faxnot { get; set; }
        public string aanot { get; set; }
        public string zonapostalnot { get; set; }
        public string emailnotant { get; set; }
        public string urlnot { get; set; }
        public string codigopostalnot { get; set; }
        public string codigozonanot { get; set; }
        public string tiposedeadm { get; set; }
        public string latitudgrados { get; set; }
        public string latitudminutos { get; set; }
        public string latitudsegundos { get; set; }
        public string latitudorientacion { get; set; }
        public string longitudgrados { get; set; }
        public string longitudminutos { get; set; }
        public string longitudsegundos { get; set; }
        public string longitudorientacion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string dircor { get; set; }
        public string telcor { get; set; }
        public string telcor2 { get; set; }
        public string muncor { get; set; }
        public List<object> ciius3 { get; set; }
        
        private string _desactiv;
        public string desactiv
        {
            get { return _desactiv; }
            set
            {
                _desactiv = value;
                NotifyPropertyChanged("desactiv");
            }
        }
        public string feciniact2 { get; set; }
        public string feciniact2Aux { get; set; }
        public string codaduaneros { get; set; }
        public string ingesperados { get; set; }
        public string gruponiif { get; set; }
        public string niifconciliacion { get; set; }
        public string aportantesegsocial { get; set; }
        public string tipoaportantesegsocial { get; set; }
        public string cap_porcnaltot { get; set; }
        public string cap_porcnalpri { get; set; }
        public string cap_porcnalpub { get; set; }
        public string cap_porcexttot { get; set; }
        public string cap_porcextpri { get; set; }
        public string cap_porcextpub { get; set; }
        public Nullable<int> cap_apolab { get; set; }
        public Nullable<int> cap_apolabadi { get; set; }
        public Nullable<int> cap_apoact { get; set; }
        public Nullable<int> cap_apodin { get; set; }
        public Nullable<int> fecdatoscap { get; set; }
        public Nullable<int> capsoc { get; set; }
        public Nullable<int> capaut { get; set; }
        public Nullable<int> capsus { get; set; }
        public Nullable<int> cappag { get; set; }
        public Nullable<int> cuosoc { get; set; }
        public Nullable<int> cuoaut { get; set; }
        public Nullable<int> cuosus { get; set; }
        public Nullable<int> cuopag { get; set; }
        public Nullable<int> capsuc { get; set; }
        public string cantidadmujerescargosdirectivos { get; set; }
        public string participacionmujeres { get; set; }
        public string ciiutamanoempresarial { get; set; }
        public string ingresostamanoempresarial { get; set; }
        public string anodatostamanoempresarial { get; set; }
        public string fechadatostamanoempresarial { get; set; }
        public string tamanoempresarial957codigo { get; set; }
        public string tamanoempresarial957 { get; set; }
        public Nullable<decimal> tamanoempresarial957uvts { get; set; }
        public string tamanoempresarial957codigoanterior { get; set; }
        public string cntestab01 { get; set; }
        public string cntestab02 { get; set; }
        public string cntestab03 { get; set; }
        public string cntestab04 { get; set; }
        public string cntestab05 { get; set; }
        public string cntestab06 { get; set; }
        public string cntestab07 { get; set; }
        public string cntestab08 { get; set; }
        public string cntestab09 { get; set; }
        public string cntestab10 { get; set; }
        public string cntestab11 { get; set; }
        public string refcrenom1 { get; set; }
        public string refcreofi1 { get; set; }
        public string refcretel1 { get; set; }
        public string refcrenom2 { get; set; }
        public string refcreofi2 { get; set; }
        public string refcretel2 { get; set; }
        public string refcomnom1 { get; set; }
        public string refcomdir1 { get; set; }
        public string refcomtel1 { get; set; }
        public string refcomnom2 { get; set; }
        public string refcomdir2 { get; set; }
        public string refcomtel2 { get; set; }
        public string ultimosactivosreportados { get; set; }
        public string ultimosactivosvinculados { get; set; }
        public string anodatos { get; set; }
        public string fechadatos { get; set; }
        
        private string _personal;
        public string personal
        {
            get { return _personal; }
            set
            {
                _personal = value;
                NotifyPropertyChanged("personal");
            }
        }
        public string personaltemp { get; set; }
        public decimal actvin { get; set; }
        public string valest { get; set; }
        public decimal actcte { get; set; }
        public decimal actnocte { get; set; }
        public string actfij { get; set; }
        public string fijnet { get; set; }
        public string actotr { get; set; }
        public string actval { get; set; }
        public decimal acttot { get; set; }
        public int actsinaju { get; set; }
        public int invent { get; set; }
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
        public string balsoc { get; set; }
        public decimal ingope { get; set; }
        public decimal ingnoope { get; set; }
        public string gtoven { get; set; }
        public string gtoadm { get; set; }
        public decimal cosven { get; set; }
        public int depamo { get; set; }
        public string gasint { get; set; }
        public string gasimp { get; set; }
        public decimal utiope { get; set; }
        public string utinet { get; set; }
        public string apolab { get; set; }
        public string apolabadi { get; set; }
        public string apoact { get; set; }
        public string apodin { get; set; }
        public string apotra { get; set; }
        public string apotot { get; set; }
        public string anodatospatrimonio { get; set; }
        public string fechadatospatrimonio { get; set; }
        public int patrimonioesadl { get; set; }
        public string ctrmen { get; set; }
        public string ctrmennot { get; set; }
        public string ctrubi { get; set; }
        public string ctrfun { get; set; }
        public string art4 { get; set; }
        public string art7 { get; set; }
        public string art50 { get; set; }
        public string ctrcancelacion1429 { get; set; }
        public string benley1780 { get; set; }
        public string cumplerequisitos1780 { get; set; }
        public string renunciabeneficios1780 { get; set; }
        public string cumplerequisitos1780primren { get; set; }
        public string ctrbic { get; set; }
        public string ctrdepuracion1727 { get; set; }
        public string ctrfechadepuracion1727 { get; set; }
        public string ctrben658 { get; set; }
        public string fecmatant { get; set; }
        public string fecrenant { get; set; }
        public string matriculaanterior { get; set; }
        public string matant { get; set; }
        public string camant { get; set; }
        public string munant { get; set; }
        public string ultanorenant { get; set; }
        public string benart7ant { get; set; }
        public string benley1780ant { get; set; }
        public string ivcenvio { get; set; }
        public string ivcsuelos { get; set; }
        public string ivcarea { get; set; }
        public string ivcver { get; set; }
        public string ivccretip { get; set; }
        public string ivcali { get; set; }
        public string ivcqui { get; set; }
        public string ivcriesgo { get; set; }
        public string idtipoidentificacionreplegal { get; set; }
        public string identificacionreplegal { get; set; }
        public string nombrereplegal { get; set; }
        public string idtipoidentificacionadministrador { get; set; }
        public string identificacionadministrador { get; set; }
        public string nombreadministrador { get; set; }
        public string cpcodcam { get; set; }
        public string cpnummat { get; set; }
        public string cprazsoc { get; set; }
        public string cpnumnit { get; set; }
        public string cpdircom { get; set; }
        public string cpdirnot { get; set; }
        public string cpnumtel { get; set; }
        public string cpnumtel2 { get; set; }
        public string cpnumtel3 { get; set; }
        public string cpnumfax { get; set; }
        public string cpcodmun { get; set; }
        public string cpmunnot { get; set; }
        public string datconst_fecdoc { get; set; }
        public string datconst_tipdoc { get; set; }
        public string datconst_numdoc { get; set; }
        public string datconst_oridoc { get; set; }
        public string datconst_mundoc { get; set; }
        //public List<object> bienes { get; set; }
        public string existenvinculos { get; set; }
        //public List<object> replegal { get; set; }
        //public List<object> vinculos { get; set; }
        //public List<object> vinculosh { get; set; }
        //public List<object> vincuprop { get; set; }
        //public List<object> propietarios { get; set; }
        //public List<object> propietariosh { get; set; }
        //public List<object> sucursalesagencias { get; set; }
        //public List<object> establecimientosarrendados { get; set; }
        //public List<object> establecimientosnacionales { get; set; }
        //public List<object> rr { get; set; }
        //public List<object> lcodigosbarras { get; set; }
        //public List<object> capitales { get; set; }
        //public List<object> patrimoniosesadl { get; set; }
        //public List<object> ctrembargos { get; set; }
        public List<ArrayF> f { get; set; }
        public string placaalcaldia { get; set; }
        public string placaalcaldiafecha { get; set; }
        public string reportealcaldia { get; set; }
        public string hashcontrol { get; set; }
        public string hashcontrolnuevo { get; set; }
    }

    public class FormularioResponse
    {
        public string codigoerror { get; set; }
        public string mensajeerror { get; set; }
        public string idliquidacion { get; set; }
        public string numerorecuperacion { get; set; }
        public string expediente { get; set; }
        public Datos datos { get; set; }
    }

    #endregion

    #region "RESPONSE-consultarCiius"
    public class Renglone
    {
        public bool expanded { get; set; }
        public string ciiu { get; set; }
        public string descripcion { get; set; }
        public string detalle { get; set; }
        public string incluye { get; set; }
        public string excluye { get; set; }
        public object restriccionponal { get; set; }
        public string actividadcomercial { get; set; }
        public string extraData { get; set; }
        public string title1 { get; set; }
        public string title2 { get; set; }
        public string title3 { get; set; }
    }

    public class CIIUS
    {
        public string codigoerror { get; set; }
        public string mensajeerror { get; set; }
        public string palabras { get; set; }
        public List<Renglone> renglones { get; set; }
    }
    #endregion

    #region "RESPONSE-firmarElectronicamenteTramite"
    public class RFirmaElectronica
    {
        public string codigoerror { get; set; }
        public string mensajeerror { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region "RESPONSE-consultarLiquidacion"
    public class Liquidaciondetalle
    {
        public string secuencia { get; set; }
        public string idsec { get; set; }
        public string idservicio { get; set; }
        public string txtservicio { get; set; }
        public string cc { get; set; }
        public string expediente { get; set; }
        public string nombre { get; set; }
        public string ano { get; set; }
        public string cantidad { get; set; }
        public string valorbase { get; set; }
        public string porcentaje { get; set; }
        public string valorservicio { get; set; }
        public string benart7 { get; set; }
        public string benley1780 { get; set; }
        public string reliquidacion { get; set; }
        public string serviciobase { get; set; }
        public string pagoafiliacion { get; set; }
        public string ir { get; set; }
        public string iva { get; set; }
        public string idalerta { get; set; }
        public string expedienteafiliado { get; set; }
        public string porcentajeiva { get; set; }
        public string valoriva { get; set; }
        public string servicioiva { get; set; }
        public string porcentajedescuento { get; set; }
        public string valordescuento { get; set; }
        public string serviciodescuento { get; set; }
        public string clavecontrol { get; set; }
    }

    public class RConsultarLiquidacion
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
        public string fecha { get; set; }
        public string hora { get; set; }
        public string tipotramite { get; set; }
        public string subtipotramite { get; set; }
        public string idestado { get; set; }
        public string matricula { get; set; }
        public string proponente { get; set; }
        public string tipoidentificacion { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string valor { get; set; }
        public string recibo { get; set; }
        public string fecharecibo { get; set; }
        public string horarecibo { get; set; }
        public string radicacion { get; set; }
        public string operacion { get; set; }
        public List<Liquidaciondetalle> liquidaciondetalle { get; set; }
    }
    #endregion

    #region "RESPONSE-aplicar1756Liquidacion"
    public class RAplicarDescuento
    {
        public string codigoerror { get; set; }
        public string mensajeerror { get; set; }
        public decimal descuentoaplicado { get; set; }
    }
    #endregion
}
