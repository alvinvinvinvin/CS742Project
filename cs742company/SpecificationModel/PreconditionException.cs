using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class PreconditionException : Exception
    {
        private string ClassName { get; set; }
        private string Method { get; set; }
        private string BeforeOrAfter { get; set; }
        public string MyMessage { get; set; }
        public PreconditionException (String className, String method, String message) 
        {
            ClassName = className;
            Method = method;
            MyMessage = "\n\n Class " + className + "::" + " Method " + method + ":" +
                            " Precondition for this method is violated\n " + message + "\n\n";
        }

        public string errorMessage()
        {
            return MyMessage;
        }
    }
}
