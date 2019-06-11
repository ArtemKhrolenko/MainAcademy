using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Hello_DataSets
{
    class DB_work
    {
        // declare    Common_db MyDBtest   
        Common_db MyDBtest;

        // implement DB_work(string conn) constructor to initiate MyDBtest
        public DB_work(string ConnString)
        {
            MyDBtest = new Common_db(ConnString);
        }



        // implement  void DB_conn() to check the MyDBtest 
        // try check connection using MyConnect() and MyDisConnect()
        public void DB_conn()
        {
            MyDBtest.MyConnect();
            MyDBtest.MyDissConnect();

        }



        // implement void Courses_Update_ds(string table_name, string key, string key_value, string clmn, string clmn_value)
        // to update table_name using MyDBtest.MyTable_update_ds method with parameters in try-catch block



        // implement void Courses_Insert_bldr(string table_name, string key,  string [] clmn, string[] clmn_value)
        // to insert into table_name using MyDBtest.MyTable_insert_bldr method with parameters in try-catch block



        // implement void Courses_Update_bldr(string table_name, string key, string key_value, string clmn, string clmn_value)
        // to update table_name using MyDBtest.MyTable_update_bldr method with parameters in try-catch block



        // implement void Courses_Update(string table_name, string key, string key_value, string clmn, string clmn_value)
        // to update table_name using MyDBtest.MyTable_update method with parameters in try-catch block

        //create new DataTable object and define its TableName property

        //call MyDBtest.MyTable_update with parameters



        // implement void Courses_Read(string table_name) method






        public void Courses_Read(string table_name)
        {
            //create new DataTable object and define its TableName property
            DataTable dataTable = new DataTable { TableName = table_name };

            // to read table_name using MyDBtest.MyTable_read method with parameters in try-catch block
            try
            {
                //call MyDBtest.MyTable_read with parameter
                bool readResult = MyDBtest.MyTable_read(dataTable);

                //foreach DataRow item  write its value to the console
                if (readResult)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        Console.Write($"{column.ColumnName,-22}");
                    }

                    Console.ResetColor();
                    Console.WriteLine();


                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            Console.Write($"{row[column].ToString(),-22}");
                        }
                        Console.WriteLine();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }



        // implement Courses_Delete(string table_name, string key, string key_value) method
        // to delete row from the table_name using MyDBtest.MyTable_delete method with parameters in try-catch block

        //create new DataTable object and define its TableName property

        //call MyDBtest.MyTable_delete with parameters


    }
}
