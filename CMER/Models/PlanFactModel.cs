using MvcGrid.Models.Grid;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CMER.Models
{
    public class PlanFactModel
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["CMER_DWEntities"].ConnectionString;

        public List<vwPlanFactLists> GetData(GridSettings grid)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
	        con.Open();
	        try
	        {
                string sql = string.Format(@"SELECT TOP {0} [IDFact] ,[DateStart] ,[DateEnd] ,[Name],[Volume] ,[Qty]
                          ,[ctgSName] ,[ctgPName]  ,[katoSName],[katoPName] ,[mkeeName] ,[kpvedName] ,[skpName] ,[countrySName] ,[countryPName] ,[truType]
                          ,[srcName] FROM [CMER_DW].[dbo].[vwPlanFactLists]",grid.PageSize);
                using (SqlCommand cmd = new SqlCommand(sql, con))
	            {
                    cmd.ExecuteNonQuery();
                    return new List<vwPlanFactLists>();
	            }
              
	        }
	        catch
	        {
                return new List<vwPlanFactLists>();
	        }
            }
        }

        public int GetCount()
        {
             using (SqlConnection con = new SqlConnection(connectionString))
            {
	        con.Open();
	        try
	        {
                string sql = "SELECT COUNT([IDFact]) FROM [CMER_DW].[dbo].[PlanFact]";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    int getValue = (int)cmd.ExecuteScalar();
                    return getValue;
                }
            }
            catch
            {
                return 1000000;
            }
            }

        }

    }
}