using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Airport
{
    class Program
    {
        private static Flight[] arrivalFlights;
        private static Flight[] departureFlights;
        internal const byte deskTableLength = 10;
                                    
        static void Main(string[] args)
        {
            //Console adjastment
            Console.WindowHeight = 35;

            //DeskTableInit tables initalization
            arrivalFlights = DeskTableInit();
            departureFlights = DeskTableInit();

            //Main menu loop
            bool exitBit = false;
            do
            {
                Console.Clear();
                printTable(arrivalFlights,   "Arrivals");
                printTable(departureFlights, "Departures");

                Console.WriteLine("Edit Arrival: \t\tPress 1\nEdit Departures: \tPress 2\nTo Exit: \t\tPress 0");
                
                Int32.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 0:
                        exitBit = true;
                        break;
                    case 1:                                          
                        EditFlight(arrivalFlights, "Arrivals");
                        break;
                    case 2:                                            
                        EditFlight(departureFlights, "Departures");
                        break;                    
                    default:
                        Console.WriteLine("Incorrect input...");
                        break;
                }
            }
            while (!exitBit);

            
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
        

        
        //Method for editing chosen flight
        private static void EditFlight(Flight[] _flights, string _direction)
        {
            bool isCorrectChoice = false;
            Flight flightItem;
            
            do
            {
                Console.Clear();
                printTable(_flights, _direction);
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
                    Console.Clear();
                    printTable(_flights, _direction);
                    Console.WriteLine($"...Editing flight {flightItem.flightID} to(from) {flightItem.cityName}");
                    Console.WriteLine($"1. Flight;\n2. Time;\n3. City;\n4. Air Company;\n5. Terminal;\n6. Gate;\n7. Status;\n0. Press 0 to Exit editing");
                    Console.WriteLine("Select item number to edit...");
                    Int32.TryParse(Console.ReadLine(), out int numOfItemToEdit);

                    Console.Clear();
                    printTable(_flights, _direction);

                    switch (numOfItemToEdit)
                    {
                        case 0:
                            return;                            
                        case 1: //FlightID                            
                            _flights[numOfFlightToEdit - 1].flightID = ChangeStringItemInDesk("flight ID", flightItem.flightID);
                            break;

                        case 2: //Time                            
                            Console.WriteLine("Editing Time");
                            Console.Write($"Change flight ID from {flightItem.time.Hour}:{flightItem.time.Minute} to (in HH:mm format)...:  ");
                            string timeStr = Console.ReadLine();
                            try
                            {
                                _flights[numOfFlightToEdit - 1].time = DateTime.ParseExact(timeStr+":00", "HH:mm:ss", CultureInfo.InvariantCulture);
                                Array.Sort(_flights);
                                Console.WriteLine($"Time changed to {_flights[numOfFlightToEdit - 1].time.Hour.ToString("D2")}:{_flights[numOfFlightToEdit - 1].time.Minute.ToString("D2")}");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Incorrect time Format. Press any key to retry!");
                                isCorrectChoice = false; //Continue loop
                                Console.WriteLine();
                            }                            
                            break;

                        case 3: //City                            
                            _flights[numOfFlightToEdit - 1].cityName = ChangeStringItemInDesk("City", flightItem.cityName);
                            break;

                        case 4: //Air Company
                            _flights[numOfFlightToEdit - 1].airCompany = ChangeStringItemInDesk("Air Company", flightItem.airCompany);
                            break;

                        case 5: //Terminal
                            Console.WriteLine("Editing Terminal");
                            Console.Write($"Change terminal from {flightItem.terminal} to...:  ");
                            ConsoleKey key = Console.ReadKey().Key;
                            Console.ReadLine();
                            if (key >= (ConsoleKey)65 && key <= (ConsoleKey)90)
                            {
                                _flights[numOfFlightToEdit - 1].terminal = Char.Parse(key.ToString());
                                Console.WriteLine($"Terminal changed to {_flights[numOfFlightToEdit - 1].terminal}");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect TErminal input. Press any key to Continue...");
                            }                            
                            break;

                        case 6: //Gate
                            _flights[numOfFlightToEdit - 1].gateID = ChangeStringItemInDesk("Gate ID", flightItem.gateID);
                            break;

                        case 7:
                            Console.WriteLine("Editing Flight Status");
                            break;
                        default:
                            Console.WriteLine("Incorrect input...Press eny key to exit editing");
                            Console.ReadKey();
                            return;                            
                    }
                    //Some actions for editing
                    //break;
                }
                
                Console.ReadKey();
                
            }
            while (!isCorrectChoice);
        }     
        
        //Method for changing string Items in Flight Structure
        private static string ChangeStringItemInDesk(string itemName, string oldItemValue)
        {            
            Console.WriteLine($"Editing {itemName}");
            Console.Write($"Change {itemName} from {oldItemValue} to...:  ");
            string strNewValue = Console.ReadLine();            
            Console.WriteLine($"{itemName} was changed to {strNewValue}. Press any key to Continue...");
            return strNewValue;
        }


    }
}
