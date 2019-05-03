using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Project.Flight_Data;

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

            //bool goAhead = true;
            while (true)
            {
                Console.Clear();
                flightPrinter.PrintTable(flights, direction);
                Console.Write($"Enter number of flight you want to edit...Or press 0 to exit...");

                parseIsOk = Int32.TryParse(Console.ReadLine(), out numOfFlightToEdit);

                if (numOfFlightToEdit == 0 && parseIsOk)
                    return;

                //Checking by range of number of flights
                if (CheckForNowChoice(numOfFlightToEdit > 0 && numOfFlightToEdit < flights.Count))
                    return;
                Console.WriteLine( "ssdadsa");

                flightItem = flights[numOfFlightToEdit - 1];
                //if (numOfFlightToEdit < 0 || numOfFlightToEdit >= flights.Count)
                //{
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine("Incorrect Input. Retry? y/n");
                //    if (Console.ReadKey(true).Key == ConsoleKey.N)
                //        return;
                //    Console.ResetColor();
                //}



                while (true)
                {
                    Console.Clear();
                    flightPrinter.PrintTable(flights, direction);
                    Console.WriteLine($"...Editing flight {flightItem.FlightID} to(from) {flightItem.CityName}");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"1. Flight;\n2. Time;\n3. City;\n4. Air Company;\n5. Terminal;\n6. Gate;\n7. Status;\n0. Press 0 to Exit current menu.\nPress \"e\" to return to Dask Table");
                    Console.ResetColor();
                    Console.Write("Select item number to edit...");
                    parseIsOk = Int32.TryParse(Console.ReadLine(), out int numOfItemToEdit);

                    //Checked for correct input
                    if (CheckForNowChoice(parseIsOk))
                        return;



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


                        switch (numOfItemToEdit)
                        {
                            case 0:
                                return;
                            case 1: //FlightID                      

                                Console.Clear();
                                PrintTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].flightID = ChangeItemInDesk("flight ID", flightItem.flightID, 8);
                                break;

                            case 2: //Time   

                                Console.Clear();
                                PrintTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].time = ChangeItemInDesk("Time", flightItem.time, ref goAhead);
                                //Array.Sort(_flights);
                                BubbleSort(_flights);
                                break;

                            case 3: //City                            

                                Console.Clear();
                                PrintTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].cityName = ChangeItemInDesk("City", flightItem.cityName, 10);
                                break;

                            case 4: //Air Company

                                Console.Clear();
                                PrintTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].airCompany = ChangeItemInDesk("Air Company", flightItem.airCompany, 12);
                                break;

                            case 5: //Terminal                            

                                Console.Clear();
                                PrintTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].terminal = ChangeItemInDesk("Terminal", flightItem.terminal, ref goAhead);
                                break;

                            case 6: //Gate

                                Console.Clear();
                                PrintTable(_flights, _direction);
                                _flights[numOfFlightToEdit - 1].gateID = ChangeItemInDesk("Gate ID", flightItem.gateID, 4);
                                break;

                            case 7: //Flight Status
                                Console.Clear();
                                PrintTable(_flights, _direction);
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

                
                */

            }

        }

        private bool CheckForNowChoice(bool condition)
        {
            if (!condition)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect Input. Retry? y/n");
                Console.ResetColor();
                return (Console.ReadKey(true).Key == ConsoleKey.N);
            }
            return !condition;
        }



    }
}
