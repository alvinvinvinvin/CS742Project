using cs742console.SpecificationModel;
using System;

namespace cs742console
{
	class MainClass
	{
        static Company c;
        static DIVISION_NAME marketing = new DIVISION_NAME("Marketing division");
        static DIVISION_NAME data_quality = new DIVISION_NAME("Data Quality division");
        static DIVISION_NAME software_development = new DIVISION_NAME("Software Development division");
        static DIVISION_NAME real_time_systems = new DIVISION_NAME("Real-Time Systems division");

        // For simplifying problem, I use string as parameter to generate manager and employee objects.
        // However, if you go to check the constructor method of each class, the string parameters still will be
        // converted to NAME object. Therefore the way I generate objects here is just for convenience.
        static Manager cm_M = new Manager("Craig Marhsall");
        static Manager sw_M = new Manager("Steven Wayne");
        static Manager pl_M = new Manager("Peter Larson");
        static Manager jo_M = new Manager("Jack Olson");

        //"Marketing division"
        static Employee jk_E = new Employee("Jane Krusso");
        static Employee jf_E = new Employee("Jim Frank");
        static Employee rw_E = new Employee("Ryan Wester");
        static Employee mr_E = new Employee("Marcie Richter");
        static Employee lc_E = new Employee("Lu Chang");
        static Employee ac_E = new Employee("Amy Chuck");
        //"Data Quality division"
        static Employee lf_E = new Employee("Linda Fagen");
        static Employee rj_E = new Employee("Roger Johnson");
        static Employee dg_E = new Employee("Debra Gretchen");
        static Employee cs_E = new Employee("Chris Spencer");
        static Employee sw_E = new Employee("Steve Wilder");
        static Employee bt_E = new Employee("Bui Thanh");
        static Employee nh_E = new Employee("Nick Heilst");
        static Employee wb_E = new Employee("Walker Bourne");
        static Employee el_E = new Employee("Eric Louis");
        //"Software Development division"
        static Employee ws_E = new Employee("William Sanders");
        static Employee at_E = new Employee("Aaron Torkelson");
        static Employee km_E = new Employee("Kim Mai");
        static Employee lcy_E = new Employee("Lu Choy");
        static Employee wl_E = new Employee("Warren Long");
        static Employee kms_E = new Employee("Katie Murgser");
        static Employee sb_E = new Employee("Sheila Burge");
        static Employee bm_E = new Employee("Bala Murugan");
        static Employee ms_E = new Employee("Mike Stuart");
        static Employee ks_E = new Employee("Kokila Singam");
        static Employee hw_E = new Employee("Hu Wang");
        static Employee dm_E = new Employee("David Meister");
        //"Real-Time Systems division"
        static Employee as_E = new Employee("Arun Shankar");
        static Employee lh_E = new Employee("Lilly Hudson");
        static Employee an_E = new Employee("Ann Niger");
        static Employee cz_E = new Employee("Cheng Zhao");
        static Employee jr_E = new Employee("Jack Richardson");
        static Employee sp_E = new Employee("Samy Pillai");
        static Employee mk_E = new Employee("Michael Kruger");

        static Project img_P = new Project("iPad Math game");
        static Project csfu_P = new Project("CRM software for UW-Stout");
        static Project tlcfj_P = new Project("Traffic Light Controller for Janesville");
        static Project tsvftc_P = new Project("Time-sensitive valve for Trane Company");
        static Project psfwc_P = new Project("Payroll System for Wettstein Company");
        static Project ipp1_P = new Project("Internal project PRJ1");
        static Project ipp2_P = new Project("Internal project PRJ2");
        static Project ipp3_P = new Project("Internal project PRJ3");

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			printMenu ();
            initCompany();
            Console.ReadKey();

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

