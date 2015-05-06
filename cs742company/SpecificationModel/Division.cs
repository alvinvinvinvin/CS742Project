using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    public class Division : System.Object, IComparable
    {

		public DIVISION_NAME Name {
			get;
			set;
		}


        public HashSet<Employee> Employees {
			get;
			set;
		}

        public HashSet<Project> Projects {
			get;
			set;
		}

        Dictionary<Project, int> estimatedHours;

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
                        throw new InvariantException(GetType().Name, "setEstimatedHours", "before");
                    }
                    else
                    {
                        setTo.Add(entry.Key, entry.Value);
                    }
                }
                estimatedHours = setTo;
            }
        }

        Dictionary<Project, int> projectHours;

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
                        throw new InvariantException(GetType().Name, "setProjectHours", "before");
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
                return Name.getDIVISION_NAME().CompareTo(otherDivision.Name.getDIVISION_NAME());
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
            return Name.getDIVISION_NAME() == d.Name.getDIVISION_NAME();
        }

        public override int GetHashCode()
        {
            return Name.getDIVISION_NAME().GetHashCode();
        }

        private Boolean stateInvariantCheck() 
        {
            //
            // The state invariant asserts that the domain of estimatedHours 
            // must be equal to projects
            //
            if (new HashSet<Project>(EstimatedHours.Keys).SetEquals(Projects))
            {
                //
                // The state invariant asserts that the domain of projectHours
                // must be equal to projects
                //
                if (new HashSet<Project>(ProjectHours.Keys).SetEquals(Projects))
                {

                    foreach(EmployeeProjectPair e1 in EmployeeHours)
                    {
                        //
                        // The state invariant asserts that the employee of each element
                        // in employeeHours must be the member of employees and the project
                        // of each element in employeeHours must be the member of projects
                        //
                        if (Employees.Contains(e1.Employee) &&
                            Projects.Contains(e1.Project))
                        {
                            foreach (EmployeeProjectPair e2 in EmployeeHours)
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
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
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
        /// I have to generate new objects here and pass them to properties
        /// because of language requirement. If I didn't, I cannot generate
        /// a new object which only contains name to directly use it to
        /// search or comparing with other object in Company class's methods.
        /// </summary>
        /// <param name="division_name"></param>
        public Division()
        {
            Name = new DIVISION_NAME("");
            Employees = new HashSet<Employee>();
            Projects = new HashSet<Project>();
            EmployeeHours = new HashSet<EmployeeProjectPair>();
            EstimatedHours = new Dictionary<Project, int>();
            ProjectHours = new Dictionary<Project, int>();
        }
        public Division(DIVISION_NAME division_name) 
        {
			Name = division_name;
            Employees = new HashSet<Employee>();
            Projects = new HashSet<Project>();
            EmployeeHours = new HashSet<EmployeeProjectPair>();
            EstimatedHours = new Dictionary<Project, int>();
            ProjectHours = new Dictionary<Project,int>();
        }

        /// <summary>
        /// Add a new employee to division
        /// </summary>
        /// <param name="newEmployee"></param>
        public void AddEmployee(Employee newEmployee)
        {
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "AddEmployee", "before");
            //Precondition checking, if employee already exists then throw exception.
            if (Employees.Any(e => e.Name.getNAME().Equals(newEmployee.Name.getNAME())))
                throw new 
                    PreconditionException(GetType().Name, 
                    "AddEmployee", 
                    "New Employee is already a member of the division " + Name.getDIVISION_NAME() + ".");
            else
            Employees.Add(newEmployee);

            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "AddEmployee", "after");

        }

        public void RemoveEmployee(Employee employee) 
        {
            Boolean resultOfRemoveFromEmployees;
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "RemoveEmployee", "before");
            if (!Employees.Any(e => e.Name.getNAME().Equals(employee.Name.getNAME())))
                throw new 
                    PreconditionException(GetType().Name, 
                    "RemoveEmployee", 
                    "Employee is not a member of the division " + Name.getDIVISION_NAME() + ".");

            else
            {
                //remove employee from employee set first
                resultOfRemoveFromEmployees = Employees.Remove(employee);
                //Targeting the elements in employeeHours set based on condition below.
                IEnumerable<EmployeeProjectPair> target =
                    EmployeeHours.Where(eh => eh.Employee.Name.getNAME().Equals(employee.Name.getNAME()));
                var enumeration = target.ToList();
                //Remove the subset corresponding to what we found earlier
                EmployeeHours.ExceptWith((IEnumerable<EmployeeProjectPair>)enumeration); 
            }

            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "RemoveEmployee", "after");

        }

        public void AddProject(Project newProject, int estimated) 
        {
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "AddProject", "before");
            if(estimated < 1)
                throw new PreconditionException(GetType().Name, 
                    "AddProject", 
                    "Estimated hours is less than 1");
            if(Projects.Contains(newProject))
                throw new PreconditionException(GetType().Name, 
                    "AddProject", 
                    "Project " + newProject.Name.getNAME() + " already exist.");
            else
            {
                Projects.Add(newProject);
                EstimatedHours.Add(newProject, estimated);
                ProjectHours.Add(newProject, 0); 
            }
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "AddProject", "after");
        }

        public void RemoveProject(Project project) 
        {
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "RemoveProject", "before");
            if (!Projects.Contains(project))
                throw new 
                    PreconditionException(GetType().Name, 
                    "RemoveProject", 
                    "Project " + project.Name.getNAME() + " doesn't exist.");
            Projects.Remove(project);
            //Update estimatedHours;
            EstimatedHours = 
                EstimatedHours.Where(kvp => !kvp.Key.Equals(project)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            //Update ProjectHours;
            ProjectHours =
                ProjectHours.Where(kvp => !kvp.Key.Equals(project)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            //Targeting the elements in employeeHours set based on condition below.
            IEnumerable<EmployeeProjectPair> target =
                EmployeeHours.Where(eh => eh.Project.Equals(project));
            var enume = target.ToList();
            //Remove the subset corresponding to what we found earlier
            EmployeeHours.ExceptWith((IEnumerable<EmployeeProjectPair>)enume);
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "RemoveProject", "after");
        }

        public void AssignProject(Employee employee, Project project)
        {
            if (!stateInvariantCheck())
                throw new 
                    InvariantException(GetType().Name, "AssignProject", "before");
            if (!Employees.Contains(employee))
                throw new 
                    PreconditionException(GetType().Name, 
                    "AssignProject", 
                    "Employee "+employee.Name.getNAME()+" doesn't exist.");
            if (!Projects.Contains(project))
                throw new 
                    PreconditionException(GetType().Name, 
                    "AssignProject", 
                    "Project " + project.Name.getNAME() + " doesn't exist.");
            if(EmployeeHours.Any(eh => eh.Employee.Name.getNAME().Equals(employee.Name.getNAME()) 
                && eh.Project.Name.getNAME().Equals(project.Name.getNAME())))
                throw new 
                    PreconditionException(GetType().Name, 
                    "AssignProject", 
                    "Project " + project.Name.getNAME() + " has already been assigned to Employee "+employee.Name+".");
            else
            {
                //Generate new object and add it to employeehours.
                EmployeeProjectPair empProj = new EmployeeProjectPair();
                empProj.Employee = employee;
                empProj.Project = project;
                empProj.HoursSpent = 0;
                EmployeeHours.Add(empProj); 
            }
            if (!stateInvariantCheck())
                throw new 
                    InvariantException(GetType().Name, "AssignProject", "after");
        }

        public void DeAssignProject(Employee employee, Project project) 
        {
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "DeAssignProject", "before");
            if (!Employees.Contains(employee))
                throw new
                    PreconditionException(GetType().Name,
                    "DeAssignProject",
                    "Employee " + employee.Name.getNAME() + " doesn't exist.");
            if (!Projects.Contains(project))
                throw new
                    PreconditionException(GetType().Name,
                    "DeAssignProject",
                    "Project " + project.Name.getNAME() + " doesn't exist.");
            //extract the elements we want based on condition
            IEnumerable<EmployeeProjectPair> target = 
                EmployeeHours.Where(empProj => empProj.Employee.Equals(employee) && empProj.Project.Equals(project));
            var enume = target.ToList();
            if (!enume.Any())//If there is no corresponding element.
            {
                throw new
                       PreconditionException(GetType().Name,
                       "DeAssignProject",
                       "Project " + project.Name.getNAME() + " has not been assigned to Employee " + employee.Name + ".");
            }
            else
            {
                //Remove the subset corresponding to what we found earlier
                EmployeeHours.ExceptWith((IEnumerable<EmployeeProjectPair>)enume);
            }
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "DeAssignProject", "after");
        }

        public void EmployeeAddingHoursToProject(Employee employee, Project project, int hoursToAdd)
        {
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "EmployeeAddingHoursToProject", "before");
            if (hoursToAdd < 1)
            {
                throw new
                    PreconditionException(GetType().Name,
                    "EmployeeAddingHoursToProject",
                    "hoursToAdd of "+employee.Name.getNAME()+" is less than 1.");
            }
            if (!Employees.Contains(employee))
                throw new
                    PreconditionException(GetType().Name,
                    "EmployeeAddingHoursToProject",
                    "Employee " + employee.Name.getNAME() + " doesn't exist in Employees.");
            if (!ProjectHours.Any(ph => ph.Key.Name.Equals(project.Name)))
            {
                throw new
                    PreconditionException(GetType().Name,
                    "EmployeeAddingHoursToProject",
                    "Project " + project.Name.getNAME() + " doesn't exist in ProjectHours.");
            }
            //extract the elements we want based on condition
            IEnumerable<EmployeeProjectPair> target =
                EmployeeHours.Where(empProj => empProj.Employee.Equals(employee) && empProj.Project.Equals(project));
			var enumerable = target.ToList ();
            if (!enumerable.Any())
            {
                throw new
                       PreconditionException(GetType().Name,
                       "DeAssignProject",
                       "Project " + project.Name.getNAME() + " has not been assigned to Employee " + employee.Name + ".");
            }
            else
            {
                //remove the elements we found above based on condition first
				EmployeeHours.ExceptWith((IEnumerable<EmployeeProjectPair>)enumerable);
                //generate new pair
                EmployeeProjectPair newEmpProj = new EmployeeProjectPair();
                newEmpProj.Employee = employee;
                newEmpProj.Project = project;
                //compute hours spent
                newEmpProj.HoursSpent = 
                    enumerable.FirstOrDefault(empProj => empProj.Employee.Equals(employee) && empProj.Project.Equals(project)).HoursSpent + hoursToAdd;
                EmployeeHours.Add(newEmpProj);//add the new pair
                //update project hours
                ProjectHours[project] = ProjectHours[project] + hoursToAdd;
            }
            if (!stateInvariantCheck())
                throw new InvariantException(GetType().Name, "EmployeeAddingHoursToProject", "after");
        }
    }
}
