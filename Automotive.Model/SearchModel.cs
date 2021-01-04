using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automotive.Model
{
    public class SearchModel
    {
        public int currentIndex { get; set; }
        public int TotalRecordsPerPage { get; set; }
        public string searchItem { get; set; }
        public int OrderByColumn { get; set; }
        public string orderByCommand { get; set; }
        
    }
}
