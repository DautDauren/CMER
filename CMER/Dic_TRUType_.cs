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
    
    public partial class Dic_TRUType_
    {
        public Dic_TRUType_()
        {
            this.PlanFact = new HashSet<PlanFact>();
        }
    
        public int ID { get; set; }
        public string Descr { get; set; }
    
        public virtual ICollection<PlanFact> PlanFact { get; set; }
    }
}