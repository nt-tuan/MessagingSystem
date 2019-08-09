using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.Exceptions
{
    class EntityNotFound : Exception
    {
        public EntityNotFound(Type type, object value) : base(String.Format("ENTITY TYPE {0}:{1} NOT FOUND",type.Name,value))
        {

        }
    }
}
