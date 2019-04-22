using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class MessageServiceProvider : BaseEntity
    {
        public string Name { get; set; }

        //Meta data
        public DateTime CreatedTime { get; set; }
        public int? CreatedBy { get; set; }
    }
}
