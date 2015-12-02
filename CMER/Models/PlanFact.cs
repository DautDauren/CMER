using CMER.Helpers;
using CMER.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Globalization;

namespace CMER
{
    public partial class PlanFact
    {


        public static List<PlanFact> GetList(int page, int rows)
        {
            using (var context = new CMER_DWEnt())
            {
                context.Configuration.ProxyCreationEnabled =false;
                var qr = context.PlanFact
                    .OrderBy(x => x.IDFact).Skip(rows * (page - 1))
                    .Take(rows);

               

                return qr.ToList<PlanFact>();
            }
        }
        public static List<vwPlanFactLists> GetListView(int page, int rows)
        {
            using (var context = new CMER_DWEnt())
            {
                var qr = context.vwPlanFactLists

                    .OrderBy(x => x.IDFact).Skip(rows * (page - 1))
                    .Take(rows);



                return qr.ToList<vwPlanFactLists>();
            }
        }

        public static PlanFact GetByID(int id)
        {
            using (var context = new CMER_DWEnt())
            {
                PlanFact qr = context.PlanFact.Include("Dic_Kpved").Include("Dic_Kato").Include("Dic_Kato1").Include("Dic_Kato2").Include("Dic_Kato2")
                    .Include("Dic_ContragentsCl").Include("Dic_ContragentsCl1").Include("Dic_ContragentsCl1").Include("Dic_TypePlanFact").Include("Dic_Source")
                    .SingleOrDefault(x => x.IDFact == id); //.OrderBy(x => x.DateStart).Skip(rows * (page - 1)).
                return qr;
            }
        }

        public static PlanFact Update(PlanFact model)
        {
              using (var context = new CMER_DWEnt())
              {
                  var m = context.PlanFact.SingleOrDefault(x => x.IDFact == model.IDFact);
                  if (m == null) return model;
                  m.Qty = model.Qty ?? m.Qty;
                  m.Volume = model.Volume ?? m.Volume;
                  m.IDKatoDelivery = model.IDKatoDelivery ?? m.IDKatoDelivery;
                  m.IDKatoPurchaser = model.IDKatoPurchaser ?? m.IDKatoPurchaser;
                  m.IDKatoSupplier = model.IDKatoSupplier ?? m.IDKatoSupplier;
                  m.IDMkee = model.IDMkee ?? m.IDMkee;
                  m.IDKpved = model.IDKpved ?? m.IDKpved;
                 
                  
                  //context.SaveChanges();

                  return m;
              }
        }

