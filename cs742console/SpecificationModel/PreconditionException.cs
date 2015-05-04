using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742console.SpecificationModel
{
    class PreconditionException : Exception
    {
        public PreconditionException (String className, String method, String message) 
        {
            Console.WriteLine ("\n\n Class " + className + "::" + " Method " + method + ":" +
                            " Precondition for this method is violated\n " + message + "\n\n");
        }
    }
}
