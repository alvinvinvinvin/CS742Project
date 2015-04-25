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

        private HashSet<Employee> employees;

        public HashSet<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }
        private HashSet<Project> projects;

        public HashSet<Project> Projects
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
        private HashSet<EmployeeProjectPair> employeeHours;

        public HashSet<EmployeeProjectPair> EmployeeHours
        {
            get { return employeeHours; }
            set { employeeHours = value; }
        }

        private Boolean stateInvariantCheck() 
        {
            //Boolean domOfEstimatedHoursComparation = true;
            //Boolean result = true;
            if (this.EstimatedHours.Keys.Equals(this.Projects))
            {
                if (this.ProjectHours.Keys.Equals(this.Projects))
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
            if (this.Employees.Any(e => e.Name.Equals(newEmployee.Name)))
                throw new PreconditionException(this.GetType().Name, "AddEmployee", "New Employee is already a member of the division " + this.Name + ".");
            this.Employees.Add(newEmployee);

            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddEmployee", "after");

        }

        public void RemoveEmployee(Employee employee) 
        {
            Boolean resultOfRemoveFromEmployees;
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "RemoveEmployee", "before");
            if (this.Employees.Any(e => e.Name.Equals(employee.Name)))
                throw new PreconditionException(this.GetType().Name, "RemoveEmployee", "Employee is not a member of the division " + this.Name + ".");

            resultOfRemoveFromEmployees = this.Employees.Remove(employee);
            this.EmployeeHours.ExceptWith(this.EmployeeHours.Where(eh => eh.Employee.Equals(employee)));

            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "RemoveEmployee", "after");
            //result = this.EmployeeHours.Remove(employee);
        }

        public void AddProject(Project newProject, int estimated) 
        {
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "before");
            if(estimated < 1)
                throw new PreconditionException(this.GetType().Name, "RemoveEmployee", "Estimated hours is less than 1");
            if(this.Projects.Contains(newProject))
                throw new PreconditionException(this.GetType().Name, "RemoveEmployee", "Project "+newProject.Name+" already exist.");
            this.Projects.Add(newProject);
            this.EstimatedHours.Add(newProject,estimated);
            this.ProjectHours.Add(newProject, 0);
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "after");
        }

        public void RemoveProject(Project project) 
        {
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "before");
            if (!this.Projects.Contains(project))
                throw new PreconditionException(this.GetType().Name, "RemoveEmployee", "Project " + project.Name + " doesn't exist.");
            this.Projects.Remove(project);
            this.EstimatedHours = 
                this.EstimatedHours.Where(kvp => !kvp.Key.Equals(project)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            this.ProjectHours =
                this.ProjectHours.Where(kvp => !kvp.Key.Equals(project)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            this.EmployeeHours.ExceptWith(this.EmployeeHours.Where(eh => eh.Project.Equals(project)));
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "after");
        }

        public void AssignProject(Employee employee, Project project)
        {
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "before");

            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "after");
        }

        public void DeAssignProject() 
        {
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "before");

            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "after");
        }

        public void EmployeeAddingHoursToProject()
        {
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "before");

            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "after");
        }
    }
}
