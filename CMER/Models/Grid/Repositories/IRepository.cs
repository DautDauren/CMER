using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcGrid.Models.Entities;
using CMER;

namespace MvcGrid.Models
{
    public interface IRepository
    {
        IQueryable<vwPlanFactLists> PlanFactLists();
    }
}