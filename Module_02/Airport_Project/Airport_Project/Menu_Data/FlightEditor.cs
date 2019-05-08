using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Airport_Project.Flight_Data;



namespace Airport_Project.Menu_Data
{
    class FlightEditor : Editor
    {
        public List<Flight> ArrivalFlights { get; set; }
        public List<Flight> DepartureFlights { get; set; }
        private const byte deskTableLength = 10;
        private ItemsPrinter itemsPrinter;
        private PassengerEditor passengerEditor;

        public FlightEditor(ItemsPrinter _itemsPrinter)
        {
            itemsPrinter = _itemsPrinter;

            passengerEditor = new PassengerEditor(_itemsPrinter);
            ArrivalFlights = new List<Flight>();
            DepartureFlights = new List<Flight>();
            
            
        }

        //Initalize lists
        public FlightEditor(bool isRandomInitalization, ItemsPrinter _flightPrinter) : this(_flightPrinter) //True - Random data Initialization 
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
                DepartureFlights.Sort();
            }
        }

        internal void EditFlight(List<Flight> flights, string direction)
        {
            Flight flightItem;
            int numOfFlightToEdit;
            bool parseIsOk;
            string usersChoice = string.Empty;

            //bool goAhead = true;
            while (true)
            {
                Console.Clear();
                //flightPrinter.PrintTable(flights, direction);
                itemsPrinter.PrintItemsList(flights, 0, direction);
                Console.Write($"Enter number of flight you want to edit...Or press 0 to return to previous menu...");

                parseIsOk = Int32.TryParse(Console.ReadLine(), out numOfFlightToEdit);

                if (numOfFlightToEdit == 0 && parseIsOk)
                    return;

                if (!parseIsOk || numOfFlightToEdit < 0 || numOfFlightToEdit > flights.Count)
                {
                    usersChoice = ReceiveUserChoice();
                    if (usersChoice == "1") break;
                    if (usersChoice == "2") return;
                    else continue;
                }

                flightItem = flights[numOfFlightToEdit - 1];

                while (true)
                {
                    Console.Clear();                    
                    itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                    Console.WriteLine($"...Editing flight {flightItem.FlightID} to(from) {flightItem.CityName}");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"1. Flight;\n2. Time;\n3. City;\n4. Air Company;\n5. Terminal;\n6. Gate;\n7. Status;\n8. Passenger list\n0. To return to previous menuu.");
                    Console.ResetColor();
                    Console.Write("Select item number to edit...");
                    parseIsOk = Int32.TryParse(Console.ReadLine(), out int numOfItemToEdit);

                    if (parseIsOk && numOfItemToEdit == 0)
                        break;

                    //Handling correct input
                    switch (numOfItemToEdit)
                    {
                        case 1: //FlightID                      
                            while (true)
                            {
                                Console.Clear();
                                //flightPrinter.PrintTable(flights, direction);
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, string result) flightIdFromUser = ChangeItemInDesk("flight ID", flightItem.FlightID, @"[A-Z]{2}\s\d{4}$", 8);
                                if (!flightIdFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                flights[numOfFlightToEdit - 1].FlightID = flightIdFromUser.result;
                                break;
                            }
                            break;

                        case 2: //Time   
                            while (true)
                            {
                                Console.Clear();
                                //flightPrinter.PrintTable(flights, direction);
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, DateTime result) timeFromUser = ChangeItemInDesk("Time", flightItem.Time);
                                if (!timeFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                flights[numOfFlightToEdit - 1].Time = timeFromUser.result;                                
                                flights.Sort();
                                numOfFlightToEdit = flights.IndexOf(flightItem) + 1;
                                break;
                            }
                            break;

                        case 3: //City                            

                            while (true)
                            {
                                Console.Clear();
                                //flightPrinter.PrintTable(flights, direction);
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, string result) flightCityFromUser = ChangeItemInDesk("City", flightItem.CityName, @"^[A-Z][a-z]+(?:[\s-][A-Z][a-z]+)*$", 10);
                                if (!flightCityFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                flights.FirstOrDefault(f => f.FlightID == flightItem.FlightID).CityName = flightCityFromUser.result;
                                
                                //flights[numOfFlightToEdit - 1].CityName = flightCityFromUser.result;
                                break;
                            }
                            break;

                        case 4: //Air Company

                            while (true)
                            {
                                Console.Clear();
                                //flightPrinter.PrintTable(flights, direction);
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, string result) flightAirCompFromUser = ChangeItemInDesk("Air Company", flightItem.AirCompany, @"[A-Z][a-z]+$", 8);
                                if (!flightAirCompFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                flights[numOfFlightToEdit - 1].AirCompany = flightAirCompFromUser.result;
                                break;
                            }
                            break;

                        case 5: //Terminal                            

                            while (true)
                            {
                                Console.Clear();
                                //flightPrinter.PrintTable(flights, direction);
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, char result) flightTerminalFromUser = ChangeItemInDesk("Terminal", flightItem.Terminal);
                                if (!flightTerminalFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                flights[numOfFlightToEdit - 1].Terminal = flightTerminalFromUser.result;
                                break;
                            }
                            break;

                        case 6: //Gate

                            while (true)
                            {
                                Console.Clear();
                                //flightPrinter.PrintTable(flights, direction);
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, string result) flightGateFromUser = ChangeItemInDesk("Gate ID", flightItem.GateID, @"^[A-Z]\d+", 4);
                                if (!flightGateFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                flights[numOfFlightToEdit - 1].GateID = flightGateFromUser.result;
                                break;
                            }
                            break;

                        case 7: //Flight Status
                            while (true)
                            {
                                Console.Clear();
                                //flightPrinter.PrintTable(flights, direction);
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
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
                                            if (usersChoice == "1") break;
                                            if (usersChoice == "2") return;
                                            else continue;
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
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                            }
                            break;
                        case 8: //Passenger list
                            Console.Clear();
                            //itemsPrinter.PrintItemsList(flightItem.PassengerList, 0, $"List of Passenger of flight {flightItem}");
                            //Console.ReadKey();
                            passengerEditor.EditPassenger(flightItem.PassengerList, $"List of Passenger of flight {flightItem}");


                            break;
                        default:
                            //If edit info is incorrect
                            numOfItemToEdit = -1;
                            usersChoice = ReceiveUserChoice();
                            if (usersChoice != "1") continue;
                            if (usersChoice == "2") return;
                            break;

                    }
                    if (numOfItemToEdit == -1 && usersChoice == "1") break;
                }
            }
        }      
    }
}
