using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace CleanArchitecture.Core
{
    public static class DatabasePopulator
    {
        public static int PopulateDatabase(ICoreRepository repos, IHostingEnvironment env)
        {
           
            return 0;
            /*
            if (todoRepository.List<ToDoItem>().Any()) return 0;

            todoRepository.Add(new ToDoItem
            {
                Title = "Get Sample Working",
                Description = "Try to get the sample to build."
            });
            todoRepository.Add(new ToDoItem
            {
                Title = "Review Solution",
                Description = "Review the different projects in the solution and how they relate to one another."
            });
            todoRepository.Add(new ToDoItem
            {
                Title = "Run and Review Tests",
                Description = "Make sure all the tests run and review what they are doing."
            });

            return todoRepository.List<ToDoItem>().Count;
            */
        }
    }
}
