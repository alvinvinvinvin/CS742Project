﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs742company.SpecificationModel
{
    class Manager : System.Object, IComparable
    {

		public NAME Name {
			get;
			set;
		}

        public Manager(String name) 
        {
			this.Name = new NAME(name);
        }

        int IComparable.CompareTo(System.Object that)
        {
            if (that == null) return 1;
            Manager otherManager = that as Manager;
            if (otherManager != null)
            {
                return this.Name.CompareTo(otherManager.Name);
            }
            else
            {
                throw new ArgumentException("Object is not a Manager");
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
            Manager m = obj as Manager;
            if ((System.Object)m == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this.Name == m.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
