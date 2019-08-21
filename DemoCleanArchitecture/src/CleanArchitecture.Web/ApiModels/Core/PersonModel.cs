using CleanArchitecture.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.Core
{
    public class PersonModel : BaseModel<Person>
    {
        public string identityNumber { get; set; }
        public string fullname { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string displayname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int gender { get; set; }
        public string country { get; set; }
        public PersonModel()
        {

        }

        public PersonModel(Person entity) : base(entity)
        {
            identityNumber = entity.IdentityNumber;
            fullname = entity.FullName;
            firstname = entity.FirstName;
            lastname = entity.LastName;
            displayname = entity.DisplayName;
            address = entity.Address;
            phone = entity.Phone;
            email = entity.Email;
            gender = entity.Gender;
            if(entity.Country != null)
                country = entity.Country.Name;
        }
    }
}
