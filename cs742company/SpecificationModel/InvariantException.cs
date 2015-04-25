using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class InvariantException : Exception
    {
        public InvariantException 
      (String className, String method, String beforeOrAfter) 
        {
            Console.WriteLine("\n\n Class " + className + "::" + 
                            " Method " + method + ":" +
                            " State invariant is violated " +       
                            beforeOrAfter + " this method\n\n");
        }
    }
}