        static void initCompany()
        {
            try
            {
                c = new Company(marketing, data_quality, software_development, real_time_systems);

                c.HireManager(cm_M, marketing);
                c.HireManager(sw_M, data_quality);
                c.HireManager(pl_M, software_development);
                c.HireManager(jo_M, real_time_systems);

                c.HireEmployee(marketing, jk_E);
                c.HireEmployee(marketing, jf_E);
                c.HireEmployee(marketing, rw_E);
                c.HireEmployee(marketing, mr_E);
                c.HireEmployee(marketing, lc_E);
                c.HireEmployee(marketing, ac_E);

                c.HireEmployee(data_quality, lf_E);
                c.HireEmployee(data_quality, rj_E);
                c.HireEmployee(data_quality, dg_E);
                c.HireEmployee(data_quality, cs_E);
                c.HireEmployee(data_quality, sw_E);
                c.HireEmployee(data_quality, bt_E);
                c.HireEmployee(data_quality, nh_E);
                c.HireEmployee(data_quality, wb_E);
                c.HireEmployee(data_quality, el_E);

                c.HireEmployee(software_development, ws_E);
                c.HireEmployee(software_development, at_E);
                c.HireEmployee(software_development, km_E);
                c.HireEmployee(software_development, lcy_E);
                c.HireEmployee(software_development, wl_E);
                c.HireEmployee(software_development, kms_E);
                c.HireEmployee(software_development, sb_E);
                c.HireEmployee(software_development, bm_E);
                c.HireEmployee(software_development, ms_E);
                c.HireEmployee(software_development, ks_E);
                c.HireEmployee(software_development, hw_E);
                c.HireEmployee(software_development, dm_E);

                c.HireEmployee(real_time_systems, as_E);
                c.HireEmployee(real_time_systems, lh_E);
                c.HireEmployee(real_time_systems, an_E);
                c.HireEmployee(real_time_systems, cz_E);
                c.HireEmployee(real_time_systems, jr_E);
                c.HireEmployee(real_time_systems, sp_E);
                c.HireEmployee(real_time_systems, mk_E);

                //"iPad Math game" img_P
                c.AddNewProjectToDivision(marketing, img_P, 300);
                c.AddNewProjectToDivision(software_development, img_P, 650);
                c.AddNewProjectToDivision(real_time_systems, img_P, 300);

                c.AssignProjectWithinDivision(marketing, img_P, jk_E);
                c.AssignProjectWithinDivision(software_development, img_P, km_E);
                c.AssignProjectWithinDivision(software_development, img_P, kms_E);
                c.AssignProjectWithinDivision(real_time_systems, img_P, an_E);

                c.EmployeeAddingHoursToProjectInDivision(marketing, img_P, jk_E, 14);
                c.EmployeeAddingHoursToProjectInDivision(software_development, img_P, km_E, 78);
                c.EmployeeAddingHoursToProjectInDivision(software_development, img_P, kms_E, 65);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, img_P, an_E, 15);

                //"CRM software for UW-Stout" csfu_P
                c.AddNewProjectToDivision(marketing, csfu_P, 650);
                c.AddNewProjectToDivision(data_quality, csfu_P, 1100);
                c.AddNewProjectToDivision(software_development, csfu_P, 1700);

                c.AssignProjectWithinDivision(marketing, csfu_P, jf_E);
                c.AssignProjectWithinDivision(software_development, csfu_P, ws_E);
                c.AssignProjectWithinDivision(software_development, csfu_P, at_E);
                c.AssignProjectWithinDivision(software_development, csfu_P, km_E);
                c.AssignProjectWithinDivision(software_development, csfu_P, wl_E);
                c.AssignProjectWithinDivision(software_development, csfu_P, lcy_E);
                c.AssignProjectWithinDivision(data_quality, csfu_P, cs_E);
                c.AssignProjectWithinDivision(data_quality, csfu_P, rj_E);
                c.AssignProjectWithinDivision(data_quality, csfu_P, dg_E);

                c.EmployeeAddingHoursToProjectInDivision(marketing, csfu_P, jf_E, 602);
                c.EmployeeAddingHoursToProjectInDivision(software_development, csfu_P, ws_E, 87);
                c.EmployeeAddingHoursToProjectInDivision(software_development, csfu_P, at_E, 640);
                c.EmployeeAddingHoursToProjectInDivision(software_development, csfu_P, km_E, 50);
                c.EmployeeAddingHoursToProjectInDivision(software_development, csfu_P, wl_E, 823);
                c.EmployeeAddingHoursToProjectInDivision(software_development, csfu_P, lcy_E, 164);
                c.EmployeeAddingHoursToProjectInDivision(data_quality, csfu_P, cs_E, 734);
                c.EmployeeAddingHoursToProjectInDivision(data_quality, csfu_P, rj_E, 231);
                c.EmployeeAddingHoursToProjectInDivision(data_quality, csfu_P, dg_E, 116);

                //"Traffic Light Controller for Janesville" tlcfj_P
                c.AddNewProjectToDivision(software_development, tlcfj_P, 2100);
                c.AddNewProjectToDivision(real_time_systems, tlcfj_P, 2400);

                c.AssignProjectWithinDivision(software_development, tlcfj_P, ws_E);
                c.AssignProjectWithinDivision(software_development, tlcfj_P, at_E);
                c.AssignProjectWithinDivision(software_development, tlcfj_P, lcy_E);
                c.AssignProjectWithinDivision(software_development, tlcfj_P, kms_E);
                c.AssignProjectWithinDivision(real_time_systems, tlcfj_P, as_E);
                c.AssignProjectWithinDivision(real_time_systems, tlcfj_P, lh_E);

                c.EmployeeAddingHoursToProjectInDivision(software_development, tlcfj_P, ws_E, 2);
                c.EmployeeAddingHoursToProjectInDivision(software_development, tlcfj_P, at_E, 187);
                c.EmployeeAddingHoursToProjectInDivision(software_development, tlcfj_P, lcy_E, 432);
                c.EmployeeAddingHoursToProjectInDivision(software_development, tlcfj_P, kms_E, 98);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, tlcfj_P, as_E, 112);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, tlcfj_P, lh_E, 108);

