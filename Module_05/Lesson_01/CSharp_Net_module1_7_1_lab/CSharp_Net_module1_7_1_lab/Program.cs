using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp_Net_module1_7_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3) create collection of computers;
            // set path to file and file name

            // 4) save data and read it in the seamplest way (with WriteData() and ReadData() methods)

            // 5) save data and read it with WriteZip() and ReadZip() methods
            // Note: create another file for these operations

            // 6) read info about computers asynchronously (from the 1st file)
            // While asynchronous method will be running, Main() method must print ‘*’ 
            
            // use 
            // collection of Task with info about computers as type to get returned data from method ReadAsync()
            // use property Result of collection of Task to get access to info about computers

            // Note:
            // print all info about computers after reading from files


            // ADVANCED:
            // 8) save data to memory stream and from memory to file
            // declare file stream and set it to null
            // call method WriteToMemory() with info about computers as parameter
            // save returned stream to file stream

            // call method WriteToFileFromMemory() with parameter of file stream
            // open file with saved data and compare it with input info
            
                        
            Console.ReadKey();
        }
    }
}
