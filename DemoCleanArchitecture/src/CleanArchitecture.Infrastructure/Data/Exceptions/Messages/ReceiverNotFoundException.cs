using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.Exceptions.Messages
{
    class ReceiverNotFoundException : Exception
    {
        public ReceiverNotFoundException() : base("MESSAGE RECEIVER NOT FOUND")
        {

        }
    }
}
