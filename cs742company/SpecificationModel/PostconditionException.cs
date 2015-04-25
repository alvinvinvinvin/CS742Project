using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class PostconditionException : Exception
    {
        public PostconditionException (String className, String method, String message) 
        {
            Console.WriteLine("\n\n Class " + className + "::" + " Method " + method + ":" +
                            " Postcondition for this method is violated\n " + message + "\n\n");
        }
    }
}
