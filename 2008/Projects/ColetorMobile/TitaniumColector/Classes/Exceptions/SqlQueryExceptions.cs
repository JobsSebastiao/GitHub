using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TitaniumColector.Classes.Exceptions
{
    class SqlQueryExceptions :Exception 
    {

        public SqlQueryExceptions()
        {
        }

        public SqlQueryExceptions(string message)
            : base(message)
        {
        }

        public SqlQueryExceptions(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
