using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class InvariantException : Exception
    {
        private string ClassName {get;set;}
        private string Method {get;set;}
        private string BeforeOrAfter { get; set; }
        public string message { get; set; }
        public InvariantException 
      (String className, String method, String beforeOrAfter) 
        {
            ClassName = className;
            Method = method;
            BeforeOrAfter = beforeOrAfter;
            message = "\n\n Class " + className + "::" +
                            " Method " + method + ":" +
                            " State invariant is violated " +
                            beforeOrAfter + " this method\n\n";
        }

        public string erroMessage()
        {
            return message;
        }
    }
}
