using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Project.Flight_Data;
using Airport_Project.Passenger_Data;
using Airport_Project.Menu_Data;


namespace Airport_Project
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //Console adjustment
            Console.WindowHeight = 35;            
            string arrivalStr = "Arrivals <<===== ";
            string departStr = "Departures  =====>>";

            ItemsPrinter flightPrinter = new ItemsPrinter();            
            FlightEditor flightEditor = new FlightEditor(true, flightPrinter); //Creating Flight Editor class with Random list initialization
            PassengerSeeker passengerSeeker = new PassengerSeeker(flightEditor.ArrivalFlights, flightEditor.DepartureFlights, flightPrinter);
            

            string userInput;
            while (true)
            {
                Console.Clear();                
                flightPrinter.PrintItemsList(flightEditor.ArrivalFlights, 0, arrivalStr);                
                flightPrinter.PrintItemsList(flightEditor.DepartureFlights, 0, departStr);
                Console.WriteLine("Edit Arrival: \t\tPress 1\nEdit Departures: \tPress 2\nFind Passenger: \tPress 3\nTo Exit: \t\tPress 0");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        flightEditor.HandleFlightList(flightEditor.ArrivalFlights, arrivalStr);
                        break;
                    case "2":
                        flightEditor.HandleFlightList(flightEditor.DepartureFlights, departStr);
                        break;
                    case "3":
                        passengerSeeker.FinAllPassengers();
                        break;
                    case "0":
                        return;                       

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect Input. Retry? y/n");
                        if (Console.ReadKey(true).Key == ConsoleKey.N)
                            return;
                        Console.ResetColor();
                        break;
                }

            }

        }

      
    }
}

