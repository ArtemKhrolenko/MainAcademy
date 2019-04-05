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
                        return;
                        
                    case 1:                                          
                        EditFlight(arrivalFlights, arrivalStr);
                        break;
                    case 2:                                            
                        EditFlight(departureFlights, departStr);
                        break;                    
                    default:
                        //PrintIncorrectInputString(false);
                        Console.ReadKey();
                        break;
                }
            }
            while (true);            
            
        }

        
        //Method for printing Desk Table
        private static void printTable(Flight[] flightDesk, string _direction)
        {            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(_direction);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new String('-', 90));            
            Console.WriteLine(String.Format("{7, 2} | {0,-8} | {1, -5} | {2,-10} | {3,-12} | {4, -9} | {5,-4} | {6, -17} |", " Flight", " Time", "   City", " Air company", "Terminal", "Gate", "   Status", "#"));            
            Console.WriteLine(new String('-', 90));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string tmpTimeStr;

            for (int i = 0; i < flightDesk.Length; i++)
            {
                Flight flightItem = flightDesk[i];
                tmpTimeStr = flightItem.flightStatus == FlightStatus.DEPARTED_AT || flightItem.flightStatus == FlightStatus.EXPECTED_AT ? flightItem.statusTime.Hour.ToString("D2") + ":" + flightItem.statusTime.Minute.ToString("D2") : "";                
                Console.WriteLine(String.Format("{8, 2} | {0,-8} | {1}:{2} | {3,-10} | {4,-12} | {5, -9} | {6,-4} | {7, -11} {9, -5} |",
                    flightItem.flightID, flightItem.time.Hour.ToString("D2"), flightItem.time.Minute.ToString("D2"), flightItem.cityName, flightItem.airCompany, flightItem.terminal, flightItem.gateID, flightItem.flightStatus.GetDescription(), i+1, tmpTimeStr));
            }

            Console.WriteLine(new String('-', 90));

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
            //Array.Sort(_deskTable);
            BubbleSort(_deskTable);
            return _deskTable;
        }
        

        
        //Method for editing chosen flight
        private static void EditFlight(Flight[] _flights, string _direction)
        {
            
            Flight flightItem;

            bool goAhead = true;
            do
            {
                Console.Clear();
                printTable(_flights, _direction);
                Console.Write($"Enter number of flight you want to edit...Or press 0 to exit...");

                Int32.TryParse(Console.ReadLine(), out int numOfFlightToEdit);

                if (numOfFlightToEdit == 0) return;

                if (numOfFlightToEdit < 0 || numOfFlightToEdit >= deskTableLength)
                {
                    PrintIncorrectInputString(ref goAhead);  
                }
                else
                {
                    bool goAheadL2 = true;
                    while (goAhead)
                    {
                        Console.Clear();
                        Console.ResetColor();
                        flightItem = _flights[numOfFlightToEdit - 1];                        
                        printTable(_flights, _direction);
                        Console.WriteLine($"...Editing flight {flightItem.flightID} to(from) {flightItem.cityName}");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"1. Flight;\n2. Time;\n3. City;\n4. Air Company;\n5. Terminal;\n6. Gate;\n7. Status;\n0. Press 0 to Exit editing");
                        Console.ResetColor();

                        Console.WriteLine("Select item number to edit...");
                        Int32.TryParse(Console.ReadLine(), out int numOfItemToEdit);  


                        switch (numOfItemToEdit)
                        {
                            case 0:                                
                                return;
                            case 1: //FlightID                      

                                Console.Clear();
                                printTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].flightID = ChangeItemInDesk("flight ID", flightItem.flightID, 8);
                                break;

                            case 2: //Time   

                                Console.Clear();
                                printTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].time = ChangeItemInDesk("Time", flightItem.time, ref goAhead);                                
                                //Array.Sort(_flights);
                                BubbleSort(_flights);
                                break;

                            case 3: //City                            

                                Console.Clear();
                                printTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].cityName = ChangeItemInDesk("City", flightItem.cityName, 10);
                                break;

                            case 4: //Air Company

                                Console.Clear();
                                printTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].airCompany = ChangeItemInDesk("Air Company", flightItem.airCompany, 12);
                                break;

                            case 5: //Terminal                            

                                Console.Clear();
                                printTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].terminal = ChangeItemInDesk("Terminal", flightItem.terminal, ref goAhead);
                                break;

                            case 6: //Gate

                                Console.Clear();
                                printTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].gateID = ChangeItemInDesk("Gate ID", flightItem.gateID, 4);
                                break;

                            case 7:
                                Console.Clear();
                                printTable(_flights, _direction);
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
                                    _flights[numOfFlightToEdit - 1].flightStatus = (FlightStatus)_flightStatusIndex - 1;

                                    //if Status == Departed At OR Departed AT - ask user about exat time of departing or excepting
                                    if ((FlightStatus)_flightStatusIndex - 1 == FlightStatus.DEPARTED_AT || (FlightStatus)_flightStatusIndex - 1 == FlightStatus.EXPECTED_AT)
                                    {                                        
                                        _flights[numOfFlightToEdit - 1].statusTime = ChangeItemInDesk("Time of Departure or Arrival", flightItem.statusTime, ref goAhead);
                                    }

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Flight status changed from \"{flightItem.flightStatus.GetDescription()}\" to \"{((FlightStatus)_flightStatusIndex - 1).GetDescription()}\". Press any key to Continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    PrintIncorrectInputString(ref goAhead);
                                }
                                
                                break;

                            default:
                                PrintIncorrectInputString(ref goAhead);                                                                
                                break;                                                    
                        }
                        
                    }
                    
                }
                
            }
            while (goAhead);
        }     
        
        //Method for changing string Items in Flight Structure
        private static string ChangeItemInDesk(string itemName, string oldItemValue, int length)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Editing {itemName}");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write($"Change {itemName} from {oldItemValue} to...:  ");
            string strNewValue = Console.ReadLine();
            if (strNewValue.Length > length)
            {
                strNewValue = strNewValue.Substring(0, length);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{itemName} was changed to {strNewValue}. Press any key to Continue...");
            Console.ResetColor();
            Console.ReadKey();
            return strNewValue;
        }

        //Method for changing character Items in Flight Structure
        private static char ChangeItemInDesk(string itemName, char oldItemValue, ref bool _internalLoopFlag)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Editing {itemName}");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write($"Change {itemName} from {oldItemValue} to...:  ");
            
            if (Char.TryParse(Console.ReadLine(), out char charItem) && charItem > 64 && charItem < 91)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{itemName} was changed to {charItem}. Press any key to Continue...");
                Console.ForegroundColor = ConsoleColor.Gray;
                
            }
            else
            {
                PrintIncorrectInputString(ref _internalLoopFlag);
                return oldItemValue;
                
            }

            Console.ResetColor();
            Console.ReadKey();
            return charItem;
        }

        //Method for changing time Items in Flight Structure
        private static DateTime ChangeItemInDesk(string itemName, DateTime oldItemValue, ref bool _internalLoopFlag)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Editing {itemName}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Change time from {oldItemValue.Hour.ToString("D2")}:{oldItemValue.Minute.ToString("D2")} to (in HH:mm format)...:  ");

            DateTime _newDateTime = DateTime.Now;
            try
            {
                _newDateTime = DateTime.ParseExact(Console.ReadLine() + ":00", "HH:mm:ss", CultureInfo.InvariantCulture);               
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Time changed to {_newDateTime.Hour.ToString("D2")}:{_newDateTime.Minute.ToString("D2")}. Press any key to continue...");
            }
            catch (Exception e)
            {
                
                PrintIncorrectInputString(ref _internalLoopFlag);
                return oldItemValue;
            }
            Console.ResetColor();
            Console.ReadKey();
            return _newDateTime;
        }

        //Method for printing IncorrectInput String
        private static void PrintIncorrectInputString(ref bool _goAhead)
        {            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Incorrect input Data. Continue editing? y/n:  ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string userAnswer = Console.ReadLine();
            if (userAnswer == "n")
                _goAhead = false;
            
        }

        //Method for sorting Table
        private static void BubbleSort(Flight[] flightDesk)
        {
            Flight tmpFlight;
            
            for (int i = 0; i < flightDesk.Length - 1; i++)
            {
                for (int j = 0 ; j < flightDesk.Length - 1 - i; j++)
                {
                    if (flightDesk[j].time > flightDesk[j + 1].time)
                    {
                        tmpFlight = flightDesk[j + 1];
                        flightDesk[j + 1] = flightDesk[j];
                        flightDesk[j] = tmpFlight;
                    }
                }
            }
        }


    }
}
