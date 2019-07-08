using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.Exceptions.Messages
{
    class ProviderNotFoundException : Exception
    {
        public ProviderNotFoundException() : base("MESSAGE SERVICE PROVIDER NOT FOUND")
        {

        }
    }
}
