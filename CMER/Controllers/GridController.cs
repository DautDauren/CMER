using MvcGrid.Models;
using MvcGrid.Models.Grid;
using MvcGrid.Models.Helpers;
using MvcGrid.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMER.Controllers
{
     //[HandleError]
    public class GridController : Controller
    {
        private IRepository _repository;

        public GridController()
        {
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
            //IRepository repository;
            //_repository = repository;
        }
        public GridController(IRepository repository)
        {
            //IRepository repository;
            _repository = repository;
        }

        public JsonResult GetDicList(string column, string search = "")
        {
            var model = PlanFact.GetDicHead(column, search);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDicModel(string column)
        {
            var model = PlanFact.GetDicColModels(column);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDicData(string Name, string search ="", int rows=20, int page=1, int selid=0)
        {
            var model = PlanFact.GetDicList(Name, search,rows,page,selid);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetData(GridSettings grid)
         {
             //GridSettings grid = new GridSettings();
            // Get the ObjectContext related to this DbContext
    //var objectContext = (this as IObjectContextAdapter).ObjectContext;
    //objectContext.CommandTimeout = 120;
            // var query = _repository.PlanFactLists();
            using (var context = new CMER_DWEnt())
            {
              var  query = context.vwPlanFactLists.AsQueryable();
            
          

             //filtring
             if (grid.IsSearch)
             {
                 if (grid.Where != null)
                 {
                     //And
                     if (grid.Where.groupOp == "AND")
                         foreach (var rule in grid.Where.rules)
                             query = query.Where<vwPlanFactLists>(
                                 rule.field, rule.data,
                                 (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op));
                     else
                     {
                         //Or
                         var temp = (new List<vwPlanFactLists>()).AsQueryable();
                         foreach (var rule in grid.Where.rules)
                         {
                             var t = query.Where<vwPlanFactLists>(
                             rule.field, rule.data,
                             (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op));
                             temp = temp.Concat<vwPlanFactLists>(t);
                         }
                         //remove repeating records
                         query = temp.Distinct<vwPlanFactLists>();
                     }
                 }
             }

             //sorting
             query = query.OrderBy<vwPlanFactLists>(grid.SortColumn,
                 grid.SortOrder);

             //count
             var count = 17862269; //query.Count();

             //paging
             var data = query.Skip((grid.PageIndex - 1) * grid.PageSize).Take(grid.PageSize).ToArray();

             //converting in grid format
             var result = new
             {
                 total = (int)Math.Ceiling((double)count / grid.PageSize),
                 page = grid.PageIndex,
                 records = count,
                 rows = (data).ToArray()
             };

             //convert to JSON and return to client
             return Json(result, JsonRequestBehavior.AllowGet);
            }
         }
        // GET: Grid

        public JsonResult PostRawCell(string column, int rowID, int id)
        {
            Object obj = new object();
            var model = PlanFact.SaveRaw(column,rowID, id);
            return Json(obj, JsonRequestBehavior.AllowGet);
        
        }

        public JsonResult PostRawCellValue(string column, int rowID, int id)
        {
            Object obj = new object();
            var model = PlanFact.SaveRawValue(column, rowID, id);
            return Json(obj, JsonRequestBehavior.AllowGet);

        }

        public JsonResult PostRawCellDate(string column, int rowID, string id)
        {
            Object obj = new object();
            DateTime dateTime = DateTime.ParseExact(id, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var model = PlanFact.SaveRawDate(column, rowID, dateTime);
            return Json(obj, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Index()
        {
            return View();
        }

    }
}