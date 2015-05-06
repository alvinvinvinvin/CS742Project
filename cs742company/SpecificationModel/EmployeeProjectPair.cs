using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    public class EmployeeProjectPair : System.Object, IComparable
    {
        private Employee employee;

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }
        private Project project;

        public Project Project
        {
            get { return project; }
            set { project = value; }
        }
        private int hoursSpent;

        public int HoursSpent
        {
            get { return hoursSpent; }
            set 
            {
                if (value >= 0)
                {
                    hoursSpent = value;
                }
                else
                {
                    throw new InvariantException(this.GetType().Name, "setHoursSpent", "before");
                }
            }
        }

        /// <summary>
        ///  INIT
        /// </summary>
        public EmployeeProjectPair() 
        {
            this.HoursSpent = 0;
        }

        public EmployeeProjectPair(Employee employee, Project project, int hoursSpent)
        {
            this.Employee = employee;
            this.Project = project;
            this.HoursSpent = hoursSpent;
        }

        /// <summary>
        ///  compareTo method
        /// </summary>
        int IComparable.CompareTo(System.Object that) 
        {
            if (that == null) return 1;
            EmployeeProjectPair otherEmployeeProjectPair = that as EmployeeProjectPair;
            if (otherEmployeeProjectPair != null)
            {
                return this.HoursSpent.CompareTo(otherEmployeeProjectPair.HoursSpent);
            }
            else
            {
                throw new ArgumentException("Object is not a EmployeeProjectPair");
            }
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to EmployeeProjectPair return false.
            EmployeeProjectPair epp = obj as EmployeeProjectPair;
            if ((System.Object)epp == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this.Employee.Name == epp.Employee.Name &&
                this.Project.Name == epp.Project.Name;
        }

        public override int GetHashCode()
        {
            return this.Employee.Name.GetHashCode() ^ this.Project.Name.GetHashCode();
        }
    }
}
