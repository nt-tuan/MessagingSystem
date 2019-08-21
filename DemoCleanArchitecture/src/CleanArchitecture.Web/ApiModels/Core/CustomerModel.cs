using CleanArchitecture.Core.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.Core
{
    public class CustomerModel : BaseModel<Customer>
    {
        public PersonModel person { get; set; }
        public BusinessModel business { get; set; }
        public string code { get; set; }
        public DistributorModel model { get; set; }
        public float? coordinateX { get; set; }
        public float? coordinateY { get; set; }
        public DistributorModel distributor { get; set; }
        public CustomerModel()
        {

        }

        public CustomerModel(Customer entity) : base(entity)
        {
            code = entity.Code;
            coordinateX = entity.CoordinateX;
            coordinateY = entity.CoordinateY;
            if(entity.Person != null)
                person = new PersonModel(entity.Person);
            if(entity.Business != null)
            business = new BusinessModel(entity.Business);
            if(entity.Distributor != null)
                distributor = new DistributorModel  (entity.Distributor);
        }
    }
}
