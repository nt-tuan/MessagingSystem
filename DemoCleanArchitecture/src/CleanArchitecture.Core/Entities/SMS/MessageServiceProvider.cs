using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class MessageServiceProvider : BaseEntity
    {
        public string Name { get; set; }

        public string AddressRegex { get; set; }

        public string AddressLabel { get; set; }

        //Meta data
        public DateTime CreatedTime { get; set; }
        public int? CreatedBy { get; set; }

        public ICollection<ReceiverProvider> ReceiverProviders { get; set; }

        public bool IsValidAddress(string address)
        {
            return Regex.IsMatch(address, AddressRegex);
        }
    }
}
