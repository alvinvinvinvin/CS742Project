using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class Company
    {
        private int numberOfDivisions;

        public int NumberOfDivisions
        {
            get { return numberOfDivisions; }
            set 
            {
                if (value < 1)
                {
                    throw new PreconditionException(this.GetType().Name, "setNumberOfDivisions", "Number of divisions is less than 1.");
                }
                numberOfDivisions = value; 
            }
        }

        public int extractEstimatedHoursForProject(HashSet<Division> divisions, Project p) 
        {
            if (!divisions.Any())
            {
                return 0;
            }
            else
            {
                if (!divisions.Any(d => d.Projects.Contains(p)))
                {
                    throw new
                        PreconditionException(this.GetType().Name,
                        "extractEstimatedHoursForProject",
                        "Project " + p.Name + " doesn't belong to any of these divisions.");
                }
                else
                {
                    IEnumerable<Division> target = divisions.Where(d => d.Projects.Contains(p));
                    divisions.ExceptWith(divisions.Where(d => d.Projects.Contains(p)));
                    return target.FirstOrDefault(d => d.Projects.Contains(p)).EstimatedHours[p]
                        + extractEstimatedHoursForProject(divisions, p);
                }
            }
        }

        public int extractHoursSpentForProject(HashSet<Division> divisions, Project p)
        {
            if (!divisions.Any())
            {
                return 0;
            }
            else
            {
                if (!divisions.Any(d => d.Projects.Contains(p)))
                {
                    throw new
                        PreconditionException(this.GetType().Name,
                        "extractEstimatedHoursForProject",
                        "Project " + p.Name + " doesn't belong to any of these divisions.");
                }
                else
                {
                    IEnumerable<Division> target = divisions.Where(d => d.Projects.Contains(p));
                    divisions.ExceptWith(divisions.Where(d => d.Projects.Contains(p)));
                    return target.FirstOrDefault(d => d.Projects.Contains(p)).ProjectHours[p]
                        + extractHoursSpentForProject(divisions, p);
                }
            }
        }

        public Boolean isDivisionOperational(Dictionary<Division, Manager> managers, Division d)
        {
            return managers.Keys.Contains(d) && d.Employees.Any();
        }

        private HashSet<Division> divisions;

        public HashSet<Division> Divisions
        {
            get { return divisions; }
            set { divisions = value; }
        }
        private Dictionary<Division, Manager> managers;

        public Dictionary<Division, Manager> Managers
        {
            get { return managers; }
            set { managers = value; }
        }


        private Boolean stateInvariantCheck() 
        {
            //
            // The state invariant asserts that the domain of managers must be
            // the subset of divisions.
            //
            if (new HashSet<Division>(this.Managers.Keys).IsSubsetOf(this.Divisions))
            {
                //
                // The state invariant asserts that employees of each element in divisions
                // must not have intersection and each division must be unique by name.
                //
                foreach (Division d1 in this.Divisions)
                {
                    foreach (Division d2 in this.Divisions)
                    {
                        if (!d1.Employees.Intersect(d2.Employees).Any())
                        {
                            if (d1.Equals(d2))
                            {
                                if (d1.Name.Equals(d2.Name))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
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

		/// <summary>
		/// Constructor method based on INIT.
		/// 
		/// </summary>

		public Company(String[] divisionsNames)
        {
            if (divisionsNames.Length < 1)
            {
                throw new
                    PreconditionException(this.GetType().Name,
                    "INIT of company",
                    "you must input at least one division name to initialize a company");
            }
            this.NumberOfDivisions = divisionsNames.Length;
            // Duplicated elements checking
            if (divisionsNames.Distinct().Count() != divisionsNames.Count())
            {
                throw new
                    PreconditionException(this.GetType().Name,
                    "INIT of company",
                    "you must input non-duplicated names for each divisions to initialize a company");
            }

            /// <summary>
            /// Dynamically generate division objects by names input.
            /// </summary>
            IDictionary<String, Division> col = new Dictionary<String, Division>();
            foreach (string name in divisionsNames)
            {
                col[name] = new Division { Name = "Division " + name};
            }

            /// <summary>
            /// Pass generated division objects to divisions of this company
            /// </summary>
			this.Divisions = new HashSet<Division> (col.Values);
            this.Managers = null;
		}

        public void HireManager(Manager manager, String division) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name, "HireManager","before");
            }
            if (this.Managers.Values.Contains(manager)) 
            {
                throw new
                   PreconditionException(this.GetType().Name,
                   "HireManager",
                   "Manager "+manager.Name+" already belong to Managers.");
            }
            if (this.Managers.Keys.Any(d => d.Name.Equals(division)))
            {
                throw new 
                    PreconditionException(this.GetType().Name,
                    "HireManager",
                    "Division " + division + " already have a manager.");
            }
            Division target = this.Divisions.Where(d => d.Name.Equals(division)).FirstOrDefault();
            if (target == null)
            {
                throw new
                    PreconditionException(this.GetType().Name,
                    "HireManager",
                    "Division " + division + " doesn't exist.");
            }
            else
            {
                this.Managers.Add(target, manager);
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name, "HireManager", "after");
            }
        }

        public void FireManager(String division) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name, "FireManager", "before");
            }
            Division target = this.Managers.Keys.Where(d => d.Name.Equals(division)).FirstOrDefault();
            if (target == null)
            {
                throw new
                    PreconditionException(this.GetType().Name,
                    "HireManager",
                    "Division " + division + " doesn't exist.");
            }
            else
            {
                this.Managers = 
                    this.Managers.Where(m => !m.Key.Name.Equals(division)).ToDictionary(m => m.Key, m => m.Value);
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name, "FireManager", "after");
            }
        }

        public void MoveManagerFromOneDivisionToAnother(String from, String to) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name, "MoveManagerFromOneDivisionToAnother", "before");
            }
            Division source = this.Divisions.Where(s => s.Name.Equals(from)).FirstOrDefault();
            Division destination = this.Divisions.Where(d => d.Name.Equals(to)).FirstOrDefault();
            if (source == null)
            {
                throw new
                    PreconditionException(this.GetType().Name,
                    "MoveManagerFromOneDivisionToAnother",
                    "Division " + from + " doesn't exist.");
            }
            else
            {
                if (destination == null)
                {
                    throw new
                    PreconditionException(this.GetType().Name,
                    "MoveManagerFromOneDivisionToAnother",
                    "Division " + to + " doesn't exist.");
                }
                else
                {
                    IEnumerable<Division> domManagerD = this.Managers.Keys.Where(dm => dm.Name.Equals(destination.Name));
                    if (domManagerD.Any())
                    {
                        throw new
                        PreconditionException(this.GetType().Name,
                        "MoveManagerFromOneDivisionToAnother",
                        "Division " + domManagerD.FirstOrDefault().Name + " already have a manager.");
                    }
                    else
                    {
                        IEnumerable<Division> domManagerS = this.Managers.Keys.Where(dm => dm.Name.Equals(source.Name));
                        if (!domManagerS.Any())
                        {
                            throw new
                            PreconditionException(this.GetType().Name,
                            "MoveManagerFromOneDivisionToAnother",
                            "Division " + domManagerD.FirstOrDefault().Name + " doesn't have any manager.");
                        }
                        else
                        {
                            this.Managers =
                            this.Managers.Where
                            (m => !m.Key.Name.Equals(source.Name)).ToDictionary
                            (m => m.Key, m => m.Value);
                            this.Managers.Add(destination, this.Managers[source]);
                        }
                    }
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name, "MoveManagerFromOneDivisionToAnother", "after");
            }
        }

        public void HireEmployee(String division, Employee newEmployee) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "HireEmployee", "before");
            }
            Division d = this.Divisions.Where(div => div.Name.Equals(division)).FirstOrDefault();
            if (d == null)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "HireEmployee",
                "Division " + division + " doesn't exist.");
            }
            else
            {
                if (this.Divisions.Any(dOther => dOther.Employees.Contains(newEmployee)))
                {
                    throw new
                    PreconditionException(this.GetType().Name,
                    "HireEmployee",
                    "Employee " + newEmployee.Name + " already exist in other division.");
                }
                else
                {
                    d.AddEmployee(newEmployee);
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "HireEmployee", "after");
            }
        }

        public void FireEmployee(String division, Employee employee)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "FireEmployee", "before");
            }
            Division d = this.Divisions.Where(div => div.Name.Equals(division)).FirstOrDefault();
            if (d == null)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "FireEmployee",
                "Division " + division + " doesn't exist.");
            }
            else
            {
                d.RemoveEmployee(employee);
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "FireEmployee", "after");
            }
        }

        public void MoveEmployeeFromOneDivisionToAnother(String from, String to, Employee employee)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name, "MoveEmployeeFromOneDivisionToAnother", "before");
            }
            Division source = this.Divisions.Where(s => s.Name.Equals(from)).FirstOrDefault();
            Division destination = this.Divisions.Where(d => d.Name.Equals(to)).FirstOrDefault();
            if (source == null)
            {
                throw new
                    PreconditionException(this.GetType().Name,
                    "MoveEmployeeFromOneDivisionToAnother",
                    "Division " + from + " doesn't exist.");
            }
            else
            {
                if (destination == null)
                {
                    throw new
                    PreconditionException(this.GetType().Name,
                    "MoveEmployeeFromOneDivisionToAnother",
                    "Division " + to + " doesn't exist.");
                }
                else
                {
                    if (!source.Employees.Contains(employee))
                    {
                        throw new
                        PreconditionException(this.GetType().Name,
                        "MoveEmployeeFromOneDivisionToAnother",
                        "Employee " + employee.Name + " doesn't exist in Division "
                        + source.Name + ".");
                    }
                    else
                    {
                        if (destination.Employees.Contains(employee))
                        {
                            throw new
                            PreconditionException(this.GetType().Name,
                            "MoveEmployeeFromOneDivisionToAnother",
                            "Employee " + employee.Name + " already exist in Division "
                            + destination.Name + ".");
                        }
                        else
                        {
                            this.Divisions.Remove(source);
                            this.Divisions.Remove(destination);

                            Division newSource = new Division();
                            Division newDestination = new Division();

                            newSource.Name = source.Name;
                            source.Employees.ExceptWith(source.Employees.Where(e => e.Name.Equals(employee.Name)));
                            newSource.Employees = source.Employees;
                            newSource.Projects = source.Projects;
                            newSource.EstimatedHours = source.EstimatedHours;
                            newSource.ProjectHours = source.ProjectHours;
                            source.EmployeeHours.ExceptWith(source.EmployeeHours.Where(empProj => empProj.Employee.Equals(employee)));
                            newSource.EmployeeHours = source.EmployeeHours;

                            newDestination.Name = destination.Name;
                            destination.Employees.Add(employee);
                            newDestination.Employees = destination.Employees;
                            newDestination.Projects = destination.Projects;
                            newDestination.EstimatedHours = destination.EstimatedHours;
                            newDestination.ProjectHours = destination.ProjectHours;
                            newDestination.EmployeeHours = destination.EmployeeHours;

                            this.Divisions.Add(newSource);
                            this.Divisions.Add(newDestination);
                        }
                    }
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name, "MoveEmployeeFromOneDivisionToAnother", "after");
            }
        }

        public void AddNewProjectToDivision(String division, Project newProject, int estimated) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "AddNewProjectToDivision", "before");
            }

            if (estimated < 1)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "AddNewProjectToDivision",
                "Estimated time is less than 1.");
            }

            Division d = this.Divisions.Where(div => div.Name.Equals(division)).FirstOrDefault();
            if (d == null)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "AddNewProjectToDivision",
                "Division " + d.Name + " doesn't exist.");
            }
            else
            {
                if (!isDivisionOperational(this.Managers, d))
                {
                    throw new
                    PreconditionException(this.GetType().Name,
                    "AddNewProjectToDivision",
                    "Division " + d.Name + " isn't operational.");
                }
                else
                {
                    d.AddProject(newProject, estimated);
                }
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "AddNewProjectToDivision", "after");
            }
        }

        public void RemoveProjectFromDivision(String division, Project project)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "RemoveProjectFromDivision", "before");
            }
            Division d = this.Divisions.Where(div => div.Name.Equals(division)).FirstOrDefault();
            if (d == null)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "RemoveProjectFromDivision",
                "Division " + d.Name + " doesn't exist.");
            }
            else
            {
                if (!isDivisionOperational(this.Managers, d))
                {
                    throw new
                    PreconditionException(this.GetType().Name,
                    "RemoveProjectFromDivision",
                    "Division " + d.Name + " isn't operational.");
                }
                else
                {
                    d.RemoveProject(project);
                }
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "RemoveProjectFromDivision", "after");
            }
        }

        public void AssignProjectWithinDivision(String division, Project project, Employee employee)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "AssignProjectWithinDivision", "before");
            }

            Division d = this.Divisions.Where(div => div.Name.Equals(division)).FirstOrDefault();
            if (d == null)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "AssignProjectWithinDivision",
                "Division " + d.Name + " doesn't exist.");
            }
            else
            {
                if (!isDivisionOperational(this.Managers, d))
                {
                    throw new
                    PreconditionException(this.GetType().Name,
                    "AssignProjectWithinDivision",
                    "Division " + d.Name + " isn't operational.");
                }
                else
                {
                    d.AssignProject(employee, project);
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "AssignProjectWithinDivision", "after");
            }
        }

        public void DeAssignProjectWithinDivision(String division, Project project, Employee employee)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "DeAssignProjectWithinDivision", "before");
            }

            Division d = this.Divisions.Where(div => div.Name.Equals(division)).FirstOrDefault();
            if (d == null)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "DeAssignProjectWithinDivision",
                "Division " + d.Name + " doesn't exist.");
            }
            else
            {
                if (!isDivisionOperational(this.Managers, d))
                {
                    throw new
                    PreconditionException(this.GetType().Name,
                    "DeAssignProjectWithinDivision",
                    "Division " + d.Name + " isn't operational.");
                }
                else
                {
                    d.DeAssignProject(employee, project);
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "DeAssignProjectWithinDivision", "after");
            }
        }

        public void EmployeeAddingHoursToProjectInDivision(String division, Project project, Employee employee, int hoursToAdd)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "EmployeeAddingHoursToProjectInDivision", "before");
            }
            if (hoursToAdd < 1)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "EmployeeAddingHoursToProjectInDivision",
                "Hours to add is less than 1.");
            }

            Division d = this.Divisions.Where(div => div.Name.Equals(division)).FirstOrDefault();
            if (d == null)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "EmployeeAddingHoursToProjectInDivision",
                "Division " + d.Name + " doesn't exist.");
            }
            else
            {
                if (!isDivisionOperational(this.Managers, d))
                {
                    throw new
                    PreconditionException(this.GetType().Name,
                    "EmployeeAddingHoursToProjectInDivision",
                    "Division " + d.Name + " isn't operational.");
                }
                else
                {
                    d.EmployeeAddingHoursToProject(employee, project, hoursToAdd);
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "EmployeeAddingHoursToProjectInDivision", "after");
            }
        }

        public String CompleteProject(Project project)
        {
            int totalEstimatedHours;
            int totalHoursSpent;
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "CompleteProject", "before");
            }
            HashSet<Division> divisionSubset = new HashSet<Division>(this.Divisions.Where(div => div.Projects.Contains(project)));
            if (!divisionSubset.Any())
            {
                throw new
                PreconditionException(this.GetType().Name,
                "CompleteProject",
                "Project " + project.Name + " doesn't exist.");
            }
            else
            {
                totalEstimatedHours = extractEstimatedHoursForProject(divisionSubset, project);
                totalHoursSpent = extractHoursSpentForProject(divisionSubset, project);
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "CompleteProject", "after");
            }
            return "totalEstimatedHours: " + totalEstimatedHours 
                    + "; totalHoursSpent:" + totalHoursSpent;
        }

        public int ReportHoursSpentbyEmployeeOnProject(Employee employee, Project project)
        {
            int hours;
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "ReportHoursSpentbyEmployeeOnProject", "before");
            }
            Division target = this.Divisions.Where(d =>
                     d.EmployeeHours.Any(empProj =>
                     empProj.Employee.Equals(employee) &&
                     empProj.Project.Equals(project))).FirstOrDefault();
            if (target == null)
            {
                throw new
                PreconditionException(this.GetType().Name,
                "ReportHoursSpentbyEmployeeOnProject",
                "The relation between Project " + project.Name
                + " and Employee " + employee.Name + " doesn't exist in Division "
                + target.Name + ".");
            }
            else
            {
                hours = target.EmployeeHours.FirstOrDefault(empProj =>
                     empProj.Employee.Equals(employee) &&
                     empProj.Project.Equals(project)).HoursSpent;
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(this.GetType().Name,
                    "ReportHoursSpentbyEmployeeOnProject", "after");
            }
            return hours;
        }

    }
}
