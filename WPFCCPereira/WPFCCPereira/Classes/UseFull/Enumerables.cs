﻿using System;
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
        Menu,
        ActiveCertificate,
        Consult2
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
    }
}
