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

        internal void HandleFlightList(List<Flight> flights, string description)
        {
            bool parseIsOk;
            int numOfItemToEdit;
            string usersChoice = string.Empty;

            while (true)
            {
                Console.Clear();
                itemsPrinter.PrintItemsList(flights, 0, description);
                Console.Write($"1 - Edit Flight\n2 - Add Flight\n3 - Delete Flight\n0 - Exit to previous Menu\nYour choice: ");

                parseIsOk = Int32.TryParse(Console.ReadLine(), out numOfItemToEdit);

                if (numOfItemToEdit == 0 && parseIsOk)
                    return;
                if (!parseIsOk || numOfItemToEdit < 0 || numOfItemToEdit > 3)
                {
                    usersChoice = ReceiveUserChoice();
                    if (usersChoice == "1") break;
                    if (usersChoice == "2") return;
                    else continue;
                }
                //Edit Passenger
                switch (numOfItemToEdit)
                {
                    case 1:
                        EditFlightsList(flights, description);
                        break;

                    case 2:
                        try
                        {
                            flights.Add(new Flight(new Random()));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.Write("Enter number...   ");
                            flights.Remove(flights[int.Parse(Console.ReadLine()) - 1]);

                        }
                        catch (Exception e)
                        {                            
                            usersChoice = ReceiveUserChoice();
                            if (usersChoice == "1") break;
                            if (usersChoice == "2") return;
                            else continue;
                        }
                        break;

                    default:
                        usersChoice = ReceiveUserChoice();
                        if (usersChoice == "1") break;
                        if (usersChoice == "2") return;
                        else continue;
                }

            }
        }


        //Editing List of Flights
        internal void EditFlightsList(List<Flight> flights, string direction)
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
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, string result) flightIdFromUser = ChangeItemInDesk("flight ID", flightItem.FlightID, @"[A-Z]{2}\s\d{4}$");
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
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, DateTime result) timeFromUser = ChangeItemInDesk("Time", flightItem.Time, "HH:mm");
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
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, string result) flightCityFromUser = ChangeItemInDesk("City", flightItem.CityName, @"^[A-Z][a-z]+(?:[\s-][A-Z][a-z]+)*$");
                                if (!flightCityFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                flights.FirstOrDefault(f => f.FlightID == flightItem.FlightID).CityName = flightCityFromUser.result;                                
                                break;
                            }
                            break;

                        case 4: //Air Company

                            while (true)
                            {
                                Console.Clear();                               
                                itemsPrinter.PrintItemsList(flights, numOfFlightToEdit, direction);
                                (bool succeed, string result) flightAirCompFromUser = ChangeItemInDesk("Air Company", flightItem.AirCompany, @"[A-Z][a-z]+$");
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
                                (bool succeed, string result) flightGateFromUser = ChangeItemInDesk("Gate ID", flightItem.GateID, @"^[A-Z]\d+");
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
                                (bool succeed, Enum result) statusFromUser = ChangeItemInDesk("Status", flightItem.FlightStatus);
                                if (!statusFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                flightItem.FlightStatus = (FlightStatus)statusFromUser.result;                                

                                if (flightItem.FlightStatus == FlightStatus.DEPARTED_AT || flightItem.FlightStatus == FlightStatus.EXPECTED_AT)
                                {
                                    (bool succeed, DateTime result) timeFromUser = ChangeItemInDesk("Time of Departure or Arrival", flightItem.StatusTime, "HH:mm");
                                    if (!timeFromUser.succeed)
                                    {
                                        usersChoice = ReceiveUserChoice();
                                        if (usersChoice == "1") break;
                                        if (usersChoice == "2") return;
                                        else continue;
                                    }
                                    flights[numOfFlightToEdit - 1].StatusTime = timeFromUser.result;
                                }                               
                            }
                            break;
                        case 8: //Passenger list
                            Console.Clear();                           
                            passengerEditor.HandlePassengerList(flightItem.PassengerList, $"List of Passenger of flight {flightItem}");
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
