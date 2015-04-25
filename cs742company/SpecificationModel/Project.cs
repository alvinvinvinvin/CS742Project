using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class Project : System.Object, IComparable
    {
        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Project(String name) 
        {
            this.Name = name;
        }

        int IComparable.CompareTo(object that)
        {
            if (that == null) return 1;
            Project otherProject = that as Project;
            if (otherProject != null)
            {
                return this.Name.CompareTo(otherProject.Name);
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
            return this.Name == p.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
