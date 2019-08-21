using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels
{
    public class BaseModel<T> where T:BaseDetailEntity<T>
    {
        public int id { get; set; }
        public BaseModel()
        {

        }

        public BaseModel(BaseDetailEntity<T> entity)
        {
            if (entity.OriginId == null)
                id = entity.Id;
            else
                id = entity.OriginId.Value;
        }
    }
}
