using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMER.Views.Main
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult PlanFactList(int page = 1, int rows = 10, string filters = "")
        {
            try
            {
                //Get data from database
                int recCount = 17862269; //PlanFact.GetAllCount();
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


        public JsonResult GetDicTable(string column, string search = "")
        {
            var result = new object();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}