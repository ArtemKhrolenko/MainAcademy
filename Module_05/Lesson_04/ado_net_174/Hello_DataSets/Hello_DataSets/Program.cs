using System;
using System.Configuration;

namespace Hello_DataSets
{
    class Program
    {

        static void Main(string[] args)
        {
            // update connection string for current LocalDB instance 
            Console.WindowWidth = 200;
            string connectionString = ConfigurationManager.ConnectionStrings["Hello_DataSets.Properties.Settings.tect_datasets_dbConnectionString"].ConnectionString;            
            
            //DB_work mywrk = new DB_work(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\tect_datasets_db.mdf;Integrated Security=True;Connect Timeout=30");
            DB_work mywrk = new DB_work(connectionString);
            
            mywrk.DB_conn();
            
            
            Console.WriteLine("Reading courses table");
            mywrk.Courses_Read("courses");
            Console.WriteLine();

            /*
            Console.WriteLine("Update courses table");
            mywrk.Courses_Update("courses", "course_id", "C13", "begin_date", "2014-01-06");

            Console.WriteLine("Reading courses table");
            mywrk.Courses_Read("courses");
            Console.WriteLine();

            Console.WriteLine("Update courses table by DataSet");
            mywrk.Courses_Update_ds("courses", "course_id", "C13", "begin_date", "2013-01-01");

            Console.WriteLine("Reading courses table");
            mywrk.Courses_Read("courses");
            Console.WriteLine();

            Console.WriteLine("Update courses table by Builder");
            mywrk.Courses_Update_bldr("courses", "course_id", "C13", "begin_date", "2012-01-01");

            Console.WriteLine("Reading courses table");
            mywrk.Courses_Read("courses");
            Console.WriteLine();

            Console.WriteLine("Insert  to courses table by Builder");
            string[] clmns = new string[] { "course_name", "contract", "facl_id" };
            string[] clmn_values = new string[] { "biology", "0", "" };
            mywrk.Courses_Insert_bldr("courses", "course_id", clmns, clmn_values);

            Console.WriteLine("Reading courses table");
            mywrk.Courses_Read("courses");
            Console.WriteLine();

            Console.WriteLine("Delete from courses table");

            Console.WriteLine("Write  key to delete: \r\n");
            string del_key = Console.ReadLine();
            mywrk.Courses_Delete("courses", "course_id", del_key);

            Console.WriteLine("Reading courses table");
            mywrk.Courses_Read("courses");
            
            Console.ReadKey();
            */
        }



    }
}
