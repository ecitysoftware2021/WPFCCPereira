//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFCCPereira.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRANSACTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRANSACTION()
        {
            this.TRANSACTION_DESCRIPTION = new HashSet<TRANSACTION_DESCRIPTION>();
        }
    
        public int ID { get; set; }
        public Nullable<int> TRANSACTION_ID { get; set; }
        public Nullable<int> PAYPAD_ID { get; set; }
        public Nullable<int> TYPE_TRANSACTION_ID { get; set; }
        public Nullable<System.DateTime> DATE_BEGIN { get; set; }
        public Nullable<System.DateTime> DATE_END { get; set; }
        public Nullable<decimal> TOTAL_AMOUNT { get; set; }
        public Nullable<decimal> INCOME_AMOUNT { get; set; }
        public Nullable<decimal> RETURN_AMOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<int> PAYER_ID { get; set; }
        public Nullable<int> STATE_TRANSACTION_ID { get; set; }
        public Nullable<int> STATE_NOTIFICATION { get; set; }
        public Nullable<bool> STATE { get; set; }
        public string TRANSACTION_REFERENCE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSACTION_DESCRIPTION> TRANSACTION_DESCRIPTION { get; set; }
    }
}
