using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Airport_Project.Flight_Data;
using System.Globalization;


namespace Airport_Project.Menu_Data
{
    class FlightEditor
    {
        public List<Flight> ArrivalFlights { get; set; }
        public List<Flight> DepartureFlights { get; set; }
        private const byte deskTableLength = 10;
        private FlightPrinter flightPrinter;

        public FlightEditor(FlightPrinter _flightPrinter)
        {
            flightPrinter = _flightPrinter;
            ArrivalFlights = new List<Flight>();
            DepartureFlights = new List<Flight>();
            flightPrinter = new FlightPrinter();
        }

        //Initalize lists
        public FlightEditor(bool isRandomInitalization, FlightPrinter _flightPrinter) : this(_flightPrinter) //True - Random data Initialization 
        {
            if (isRandomInitalization)
            {
                Random rnd = new Random();
                for (int i = 0; i < deskTableLength; i++)
                {
                    ArrivalFlights.Add(new Flight(rnd));
                    DepartureFlights.Add(new Flight(rnd));
                }
                ArrivalFlights.Sort();
            }
        }

        internal void EditFlight(List<Flight> flights, string direction)
        {
            Flight flightItem;
            int numOfFlightToEdit;
            bool parseIsOk;
            string usersChoice;

            //bool goAhead = true;
            while (true)
            {
                Console.Clear();
                flightPrinter.PrintTable(flights, direction);
                Console.Write($"Enter number of flight you want to edit...Or press 0 to return to previous menu...");

                parseIsOk = Int32.TryParse(Console.ReadLine(), out numOfFlightToEdit);

                if (numOfFlightToEdit == 0 && parseIsOk)
                    return;

                if (!parseIsOk || numOfFlightToEdit < 0 || numOfFlightToEdit >= flights.Count)
                {
                    usersChoice = ReceiveUserChoice();
                    if (usersChoice == "1")
                        break;
                    if (usersChoice == "2")
                        return;
                    else
                        continue;
                }

                flightItem = flights[numOfFlightToEdit - 1];

                while (true)
                {
                    Console.Clear();
                    flightPrinter.PrintTable(flights, direction);
                    Console.WriteLine($"...Editing flight {flightItem.FlightID} to(from) {flightItem.CityName}");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"1. Flight;\n2. Time;\n3. City;\n4. Air Company;\n5. Terminal;\n6. Gate;\n7. Status;\n0. To return to previous menuu.");
                    Console.ResetColor();
                    Console.Write("Select item number to edit...");
                    parseIsOk = Int32.TryParse(Console.ReadLine(), out int numOfItemToEdit);

                    if (parseIsOk && numOfItemToEdit == 0)
                        break;
                    //If edit info is incorrect
                    if (!parseIsOk || numOfItemToEdit < 0 || numOfItemToEdit >= 8)
                    {
                        usersChoice = ReceiveUserChoice();
                        if (usersChoice == "1")
                            break;
                        if (usersChoice == "2")
                            return;
                        else
                            continue;
                    }

                    //Handling correct input
                    switch (numOfItemToEdit)
                    {
                        case 1: //FlightID                      
                            while (true)
                            {
                                Console.Clear();
                                flightPrinter.PrintTable(flights, direction);
                                (bool succeed, string result) flightIdFromUser = ChangeItemInDesk("flight ID", flightItem.FlightID, @"[A-Z]{2}\s\d{4}$", 8);
                                if (!flightIdFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1")
                                        break;
                                    if (usersChoice == "2")
                                        return;
                                    else
                                        continue;
                                }
                                flights[numOfFlightToEdit - 1].FlightID = flightIdFromUser.result;                                
                                break;
                            }
                            break;

                        case 2: //Time   
                            while (true)
                            {
                                Console.Clear();
                                flightPrinter.PrintTable(flights, direction);
                                (bool succeed, DateTime result) timeFromUser = ChangeItemInDesk("Time", flightItem.Time);
                                if (!timeFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1")
                                        break;
                                    if (usersChoice == "2")
                                        return;
                                    else
                                        continue;
                                }
                                flights[numOfFlightToEdit - 1].Time = timeFromUser.result;
                                flights.Sort();
                                break;
                            }
                            break;

                        case 3: //City                            

                            while (true)
                            {
                                Console.Clear();
                                flightPrinter.PrintTable(flights, direction);
                                (bool succeed, string result) flightCityFromUser = ChangeItemInDesk("City", flightItem.CityName, @"^[A-Z][a-z]+(?:[\s-][A-Z][a-z]+)*$", 10);
                                if (!flightCityFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1")
                                        break;
                                    if (usersChoice == "2")
                                        return;
                                    else
                                        continue;
                                }
                                flights[numOfFlightToEdit - 1].CityName = flightCityFromUser.result;
                                break;
                            }
                            break;

                        case 4: //Air Company

                            while (true)
                            {
                                Console.Clear();
                                flightPrinter.PrintTable(flights, direction);
                                (bool succeed, string result) flightAirCompFromUser = ChangeItemInDesk("Air Company", flightItem.AirCompany, @"[A-Z][a-z]+$", 8);
                                if (!flightAirCompFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1")
                                        break;
                                    if (usersChoice == "2")
                                        return;
                                    else
                                        continue;
                                }
                                flights[numOfFlightToEdit - 1].AirCompany = flightAirCompFromUser.result;
                                break; 
                            }
                            break;

                        case 5: //Terminal                            

                            Console.Clear();
                            flightPrinter.PrintTable(flights, direction);
                            flights[numOfFlightToEdit - 1].Terminal = ChangeItemInDesk("Terminal", flightItem.Terminal);
                            break;

                        case 6: //Gate

                            Console.Clear();
                            flightPrinter.PrintTable(flights, direction);
                            flights[numOfFlightToEdit - 1].GateID = ChangeItemInDesk("Gate ID", flightItem.GateID, "", 4).result;
                            break;

                        case 7: //Flight Status
                            while (true)
                            {
                                Console.Clear();
                                flightPrinter.PrintTable(flights, direction);
                                Console.WriteLine("Editing Flight Status...");

                                //Printing All of statuses
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                foreach (var item in Enum.GetValues(typeof(FlightStatus)))
                                {
                                    Console.WriteLine((int)item + 1 + ". " + ((FlightStatus)item).GetDescription());
                                }
                                Console.WriteLine("0. To return to previous menu");
                                Console.ResetColor();
                                Console.WriteLine("Chose the status to set...");

                                bool isEnumValue = Int32.TryParse(Console.ReadLine(), out int _flightStatusIndex);

                                if (isEnumValue && _flightStatusIndex == 0)
                                    break;

                                //Checking for correct input for the status of Flight
                                if (isEnumValue && _flightStatusIndex > 0 && _flightStatusIndex <= Enum.GetValues(typeof(FlightStatus)).Length)
                                {
                                    //if Status == Departed At OR Departed AT - ask user about exat time of departing or excepting
                                    if ((FlightStatus)_flightStatusIndex - 1 == FlightStatus.DEPARTED_AT || (FlightStatus)_flightStatusIndex - 1 == FlightStatus.EXPECTED_AT)
                                    {
                                        (bool succeed, DateTime result) timeFromUser = ChangeItemInDesk("Time of Departure or Arrival", flightItem.StatusTime);
                                        if (!timeFromUser.succeed)
                                        {
                                            usersChoice = ReceiveUserChoice();
                                            if (usersChoice == "1")
                                                break;
                                            if (usersChoice == "2")
                                                return;
                                            else
                                                continue;
                                        }
                                        flights[numOfFlightToEdit - 1].StatusTime = timeFromUser.result;
                                    }

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Flight status changed from \"{flightItem.FlightStatus.GetDescription()}\" to \"{((FlightStatus)_flightStatusIndex - 1).GetDescription()}\". Press any key to Continue...");
                                    flights[numOfFlightToEdit - 1].FlightStatus = (FlightStatus)_flightStatusIndex - 1;
                                    Console.ReadKey();
                                }
                                else
                                {

                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1")
                                        break;
                                    if (usersChoice == "2")
                                        return;
                                    else
                                        continue;

                                }
                            }

                            break;

                        default:
                            //PrintIncorrectInputString(ref goAhead);
                            break;
                    }



                }
                /*
               
                    while (goAhead)
                    {
                        //Console.Clear();
                        //Console.ResetColor();
                        //flightItem = _flights[numOfFlightToEdit - 1];
                        //PrintTable(_flights, _direction);
                        //Console.WriteLine($"...Editing flight {flightItem.flightID} to(from) {flightItem.cityName}");

                        //Console.ForegroundColor = ConsoleColor.DarkGray;
                        //Console.WriteLine($"1. Flight;\n2. Time;\n3. City;\n4. Air Company;\n5. Terminal;\n6. Gate;\n7. Status;\n0. Press 0 to Exit editing");
                        //Console.ResetColor();

                        Console.WriteLine("Select item number to edit...");
                        Int32.TryParse(Console.ReadLine(), out int numOfItemToEdit);
                        

                    }

                
                */

            }

        }

        private string ReceiveUserChoice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Incorrect Input. {Environment.NewLine} 1 - To previous menu {Environment.NewLine} 2 - To exit editing {Environment.NewLine} Any key - Try again");
            Console.ResetColor();
            return Console.ReadLine();

        }



        //Method for changing string Items in Flight Structure
        private (bool succeed, string result) ChangeItemInDesk(string itemName, string oldItemValue, string pattern, int length)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Editing {itemName}");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write($"Change {itemName} from {oldItemValue} to...:  ");

            string strNewValue = Console.ReadLine();
            if (!Regex.IsMatch(strNewValue, pattern))
                return (false, "Error");

            if (strNewValue.Length > length)
            {
                strNewValue = strNewValue.Substring(0, length);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{itemName} was changed to {strNewValue}. Press any key to Continue...");
            Console.ResetColor();
            Console.ReadKey();
            return (true, strNewValue);
        }

        //Method for changing character Items in Flight Structure
        private char ChangeItemInDesk(string itemName, char oldItemValue)
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
                //PrintIncorrectInputString();
                return oldItemValue;

            }

            Console.ResetColor();
            Console.ReadKey();
            return charItem;
        }

        //Method for changing time Items in Flight Structure
        private (bool succeed, DateTime result) ChangeItemInDesk(string itemName, DateTime oldItemValue)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Editing {itemName}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Change time from {oldItemValue.Hour.ToString("D2")}:{oldItemValue.Minute.ToString("D2")} to (in HH:mm format)...:  ");

            (bool succeed, DateTime result) _newDateTime;
            try
            {
                _newDateTime.result = DateTime.ParseExact(Console.ReadLine() + ":00", "HH:mm:ss", CultureInfo.InvariantCulture);
                _newDateTime.succeed = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Time changed to {_newDateTime.result.Hour.ToString("D2")}:{_newDateTime.result.Minute.ToString("D2")}. Press any key to continue...");
                Console.ReadKey();

            }
            catch (Exception)
            {
                _newDateTime = (false, new DateTime());
            }
            return _newDateTime;
        }



    }
}
