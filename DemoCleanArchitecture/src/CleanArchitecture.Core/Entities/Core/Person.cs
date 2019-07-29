using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Core
{
    public class Person : BaseEntity
    {
        public enum PersonGender {MALE = 0, FEMALE = 1}
        public ICollection<PersonDetail> PersonDetailCollection { get; set; }
    }
}