        public static PlanFact_Err GetErrByID(int id)
        {
            using (var context = new CMER_DWEnt())
            {
                PlanFact_Err qr = context.PlanFact_Err.SingleOrDefault(x => x.IDFact == id); //.OrderBy(x => x.DateStart).Skip(rows * (page - 1)).
                return qr;
            }
        }
        public static Object GetDicList(string Name, string search, int rows,int page, int selid)
        {
            using (var context = new CMER_DWEnt())
            {
                int skip = rows * (page - 1);
                List<object> obj = new List<object>();
                if (Name == "IDKpved")
                {
                    obj.AddRange(context.Dic_Kpved.Where(x => x.Name_1.Contains(search)).OrderBy(x => x.ID).Skip(skip).Take(rows).Select(x => new { ID = x.ID, Label = x.Label, Name_1 = x.Name_1, Name_2 = x.Name_2, Descr = x.Descr, Unioncheck = x.Unioncheck }).ToList());
                    if (selid != 0)
                    obj.Add(context.Dic_Kpved.Where(x => x.ID == selid).Select(x => new { ID = x.ID, Label = x.Label, Name_1 = x.Name_1, Name_2 = x.Name_2, Descr = x.Descr, Unioncheck = x.Unioncheck }).SingleOrDefault());
                }
                else if (Name == "IDMkee")
                {
                    obj.AddRange(context.Dic_Mkee.Where(x => x.Name_1.Contains(search)).OrderBy(x => x.ID).Skip(skip).Take(rows).Select(x => new { ID = x.ID, Label = x.Label, Name_1 = x.Name_1, Name_2 = x.Name_2 }).ToList());
                    if (selid != 0)
                    obj.Add(context.Dic_Mkee.Where(x => x.ID == selid).Select(x => new { ID = x.ID, Label = x.Label, Name_1 = x.Name_1, Name_2 = x.Name_2 }).SingleOrDefault());
                }
                else if (Name == "IDKato")
                {
                    obj.AddRange(context.Dic_Kato.Where(x => x.Name_1.Contains(search)).OrderBy(x => x.ID).Skip(skip).Take(rows).Select(x => new { ID = x.ID, Label = x.Label, Name_1 = x.Name_1, Name_2 = x.Name_2, tempParent = x.tempParent }).ToList());
                    if (selid != 0)
                    obj.Add(context.Dic_Kato.Where(x => x.ID == selid).Select(x => new { ID = x.ID, Label = x.Label, Name_1 = x.Name_1, Name_2 = x.Name_2, tempParent = x.tempParent }).SingleOrDefault());
                }
                else if (Name == "IDContragents")
                {
                    obj.AddRange(context.Dic_ContragentsCl.Where(x => x.NameRu.Contains(search)).OrderBy(x => x.ID).Skip(skip).Take(rows).Select(x => new { ID = x.ID, NameRu = x.NameRu, NameKz = x.NameKz, Phones = x.Phones, FIOLeader = x.FIOLeader }).ToList());
                    if (selid != 0)
                    obj.Add(context.Dic_ContragentsCl.Where(x => x.ID == selid).Take(rows).Select(x => new { ID = x.ID, NameRu = x.NameRu, NameKz = x.NameKz, Phones = x.Phones, FIOLeader = x.FIOLeader }).SingleOrDefault());
                }                    
                else if (Name == "IDSource")
                {
                    obj.AddRange(context.Dic_Source.Where(x => x.Name.Contains(search)).OrderBy(x => x.ID).Skip(skip).Take(rows).Select(x => new { ID = x.ID, Name = x.Name }).ToList());
                    if (selid != 0)
                    obj.Add(context.Dic_Source.Where(x => x.ID == selid).Select(x => new { ID = x.ID, Name = x.Name }).SingleOrDefault());
                }
                else if (Name == "IDTypePlanFact")
                    return context.Dic_TypePlanFact.Where(x => x.Name.Contains(search)).Take(rows).Select(x => new { ID = x.ID, Name = x.Name }).ToList();
                else if (Name == "IDSkp")
                {
                    obj.AddRange(context.Dic_Skp.Where(x => x.Label.Contains(search)).OrderBy(x => x.ID).Skip(skip).Take(rows).Select(x => new { ID = x.ID, Label = x.Label, PlanFact = x.PlanFact, Kpved = x.Kpved, NameRu = x.NameRu }).ToList());
                    if (selid != 0)
                        obj.Add(context.Dic_Skp.Where(x => x.ID == selid).Select(x => new { ID = x.ID, Label = x.Label, PlanFact = x.PlanFact, Kpved = x.Kpved, NameRu = x.NameRu }).SingleOrDefault());
                }
                else if (Name == "IDCertificates")
                    return context.Dic_Certificates.Where(x => x.Наименование_экспортера_рус.Contains(search)).Take(rows).Select(x => new { ID = x.ID, Наименование_экспортера_рус = x.Наименование_экспортера_рус, www = x.www, email = x.email }).ToList();
                else if (Name == "IDEns")
                    return context.Dic_Ens.Where(x => x.Label.Contains(search)).Take(rows).Select(x => new { ID = x.ID, Label = x.Label, Kpved = x.Kpved, Name_1 = x.Name_1 }).ToList();
                else if (Name == "IDTnved")
                    return context.Dic_Tnved.Where(x => x.Label.Contains(search)).Take(rows).Select(x => new { ID = x.ID, Label = x.Label, Name_1 = x.Name_1, Name_2 = x.Name_2, ImportDuty = x.ImportDuty }).ToList();
                else if (Name == "IDCertificatesDetail")
                    return context.Dic_CertificatesDetail.Where(x => x.Наименование_товара_рус.Contains(search)).Take(rows).Select(x => new { ID = x.ID, Наименование_товара_рус = x.Наименование_товара_рус, FilePath = x.FilePath, IDCertificate = x.IDCertificate, RowNumber = x.RowNumber }).ToList();
                else if (Name == "IDCountries")
                    return context.Dic_Countries.Where(x => x.Names.Contains(search)).Take(rows).Select(x => new { Id = x.Id, Names = x.Names, IsDeleted = x.IsDeleted, ModifiedDate = x.ModifiedDate }).ToList();
                else if (Name == "IDTRUType")
                {
                    obj.AddRange(context.Dic_TRUType.Where(x => x.Descr.Contains(search)).OrderBy(x => x.ID).Skip(skip).Take(rows).Select(x => new { ID = x.ID, Descr = x.Descr }).ToList());
                    if (selid != 0)
                        obj.Add(context.Dic_TRUType.Where(x => x.ID == selid).Select(x => new { ID = x.ID, Descr = x.Descr }).SingleOrDefault());
                }
                return obj;

            }
        }

