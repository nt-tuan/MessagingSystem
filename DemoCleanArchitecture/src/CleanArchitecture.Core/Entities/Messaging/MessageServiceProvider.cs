using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class MessageServiceProvider : BaseDetailEntity<MessageServiceProvider>
    {
        public string Name { get; set; }

        public string AddressRegex { get; set; }

        public string AddressLabel { get; set; }

        public bool IsValidAddress(string address)
        {
            return Regex.IsMatch(address, AddressRegex);
        }
        public ICollection<ReceiverProvider> ReceiverProviders { get; set; }
    }
}
