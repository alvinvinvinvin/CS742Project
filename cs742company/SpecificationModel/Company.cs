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
                    "init of company",
                    "you must input at least one division name to initialize a company");
            }
            this.NumberOfDivisions = divisionsNames.Length;
            // Dupilicated elements checking
            if (divisionsNames.Distinct().Count() != divisionsNames.Count())
            {
                throw new
                    PreconditionException(this.GetType().Name,
                    "init of company",
                    "you must input unduplicated names for each divisions to initialize a company");
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

        }

    }
}
