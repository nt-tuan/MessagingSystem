using CleanArchitecture.Core.Entities.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.Exceptions.Messages
{
    class InvalidReceiverAddressException : Exception
    {
        public InvalidReceiverAddressException(string address, MessageServiceProvider provider) : base(String.Format("{0} IS NOT A VALID {1}", address, provider.AddressLabel))
        {
            
        }
    }
}
