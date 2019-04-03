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
                string arrivalStr = "Arrivals <<===== ";
                string departStr = "Departures  =====>>";

                printTable(arrivalFlights,   arrivalStr);
                printTable(departureFlights, departStr);

                Console.WriteLine("Edit Arrival: \t\tPress 1\nEdit Departures: \tPress 2\nTo Exit: \t\tPress 0");
                
                Int32.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 0:
                        exitBit = true;
                        break;
                    case 1:                                          
                        EditFlight(arrivalFlights, arrivalStr);
                        break;
                    case 2:                                            
                        EditFlight(departureFlights, departStr);
                        break;                    
                    default:
                        PrintIncorrectInputString();
                        Console.ReadKey();
                        break;
                }
            }
            while (!exitBit);            
            
        }

        
        //Method for printing Desk Table
        private static void printTable(Flight[] flightDesk, string _direction)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(_direction);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new String('-', 88));
            Console.WriteLine(String.Format("{7, 2} | {0,-8} | {1, -5} | {2,-10} | {3,-12} | {4, -9} | {5,-4} | {6, -15} |", " Flight", " Time", "   City", " Air company", "Terminal", "Gate", "   Status", "#"));
            Console.WriteLine(new String('-', 88));

            for (int i = 0; i < flightDesk.Length; i++)
            {
                Flight flightItem = flightDesk[i];
                Console.WriteLine(String.Format("{8, 2} | {0,-8} | {1}:{2} | {3,-10} | {4,-12} | {5, -9} | {6,-4} | {7, -15} |",flightItem.flightID, flightItem.time.Hour.ToString("D2"), flightItem.time.Minute.ToString("D2"), flightItem.cityName, flightItem.airCompany, flightItem.terminal, flightItem.gateID, flightItem.flightStatus.GetDescription(), i+1));
            }

            Console.WriteLine(new String('-', 88));

            Console.ForegroundColor = ConsoleColor.Gray;
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
                    PrintIncorrectInputString();                    
                    Console.WriteLine("Press 0 to return to Tables...");
                    //break;
                }
                else
                {
                    while (true)
                    {
                        Console.ResetColor();
                        flightItem = _flights[numOfFlightToEdit - 1];
                        Console.Clear();
                        printTable(_flights, _direction);
                        Console.WriteLine($"...Editing flight {flightItem.flightID} to(from) {flightItem.cityName}");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"1. Flight;\n2. Time;\n3. City;\n4. Air Company;\n5. Terminal;\n6. Gate;\n7. Status;\n0. Press 0 to Exit editing");
                        Console.ResetColor();

                        Console.WriteLine("Select item number to edit...");
                        Int32.TryParse(Console.ReadLine(), out int numOfItemToEdit);
                                                
                        Console.Clear();
                        printTable(_flights, _direction);                        

                        switch (numOfItemToEdit)
                        {
                            case 0:                                
                                break;
                            case 1: //FlightID                            
                                _flights[numOfFlightToEdit - 1].flightID = ChangeItemInDesk("flight ID", flightItem.flightID);
                                break;

                            case 2: //Time                            
                                Console.WriteLine("Editing Time");
                                Console.Write($"Change flight ID from {flightItem.time.Hour}:{flightItem.time.Minute} to (in HH:mm format)...:  ");
                                string timeStr = Console.ReadLine();
                                try
                                {
                                    _flights[numOfFlightToEdit - 1].time = DateTime.ParseExact(timeStr + ":00", "HH:mm:ss", CultureInfo.InvariantCulture);
                                    Array.Sort(_flights);
                                    Console.WriteLine($"Time changed to {_flights[numOfFlightToEdit - 1].time.Hour.ToString("D2")}:{_flights[numOfFlightToEdit - 1].time.Minute.ToString("D2")}");
                                }
                                catch (Exception e)
                                {
                                    PrintIncorrectInputString();
                                    isCorrectChoice = false; //Continue loop
                                    Console.WriteLine();
                                }
                                Console.ReadKey();
                                break;

                            case 3: //City                            
                                _flights[numOfFlightToEdit - 1].cityName = ChangeItemInDesk("City", flightItem.cityName);
                                break;

                            case 4: //Air Company
                                _flights[numOfFlightToEdit - 1].airCompany = ChangeItemInDesk("Air Company", flightItem.airCompany);
                                break;

                            case 5: //Terminal                            
                                _flights[numOfFlightToEdit - 1].terminal = ChangeItemInDesk("Terminal", flightItem.terminal);
                                break;

                            case 6: //Gate
                                _flights[numOfFlightToEdit - 1].gateID = ChangeItemInDesk("Gate ID", flightItem.gateID);
                                break;

                            case 7:
                                Console.WriteLine("Editing Flight Status.\nChose the status to set...");

                                //Printing All of statuses
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                foreach (var item in Enum.GetValues(typeof(FlightStatus)))
                                {
                                    Console.WriteLine((int)item + 1 + ". " + ((FlightStatus)item).GetDescription());
                                }                                

                                bool isEnumValue = Int32.TryParse(Console.ReadLine(), out int _flightStatusIndex);

                                //Checking for correct input for the status of Flight
                                if (isEnumValue && _flightStatusIndex > 0 && _flightStatusIndex <= Enum.GetValues(typeof(FlightStatus)).Length)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Flight status changed from \"{flightItem.flightStatus.GetDescription()}\" to \"{((FlightStatus)_flightStatusIndex - 1).GetDescription()}\"");
                                    _flights[numOfFlightToEdit - 1].flightStatus = (FlightStatus)_flightStatusIndex - 1;
                                    Console.ReadKey();
                                }
                                else
                                {
                                    PrintIncorrectInputString();
                                }
                                
                                break;

                            default:
                                PrintIncorrectInputString();                                                                
                                break;
                                //return!!!;                            
                        }
                        //Console.ReadKey();
                    }
                    
                }
                
            }
            while (Console.ReadKey().Key != ConsoleKey.D0);
        }     
        
        //Method for changing string Items in Flight Structure
        private static string ChangeItemInDesk(string itemName, string oldItemValue)
        {            
            Console.WriteLine($"Editing {itemName}");
            Console.Write($"Change {itemName} from {oldItemValue} to...:  ");
            string strNewValue = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{itemName} was changed to {strNewValue}. Press any key to Continue...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
            return strNewValue;
        }

        //Method for changing character Items in Flight Structure
        private static char ChangeItemInDesk(string itemName, char oldItemValue)
        {
            Console.WriteLine($"Editing {itemName}");
            Console.Write($"Change {itemName} from {oldItemValue} to...:  ");
            
            if (Char.TryParse(Console.ReadLine(), out char charItem))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{itemName} was changed to {charItem}. Press any key to Continue...");
                Console.ForegroundColor = ConsoleColor.Gray;
                
            }
            else
            {
                charItem = '?';
                PrintIncorrectInputString();
            }
            Console.ReadKey();
            return charItem;
        }

        //Method for printing IncorrectInput String
        private static void PrintIncorrectInputString()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect input Data. Press any key to continue editing...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }


    }
}
