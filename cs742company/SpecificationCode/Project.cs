using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationCode
{
    public class Project : System.Object, IComparable
    {

		public NAME Name {
			get;
			set;
		}

        public Project(String name) 
        {
			this.Name = new NAME(name);
        }

        int IComparable.CompareTo(object that)
        {
            if (that == null) return 1;
            Project otherProject = that as Project;
            if (otherProject != null)
            {
                return this.Name.getNAME().CompareTo(otherProject.Name.getNAME());
            }
            else
            {
                throw new ArgumentException("Object is not a Project");
            }
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Employee return false.
            Project p = obj as Project;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this.Name.getNAME() == p.Name.getNAME();
        }

        public override int GetHashCode()
        {
            return this.Name.getNAME().GetHashCode();
        }
    }
}
