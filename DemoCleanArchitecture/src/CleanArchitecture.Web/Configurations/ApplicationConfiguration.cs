using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Configurations
{
    public class ApplicationConfiguration
    {
        public static ApplicationConfiguration Instance { get; set; }
        public string DateFormat { get; set; }
        public string LongDateFormat { get; set; }
    }
}
