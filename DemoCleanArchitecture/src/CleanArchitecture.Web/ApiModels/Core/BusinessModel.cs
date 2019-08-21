using CleanArchitecture.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.Core
{
    public class BusinessModel : BaseModel<Business>
    {        
        public string fullname { get; set; }
        public string shortname { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string taxNumber { get; set; }
        public string country { get; set; }
        public string code { get; set; }
        public BusinessModel()
        {

        }

        public BusinessModel(Business entity) : base(entity)
        {
            fullname = entity.FullName;
            shortname = entity.ShortName;
            address = entity.Address;
            email = entity.Email;
            phone = entity.Phone;
            taxNumber = entity.TaxNumber;
        }
    }
}
