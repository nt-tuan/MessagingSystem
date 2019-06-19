using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels
{
    public class TableParameter
    {
        public const int ORDER_ASC = 0;
        public const int ORDER_DESC = 1;
        public int? pageSize { get; set; } = 30;
        public int? page { get; set; } = 0;
        public string search { get; set; } = null;
        public string orderBy { get; set; } = "id";
        public int orderDirection { get; set; } = 0;

        public IDictionary<string, string> filter { get; set; } = null;
    }
}
