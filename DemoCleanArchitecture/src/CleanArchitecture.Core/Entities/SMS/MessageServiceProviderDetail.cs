using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Core.Entities.Messaging
{
    class MessageServiceProviderDetail : BaseDetailEntity
    {
        public int MessageServiceProviderId { get; set; }
        public MessageServiceProvider MessageServiceProvider { get; set; }
        public string Name { get; set; }

        public string AddressRegex { get; set; }

        public string AddressLabel { get; set; }

        public bool IsValidAddress(string address)
        {
            return Regex.IsMatch(address, AddressRegex);
        }
    }
}
