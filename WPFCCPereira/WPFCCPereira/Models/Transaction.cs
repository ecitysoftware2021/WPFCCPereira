using System;
using System.Collections.Generic;
using System.ComponentModel;
using WPFCCPereira.Classes;
using WPFCCPereira.DataModel;
using WPFCCPereira.Services.ObjectIntegration;
using WPFCCPereira.ViewModel;

namespace WPFCCPereira.Models
{
    public class Transaction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        //BEING RENOVACION
        public ResponseIntegration ExpedientesMercantil { get; set; }

        public LiquidarRenovacionNormalResponse LiquidarRenovacionNormal{ get; set; }

        public FormularioResponse FormularioPpal { get; set; }
        
        public List<FormularioResponse> FormularioAdd { get; set; }

        public string urlFirmaElectronica { get; set; }
        public string numeroRecuperacion { get; set; }
        public string idLiquidacion { get; set; }

        public bool isRenovacion { get; set; } = false;
        //END RENOVACION

        public DetailViewModel detailViewModel { get; set; }
        public string consecutive { get; set; }

        public string reference { get; set; }

        public string Enrollment { get; set; }

        public string Tpcm { get; set; }

        public DateTime DateTransaction { get; set; }

        public PaymentViewModel Payment { get; set; }

        public bool IsReturn { get; set; }

        public ETransactionState State { get; set; }

        public string Observation { get; set; }

        public ETransactionType Type { get; set; }

        public PAYER payer { get; set; }

        public int StateNotification { get; set; }

        public List<Product> Products { get; set; }

        public object File { get; set; }

        private decimal _Amount;

        public decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
                OnPropertyRaised("Amount");
            }
        }

        private int _transactionId { get; set; }

        public int TransactionId
        {
            get
            {
                return _transactionId;
            }
            set
            {
                _transactionId = value;
                OnPropertyRaised("TransactionId");
            }
        }

        private int _idTransactionAPi { get; set; }

        public int IdTransactionAPi
        {
            get
            {
                return _idTransactionAPi;
            }
            set
            {
                _idTransactionAPi = value;
                OnPropertyRaised("IdTransactionAPi");
            }
        }
    }
}
