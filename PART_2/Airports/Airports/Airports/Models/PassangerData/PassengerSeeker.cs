﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airports.Models.FlightData;
using Airports.Models.MenuData;

namespace Airports.Models.PassengerData
{
    class PassengerSeeker
    {
        private List<Flight> listOfFlightsToFindArrive, listOfFlightsToFindDeparture;
        private List<Flight> totalListOfFlights;
        private ItemsPrinter printer;

        internal PassengerSeeker(List<Flight> _listOfFlightsToFindArrive, List<Flight> _listOfFlightsToFindDeparture, ItemsPrinter _printer)
        {
            listOfFlightsToFindArrive = _listOfFlightsToFindArrive;
            listOfFlightsToFindDeparture = _listOfFlightsToFindDeparture;

            printer = _printer;

            totalListOfFlights = new List<Flight>();

        }

        internal void FinAllPassengers()
        {
            //Dictionary<int, Func<Passenger, bool>> listOfFuncs = new Dictionary<int, Func<Passenger, bool>>();
            List<Passenger> listOfFoundPass = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What do you want to find by?... \n1 - By First Name\n2 - By Second Name\n3 - By Flight\n4 - By sex\n0 - To exit");
                bool parseIsOk = Int32.TryParse(Console.ReadLine(), out int usersChoice);
                if (parseIsOk && usersChoice >= 0)
                {

                    switch (usersChoice)
                    {
                        case 0: //Break

                            return;
                        case 1:    //By First Name                    
                            Console.WriteLine("Enter the FirstName: ");
                            string nameFromUser = Console.ReadLine();
                            listOfFoundPass = FindAllPassengersPredicate(p => p.FirstName == nameFromUser);
                            break;
                        case 2:   //By Second Name
                            Console.WriteLine("Enter the SecondName: ");
                            string nameSecondFromUser = Console.ReadLine();
                            listOfFoundPass = FindAllPassengersPredicate(p => p.SecondName == nameSecondFromUser);
                            break;
                        case 3:  //By Flight
                            Console.WriteLine("Enter the Flight: ");
                            string flightFromUser = Console.ReadLine();
                            listOfFoundPass = FindAllPassengersPredicate(p => p.PassFlight.FlightID == flightFromUser);
                            break;
                        case 4:  //By Sex
                            Console.WriteLine("Male or Female?");
                            string sexFromUser = Console.ReadLine();
                            listOfFoundPass = FindAllPassengersPredicate(p => p.Sex == (PassengerSex)Enum.Parse(typeof(PassengerSex), sexFromUser));
                            break;
                        default:
                            break;
                    }
                    //printer.PrintItemsList(listOfFoundPass, 0, "List of Passengers");
                    new PassengerEditor(printer).EditPassengerList(listOfFoundPass, "");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect Input. {Environment.NewLine} 1 - To previous menu {Environment.NewLine} Any key - Try again");
                    Console.ResetColor();
                    string choice = Console.ReadLine();
                    if (choice == "1") break;
                    else continue;
                }
            }

        }


        private List<Passenger> FindAllPassengersPredicate(Func<Passenger, bool> func)
        {
            //Union of lists of Flights
            totalListOfFlights.Clear();
            totalListOfFlights.AddRange(listOfFlightsToFindArrive);
            totalListOfFlights.AddRange(listOfFlightsToFindDeparture);

            foreach (var item in totalListOfFlights)
            {
                foreach (var item2 in item.PassengerList)
                {
                    Console.WriteLine(item2.FirstName);
                }
            }
           

             var passengerList = from f in totalListOfFlights
                                from p in f.PassengerList
                                where func(p)
                                select p;


            foreach (var item2 in passengerList)
            {
                Console.WriteLine(item2.FirstName);
            }

            Console.ReadLine();            
            return passengerList.ToList();
        }

    }
}
