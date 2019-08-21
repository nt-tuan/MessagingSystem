using CleanArchitecture.Core.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.Core
{
    public class DistributorModel : BaseModel<Distributor>
    {
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public DistributorModel()
        {

        }

        public DistributorModel(Distributor entity) : base(entity)
        {
            code = entity.Code;
            name = entity.Name;
            address = entity.Address;
            phone = entity.Phone;
            country = entity.Country.Name;
        }
    }
}
