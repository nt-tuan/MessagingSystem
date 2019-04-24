using CleanArchitecture.Core.Entities.HR;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.Articles
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public Employee CreatedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Employee LastModifiedBy { get; set; }

        
        public int? ParentId { get; set; }
        public Category Parent { get; set; }

        public int Level { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Page> Pages { get; set; }
    }
}
