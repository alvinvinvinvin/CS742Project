using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class Employee : IComparable<Employee>, IComparable
    {
        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Employee(String name) 
        {
            this.Name = name;
        }

        public int CompareTo(Employee that) 
        {
            return this.Name.CompareTo(that.Name);
        }

        public Boolean equals(Employee that) 
        {
            if (this.Name.Equals(that.Name)) return true;
            else return false;
        }
    }
}
