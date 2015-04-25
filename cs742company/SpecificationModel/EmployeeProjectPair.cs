using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class EmployeeProjectPair : IComparable<EmployeeProjectPair>, IComparable
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
        public int CompareTo(object that) 
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

        private Boolean equalToOtherEmployeeProjectPair(EmployeeProjectPair otherEmployeeProjectPair) 
        {
            if (this.Employee.Name.Equals(otherEmployeeProjectPair.Employee.Name) &&
                this.Project.Name.Equals(otherEmployeeProjectPair.Project.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
