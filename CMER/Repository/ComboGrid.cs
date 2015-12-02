using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMER.Repository
{
    public class ComboGrid
    {
        public string dicname { get; set; }

        public string textField { get; set; }
        public string idField { get; set; }
        
        public List<ColModel> colModel { get; set; }
        public List<object> data { get; set; }
        public ComboGrid()
        {
            colModel = new List<ColModel>();
            data = new List<object>();
            dicname = string.Empty;
            textField = string.Empty;
            idField = string.Empty;
        }
    }
    public class ColModel
    {
        public string name { get; set; }
        public int width { get; set; }
        public string label { get; set; }
        public bool key { get; set; }

        public ColModel()
        {
            name = string.Empty;
            width = 50;
            label = string.Empty;
            key = false;
        }

    }

}