        public static Object GetDicHead(string Name, string search)
        {
            var rows = 10;
            using (var context = new CMER_DWEnt())
            {
                List<object> obj = new List<object>();
                if (Name == "IDKpved")
                    obj.AddRange(context.Dic_Kpved.Where(x => x.Name_1.Contains(search)).Take(rows).Select(x => new { id = x.Name_1, name = x.Name_1 }).ToList());
                else if (Name == "IDMkee")
                    obj.AddRange(context.Dic_Mkee.Where(x => x.Name_1.Contains(search)).Take(rows).Select(x => new { id = x.Name_1, name = x.Name_1 }).ToList());
                else if (Name == "IDKato")
                    obj.AddRange(context.Dic_Kato.Where(x => x.Name_1.Contains(search)).Take(rows).Select(x => new { id = x.Name_1, name = x.Name_1 }).ToList());
                else if (Name == "IDContragents")
                    obj.AddRange(context.Dic_ContragentsCl.Where(x => x.NameRu.Contains(search)).Take(rows).Select(x => new { id = x.NameRu, name = x.NameRu }).ToList());
                else if (Name == "IDSource")
                    obj.AddRange(context.Dic_Source.Where(x => x.Name.Contains(search)).Take(rows).Select(x => new { id = x.Name, name = x.Name }).ToList());
                else if (Name == "IDTypePlanFact")
                    return context.Dic_TypePlanFact.Where(x => x.Name.Contains(search)).Take(rows).Select(x => new { id = x.Name, name = x.Name }).ToList();
                else if (Name == "IDSkp")
                    obj.AddRange(context.Dic_Skp.Where(x => x.Label.Contains(search)).Take(rows).Select(x => new { id = x.NameRu, name = x.NameRu }).ToList());
                else if (Name == "IDCertificates")
                    return context.Dic_Certificates.Where(x => x.Наименование_экспортера_рус.Contains(search)).Take(rows).Select(x => new { id = x.ID, name = x.Наименование_экспортера_рус }).ToList();
                else if (Name == "IDEns")
                    return context.Dic_Ens.Where(x => x.Label.Contains(search)).Take(rows).Select(x => new { id = x.Name_1, name = x.Name_1 }).ToList();
                else if (Name == "IDTnved")
                    return context.Dic_Tnved.Where(x => x.Label.Contains(search)).Take(rows).Select(x => new { id = x.Name_1, name = x.Name_1 }).ToList();
                else if (Name == "IDCertificatesDetail")
                    return context.Dic_CertificatesDetail.Where(x => x.Наименование_товара_рус.Contains(search)).Take(rows).Select(x => new { id = x.Наименование_товара_рус, name = x.Наименование_товара_рус }).ToList();
                else if (Name == "IDCountries")
                    return context.Dic_Countries.Where(x => x.Names.Contains(search)).Take(rows).Select(x => new { Id = x.Names, name = x.Names }).ToList();
                else if (Name == "IDTRUType")
                    return context.Dic_TRUType.Where(x => x.Descr.Contains(search)).Take(rows).Select(x => new { Id = x.Descr, name = x.Descr }).ToList();

                return obj;

            }
        }

