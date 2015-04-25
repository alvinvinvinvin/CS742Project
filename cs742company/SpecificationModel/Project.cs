using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class Project : IComparable<Project>, IComparable
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

        public int CompareTo(Project that)
        {
            return this.Name.CompareTo(that.Name);
        }

        public Boolean equals(Project that)
        {
            if (this.Name.Equals(that.Name)) return true;
            else return false;
        }
    }
}
