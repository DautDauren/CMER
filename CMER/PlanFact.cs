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
    
    public partial class PlanFact
    {
        public int IDFact { get; set; }
        public Nullable<int> IDKpved { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public Nullable<int> IDMkee { get; set; }
        public Nullable<int> IDKatoPurchaser { get; set; }
        public Nullable<int> IDKatoSupplier { get; set; }
        public Nullable<int> IDKatoDelivery { get; set; }
        public int IDContragentPurchaser { get; set; }
        public Nullable<int> IDContragentSupplier { get; set; }
        public int IDSource { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public string Name { get; set; }
        public int IDTypePlanFact { get; set; }
        public Nullable<int> IDSkp { get; set; }
        public Nullable<double> KS { get; set; }
        public Nullable<int> IDCertificate { get; set; }
        public string NumCertificate { get; set; }
        public Nullable<int> IDEns { get; set; }
        public Nullable<int> IDTnved { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string FilePath { get; set; }
        public Nullable<int> RowNumber { get; set; }
        public string SerialCertificate { get; set; }
        public Nullable<int> OtpLastYear { get; set; }
        public Nullable<int> IDCertificateDetail { get; set; }
        public Nullable<System.DateTime> DateReportStart { get; set; }
        public Nullable<int> IssetInSource { get; set; }
        public Nullable<System.DateTime> DateReportEnd { get; set; }
        public string ContractNumber { get; set; }
        public Nullable<int> IdCountrySupplier { get; set; }
        public Nullable<int> IdCountryPurchaser { get; set; }
        public Nullable<decimal> VolumeWNds { get; set; }
        public Nullable<decimal> Nds { get; set; }
        public Nullable<int> IDFactErr { get; set; }
        public Nullable<int> IDKpvedTRU { get; set; }
        public Nullable<decimal> KSSum { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorColumn { get; set; }
        public string ValueMkee { get; set; }
        public string ValueKatoDelivery { get; set; }
        public string ValueKatoPurchaser { get; set; }
        public string ValueKatoSupplier { get; set; }
        public string ValueCountrySupplier { get; set; }
        public string ValueCountryPurchaser { get; set; }
        public string ValueKpved { get; set; }
        public string ValueTnved { get; set; }
        public string ValueSkp { get; set; }
        public string ValueVolume { get; set; }
        public string ValueQty { get; set; }
        public string ValueDateStart { get; set; }
        public string ValueDateEnd { get; set; }
        public Nullable<int> IdOriginal { get; set; }
        public string TableName { get; set; }
        public Nullable<bool> IsError { get; set; }
    
        public virtual Dic_Certificates Dic_Certificates { get; set; }
        public virtual Dic_ContragentsCl Dic_ContragentsCl { get; set; }
        public virtual Dic_ContragentsCl Dic_ContragentsCl1 { get; set; }
        public virtual Dic_Countries Dic_Countries { get; set; }
        public virtual Dic_Countries Dic_Countries1 { get; set; }
        public virtual Dic_Ens Dic_Ens { get; set; }
        public virtual Dic_Kato Dic_Kato { get; set; }
        public virtual Dic_Kato Dic_Kato1 { get; set; }
        public virtual Dic_Kato Dic_Kato2 { get; set; }
        public virtual Dic_Kpved Dic_Kpved { get; set; }
        public virtual Dic_Mkee Dic_Mkee { get; set; }
        public virtual Dic_Skp Dic_Skp { get; set; }
        public virtual Dic_Source Dic_Source { get; set; }
        public virtual Dic_TRUType_ Dic_TRUType_ { get; set; }
        public virtual Dic_TypePlanFact Dic_TypePlanFact { get; set; }
        public virtual dimDate dimDate { get; set; }
        public virtual dimDate dimDate1 { get; set; }
        public virtual dimDate dimDate2 { get; set; }
        public virtual dimDate dimDate3 { get; set; }
    }
}
