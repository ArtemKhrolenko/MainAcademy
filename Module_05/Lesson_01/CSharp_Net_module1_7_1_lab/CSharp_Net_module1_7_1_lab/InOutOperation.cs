using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace CSharp_Net_module1_7_1_lab
{
    class InOutOperation
    {
        // 1) declare properties  CurrentPath - path to file (without name of file), CurrentDirectory - name of current directory,
        // CurrentFile - name of current file
        public string CurrentPath { get; private set; }
        public string CurrentDirectory { get; private set; }
        public string CurrentFile { get; set; }

        // 2) declare public methods:
        //ChangeLocation() - change of CurrentPath; 
        // method takes new file path as parameter, creates new directories (if it is necessary)
        public void ChangeLocation(string newPath)
        {
            CurrentPath = newPath;
            CreateDirectory();
        }

        // CreateDirectory() - create new directory in current location
        public void CreateDirectory()
        {
            var directory = new DirectoryInfo(CurrentPath);
            //checking on dir existing
            if (directory.Exists)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Directory {directory.FullName} is already exists!");
                Console.ResetColor();
            }
            else
            {
                directory.Create();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Directory {directory.FullName} is created");
                Console.ResetColor();
            }
            CurrentDirectory = directory.Name;
        }

        // WriteData() – save data to file
        // method takes data (info about computers) as parameter
        public void WriteData(IEnumerable<Computer> computerList)
        {
            using (var fileStream = new FileStream(Path.Combine(CurrentPath, CurrentFile), FileMode.OpenOrCreate))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    foreach (var item in computerList)
                    {
                        streamWriter.WriteLine($"{item.Cores}\t{item.Frequency}\t{item.Memory}\t{item.Hdd}");

                    }
                }
            }
        }


        // ReadData() – read data from file
        // method returns info about computers after reading it from file
        public void ReadData()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Cores   Freq    Memory  Hdd");
            Console.ResetColor();
            using (var fileStream = new FileStream(Path.Combine(CurrentPath, CurrentFile), FileMode.Open))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
                
            }
            
            
        }







    }



    // WriteZip() – save data to zip file
    // method takes data (info about computers) as parameter

    // ReadZip() – read data from file
    // method returns info about computers after reading it from file

    // ReadAsync() – read data from file asynchronously
    // method is async
    // method returns Task with info about computers
    // use ReadLineAsync() method to read data from file
    // Note: don't forget about await

    // 7)
    // ADVANCED:
    // WriteToMemoryStream() – save data to memory stream
    // method takes data (info about computers) as parameter
    // info about computers is saved to Memory Stream

    // use  method GetBytes() from class UnicodeEncoding to save array of bytes from string data 
    // create new file stream
    // use method WriteTo() to save memory stream to file stream 
    // method returns file stream

    // WriteToFileFromMemoryStream() – save data to file from memory stream and read it
    // method takes file stream as parameter
    // save data to file      


    // Note: 
    // - use '//' in path string or @ before it (for correct path handling without escape sequence)
    // - use 'using' keyword to organize correct working with files
    // - don't forget to check path before any file or directory operations
    // - don't forget to check existed directory and file before creating
    // use File class to check files, Directory class to check directories, Path to check path



}
