using System;
using System.Collections.Generic;
using System.IO;
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
            List<Computer> computersList = new List<Computer>();
            #region Filling ComputerList
            computersList.Add(new Computer{Cores = 4, Frequency = 2.5, Hdd = 500,  Memory = 8 });
            computersList.Add(new Computer{Cores = 8, Frequency = 3.2, Hdd = 2048, Memory = 4 });
            computersList.Add(new Computer{Cores = 2, Frequency = 3.5, Hdd = 320,  Memory = 16 });
            computersList.Add(new Computer{Cores = 6, Frequency = 1.5, Hdd = 1025, Memory = 12 });
            #endregion
            
            // set path to file and file name
            InOutOperation op = new InOutOperation();
            
            //Path to File
            op.ChangeLocation(@"D:\Khrolenko\C#\MainAcademy\Module_05\Lesson_01\CSharp_Net_module1_7_1_lab\StorageFolder"); 
            //File name
            op.CurrentFile = @"ComputerInfo.txt";

            // 4) save data and read it in the seamplest way (with WriteData() and ReadData() methods)

            Console.WriteLine("1. Writing data to File...");
            op.WriteData(computersList);

            Console.WriteLine("2. Reading data data from file...");
            op.ReadData();

            // 5) save data and read it with WriteZip() and ReadZip() methods
            // Note: create another file for these operations
            Console.WriteLine("3. Creating ZIP-archive from List of computers...");
            op.WriteZip(computersList);

            Console.WriteLine("4. Reading data from ZIP-file...");
            op.ReadZip();

            // 6) read info about computers asynchronously (from the 1st file)
            // While asynchronous method will be running, Main() method must print ‘*’ 

            // use 
            // collection of Task with info about computers as type to get returned data from method ReadAsync()
            // use property Result of collection of Task to get access to info about computers

            // Note:
            // print all info about computers after reading from files

            Console.WriteLine("6. Reading data asycnhroniously...");
            
            op.MiddleAsyncMethod();

            // ADVANCED:
            // 8) save data to memory stream and from memory to file
            // declare file stream and set it to null
            // call method WriteToMemory() with info about computers as parameter
            // save returned stream to file stream

            Console.WriteLine("8. Advanced...");            
            FileStream fileStream = op.WriteToMemoryStream(computersList);

            // call method WriteToFileFromMemory() with parameter of file stream
            // open file with saved data and compare it with input info
            
                        
            Console.ReadKey();
        }
        
        
    }
}
