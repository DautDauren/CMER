using CMER.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMER.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult PlanFactView()
        {
            //ViewBag.PlanFact = id;          
             return View();
        }

        public ActionResult PlanFactErrView()
        {
            return View();
        }

        public ActionResult TestView()
        {
            return View();
        }

        public ActionResult RowView(int id)
        {
            var data = PlanFact.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult RowView(PlanFact model)
        {
            var data = PlanFact.Update(model);
            return View(data);
        }
        public ActionResult RowErrView(int id)
        {
            var data = PlanFact.GetErrByID(id);
            PlanFact_All all = new PlanFact_All();
            all.e = data;
            return View(all);
        }
 
        public JsonResult PlanFactList(int page=1, int rows=10)
        {
            try
            {
                //Get data from database
                int recCount = PlanFact.GetAllCount();               
                //List<PlanFact_Err> planfacts = PlanFact.GetErrList(param.page, param.rows);


                int pageIndex = page == 0 ? 1 : page;
                int pageSize = rows == 0 ? 10 : rows;
                int startRow = (pageIndex * pageSize) + 1;
                int totalRecords = recCount;
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
                var result = new
                {
                    total = totalPages,
                    page = pageIndex,
                    records = recCount,
                    rows = PlanFact.GetListView(pageIndex, pageSize)
                };

               
                //Return result to jTable
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public JsonResult PlanFactErrList(int page = 1, int rows = 10)
        {
            try
            {
                //Get data from database
                int recCount = PlanFact.GetAllCount();               
                //List<PlanFact_Err> planfacts = PlanFact.GetErrList(param.page, param.rows);


                int pageIndex = page == 0 ? 1 : page;
                int pageSize = rows == 0 ? 10 : rows;
                int startRow = (pageIndex * pageSize) + 1;
                int totalRecords = recCount;
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
                var result = new
                {
                    total = totalPages,
                    page = pageIndex,
                    records = recCount,
                    rows = PlanFact.GetListView(pageIndex, pageSize)
                };

               
                //Return result to jTable
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult Dic_list(string name)
        {
            var model = PlanFact.GetDicColModels(name);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDic_List(string name, int page, int rows, string q = "", int selid = 0)
        {
            List<object> data = new List<object>();

            var res = PlanFact.GetDicList(name, q, rows, page, selid);

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create()
        {
            return null;
        }
        [HttpPost]
        public JsonResult Update(PlanFact pf)
        {
            return null;
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            return null;
        }
    }
}