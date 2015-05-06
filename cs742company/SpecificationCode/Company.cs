using System;
using System.Collections.Generic;
using System.Linq;

namespace cs742company.SpecificationCode
{
    public class Company
    {
        // Fixed number of divisions
        int numberOfDivisions;

        public int NumberOfDivisions
        {
            get { return numberOfDivisions; }
            set 
            {
                if (value < 1)// number of division must be great than 1
                {
                    throw new PreconditionException(GetType().Name, "setNumberOfDivisions", "Number of divisions is less than 1.");
                }
                numberOfDivisions = value; 
            }
        }

        public int extractEstimatedHoursForProject(HashSet<Division> divisions, Project p) 
        {
            //if division hashset is empty
            if (!divisions.Any())
            {
                return 0;
            }
            else
            {
                //if project doesn't exist in divisions set input
                if (!divisions.Any(d => d.Projects.Contains(p)))
                {
                    throw new
                        PreconditionException(GetType().Name,
                        "extractEstimatedHoursForProject",
                        "Project " + p.Name.getNAME() + " doesn't belong to any of these divisions.");
                }
                else
                {
                    //Recursively extracting estimated hours
                    // WARNING: Something wrong here, it doesn't work.
                    IEnumerable<Division> target = divisions.Where(d => d.Projects.Contains(p));
                    var enumerable = target.ToList();
                    divisions.ExceptWith((IEnumerable<Division>)enumerable);
                    return enumerable.FirstOrDefault(d => d.Projects.Contains(p)).EstimatedHours[p]
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
                        PreconditionException(GetType().Name,
                        "extractEstimatedHoursForProject",
                        "Project " + p.Name.getNAME() + " doesn't belong to any of these divisions.");
                }
                else
                {
                    //Recursively extracting spent hours
                    IEnumerable<Division> target = divisions.Where(d => d.Projects.Contains(p));
                    var enumerable = target.ToList();
                    divisions.ExceptWith((IEnumerable<Division>)enumerable);
                    // WARNING: Something wrong here, it doesn't work.
                    return enumerable.FirstOrDefault(d => d.Projects.Contains(p)).ProjectHours[p]
                        + extractHoursSpentForProject(divisions, p);
                }
            }
        }

        public Boolean isDivisionOperational(Dictionary<Division, Manager> managers, Division d)
        {
            return managers.Keys.Contains(d) && d.Employees.Any();
        }


        public HashSet<Division> Divisions 
        {
			get;
			set;
		}
        public Dictionary<Division, Manager> Managers 
        {
			get;
			set;
		}
        Boolean stateInvariantCheck() 
        {
            //
            // The state invariant asserts that the domain of managers must be
            // the subset of divisions.
            //
            if (new HashSet<Division>(Managers.Keys).IsSubsetOf(Divisions))
            {
                //
                // The state invariant asserts that employees of each element in divisions
                // must not have intersection and each division must be unique by name.
                //
                foreach (Division d1 in Divisions)
                {
                    foreach (Division d2 in Divisions)
                    {
                        //if two divisions are equal, their names must be same
                        if (d1.Equals(d2))
                        {
                            return d1.Name.Equals(d2.Name);
                        }
                        else
                        {
                            //If two divisions are not same, their employee set cannot have intersections
                            if (!d1.Employees.Intersect(d2.Employees).Any())
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
                return true;
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

		public Company(params DIVISION_NAME[] divisionsNames)
        {
            if (divisionsNames.Length < 1)
            {
                throw new
                    PreconditionException(GetType().Name,
                    "INIT of company",
                    "you must input at least one division name to initialize a company");
            }
            NumberOfDivisions = divisionsNames.Length;
            // Duplicated elements checking
            if (divisionsNames.Distinct().Count() != divisionsNames.Count())
            {
                throw new
                    PreconditionException(GetType().Name,
                    "INIT of company",
                    "you must input non-duplicated names for each divisions to initialize a company");
            }

            
            // Dynamically generate division objects by names input.
            IDictionary<String, Division> col = new Dictionary<String, Division>();
            foreach (DIVISION_NAME name in divisionsNames)
            {
				col[name.getDIVISION_NAME()] = new Division { Name = name};
            }
				
            // Pass generated division objects to divisions of this company
			Divisions = new HashSet<Division> (col.Values);
            Managers = new Dictionary<Division,Manager>();
		}

        public void HireManager(Manager manager, DIVISION_NAME division) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name, "HireManager","before");
            }
            if (Managers.Values.Contains(manager)) 
            {
                throw new
                   PreconditionException(GetType().Name,
                   "HireManager",
                   "Manager "+manager.Name.getNAME()+" already belong to Managers.");
            }
            if (Managers.Keys.Any(d => d.Name.Equals(division)))
            {
                throw new 
                    PreconditionException(GetType().Name,
                    "HireManager",
                    "Division " + division.getDIVISION_NAME() + " already have a manager.");
            }
            //extract elements based on the condition below
			Division target = Divisions.FirstOrDefault(d => d.Name.Equals(division));
            if (target == null)
            {
                throw new
                    PreconditionException(GetType().Name,
                    "HireManager",
                    "Division " + division.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                Managers.Add(target, manager);
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name, "HireManager", "after");
            }
        }

        public void FireManager(DIVISION_NAME division) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name, "FireManager", "before");
            }
            //extract elements based on the condition below
			Division target = Managers.Keys.FirstOrDefault(d => d.Name.Equals(division));
            if (target == null)
            {
                throw new
                    PreconditionException(GetType().Name,
                    "HireManager",
                    "Division " + division.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                //update managers dictionary
                Managers = 
                    Managers.Where(m => !m.Key.Name.Equals(division)).ToDictionary(m => m.Key, m => m.Value);
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name, "FireManager", "after");
            }
        }

