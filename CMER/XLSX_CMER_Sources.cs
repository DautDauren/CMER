//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMER
{
    using System;
    using System.Collections.Generic;
    
    public partial class XLSX_CMER_Sources
    {
        public XLSX_CMER_Sources()
        {
            this.XLSX_CMER_Transactions = new HashSet<XLSX_CMER_Transactions>();
        }
    
        public int ID { get; set; }
        public string Descr { get; set; }
    
        public virtual ICollection<XLSX_CMER_Transactions> XLSX_CMER_Transactions { get; set; }
    }
}
