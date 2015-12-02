using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcGrid.Models.Entities;
using CMER;

namespace MvcGrid.Models.Repositories
{
    public class PlanFactRepository : IRepository
    {
        #region IRepository<vwPlanFactLists> PlanFact

        public IQueryable<vwPlanFactLists> PlanFactLists()
        {
            //For NHibernate with Linq:
            // var query = Session.Linq<Computer>().AsQueryable();
            using (var context = new CMER_DWEnt())
            {
                return context.vwPlanFactLists.AsQueryable();
            }

            //return new List<vwPlanFactLists>()
            //{
            //    new vwPlanFactLists(),
            //    new vwPlanFactLists(),
            //    new vwPlanFactLists(),
            //    new vwPlanFactLists()
            //}.AsQueryable();
        }

        #endregion
    }
}