using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCCPereira.Classes
{
    public enum ELogType
    {
        General = 0,
        Error = 1,
        Device = 2
    }

    public enum EModalType
    {
        Cancell = 0,
        NotExistAccount = 1,
        Error = 2,
        MaxAmount = 3,
        Information = 4,
        Preload = 5,
        NoPaper = 6
    }

    public enum EError
    {
        Printer = 1,
        Nopapper = 2,
        Device = 3,
        Aplication = 5,
        Api = 6,
        Customer = 7,
        Internet = 8
    }

    public enum ELevelError
    {
        Mild = 3,
        Medium = 2,
        Strong = 1,
    }

    public enum EOrganizacion
    {
        Persona_Natural = 01,
        Establecimiento_de_Comercio = 02,
        Sociedad_Limitada = 03,
        Sociedad_Anonima = 04,
        Sociedad_Colectiva = 05,
        Sociedad_Comandita_Simple = 06,
        Sociedad_Comandita_por_Acciones = 07,
        Sociedad_Extranjera = 08,
        Empresa_Asociativa_de_Trabajo = 09,
        Sociedad_Civil = 10,
        Empresa_Unipersonal = 11,
        Entidad_Sin_Animo_de_Lucro = 12,
        Entidad_de_Economia_Solidaria = 14,
        Empresa_Industrial_y_Comercial_del_Estado = 15,
        Sociedad_por_Acciones_Simplificada = 16,
        Agrarias_de_transformacion = 17,
        OtrasPersonasJuridicas = 99
    }

    public enum ETypeIdentification
    {
        Cedula_de_ciudadania = 1,
        NIT = 2,
        Cedula_de_extranjeria = 3,
        Tarjeta_de_identidad = 4,
        Pasaporte = 5,
        Personeria_juridica = 6,
        Documento_extranjero = 7,
        Registro_Civil = 8,
    }

    public enum UserControlView
    {
        Main,
        Consult,
        PaySuccess,
        Pay,
        Payer,
        ReturnMony,
        Login,
        Config,
        Admin,
        Certificates,
        PrintFile,
        CardPay,
        Menu,
        //Begin-Renovacion
        LoginUser,
        ConsultRenovacion,
        ActiveCertificate,
        MenuRenovacion,
        ListEstablecimientos,
        DigitalSignature,
            //begin-formsPpal
            Ppal_Identificacion,
            Ppal_UbicacionDatosGenerales,
            Ppal_ActividadEconomica,
            Ppal_InformacionFinanciera,
            Ppal_SistemaSeguridad,
            //end---formsPpal
            //begin-formsAdd
            Add_Identificacion,
            Add_UbicacionDatosGenerales,
            Add_ActividadEconomica,
            Add_InformacionFinanciera,
            Add_SistemaSeguridad,
            //end---formsAdd
        //End-Renovacion
    }

    public enum ETransactionState
    {
        Initial = 1,
        Success = 2,
        CancelError = 6,
        Cancel = 3,
        Error = 5,
        ErrorService = 4
    }

    public enum ETypePay
    {
        Card = 1,
        Cash = 2
    }

    public enum ETransactionType
    {
        Withdrawal = 15,
        PaymentFile = 3,
        ConsultName = 1,
        ConsultTransact = 2,
        Renewal = 4,
        Renovacion = 31,
    }

    public enum ETypeAdministrator
    {
        Balancing = 1,
        Upload = 2,
        Finished = 3,
        ReUploat = 4
    }

    public enum EtypeConsult
    {
        Id = 2,
        Name = 1,
        Settled = 3,
        Receipt = 4,
        Matricula = 5
    }

    public enum EtypeOperation
    {
        Sum = 1,
        Subtract = 2
    }

    public enum ETypeCertificate
    {
        Merchant = 1,
        Establishment = 2
    }

    public enum ETypePayer
    {
        Person = 1,
        Establishment = 2
    }

    public enum ETypeProduct
    {
        Existence = 11,
        commercialRegister = 12,
        renovacion = 31
    }
    
    public enum ETypeEstados
    {
        Radicado = 1,
        Asignado_a_estudio = 4,
        Devuelto = 5,
        Entregado_al_usuario = 6,
        Reingresado = 9,
        Inscrito = 11,
        Enviado_a_archivo = 15,
        Archivado = 16,
        En_digitacion = 23,
        En_proceso_de_firma = 34,
        En_control_de_calidad = 38,
        Desistido = 39,
        Anulado = 99,
    }
}
