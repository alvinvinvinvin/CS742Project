using System;

/*
 * NAME class represents the basic type NAME in specification 
 */
namespace cs742company
{
	public class NAME : System.Object, IComparable
	{
		public NAME (String name)
		{
			this.n = name;
		}

        //The "n" will contain the value of NAME object
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

        /// <summary>
        /// Overridden Equals method. It will be used a lot in other classes.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Also have to override gethashcode method to ensure object itself is unique
        /// during comparison.
        /// </summary>
        /// <returns></returns>
		public override int GetHashCode()
		{
			return this.getNAME().GetHashCode();
		}
	}
}

