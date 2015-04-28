using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting
{
    class Program
    {
        class Employee : System.Object, IComparable
        {
            private String name;
            

            public Employee(String p)
            {
                // TODO: Complete member initialization
                this.Name = p;
            }
            public String Name 
            {
                get { return name; }
                set { name = value; }
            }

            int IComparable.CompareTo(System.Object that)
            {
                if (that == null) return 1;
                Employee otherEmployee = that as Employee;
                if (otherEmployee != null)
                {
                    return this.Name.CompareTo(otherEmployee.Name);
                }
                else
                {
                    throw new ArgumentException("Object is not an Employee");
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
                Employee e = obj as Employee;
                if ((System.Object)e == null)
                {
                    return false;
                }

                // Return true if the fields match:
                return this.Name == e.Name ;
            }

            public override int GetHashCode()
            {
                return this.Name.GetHashCode();
            }
        }

        class testException : Exception
        {
            public testException(String test)
            {
                Console.WriteLine(test);
            }
        }

		int number;
        private HashSet<String> testHashSet;

		public HashSet<String> TestHashSet
		{
			get{ return testHashSet; }
			set{ testHashSet = value;}
		}


        static void Main(string[] args)
        {
            Employee a = new Employee("employee A");
            Employee b = new Employee("employee B");
            Employee a1 = new Employee("employee A");
            Console.WriteLine("a == b: {0}",a == b);
            Console.WriteLine("a == a1: {0}", a == a1);

            //exception test
            //throw new testException("test here");

            Console.WriteLine("a.Name == b.Name: {0}", a.Name == b.Name);
            Console.WriteLine("a.Name == a1.Name: {0}", a.Name == a1.Name);
            Console.WriteLine("a.Name.Equals(a1.Name): {0}", a.Name.Equals(a1.Name));
            Console.WriteLine("a.Equals(b): {0}",a.Equals(b));
            Console.WriteLine("a.Equals(a1): {0}",a.Equals(a1));
            //Console.WriteLine("a.CompareTo(b): {0}",a.CompareTo(b));
            SortedSet<Employee> list = new SortedSet<Employee>();
            list.Add(b);
            list.Add(a);
            Console.WriteLine("SortedList: {0} , {1}", list.ElementAt(0).Name, list.ElementAt(1).Name);
            Console.WriteLine("SortedList.Contains(a1): {0}", list.Contains(a1));
            SortedSet<Employee> list1 = new SortedSet<Employee>();
            //list1.Add(a1);
            list1.Add(b);
            list1.Add(a);
            list1.Add(a1);
            foreach (Employee e in list1)
            {
                Console.Write(e.Name + "   ");
            }
            Employee a2 = new Employee("employee A");
            Console.WriteLine(list.Except(list1).Any());
            Console.WriteLine("remove a2: {0}",list1.Remove(a2));
            foreach (Employee e in list1) 
            {
                Console.Write(e.Name+"   ");
            }
            Program p1 = new Program();
            String s1 = "a";
            String s2 = "a";
            String s3 = "b";
            String s4 = "c";
            List<String> temp = new List<String>(4);
            List<String> temp2 = new List<string>(3);
            temp2.TrimExcess();
            temp.Add(s1);
            temp.Add(s2);
            temp.Add(s3);
            temp.Add(s4);
            temp.TrimExcess();
            p1.TestHashSet = new HashSet<string>(temp2);
            //p1.TestHashSet.TrimExcess();
            //p1.TestHashSet = new HashSet<String>();
            Console.WriteLine(p1.TestHashSet.Count);
            Console.ReadKey();
        }
    }
}
