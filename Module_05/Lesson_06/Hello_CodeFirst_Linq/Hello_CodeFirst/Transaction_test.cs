using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Transactions;

namespace Hello_CodeFirst_Linq
{
    public class Transaction_test
    {
        public void StartOwnTransactionWithinContext()
        {
            using (var ctx = new tect_CodeFirstLingContext())
            {
                using (var dbContextTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var lecturerList = ctx.lecturers.ToList<lecturer>();
                        foreach (var item in ctx.lecturers)
                        {
                            Console.WriteLine(item.lc_lname + "  " + item.lc_fname);
                        }
                        Console.WriteLine("---------------------------------");
                        //Perform create operation
                        Console.WriteLine("Perform create operation");
                        ctx.lecturers.Add(new lecturer() { lc_id = "L_8", lc_fname = "Second lecturer", lc_lname = "sdfs" });

                        //Execute Inser, Update & Delete queries in the database
                        ctx.SaveChanges();
                        
                        var lects1 = ctx.lecturers.ToList<lecturer>();
                        foreach (var item in ctx.lecturers)
                        {
                             Console.WriteLine(item.lc_lname + "  " + item.lc_fname);
                        }
                        Console.WriteLine("---------------------------------");
                        //Perform Update operation
                        Console.WriteLine("Perform Update operation");
                        var lecturerList1 = ctx.lecturers.ToList<lecturer>();
                        lecturer lecturerToUpdate = ctx.lecturers.Where(s => s.lc_fname == "Second lecturer").FirstOrDefault<lecturer>();
                        lecturerToUpdate.lc_fname = "Edited second";
                        //Execute Inser, Update & Delete queries in the database
                        ctx.SaveChanges();
                        Console.WriteLine("Update is succesfully!");
                        dbContextTransaction.Commit();

                        foreach (var item in ctx.lecturers)
                        {
                             Console.WriteLine(item.lc_lname + "  " + item.lc_fname);
                        }
                        
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                    catch(System.Data.Entity.Infrastructure.DbUpdateException e)
                    {
                        Console.WriteLine(e.GetBaseException());
                    }
                }
            }
        }
    }
}


