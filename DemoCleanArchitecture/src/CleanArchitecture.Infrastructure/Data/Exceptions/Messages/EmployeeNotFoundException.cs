using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.Exceptions.Messages
{
    class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(int id) : base("EMPLOYEE NOT FOUND")
        {

        }
    }
}
