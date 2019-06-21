using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message)
        {

        }
    }
}
