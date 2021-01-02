using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAutoMotive.Models
{
    public class DataTableRequest
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public string search { get; set; }



        public int CurrentIndex { get; set; }

    }
}