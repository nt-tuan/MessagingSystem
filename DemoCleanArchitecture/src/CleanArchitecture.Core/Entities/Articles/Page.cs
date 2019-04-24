using CleanArchitecture.Core.Entities.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.Articles
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedTime { get; set; }
        
        public Employee CreatedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public Employee LastModifiedBy { get; set; }
    }
}
