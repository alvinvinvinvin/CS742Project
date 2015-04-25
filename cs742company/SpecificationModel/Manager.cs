using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class Manager : IComparable<Manager>, IComparable
    {
        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Manager(String name) 
        {
            this.Name = name;
        }

        public int CompareTo(Manager that)
        {
            return this.Name.CompareTo(that.Name);
        }

        public Boolean equals(Manager that)
        {
            if (this.Name.Equals(that.Name)) return true;
            else return false;
        }
    }
}
