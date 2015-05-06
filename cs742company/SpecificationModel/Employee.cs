using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    public class Employee : System.Object, IComparable
    {

		public NAME Name {
			get;
			set;
		}

        public Employee(String name) 
        {
			this.Name = new NAME(name);
        }

        int IComparable.CompareTo(System.Object that)
        {
            if (that == null) return 1;
            Employee otherEmployee = that as Employee;
            if (otherEmployee != null)
            {
                return this.Name.getNAME().CompareTo(otherEmployee.Name.getNAME());
            }
            else
            {
                throw new ArgumentException("Object is not an Employee");
            }
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Employee return false.
            Employee e = obj as Employee;
            if ((System.Object)e == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this.Name.getNAME() == e.Name.getNAME();
        }

        /// <summary>
        /// Also have to override gethashcode method to ensure object itself is unique
        /// during comparison.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Name.getNAME().GetHashCode();
        }

    }
}
