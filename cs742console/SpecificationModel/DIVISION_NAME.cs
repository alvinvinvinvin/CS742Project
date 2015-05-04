using System;

namespace cs742console
{
	public class DIVISION_NAME : System.Object, IComparable
	{
		public DIVISION_NAME (String name)
		{
			n = name;
		}

		String n;

		public String getDIVISION_NAME()
		{
			return n;
		}

		public int CompareTo(System.Object that)
		{
			if (that == null) return 1;
			DIVISION_NAME otherDIVISION_NAME = that as DIVISION_NAME;
			if (otherDIVISION_NAME != null)
			{
				return n.CompareTo(otherDIVISION_NAME.getDIVISION_NAME());
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
			DIVISION_NAME D_N = obj as DIVISION_NAME;
			if ((System.Object)D_N == null)
			{
				return false;
			}

			// Return true if the fields match:
			return n == D_N.getDIVISION_NAME();
		}

		public override int GetHashCode()
		{
			return getDIVISION_NAME().GetHashCode();
		}
	}
}