        public void MoveManagerFromOneDivisionToAnother(DIVISION_NAME from, DIVISION_NAME to) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name, "MoveManagerFromOneDivisionToAnother", "before");
            }
            //extract elements based on the condition below
			Division source = Divisions.FirstOrDefault(s => s.Name.Equals(from));
			Division destination = Divisions.FirstOrDefault(d => d.Name.Equals(to));
            if (source == null)
            {
                throw new
                    PreconditionException(GetType().Name,
                    "MoveManagerFromOneDivisionToAnother",
                    "Division " + from.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                if (destination == null)
                {
                    throw new
                    PreconditionException(GetType().Name,
                    "MoveManagerFromOneDivisionToAnother",
                    "Division " + to.getDIVISION_NAME() + " doesn't exist.");
                }
                else
                {
                    //extract elements based on the condition below
                    IEnumerable<Division> domManagerD = Managers.Keys.Where(dm => dm.Name.Equals(destination.Name));
                    if (domManagerD.Any())
                    {
                        throw new
                        PreconditionException(GetType().Name,
                        "MoveManagerFromOneDivisionToAnother",
                        "Division " + domManagerD.FirstOrDefault().Name.getDIVISION_NAME() + " already have a manager.");
                    }
                    else
                    {
                        IEnumerable<Division> domManagerS = Managers.Keys.Where(dm => dm.Name.Equals(source.Name));
                        if (!domManagerS.Any())
                        {
                            throw new
                            PreconditionException(GetType().Name,
                            "MoveManagerFromOneDivisionToAnother",
                            "Division " + domManagerD.FirstOrDefault().Name.getDIVISION_NAME() + " doesn't have any manager.");
                        }
                        else
                        {
                            //excepting no-need elements first and then adding new one

                            if (Managers.ContainsKey(source))
                            {
                                //Copy the manager to destination division.
                                Managers.Add(destination, Managers[source]);
                                //Remove manager from original division and update Managers set.
                                Managers = Managers.Where(m => !m.Key.Name.Equals(source.Name)).
                                    ToDictionary(m => m.Key, m => m.Value);
                            }
                            else
                            {
                                throw new InvariantException(GetType().Name, "MoveManagerFromOneDivisionToAnother", "after");
                            }
                        }
                    }
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name, "MoveManagerFromOneDivisionToAnother", "after");
            }
        }

        public void HireEmployee(DIVISION_NAME division, Employee newEmployee) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "HireEmployee", "before");
            }
			Division d = Divisions.FirstOrDefault(div => div.Name.Equals(division));
            if (d == null)
            {
                throw new
                PreconditionException(GetType().Name,
                "HireEmployee",
                "Division " + division.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                //if there is another employee who has same name with new one.
                //I overridden the compare method so contains method will compare
                // their name.
                if (Divisions.Any(dOther => dOther.Employees.Contains(newEmployee)))
                {
                    throw new
                    PreconditionException(GetType().Name,
                    "HireEmployee",
                    "Employee " + newEmployee.Name.getNAME() + " already exist in other division.");
                }
                else
                {
                    d.AddEmployee(newEmployee);
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "HireEmployee", "after");
            }
        }

        public void FireEmployee(DIVISION_NAME division, Employee employee)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "FireEmployee", "before");
            }
            //extract elements based on the condition below
			Division d = Divisions.FirstOrDefault(div => div.Name.getDIVISION_NAME().Equals(division.getDIVISION_NAME()));
            if (d == null)
            {
                throw new
                PreconditionException(GetType().Name,
                "FireEmployee",
                "Division " + division.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                d.RemoveEmployee(employee);
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "FireEmployee", "after");
            }
        }

        public void MoveEmployeeFromOneDivisionToAnother(DIVISION_NAME from, DIVISION_NAME to, Employee employee)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name, "MoveEmployeeFromOneDivisionToAnother", "before");
            }
            //extract elements based on the condition below
			Division source = Divisions.FirstOrDefault(s => s.Name.Equals(from));
			Division destination = Divisions.FirstOrDefault(d => d.Name.Equals(to));
            if (source == null)
            {
                throw new
                    PreconditionException(GetType().Name,
                    "MoveEmployeeFromOneDivisionToAnother",
                    "Division " + from + " doesn't exist.");
            }
            else
            {
                if (destination == null)
                {
                    throw new
                    PreconditionException(GetType().Name,
                    "MoveEmployeeFromOneDivisionToAnother",
                    "Division " + to + " doesn't exist.");
                }
                else
                {
                    if (!source.Employees.Contains(employee))
                    {
                        throw new
                        PreconditionException(GetType().Name,
                        "MoveEmployeeFromOneDivisionToAnother",
                        "Employee " + employee.Name.getNAME() + " doesn't exist in Division "
                        + source.Name.getDIVISION_NAME() + ".");
                    }
                    else
                    {
                        if (destination.Employees.Contains(employee))
                        {
                            throw new
                            PreconditionException(GetType().Name,
                            "MoveEmployeeFromOneDivisionToAnother",
                            "Employee " + employee.Name.getNAME() + " already exist in Division "
                            + destination.Name.getDIVISION_NAME() + ".");
                        }
                        else
                        {
                            Divisions.Remove(source);
                            Divisions.Remove(destination);

                            Division newSource = new Division();
                            Division newDestination = new Division();

                            newSource.Name = source.Name;
                            //Targeting the elements in employee set based on condition below.
                            IEnumerable<Employee> targer = source.Employees.Where(e => e.Name.Equals(employee.Name));
                            var enume = targer.ToList();
                            //Remove the subset corresponding to what we found earlier
                            source.Employees.ExceptWith((IEnumerable<Employee>)enume);

                            newSource.Employees = source.Employees;
                            newSource.Projects = source.Projects;
                            newSource.EstimatedHours = source.EstimatedHours;
                            newSource.ProjectHours = source.ProjectHours;
                            //Targeting the elements in employeeHours set based on condition below.
                            IEnumerable<EmployeeProjectPair> target_source = source.EmployeeHours.Where(empProj => empProj.Employee.Equals(employee));
                            var enume1 = target_source.ToList();
                            //Remove the subset corresponding to what we found earlier
                            source.EmployeeHours.ExceptWith((IEnumerable<EmployeeProjectPair>)enume1);
                            newSource.EmployeeHours = source.EmployeeHours;

                            newDestination.Name = destination.Name;
                            destination.Employees.Add(employee);
                            newDestination.Employees = destination.Employees;
                            newDestination.Projects = destination.Projects;
                            newDestination.EstimatedHours = destination.EstimatedHours;
                            newDestination.ProjectHours = destination.ProjectHours;
                            newDestination.EmployeeHours = destination.EmployeeHours;

                            Divisions.Add(newSource);
                            Divisions.Add(newDestination);
                        }
                    }
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name, "MoveEmployeeFromOneDivisionToAnother", "after");
            }
        }

        public void AddNewProjectToDivision(DIVISION_NAME division, Project newProject, int estimated) 
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "AddNewProjectToDivision", "before");
            }

            if (estimated < 1)
            {
                throw new
                PreconditionException(GetType().Name,
                "AddNewProjectToDivision",
                "Estimated time is less than 1.");
            }
            //Check whether division exists
			Division d = Divisions.FirstOrDefault(div => div.Name.Equals(division));
            if (d == null)
            {
                throw new
                PreconditionException(GetType().Name,
                "AddNewProjectToDivision",
                "Division " + d.Name.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                //Check it's operational or not.
                if (!isDivisionOperational(Managers, d))
                {
                    throw new
                    PreconditionException(GetType().Name,
                    "AddNewProjectToDivision",
                    "Division " + d.Name.getDIVISION_NAME() + " isn't operational.");
                }
                else
                {
                    d.AddProject(newProject, estimated);
                }
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "AddNewProjectToDivision", "after");
            }
        }

        public void RemoveProjectFromDivision(DIVISION_NAME division, Project project)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "RemoveProjectFromDivision", "before");
            }
			Division d = Divisions.FirstOrDefault(div => div.Name.Equals(division));
            if (d == null)
            {
                throw new
                PreconditionException(GetType().Name,
                "RemoveProjectFromDivision",
                "Division " + d.Name.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                if (!isDivisionOperational(Managers, d))
                {
                    throw new
                    PreconditionException(GetType().Name,
                    "RemoveProjectFromDivision",
                    "Division " + d.Name.getDIVISION_NAME() + " isn't operational.");
                }
                else
                {
                    d.RemoveProject(project);
                }
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "RemoveProjectFromDivision", "after");
            }
        }

        public void AssignProjectWithinDivision(DIVISION_NAME division, Project project, Employee employee)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "AssignProjectWithinDivision", "before");
            }
            //extract elements based on condition below
			Division d = Divisions.FirstOrDefault(div => div.Name.Equals(division));
            if (d == null)
            {
                throw new
                PreconditionException(GetType().Name,
                "AssignProjectWithinDivision",
                "Division " + d.Name.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                if (!isDivisionOperational(Managers, d))
                {
                    throw new
                    PreconditionException(GetType().Name,
                    "AssignProjectWithinDivision",
                    "Division " + d.Name.getDIVISION_NAME() + " isn't operational.");
                }
                else
                {
                    d.AssignProject(employee, project);
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "AssignProjectWithinDivision", "after");
            }
        }

        public void DeAssignProjectWithinDivision(DIVISION_NAME division, Project project, Employee employee)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "DeAssignProjectWithinDivision", "before");
            }

			Division d = Divisions.FirstOrDefault(div => div.Name.Equals(division));
            if (d == null)
            {
                throw new
                PreconditionException(GetType().Name,
                "DeAssignProjectWithinDivision",
                "Division " + d.Name.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                if (!isDivisionOperational(Managers, d))
                {
                    throw new
                    PreconditionException(GetType().Name,
                    "DeAssignProjectWithinDivision",
                    "Division " + d.Name.getDIVISION_NAME() + " isn't operational.");
                }
                else
                {
                    d.DeAssignProject(employee, project);
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "DeAssignProjectWithinDivision", "after");
            }
        }

        public void EmployeeAddingHoursToProjectInDivision(DIVISION_NAME division, Project project, Employee employee, int hoursToAdd)
        {
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "EmployeeAddingHoursToProjectInDivision", "before");
            }
            if (hoursToAdd < 1)
            {
                throw new
                PreconditionException(GetType().Name,
                "EmployeeAddingHoursToProjectInDivision",
                "Hours of "+employee.Name.getNAME()+" to add is less than 1.");
            }

			Division d = Divisions.FirstOrDefault(div => div.Name.Equals(division));
            if (d == null)
            {
                throw new
                PreconditionException(GetType().Name,
                "EmployeeAddingHoursToProjectInDivision",
                "Division " + d.Name.getDIVISION_NAME() + " doesn't exist.");
            }
            else
            {
                if (!isDivisionOperational(Managers, d))
                {
                    throw new
                    PreconditionException(GetType().Name,
                    "EmployeeAddingHoursToProjectInDivision",
                    "Division " + d.Name.getDIVISION_NAME() + " isn't operational.");
                }
                else
                {
                    d.EmployeeAddingHoursToProject(employee, project, hoursToAdd);
                }
            }

            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "EmployeeAddingHoursToProjectInDivision", "after");
            }
        }

        public String CompleteProject(Project project)
        {
            int totalEstimatedHours;
            int totalHoursSpent;
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "CompleteProject", "before");
            }
            HashSet<Division> divisionSubset = 
                new HashSet<Division>(Divisions.Where(div => div.Projects.Contains(project)));
            if (!divisionSubset.Any())
            {
                throw new
                PreconditionException(GetType().Name,
                "CompleteProject",
                "Project " + project.Name.getNAME() + " doesn't exist.");
            }
            else
            {
                //Computing the hours using function above.
                //WARNING. The functions above doesn't work.
                totalEstimatedHours = extractEstimatedHoursForProject(divisionSubset, project);
                totalHoursSpent = extractHoursSpentForProject(divisionSubset, project);
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
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
                throw new InvariantException(GetType().Name,
                    "ReportHoursSpentbyEmployeeOnProject", "before");
            }
            
			Division target = Divisions.FirstOrDefault(d =>
                     d.EmployeeHours.Any(empProj =>
                     empProj.Employee.Name.getNAME().Equals(employee.Name.getNAME()) &&
                     empProj.Project.Name.getNAME().Equals(project.Name.getNAME())));
            if (target == null)
            {
                throw new
                PreconditionException(GetType().Name,
                "ReportHoursSpentbyEmployeeOnProject",
                "The relation between Project " + project.Name
                + " and Employee " + employee.Name + " doesn't exist in Division "
                + target.Name + ".");
            }
            else
            {
                //Found corresponding target and get the hours
                hours = target.EmployeeHours.FirstOrDefault(empProj =>
                     empProj.Employee.Name.getNAME().Equals(employee.Name.getNAME()) &&
                     empProj.Project.Name.getNAME().Equals(project.Name.getNAME())).HoursSpent;
            }
            if (!stateInvariantCheck())
            {
                throw new InvariantException(GetType().Name,
                    "ReportHoursSpentbyEmployeeOnProject", "after");
            }
            return hours;
        }

    }
}