        public static ComboGrid GetDicColModels(string Name)
        {
            ComboGrid Model = new ComboGrid();
            List<ColModel> col = new List<ColModel>();
            if (Name == "IDKpved")
            {
                Model.dicname = "IDKpved";
                Model.textField = "Name_1";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ИД", width = 60,  key = true });
                col.Add(new ColModel { name = "Label", label = "Метка", width = 60 });
                //col.Add(new ColModel { name = "Unioncheck", label = "Unioncheck", width = 60 });
                col.Add(new ColModel { name = "Name_1", label = "Наименование по КПВЭД", width = 60 });
                //col.Add(new ColModel { name = "Name_2", label = "Name_2", width = 60 });
                //col.Add(new ColModel { field = "IdTRUType", title = "IdTRUType", width = 60 });
                //col.Add(new ColModel { field = "Kpved_type_desc", title = "Kpved_type_desc", width = 60 });
                //col.Add(new ColModel { field = "ParentID", title = "ParentID", width = 60 });
                //col.Add(new ColModel { field = "CountSymbols", title = "CountSymbols", width = 60 });
                //col.Add(new ColModel { field = "CodeMkee", title = "CodeMkee", width = 60 });
                //col.Add(new ColModel { field = "ValueMkee", title = "ValueMkee", width = 60 });
                //col.Add(new ColModel { field = "Descr", title = "Descr", width = 60 });
                //col.Add(new ColModel { field = "StandardName", title = "StandardName", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDMkee")
            {
                Model.dicname = "IDMkee";
                Model.textField = "Name_1";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ИД", width = 60, key = true });
                col.Add(new ColModel { name = "Label", label = "Метка", width = 60 });
                col.Add(new ColModel { name = "Name_1", label = "Ед. Измерения", width = 60 });
                //col.Add(new ColModel { name = "Name_2", label = "Name_2", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDKato")
            {
                Model.dicname = "IDKato";
                Model.textField = "Name_1";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ИД", width = 60, key = true });
                col.Add(new ColModel { name = "Label", label = "Метка", width = 60 });
                col.Add(new ColModel { name = "Name_1", label = "Наименование", width = 60 });
                //col.Add(new ColModel { name = "Name_2", label = "Name_2", width = 60 });
                //col.Add(new ColModel { name = "tempParent", label = "tempParent", width = 60 });
                //col.Add(new ColModel { name = "ParentID", label = "ParentID", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDContragents")
            {
                Model.dicname = "IDContragents";
                Model.textField = "NameRu";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ИД", width = 60, key = true });
                //col.Add(new ColModel { name = "Label", label = "Метка", width = 60 });
                col.Add(new ColModel { name = "NameRu", label = "Наименование", width = 60 });
                //col.Add(new ColModel { name = "NameKz", label = "NameKz", width = 60 });
                //col.Add(new ColModel { name = "AdressJur", label = "Юр Адрес", width = 60 });
                //col.Add(new ColModel { name = "AdressFact", label = "Факт Адрес", width = 60 });
                //col.Add(new ColModel { name = "Email", label = "Email", width = 60 });
                //col.Add(new ColModel { name = "Phones", label = "Телефон", width = 60 });
                //col.Add(new ColModel { name = "IDOked", label = "IDOked", width = 60 });
                //col.Add(new ColModel { name = "ShorNameRu", label = "Кр Название", width = 60 });
                //col.Add(new ColModel { name = "ShorNameKz", label = "ShorNameKz", width = 60 });
                //col.Add(new ColModel { name = "IDCountry", label = "IDCountry", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDSource")
            {
                Model.dicname = "IDSource";
                Model.textField = "Name";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ИД", width = 60, key = true });
                col.Add(new ColModel { name = "Name", label = "Источник", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDTypePlanFact")
            {
                Model.dicname = "IDKpved";
                Model.textField = "Name";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ID", width = 60, key = true });
                col.Add(new ColModel { name = "Name", label = "Name", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDSkp")
            {
                Model.dicname = "IDSkp";
                Model.textField = "Label";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ИД", width = 60, key = true });
                col.Add(new ColModel { name = "Label", label = "Метка", width = 60 });
                col.Add(new ColModel { name = "NameRu", label = "Наименование", width = 60 });
                //col.Add(new ColModel { name = "NameKz", label = "NameKz", width = 60 });
                //col.Add(new ColModel { name = "NameEn", label = "NameEn", width = 60 });
                col.Add(new ColModel { name = "Unit1", label = "Unit1", width = 60 });
                col.Add(new ColModel { name = "Unit2", label = "Unit2", width = 60 });
                col.Add(new ColModel { name = "Unit3", label = "Unit3", width = 60 });
                col.Add(new ColModel { name = "Unit4", label = "Unit4", width = 60 });
                col.Add(new ColModel { name = "TypeTru", label = "TypeTru", width = 60 });
                col.Add(new ColModel { name = "Kpved", label = "Kpved", width = 60 });
                col.Add(new ColModel { name = "Level", label = "Level", width = 60 });
                col.Add(new ColModel { name = "ParentKod", label = "ParentKod", width = 60 });
                col.Add(new ColModel { name = "IDParent", label = "IDParent", width = 60 });
                col.Add(new ColModel { name = "IDKpved", label = "IDKpved", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDCertificates")
            {
                Model.dicname = "IDCertificates";
                Model.textField = "Наименование_экспортера_рус";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ID", width = 60, key = true });
                col.Add(new ColModel { name = "KatoRef", label = "KatoRef", width = 60 });
                col.Add(new ColModel { name = "Дата_сертификата", label = "Дата_сертификата", width = 60 });
                col.Add(new ColModel { name = "Наименование_экспортера_рус", label = "Наименование_экспортера_рус", width = 60 });
                col.Add(new ColModel { name = "Наименование_экспортера_каз", label = "Наименование_экспортера_каз", width = 60 });
                col.Add(new ColModel { name = "Адрес_экспортера_рус", label = "Адрес_экспортера_рус", width = 60 });
                col.Add(new ColModel { name = "Адрес_экспортера_каз", label = "Адрес_экспортера_каз", width = 60 });
                col.Add(new ColModel { name = "БИН_экспортера", label = "БИН_экспортера", width = 60 });
                col.Add(new ColModel { name = "КАТО", label = "КАТО", width = 60 });
                col.Add(new ColModel { name = "Организационно_правовая_форма_рус", label = "Организационно_правовая_форма_рус", width = 60 });
                col.Add(new ColModel { name = "Организационно_правовая_форма_каз", label = "Организационно_правовая_форма_каз", width = 60 });
                col.Add(new ColModel { name = "email", label = "email", width = 60 });
                col.Add(new ColModel { name = "www", label = "www", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDEns")
            {
                Model.dicname = "IDEns";
                Model.textField = "Label";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ID", width = 60, key = true });
                col.Add(new ColModel { name = "Label", label = "Label", width = 60 });
                col.Add(new ColModel { name = "TypePurchase", label = "TypePurchase", width = 60 });
                col.Add(new ColModel { name = "Kpved", label = "Kpved", width = 60 });
                col.Add(new ColModel { name = "Unioncheck", label = "Unioncheck", width = 60 });
                col.Add(new ColModel { name = "Name_1", label = "Name_1", width = 60 });
                col.Add(new ColModel { name = "Descript", label = "Descript", width = 60 });
                col.Add(new ColModel { name = "Mkee_name", label = "Mkee_name", width = 60 });
                col.Add(new ColModel { name = "Mkee_label", label = "Mkee_label", width = 60 });
                col.Add(new ColModel { name = "FileName", label = "FileName", width = 60 });
                col.Add(new ColModel { name = "SheetName", label = "SheetName", width = 60 });
                col.Add(new ColModel { name = "RowNumber", label = "RowNumber", width = 60 });
                col.Add(new ColModel { name = "ParentID", label = "ParentID", width = 60 });
                col.Add(new ColModel { name = "IDKpved", label = "IDKpved", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDTnved")
            {
                Model.dicname = "IDTnved";
                Model.textField = "Label";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ID", width = 60, key = true });
                col.Add(new ColModel { name = "Label", label = "Label", width = 60 });
                col.Add(new ColModel { name = "Unioncheck", label = "Unioncheck", width = 60 });
                col.Add(new ColModel { name = "Name_1", label = "Name_1", width = 60 });
                col.Add(new ColModel { name = "Name_2", label = "Name_2", width = 60 });
                col.Add(new ColModel { name = "Mkee", label = "Mkee", width = 60 });
                col.Add(new ColModel { name = "ImportDuty", label = "ImportDuty", width = 60 });
                col.Add(new ColModel { name = "ParentID", label = "ParentID", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDCertificatesDetail")
            {
                Model.dicname = "IDCertificatesDetail";
                Model.textField = "Наименование_товара_рус";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ID", width = 60, key = true });
                col.Add(new ColModel { name = "IDCertificate", label = "IDCertificate", width = 60 });
                col.Add(new ColModel { name = "MkeeRef", label = "MkeeRef", width = 60 });
                col.Add(new ColModel { name = "KpvedRef", label = "KpvedRef", width = 60 });
                col.Add(new ColModel { name = "TnvedRef", label = "TnvedRef", width = 60 });
                col.Add(new ColModel { name = "ТНВЭД", label = "ТНВЭД", width = 60 });
                col.Add(new ColModel { name = "КПВЭД", label = "КПВЭД", width = 60 });
                col.Add(new ColModel { name = "Упаковка", label = "Упаковка", width = 60 });
                col.Add(new ColModel { name = "Наименование_товара_рус", label = "Наименование_товара_рус", width = 60 });
                col.Add(new ColModel { name = "Наименование_товара_каз", label = "Наименование_товара_каз", width = 60 });
                col.Add(new ColModel { name = "Доля_КС__", label = "Доля_КС__", width = 60 });
                col.Add(new ColModel { name = "Вес_нетто_брутто", label = "Вес_нетто_брутто", width = 60 });
                col.Add(new ColModel { name = "Кол_во", label = "Кол_во", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDCountries")
            {
                Model.dicname = "IDCountries";
                Model.textField = "Names";
                Model.idField = "Id";
                col.Add(new ColModel { name = "Id", label = "ИД", width = 60, key = true });
                col.Add(new ColModel { name = "Code", label = "Code", width = 60 });
                //col.Add(new ColModel { name = "IsDeleted", label = "IsDeleted", width = 60 });
                col.Add(new ColModel { name = "Names", label = "Название", width = 60 });
                col.Add(new ColModel { name = "CreatedDate", label = "CreatedDate", width = 60 });
                col.Add(new ColModel { name = "ModifiedDate", label = "ModifiedDate", width = 60 });
                col.Add(new ColModel { name = "Alfa2", label = "Alfa2", width = 60 });
                col.Add(new ColModel { name = "Alfa3", label = "Alfa3", width = 60 });
                Model.colModel = col;
            }
            else if (Name == "IDTRUType")
            {
                Model.dicname = "IDTRUType";
                Model.textField = "Descr";
                Model.idField = "ID";
                col.Add(new ColModel { name = "ID", label = "ИД", width = 60, key = true });
                col.Add(new ColModel { name = "Descr", label = "Тип ТРУ", width = 60 });
                Model.colModel = col;
            }


                    return Model;

        }



        public static List<PlanFact_Err> GetErrList(int page, int rows)
        {
            using (var context = new CMER_DWEnt())
            {
               // var qr = PagingUtils.Page<PlanFact_Err>(context.PlanFact_Err, rows, page); 
                var qr = context.PlanFact_Err.OrderBy(x => x.IDFact).Skip(rows * (page - 1)).Take(rows);

                return qr.ToList<PlanFact_Err>();
            }
        }

        

        public static List<Dic_Kpved> GetKpvedList(int page, int rows)
        {
            using (var context = new CMER_DWEnt())
            {
                var qr = context.Dic_Kpved.Take(rows); //.OrderBy(x => x.DateStart).Skip(rows * (page - 1)).
                return qr.ToList<Dic_Kpved>();
            }
        }

        public static string SaveRaw(string column, int rowID, int id)
        {
            using (var context = new CMER_DWEnt())
            {
                PlanFact pf = context.PlanFact.Where(x => x.IDFact == rowID).FirstOrDefault();
                if (pf != null)
                {
                    if (column == "kpvedName")
                    pf.IDKpved = id;
                    if (column == "ctgSName")
                        pf.IDContragentSupplier = id;
                    if (column == "ctgPName")
                        pf.IDContragentPurchaser= id;
                    if (column == "katoSName")
                        pf.IDKatoSupplier = id;
                    if (column == "katoPName")
                        pf.IDKatoPurchaser = id;
                    if (column == "mkeeName")
                        pf.IDMkee = id;
                    if (column == "skpName")
                        pf.IDSkp = id;
                    if (column == "countrySName")
                        pf.IdCountrySupplier = id;
                    if (column == "countryPName")
                        pf.IdCountryPurchaser = id;
                    if (column == "truType")
                        pf.IDKpvedTRU = id;
                    if (column == "srcName")
                        pf.IDSource = id;
                    context.Entry(pf).CurrentValues.SetValues(pf);
                }
                context.SaveChanges();
                return "";
            }
        }
        public static string SaveRawDate(string column, int rowID, DateTime date)
        {
            using (var context = new CMER_DWEnt())
            {
                PlanFact pf = context.PlanFact.Where(x => x.IDFact == rowID).FirstOrDefault();
                if (pf != null)
                {
                    if (column == "DateStart")
                        pf.DateStart = date;
                    if (column == "DateEnd")
                        pf.DateEnd = date;
                    context.Entry(pf).CurrentValues.SetValues(pf);
                }
                context.SaveChanges();
                return "";
            }
        }
        public static string SaveRawValue(string column, int rowID, int value)
        {
            using (var context = new CMER_DWEnt())
            {
                PlanFact pf = context.PlanFact.Where(x => x.IDFact == rowID).FirstOrDefault();
                if (pf != null)
                {
                    if (column == "Qty")
                        pf.Qty = value;
                    if (column == "Volume")
                        pf.Volume = value;
                    context.Entry(pf).CurrentValues.SetValues(pf);
                }
                context.SaveChanges();
                return "";
            }
        }

        internal static int GetAllCount()
        {
            using (var context = new CMER_DWEnt())
            {               
                var qr = context.PlanFact.Select(p => p.IDFact).Count();
                return qr;
            }
        }

        internal static int GetAllErrCount()
        {
            using (var context = new CMER_DWEnt())
            {
                var qr = context.PlanFact_Err.Count();
                return qr;
            }
        }


    }

    public class PlanFact_All
    {
        public PlanFact r { get; set; }
        public PlanFact_Err e { get; set; }
        public List<Dic_Kpved> Dic_Kpved { get; set; }
        public List<Dic_Mkee> Dic_Mkee { get; set; }
        public List<Dic_Kato> Dic_Kato { get; set; }
        public List<Dic_ContragentsCl> Dic_ContragentsCl { get; set; }
        public List<Dic_Source> Dic_Source { get; set; }
        public List<Dic_TypePlanFact> Dic_TypePlanFact { get; set; }
        public List<Dic_Skp> Dic_Skp { get; set; }
        public List<Dic_Certificates> Dic_Certificates { get; set; }
        public List<Dic_Ens> Dic_Ens { get; set; }
        public List<Dic_Tnved> Dic_Tnved { get; set; }
        public List<Dic_CertificatesDetail> Dic_CertificatesDetail { get; set; }
        public List<Dic_Countries> Dic_Countries { get; set; }

        public PlanFact_All()
        {
            r = new PlanFact();
            e = new PlanFact_Err();
            using (var context = new CMER_DWEnt())
            {
                Dic_Kpved = context.Dic_Kpved.Take(10).ToList<Dic_Kpved>();
                Dic_Mkee = context.Dic_Mkee.Take(10).ToList<Dic_Mkee>();
                Dic_Kato = context.Dic_Kato.Take(10).ToList<Dic_Kato>();
                Dic_ContragentsCl = new List<CMER.Dic_ContragentsCl>(); //context.Dic_ContragentsCl.ToList<Dic_ContragentsCl>();
                Dic_Source = context.Dic_Source.Take(10).ToList<Dic_Source>();
                Dic_TypePlanFact = context.Dic_TypePlanFact.Take(10).ToList<Dic_TypePlanFact>();
                Dic_Skp = context.Dic_Skp.Take(10).ToList<Dic_Skp>();
                Dic_Certificates = context.Dic_Certificates.Take(10).ToList<Dic_Certificates>();
                Dic_Ens = context.Dic_Ens.Take(10).ToList<Dic_Ens>();
                Dic_Tnved = context.Dic_Tnved.Take(10).ToList<Dic_Tnved>();
                Dic_CertificatesDetail = context.Dic_CertificatesDetail.Take(10).ToList<Dic_CertificatesDetail>();
                Dic_Countries = context.Dic_Countries.Take(10).ToList<Dic_Countries>();

            }
        
        }


        public static List<PlanFact> PlanFactErrToPlanFact(List<PlanFact_Err> PFErrList)
        {
            List<PlanFact> PFList = new List<PlanFact>();

            foreach (PlanFact_Err item in PFErrList)
            {
                PlanFact PF = new PlanFact();
                PF.Name = item.Name;
                //PF.Qty = item.Qty
                PF.IDFact = item.IDFact;

            }
            return PFList;
        }         
    }

    public class JqGridViewModal
    {
        public string sidx { get; set; }
        public string sord { get; set; }
        public int page { get; set; }
        public int rows { get; set; }
        public bool _search { get; set; }
    }
}