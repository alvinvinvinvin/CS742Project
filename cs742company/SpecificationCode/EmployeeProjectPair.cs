using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationCode
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
        /// I have to generate new objects here and pass them to properties
        /// because of language requirement. If I didn't, I cannot generate
        /// a new object which only contains name to directly use it to
        /// search or comparing with other object in Company class's methods.
        /// </summary>
        public EmployeeProjectPair() 
        {
            this.HoursSpent = 0;
            Employee = new Employee("");
            Project = new Project("");
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
            return this.Employee.Name.getNAME() == epp.Employee.Name.getNAME() &&
                this.Project.Name.getNAME() == epp.Project.Name.getNAME();
        }


        /// <summary>
        /// Also have to override gethashcode method to ensure object itself is unique
        /// during comparison. The difference here is I used caret('^') to get the 
        /// bitwise exclusive-OR of its operands, therefore it will ensure two objects are
        /// unique by both employee name hash code and project name hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Employee.Name.getNAME().GetHashCode() ^ this.Project.Name.getNAME().GetHashCode();
        }
    }
}
