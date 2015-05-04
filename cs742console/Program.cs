using System;

namespace cs742console
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			printMenu ();

		}

		static void printMenu()
		{
			Console.WriteLine ();
			Console.WriteLine  (
				"1. Hire Manager. \n"+
				"2. File Manager. \n"+
				"3. Move Manager From One Division To Another. \n"+
				"4. Hire Employee. \n"+
				"5. Fire Employee. \n"+
				"6. Move Employee From One Division To Another. \n"+
				"7. Add New Project To Division. \n"+
				"8. Remove Project From Division. \n"+
				"9. Assign Project Within Division. \n"+
				"10. DeAssign Project Within Division. \n"+
				"11. Employee Adding Hours To Project In Division. \n"+
				"12. Complete Project. \n"+
				"13. Report Hours Spent By Employee On Project. \n"+
				"14. Display All Divisions. \n"+
				"15. Display All Managers. \n"+
				"16. Display All Employees By Division. \n"+
				"0. Exit. \n"
			);
			Console.WriteLine ();
		}
	}


}
