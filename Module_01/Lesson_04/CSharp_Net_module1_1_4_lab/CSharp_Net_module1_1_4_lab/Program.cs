using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_1_4_lab
{
    class Program
    {
        // 1) declare enum ComputerType
        enum ComputerType
        {
            Desktop,
            Laptop,
            Server
        }

        // 2) declare struct Computer
        struct Computer
        {
            internal int CPUcores;
            internal double CPUFrequency;
            internal int CPUmemory;
            internal int CPUHdd;
            internal ComputerType type;
                

            internal Computer(ComputerType _type)
            {
                type = _type;
                switch (_type)
                {
                    case ComputerType.Desktop:
                        CPUcores     = 4;       //4 Cores
                        CPUFrequency = 2.5;     //2.5 GHz
                        CPUmemory    = 8;       //8 GB RAM
                        CPUHdd       = 500;     //500 GB HDD 
                        break;

                    case ComputerType.Laptop:
                        CPUcores     = 2;       //2 Cores
                        CPUFrequency = 1.7;     //1.7 GHz
                        CPUmemory    = 4;       //4 GB RAM
                        CPUHdd       = 250;     //500 GB HDD 
                        break;

                    case ComputerType.Server:
                        CPUcores     = 8;       //8 Cores
                        CPUFrequency = 3;       //3 GHz
                        CPUmemory    = 16;      //4 GB RAM
                        CPUHdd       = 2048;    //2 TB HDD 
                        break;

                    default:
                        CPUcores     = -1;      //8 Cores
                        CPUFrequency = -1;      //3 GHz
                        CPUmemory    = -1;      //4 GB RAM
                        CPUHdd       = -1;      //2 TB HDD 
                        break;
                }
            }

        } 

        static void Main(string[] args)
        {
            // 3) declare jagged array of computers size 4 (4 departments)
            Computer[][] computersArray = new Computer[4][];

            // 4) set the size of every array in jagged array (number of computers)
            computersArray[0] = new Computer[5] { new Computer(ComputerType.Desktop),
                                                  new Computer(ComputerType.Desktop),
                                                  new Computer(ComputerType.Laptop),
                                                  new Computer(ComputerType.Laptop),
                                                  new Computer(ComputerType.Server)};

            computersArray[1] = new Computer[3] { new Computer(ComputerType.Laptop),
                                                  new Computer(ComputerType.Laptop),
                                                  new Computer(ComputerType.Laptop)};

            computersArray[2] = new Computer[5] { new Computer(ComputerType.Desktop),
                                                  new Computer(ComputerType.Desktop),
                                                  new Computer(ComputerType.Desktop),
                                                  new Computer(ComputerType.Laptop),
                                                  new Computer(ComputerType.Laptop)}; 

            computersArray[3] = new Computer[4] { new Computer(ComputerType.Desktop),
                                                  new Computer(ComputerType.Laptop),
                                                  new Computer(ComputerType.Server),
                                                  new Computer(ComputerType.Server)};


            Console.WriteLine("All computers: \n");
            int i = 0;
            foreach (var item in computersArray)
            {
                Console.WriteLine($"Department# {++i}");
                foreach (Computer comp in item)
                {
                    Console.WriteLine($"Type = {comp.type};  CPU = {comp.CPUcores};  RAM = {comp.CPUmemory};  HDD = {comp.CPUHdd}");
                }
                Console.WriteLine();
            }

            // 5) initialize array
            // Note: use loops and if-else statements


            // 6) count total number of every type of computers
            // 7) count total number of all computers
            // Note: use loops and if-else statements
            // Note: use the same loop for 6) and 7)



            // 8) find computer with the largest storage (HDD) - 
            // compare HHD of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements


            // 9) find computer with the lowest productivity (CPU and memory) - 
            // compare CPU and memory of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            // Note: use logical oerators in statement conditions


            // 10) make desktop upgrade: change memory up to 8
            // change value of memory to 8 for every desktop. Don't do it for other computers
            // Note: use loops and if-else statements

        }

    }
}
