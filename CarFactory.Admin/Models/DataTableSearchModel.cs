using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarFactory.Admin.Models
{
    public class DataTableSearchModel
    {
        public int? FilterId { get; set; }

        public DateTime? FilterDateFrom { get; set; }

        public DateTime? FilterDateTo { get; set; }

        public string FilterName { get; set; }

        public bool? FilterStatus { get; set; }

        public string ActionType { get; set; }
    }
}