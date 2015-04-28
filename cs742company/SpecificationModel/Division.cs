using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class Division : System.Object, IComparable
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

        int IComparable.CompareTo(System.Object that)
        {
            if (that == null) return 1;
            Division otherDivision = that as Division;
            if (otherDivision != null)
            {
                return this.Name.CompareTo(otherDivision.Name);
            }
            else
            {
                throw new ArgumentException("Object is not an Division");
            }
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Division return false.
            Division d = obj as Division;
            if ((System.Object)d == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this.Name == d.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        private Boolean stateInvariantCheck() 
        {
            //
            // The state invariant asserts that the domain of estimatedHours 
            // must be equal to projects
            //
            if (this.EstimatedHours.Keys.Equals(this.Projects))
            {
                //
                // The state invariant asserts that the domain of projectHours
                // must be equal to projects
                //
                if (this.ProjectHours.Keys.Equals(this.Projects))
                {

                    foreach(EmployeeProjectPair e1 in this.EmployeeHours)
                    {
                        //
                        // The state invariant asserts that the employee of each element
                        // in employeeHours must be the member of employees and the project
                        // of each element in employeeHours must be the member of projects
                        //
                        if (this.Employees.Contains(e1.Employee) &&
                            this.Projects.Contains(e1.Project))
                        {
                            foreach (EmployeeProjectPair e2 in this.EmployeeHours)
                            {
                                //
                                // The state invariant asserts that each element
                                // in employeeHours must be uniquely identified by its
                                // employee and project. I have already overridden the
                                // "Equals()" method in each class to comparing "Name"
                                // property between each object to determine whether they
                                // are equal or not. For more details please check each
                                // class.
                                //
                                if (e1.Equals(e2)) 
                                {
                                    if (e1.Employee.Name.Equals(e2.Employee.Name) && 
                                        e1.Project.Name.Equals(e2.Project.Name))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            return false;
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
                throw new 
                    PreconditionException(this.GetType().Name, 
                    "AddEmployee", 
                    "New Employee is already a member of the division " + this.Name + ".");
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
                throw new 
                    PreconditionException(this.GetType().Name, 
                    "RemoveEmployee", 
                    "Employee is not a member of the division " + this.Name + ".");

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
                throw new PreconditionException(this.GetType().Name, 
                    "AddProject", 
                    "Estimated hours is less than 1");
            if(this.Projects.Contains(newProject))
                throw new PreconditionException(this.GetType().Name, 
                    "AddProject", 
                    "Project " + newProject.Name + " already exist.");
            this.Projects.Add(newProject);
            this.EstimatedHours.Add(newProject,estimated);
            this.ProjectHours.Add(newProject, 0);
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "AddProject", "after");
        }

        public void RemoveProject(Project project) 
        {
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "RemoveProject", "before");
            if (!this.Projects.Contains(project))
                throw new 
                    PreconditionException(this.GetType().Name, 
                    "RemoveProject", 
                    "Project " + project.Name + " doesn't exist.");
            this.Projects.Remove(project);
            this.EstimatedHours = 
                this.EstimatedHours.Where(kvp => !kvp.Key.Equals(project)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            this.ProjectHours =
                this.ProjectHours.Where(kvp => !kvp.Key.Equals(project)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            this.EmployeeHours.ExceptWith(this.EmployeeHours.Where(eh => eh.Project.Equals(project)));
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "RemoveProject", "after");
        }

        public void AssignProject(Employee employee, Project project)
        {
            if (!stateInvariantCheck())
                throw new 
                    InvariantException(this.GetType().Name, "AssignProject", "before");
            if (!this.Employees.Contains(employee))
                throw new 
                    PreconditionException(this.GetType().Name, 
                    "AssignProject", 
                    "Employee "+employee.Name+" doesn't exist.");
            if (!this.Projects.Contains(project))
                throw new 
                    PreconditionException(this.GetType().Name, 
                    "AssignProject", 
                    "Project " + project.Name + " doesn't exist.");
            if(this.EmployeeHours.Any(eh => eh.Employee.Equals(employee) && eh.Project.Equals(project)))
                throw new 
                    PreconditionException(this.GetType().Name, 
                    "AssignProject", 
                    "Project " + project.Name + " has already been assigned to Employee "+employee.Name+".");
            EmployeeProjectPair empProj = new EmployeeProjectPair();
            empProj.Employee = employee;
            empProj.Project = project;
            empProj.HoursSpent = 0;
            this.EmployeeHours.Add(empProj);
            if (!stateInvariantCheck())
                throw new 
                    InvariantException(this.GetType().Name, "AssignProject", "after");
        }

        public void DeAssignProject(Employee employee, Project project) 
        {
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "DeAssignProject", "before");
            if (!this.Employees.Contains(employee))
                throw new
                    PreconditionException(this.GetType().Name,
                    "DeAssignProject",
                    "Employee " + employee.Name + " doesn't exist.");
            if (!this.Projects.Contains(project))
                throw new
                    PreconditionException(this.GetType().Name,
                    "DeAssignProject",
                    "Project " + project.Name + " doesn't exist.");
            IEnumerable<EmployeeProjectPair> target = 
                this.EmployeeHours.Where(empProj => empProj.Employee.Equals(employee) && empProj.Project.Equals(project));
            if (!target.Any())
            {
                throw new
                       PreconditionException(this.GetType().Name,
                       "DeAssignProject",
                       "Project " + project.Name + " has not been assigned to Employee " + employee.Name + ".");
            }
            else
            {
                this.EmployeeHours.ExceptWith(target);
            }
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "DeAssignProject", "after");
        }

        public void EmployeeAddingHoursToProject(Employee employee, Project project, int hoursToAdd)
        {
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "EmployeeAddingHoursToProject", "before");
            if (hoursToAdd < 1)
            {
                throw new
                    PreconditionException(this.GetType().Name,
                    "EmployeeAddingHoursToProject",
                    "hoursToAdd is less than 1.");
            }
            if (!this.Employees.Contains(employee))
                throw new
                    PreconditionException(this.GetType().Name,
                    "EmployeeAddingHoursToProject",
                    "Employee " + employee.Name + " doesn't exist in Employees.");
            if (!this.ProjectHours.Any(ph => ph.Key.Name.Equals(project.Name)))
            {
                throw new
                    PreconditionException(this.GetType().Name,
                    "EmployeeAddingHoursToProject",
                    "Project " + project.Name + " doesn't exist in ProjectHours.");
            }
            IEnumerable<EmployeeProjectPair> target =
                this.EmployeeHours.Where(empProj => empProj.Employee.Equals(employee) && empProj.Project.Equals(project));
            if (!target.Any())
            {
                throw new
                       PreconditionException(this.GetType().Name,
                       "DeAssignProject",
                       "Project " + project.Name + " has not been assigned to Employee " + employee.Name + ".");
            }
            else
            {
                this.EmployeeHours.ExceptWith(target);
                EmployeeProjectPair newEmpProj = new EmployeeProjectPair();
                newEmpProj.Employee = employee;
                newEmpProj.Project = project;
                newEmpProj.HoursSpent = 
                    target.FirstOrDefault(empProj => empProj.Employee.Equals(employee) && empProj.Project.Equals(project)).HoursSpent + hoursToAdd;
                this.EmployeeHours.Add(newEmpProj);
                this.ProjectHours[project] = this.ProjectHours[project] + hoursToAdd;
            }
            if (!stateInvariantCheck())
                throw new InvariantException(this.GetType().Name, "EmployeeAddingHoursToProject", "after");
        }
    }
}
