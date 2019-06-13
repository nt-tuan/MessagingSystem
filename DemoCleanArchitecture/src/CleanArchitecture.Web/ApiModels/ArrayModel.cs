using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels
{
    public class IntCollectionModel
    {
        public ICollection<int> collection { get; set; } = new List<int>();
    }
}
