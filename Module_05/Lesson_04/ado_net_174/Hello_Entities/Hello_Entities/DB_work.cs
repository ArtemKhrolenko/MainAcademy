using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.EntityClient;
using System.Data;

namespace Hello_Entities
{
    class DB_work
    {

        // implement bool lecturer_check() method to write lecturers

                // implement try-catch block with using block for  var ctx = new tect_entities_dbEntities()
                // to write lecturers in foreach loop


                    //lecturer cur_lecturer = ctx.lecturers.FirstOrDefault<lecturer>();
                    //Console.WriteLine("Last lecturer: lc_id {0}, name {1} {2}", cur_lecturer.lc_id, cur_lecturer.lc_fname, cur_lecturer.lc_lname);


        // implement bool lecturer_find(string key) method to find the  lecturer by primary key

            // implement try-catch block with using block var ctx = new tect_entities_dbEntities() 

                    //use ctx.lecturers.Find(key) method call
 
        
         

        // implement bool lecturer_phoneUpd(string key, string phone) method to update the  lecturer phone number       

                // implement try-catch block with using block var ctx = new tect_entities_dbEntities() 

                    //use ctx.lecturers.Find(key) method call

                        //assign parameter value to phone property

                        //ctx.SaveChanges();
                        //rslt = true;




        // implement bool lecturer_entRdr(string clmn, string clmn_value, Dictionary<string, string> dict) method to read the  lecturers information       

                // implement try-catch block with using block var con = new EntityConnection(@"name = tect_entities_dbEntities")

                    // open connection
                    // create EntityCommand by CreateCommand() method

                    // define CommandText for the select query with where statement clmn column = clmn_value


                    // implement using block for EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection)

                        // create while (rdr.Read())  loop

                            // to read 
                            // var a = rdr.GetString(0);
                            // var b = rdr.GetString(1);
                            // dict.Add(a, b);


    }
}
