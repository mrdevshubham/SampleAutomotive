using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAutoMotive.Models
{
    public class DataTableResponse
    {
        public int draw { get; set; }
        public Int64 recordsTotal { get; set; }
        public Int64 recordsFiltered { get; set; }
        public object data { get; set; }
        public string error { get; set; }
    }
}