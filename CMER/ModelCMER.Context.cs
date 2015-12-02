﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CMER_DWEnt : DbContext
    {
        public CMER_DWEnt()
            : base("name=CMER_DWEnt")
        {
            this.Configuration.LazyLoadingEnabled = false;
            // Get the ObjectContext related to this DbContext
            var objectContext = (this as IObjectContextAdapter).ObjectContext;

            // Sets the command timeout for all the commands
            objectContext.CommandTimeout = 120;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dic_Certificates> Dic_Certificates { get; set; }
        public virtual DbSet<Dic_Certificates_> Dic_Certificates_ { get; set; }
        public virtual DbSet<Dic_CertificatesDetail> Dic_CertificatesDetail { get; set; }
        public virtual DbSet<Dic_CertificatesNEW> Dic_CertificatesNEW { get; set; }
        public virtual DbSet<Dic_Contragents> Dic_Contragents { get; set; }
        public virtual DbSet<Dic_ContragentsCl> Dic_ContragentsCl { get; set; }
        public virtual DbSet<Dic_Countries> Dic_Countries { get; set; }
        public virtual DbSet<Dic_Ens> Dic_Ens { get; set; }
        public virtual DbSet<Dic_Kato> Dic_Kato { get; set; }
        public virtual DbSet<Dic_Kpved> Dic_Kpved { get; set; }
        public virtual DbSet<Dic_Mkee> Dic_Mkee { get; set; }
        public virtual DbSet<Dic_Oked> Dic_Oked { get; set; }
        public virtual DbSet<Dic_Skp> Dic_Skp { get; set; }
        public virtual DbSet<Dic_Source> Dic_Source { get; set; }
        public virtual DbSet<Dic_Tnved> Dic_Tnved { get; set; }
        public virtual DbSet<Dic_TRUType> Dic_TRUType { get; set; }
        public virtual DbSet<Dic_TRUType_> Dic_TRUType_ { get; set; }
        public virtual DbSet<Dic_TypePlanFact> Dic_TypePlanFact { get; set; }
        public virtual DbSet<dimDate> dimDate { get; set; }
        public virtual DbSet<PlanFact> PlanFact { get; set; }
        public virtual DbSet<PlanFact_Err> PlanFact_Err { get; set; }
        public virtual DbSet<XLSX_CMER_Contragents> XLSX_CMER_Contragents { get; set; }
        public virtual DbSet<XLSX_CMER_Countries> XLSX_CMER_Countries { get; set; }
        public virtual DbSet<XLSX_CMER_Regions> XLSX_CMER_Regions { get; set; }
        public virtual DbSet<XLSX_CMER_Segments> XLSX_CMER_Segments { get; set; }
        public virtual DbSet<XLSX_CMER_Sources> XLSX_CMER_Sources { get; set; }
        public virtual DbSet<XLSX_CMER_Transactions> XLSX_CMER_Transactions { get; set; }
        public virtual DbSet<XLSX_CMER_TRUTypes> XLSX_CMER_TRUTypes { get; set; }
        public virtual DbSet<vwPlanFactLists> vwPlanFactLists { get; set; }
    }
}
