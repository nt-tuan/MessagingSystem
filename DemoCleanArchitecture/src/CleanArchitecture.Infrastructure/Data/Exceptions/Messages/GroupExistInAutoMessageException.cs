using CleanArchitecture.Core.Entities.SMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.Exceptions.Messages
{
    class GroupExistInAutoMessageException : Exception
    {
        public GroupExistInAutoMessageException(MessageReceiverGroup group) : base(String.Format("Group {0} ({1}) exists in an auto message config", group.Name, group.Id)){

        }
    }
}
