using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class ReceiverCategoryDetail : BaseDetailEntity
    {
        public int ReceiverCategoryId { get; set; }
        public ReceiverCategory ReceiverCategory { get; set; }
        public string Name { get; set; }
    }
}
