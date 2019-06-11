using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hello_DataSets
{
    public class Common_db
    {
        // define string MyConnectionString
        public string myConnectionString = null;

        // implement Common_db constructor with string parameter for connection string
        public Common_db(string myConnectionString)
        {
            this.myConnectionString = myConnectionString;
        }

        // implement bool MyTable_delete(DataTable usr_table, string key, string key_value) method
        // with parameters fot DataTable , string key name, string key value to delete row

        // define bool result and initiate it with false
        // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString

        // create SqlCommand object for SglConnection object
        // define its CommandText like sql query to select all from "usr_table.tablename" from database

        // create SqlDataAdapter object associated with SqlCommand object

        // populate usr_table by data from database

        // define usr_table primary key by new DataColumn[], initiate it by key value

        // accept changes for usr_table

        //define DataRow object as the usr_table row with key value which equals key_value

        // create string for sql query to delete this row in the database table

        // in try-catch block open connection, create adapter UpdateCommand  using connection CreateCommand method

        // Open connection

        // define UpdateCommand for adapter 
        // define its CommandText for string to delete row
        // execute query

        // exception message output

        // assign true for result

        // return result

        // exception message output
        // return false
        public bool MyTable_delete(DataTable usr_table, string key, string key_value)
        {
            bool result = false;

            return result;
        }



        // implement bool MyTable_update(DataTable usr_table, string key, string key_value, string clmn, string clmn_value) method
        // with parameters fot DataTable , string key name, string key value, string clmn, string clmn_value to update row

        // define bool result and initiate it with false
        // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString

        // create SqlCommand object for SglConnection object
        // define its CommandText like sql query to select all from "usr_table.tablename" from database

        // create SqlDataAdapter object associated with SqlCommand object

        // populate usr_table by data from database

        // define usr_table primary key by new DataColumn[], initiate it by key value

        // accept changes for usr_table

        //define DataRow object as the usr_table row with key value which equals key_value

        // create string for sql query to update this row in the database table

        // in try-catch block open connection, create adapter UpdateCommand  using connection CreateCommand method

        // Open connection
        // define UpdateCommand for adapter 
        // define its CommandText for string to update row
        // execute query

        // exception message output

        // assign true for result

        // return result

        // exception message output
        // return false

        public bool MyTable_update(DataTable usr_table, string key, string key_value, string clmn, string clmn_value)
        {
            bool result = false;

            return result;
        }



        // implement bool MyTable_insert_bldr(string usr_table, string key,  string[] clmn, string[] clmn_value) method
        // with parameters fot DataTable , string key name, string clmn, string clmn_value to insert row

        // define bool result and initiate it with false
        // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString

        // create SqlCommand object for SglConnection object
        // define its CommandText like sql query to select all from "usr_table" from database

        // create SqlDataAdapter object associated with SqlCommand object

        // create new  SqlCommandBuilder  object associated with adapter

        // create new DataSet
        // fill it using usr_table

        // define DataTable object  from DataSet with usr_table name

        // define its primary key by new DataColumn[], initiate it by key value

        // accept changes for DataTable object

        // create next key value using Next_key_gen method

        // declare DataRow object

        // asiign DataTable object NewRow method result to it

        // define it key value

        // assign DataRow object column values in the for loop

        // add this row to the DataTable object

        // call adapter Update method to update usr_table

        // assign true for result

        // return result

        // exception message output
        // return false
        public bool MyTable_insert_bldr(string usr_table, string key, string[] clmn, string[] clmn_value)
        {
            bool result = false;

            return result;
        }


        // implement string Next_key_gen(DataTable dt, string key ) method  to receive the next key value

        // create List<string> new object

        // in foreach loop for DataRow item in dt.Rows add key values to List

        // sort the List object

        // find the last key value

        //Console.WriteLine("Max key: {0} . Write next key value: \r\n", Last_key_value);
        // return Console.ReadLine();



        // implement bool MyTable_update_bldr(string usr_table, string key, string key_value, string clmn, string clmn_value) method
        // with parameters fot table name , string key name,  string key_value,string clmn, string clmn_value to update the table

        // define bool result and initiate it with false
        // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString

        // create SqlCommand object for SglConnection object
        // define its CommandText like sql query to select all from "usr_table" from database


        // create SqlDataAdapter object associated with SqlCommand object

        // Set up the CommandBuilder

        // create new DataSet
        // fill it using usr_table

        // define DataTable object  from DataSet with usr_table name

        // define its primary key by new DataColumn[], initiate it by key value
        // accept changes for DataTable object

        // create DataRow object and assign  DataTable object Rows.Find(key_value) result to it

        // assign to its clmn column clmn_value

        // call adapter Update method to update usr_table

        // assign true for result


        // return result

        // exception message output
        //return false
        public bool MyTable_update_ds(string usr_table, string key, string key_value, string clmn, string clmn_value)
        {
            bool result = false;

            return result;
        }



        // implement bool MyTable_update_ds(string usr_table, string key, string key_value, string clmn, string clmn_value) method
        // with parameters fot table name , string key name,  string key_value, string clmn, string clmn_value to update the table

        // define bool result and initiate it with false
        // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString

        // create SqlCommand object for SglConnection object
        // define its CommandText like sql query to select all from "usr_table" from database

        // create SqlDataAdapter object associated with SqlCommand object

        // create new DataSet
        // fill it using usr_table

        // define DataTable object  from DataSet with usr_table name

        // define its primary key by new DataColumn[], initiate it by key value
        // accept changes for DataTable object

        // create DataRow object and assign  DataTable object Rows.Find(key_value) result to it

        // assign to its clmn column clmn_value

        // create string for sql query to update clmn column for clmn_value where key = key_value

        // in try-catch block open connection, create adapter UpdateCommand  using connection CreateCommand method

        // Open connection
        // define UpdateCommand for adapter 
        // define its CommandText for string to update row
        // call adapter update method to update usr_table


        // exception message output

        // assign true for result

        // return result

        // exception message output
        // return false




        //implement bool MyTable_read(DataTable usr_table) method to read from usr_table
        public bool MyTable_read(DataTable usr_table)
        {
            // define bool result and initiate it with false
            bool result = false;
            // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString
            try
            {
                using (SqlConnection connection = new SqlConnection(this.myConnectionString))
                {
                    // Open connection
                    connection.Open();
                    Console.WriteLine("Checking for connection state... " + $"{connection.State}");

                    // create SqlCommand object for SglConnection object
                    // define its CommandText like sql query to select all from "usr_table" from database
                    SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM {usr_table.TableName}", connection);

                    // create SqlDataAdapter object associated with SqlCommand object
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    // fill  usr_table
                    sqlDataAdapter.Fill(usr_table);

                    // define DataTable object  from DataSet with usr_table name                    

                    // assign true for result
                    result = true;
                }
            }
            catch (Exception e)
            {
                // exception message output
                Console.WriteLine(e.Message);

                // return false
            }

            // return result
            return result;
        }



        // implement MyConnect() method to open and check the connection
        public bool MyConnect()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("MyConnect Method");
            Console.ResetColor();
            // define bool result and initiate it with false
            bool connectionResult = false;

            // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString
            try
            {
                using (SqlConnection connection = new SqlConnection(this.myConnectionString))
                {
                    Console.WriteLine("Checking for connection state... " + $"{connection.State}");
                    // Open connection
                    connection.Open();
                    Console.WriteLine("Checking for connection state... " + $"{connection.State}");

                    // assign true for result
                    connectionResult = true;
                }
            }
            catch (Exception e)
            {
                // exception message output
                Console.WriteLine(e.Message);
                // return false                
            }

            // return result
            Console.WriteLine($"Connetion {(connectionResult ? "Established" : "is Not Established")}");
            Console.WriteLine("----------------------");
            return connectionResult;
        }


        // implement ??MyDissConnect() method to close and check the connection
        public bool MyDissConnect()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("MyDissConnect Method");
            Console.ResetColor();

            // define bool result and initiate it with false
            bool dissConnectionResult = false;

            // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString
            try
            {
                using (SqlConnection connection = new SqlConnection(this.myConnectionString))
                {
                    Console.WriteLine("Checking for connection state... " + $"{connection.State}");
                    // close connection
                    connection.Close();

                    // assign true for result
                    dissConnectionResult = true;
                }
            }
            catch (Exception e)
            {
                // exception message output
                Console.WriteLine(e.Message);
                // return false                
            }

            // return result
            Console.WriteLine($"Connetion {(dissConnectionResult ? "Closed" : "is Not Closed")}");
            Console.WriteLine("----------------------");
            return dissConnectionResult;
        }

    }
}
