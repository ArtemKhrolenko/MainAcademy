using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
        private static Flight[] arrivalFlights;
        private static Flight[] departureFlights;
        internal const byte deskTableLength = 10;
                                    
        static void Main(string[] args)
        {
            arrivalFlights = DeskTableInit();
            departureFlights = DeskTableInit();

            do
            {
                Console.Clear();
                printTable(arrivalFlights,   "Arrivals");
                printTable(departureFlights, "Departures");

                Console.WriteLine("Edit Arrival: Press 1\nEdit Departures: Press 2...");
                
                Int32.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:                                          
                        EditFlight(ref arrivalFlights, "Arrivals");
                        break;
                    case 2:                                            
                        EditFlight(ref departureFlights, "Departures");
                        break;
                    default:
                        Console.WriteLine("Incorrect input...");
                        break;
                }
            }
            while (Console.ReadKey().Key != ConsoleKey.Spacebar);

            
            //Console.ReadKey();


            #region printValues
            //foreach(var item in Enum.GetValues(typeof(FlightStatus)))
            //{
            //    Console.WriteLine(((FlightStatus)item).GetDescription());
            //}

            //ConsoleKeyInfo cki;
            //do
            //{

            //}
            //while (Console.ReadKey().Key != ConsoleKey.Spacebar);           
            #endregion

        }

        #region Printing Desk Table
        //Method for printing Desk Table
        private static void printTable(Flight[] flightDesk, string _direction)
        {
            Console.WriteLine(_direction);
            Console.WriteLine(new String('-', 88));
            Console.WriteLine(String.Format("{7, 2} | {0,-8} | {1, -5} | {2,-10} | {3,-12} | {4, -9} | {5,-4} | {6, -15} |", " Flight", " Time", "   City", " Air company", "Terminal", "Gate", "   Status", "#"));
            Console.WriteLine(new String('-', 88));

            for (int i = 0; i < flightDesk.Length; i++)
            {
                Flight flightItem = flightDesk[i];
                Console.WriteLine(String.Format("{8, 2} | {0,-8} | {1}:{2} | {3,-10} | {4,-12} | {5, -9} | {6,-4} | {7, -15} |",flightItem.flightID, flightItem.time.Hour.ToString("D2"), flightItem.time.Minute.ToString("D2"), flightItem.cityName, flightItem.airCompany, flightItem.terminal, flightItem.gateID, flightItem.flightStatus.GetDescription(), i+1));
            }

            Console.WriteLine(new String('-', 88));
        }
        #endregion

        #region Initalize Desk Table
        //Method for Desk Table initalization
        private static Flight[] DeskTableInit()        
        {
            Flight[] _deskTable = new Flight[deskTableLength];
            Random rnd = new Random();
            for (int i = 0; i < _deskTable.Length; i++)
            {
                _deskTable[i] = new Flight(rnd); //random initalization
            }
            Array.Sort(_deskTable);
            return _deskTable;
        }
        #endregion

        #region EditFlight
        //Method for editing chosen flight
        private static void EditFlight(ref Flight[] _flights, string _direction)
        {
            bool isCorrectChoice = false;
            Flight flightItem;
            
            do
            {
                Console.Clear();
                printTable(arrivalFlights, _direction);
                Console.Write($"Enter number of flight you want to edit...");

                Int32.TryParse(Console.ReadLine(), out int numOfFlightToEdit);
                isCorrectChoice = numOfFlightToEdit > 0 && numOfFlightToEdit <= deskTableLength;
                
                if (!isCorrectChoice)
                {
                    Console.WriteLine("Incorrect input...Press any key to retry!");                 
                }
                else
                {
                    flightItem = _flights[numOfFlightToEdit - 1];

                    Console.WriteLine($"...Editing flight {flightItem.flightID} to(from) {flightItem.cityName}");
                    Console.WriteLine($"1. Flight;\n2. Time;\n3. City;\n4. Air Company;\n5. Terminal;\n6. Gate;\n7. Status;");
                    //Some actions for editing
                    break;
                }
                
                Console.ReadKey();
                
            }
            while (!isCorrectChoice);
        }

        #endregion


    }
}
