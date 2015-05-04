using System;

namespace cs742console
{
	public class NAME : System.Object, IComparable
	{
		public NAME (String name)
		{
			this.n = name;
		}

		private String n;

		public String getNAME()
		{
			return this.n;
		}

		#region IComparable implementation

		public int CompareTo (object that)
		{
			if (that == null) return 1;
			NAME otherNAME = that as NAME;
			if (otherNAME != null)
			{
				return n.CompareTo(otherNAME.getNAME());
			}
			else
			{
				throw new ArgumentException("Object is not a Manager");
			}
		}

		#endregion


		public override bool Equals(System.Object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Employee return false.
			NAME N = obj as NAME;
			if ((System.Object)N == null)
			{
				return false;
			}

			// Return true if the fields match:
			return this.n == N.getNAME();
		}

		public override int GetHashCode()
		{
			return this.getNAME().GetHashCode();
		}
	}
}

