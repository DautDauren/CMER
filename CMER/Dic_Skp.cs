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
    
    public partial class Dic_Skp
    {
        public Dic_Skp()
        {
            this.Dic_Skp1 = new HashSet<Dic_Skp>();
            this.PlanFact = new HashSet<PlanFact>();
        }
    
        public string Label { get; set; }
        public string NameRu { get; set; }
        public string NameKz { get; set; }
        public string NameEn { get; set; }
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Unit3 { get; set; }
        public string Unit4 { get; set; }
        public Nullable<int> TypeTru { get; set; }
        public string Kpved { get; set; }
        public Nullable<int> Level { get; set; }
        public string ParentKod { get; set; }
        public int ID { get; set; }
        public Nullable<int> IDParent { get; set; }
        public Nullable<int> IDKpved { get; set; }
    
        public virtual ICollection<Dic_Skp> Dic_Skp1 { get; set; }
        public virtual Dic_Skp Dic_Skp2 { get; set; }
        public virtual ICollection<PlanFact> PlanFact { get; set; }
    }
}