                //"Time-sensitive valve for Trane Company" tsvftc_P
                c.AddNewProjectToDivision(software_development, tsvftc_P, 700);
                c.AddNewProjectToDivision(real_time_systems, tsvftc_P, 850);

                c.AssignProjectWithinDivision(software_development, tsvftc_P, ws_E);
                c.AssignProjectWithinDivision(software_development, tsvftc_P, wl_E);
                c.AssignProjectWithinDivision(software_development, tsvftc_P, at_E);
                c.AssignProjectWithinDivision(real_time_systems, tsvftc_P, an_E);
                c.AssignProjectWithinDivision(real_time_systems, tsvftc_P, mk_E);

                c.EmployeeAddingHoursToProjectInDivision(software_development, tsvftc_P, ws_E, 5);
                c.EmployeeAddingHoursToProjectInDivision(software_development, tsvftc_P, wl_E, 432);
                c.EmployeeAddingHoursToProjectInDivision(software_development, tsvftc_P, at_E, 17);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, tsvftc_P, an_E, 412);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, tsvftc_P, mk_E, 198);

                //"Payroll System for Wettstein Company" psfwc_P
                c.AddNewProjectToDivision(marketing, psfwc_P, 1100);
                c.AddNewProjectToDivision(data_quality, psfwc_P, 2100);
                c.AddNewProjectToDivision(software_development, psfwc_P, 5600);
                c.AddNewProjectToDivision(real_time_systems, psfwc_P, 1200);

                c.AssignProjectWithinDivision(marketing, psfwc_P, mr_E);
                c.AssignProjectWithinDivision(data_quality, psfwc_P, sw_E);
                c.AssignProjectWithinDivision(data_quality, psfwc_P, el_E);
                c.AssignProjectWithinDivision(software_development, psfwc_P, sb_E);
                c.AssignProjectWithinDivision(software_development, psfwc_P, bm_E);
                c.AssignProjectWithinDivision(software_development, psfwc_P, hw_E);
                c.AssignProjectWithinDivision(software_development, psfwc_P, dm_E);
                c.AssignProjectWithinDivision(real_time_systems, psfwc_P, cz_E);
                c.AssignProjectWithinDivision(real_time_systems, psfwc_P, sp_E);
                c.AssignProjectWithinDivision(real_time_systems, psfwc_P, mk_E);

                c.EmployeeAddingHoursToProjectInDivision(marketing, psfwc_P, mr_E, 0);
                c.EmployeeAddingHoursToProjectInDivision(data_quality, psfwc_P, sw_E, 10);
                c.EmployeeAddingHoursToProjectInDivision(data_quality, psfwc_P, el_E, 32);
                c.EmployeeAddingHoursToProjectInDivision(software_development, psfwc_P, sb_E, 40);
                c.EmployeeAddingHoursToProjectInDivision(software_development, psfwc_P, bm_E, 110);
                c.EmployeeAddingHoursToProjectInDivision(software_development, psfwc_P, hw_E, 98);
                c.EmployeeAddingHoursToProjectInDivision(software_development, psfwc_P, dm_E, 76);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, psfwc_P, cz_E, 52);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, psfwc_P, sp_E, 31);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, psfwc_P, mk_E, 2);

                //"Internal project PRJ1" ipp1_P
                c.AddNewProjectToDivision(software_development, ipp1_P, 540);

                c.AssignProjectWithinDivision(software_development, ipp1_P, lcy_E);
                c.AssignProjectWithinDivision(software_development, ipp1_P, ks_E);
                c.AssignProjectWithinDivision(software_development, ipp1_P, hw_E);

                c.EmployeeAddingHoursToProjectInDivision(software_development, ipp1_P, lcy_E, 13);
                c.EmployeeAddingHoursToProjectInDivision(software_development, ipp1_P, ks_E, 10);
                c.EmployeeAddingHoursToProjectInDivision(software_development, ipp1_P, hw_E, 7);

                //"Internal project PRJ2" ipp2_P
                c.AddNewProjectToDivision(data_quality, ipp2_P, 150);
                c.AddNewProjectToDivision(software_development, ipp2_P, 600);

                c.AssignProjectWithinDivision(data_quality, ipp2_P, wb_E);
                c.AssignProjectWithinDivision(data_quality, ipp2_P, bt_E);
                c.AssignProjectWithinDivision(software_development, ipp2_P, kms_E);
                c.AssignProjectWithinDivision(software_development, ipp2_P, ks_E);

                c.EmployeeAddingHoursToProjectInDivision(data_quality, ipp2_P, wb_E, 10);
                c.EmployeeAddingHoursToProjectInDivision(data_quality, ipp2_P, bt_E, 3);
                c.EmployeeAddingHoursToProjectInDivision(software_development, ipp2_P, kms_E, 12);
                c.EmployeeAddingHoursToProjectInDivision(software_development, ipp2_P, ks_E, 6);

                //"Internal project PRJ3" ipp3_P
                c.AddNewProjectToDivision(software_development, ipp3_P, 120);
                c.AddNewProjectToDivision(real_time_systems, ipp3_P, 50);

                c.AssignProjectWithinDivision(software_development, ipp3_P, sb_E);
                c.AssignProjectWithinDivision(software_development, ipp3_P, dm_E);
                c.AssignProjectWithinDivision(real_time_systems, ipp3_P, jr_E);
                c.AssignProjectWithinDivision(real_time_systems, ipp3_P, mk_E);

                c.EmployeeAddingHoursToProjectInDivision(software_development, ipp3_P, sb_E, 7);
                c.EmployeeAddingHoursToProjectInDivision(software_development, ipp3_P, dm_E, 14);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, ipp3_P, jr_E, 10);
                c.EmployeeAddingHoursToProjectInDivision(real_time_systems, ipp3_P, mk_E, 3);
            }
            catch (InvariantException iE)
            {
                Console.WriteLine(iE.Message);
            }
            catch (PreconditionException preE)
            {
                Console.WriteLine(preE.Message);
            }
            
        }
	}


}
