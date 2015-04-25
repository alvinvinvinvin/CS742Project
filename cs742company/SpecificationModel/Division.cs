using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class Division
    {
        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private SortedSet<Employee> employees;

        public SortedSet<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }
        private SortedSet<Project> projects;

        public SortedSet<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }
        private Dictionary<Project, int> estimatedHours;

        public Dictionary<Project, int> EstimatedHours
        {
            get { return estimatedHours; }
            set 
            {
                Dictionary<Project, int> setTo = new Dictionary<Project, int>();
                foreach(KeyValuePair<Project, int> entry in value)
                {
                    if (entry.Value < 1)
                    {
                        throw new InvariantException(this.GetType().Name, "setEstimatedHours", "before");
                    }
                    else
                    {
                        setTo.Add(entry.Key, entry.Value);
                    }
                }
                estimatedHours = setTo;
            }
        }
        private Dictionary<Project, int> projectHours;

        public Dictionary<Project, int> ProjectHours
        {
            get { return projectHours; }
            set
            {
                Dictionary<Project, int> setTo = new Dictionary<Project, int>();
                foreach (KeyValuePair<Project, int> entry in value)
                {
                    if (entry.Value < 0)
                    {
                        throw new InvariantException(this.GetType().Name, "setProjectHours", "before");
                    }
                    else
                    {
                        setTo.Add(entry.Key, entry.Value);
                    }
                }
                projectHours = setTo;
            }
        }
        private SortedSet<EmployeeProjectPair> employeeHours;

        public SortedSet<EmployeeProjectPair> EmployeeHours
        {
            get { return employeeHours; }
            set { employeeHours = value; }
        }

        private Boolean stateInvariantCheck() 
        {
            //Boolean domOfEstimatedHoursComparation = true;
            //Boolean result = true;
            if (!this.EstimatedHours.Keys.Except(Projects).Any())
            {
                if (!this.ProjectHours.Keys.Except(Projects).Any())
                {
                    foreach(EmployeeProjectPair e in this.EmployeeHours)
                    {
                        if (this.Employees.Contains(e.Employee) &&
                            this.Projects.Contains(e.Project))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false;
                }
                else 
                {
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }

        
        /// <summary>
        /// INIT statement
        /// </summary>
        /// <param name="division_name"></param>
        public Division() { }
        public Division(String division_name) 
        {
            this.Name = division_name;
            this.Employees = null;
            this.Projects = null;
            this.EmployeeHours = null;
            this.ProjectHours = null;
            this.EmployeeHours = null;
        }

        public void AddEmployee(Employee newEmployee)
        {
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddEmployee", "before");
            if (this.Employees.Contains(newEmployee))
                throw new PreconditionException(this.GetType().Name, "AddEmployee", "New Employee is already a member of the division " + this.Name + ".");
            this.Employees.Add(newEmployee);

            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddEmployee", "after");

        }



    }
}
