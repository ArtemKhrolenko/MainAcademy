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

            FlightPrinter flightPrinter = new FlightPrinter();
            FlightEditor flightEditor = new FlightEditor(true, flightPrinter); //Creating Flight Editor class with Random list initialization

            string userInput;
            while (true)
            {
                Console.Clear();
                flightPrinter.PrintTable(flightEditor.ArrivalFlights,   arrivalStr);
                flightPrinter.PrintTable(flightEditor.DepartureFlights, departStr);
                Console.WriteLine("Edit Arrival: \t\tPress 1\nEdit Departures: \tPress 2\nTo Exit: \t\tPress 0");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        flightEditor.EditFlight(flightEditor.ArrivalFlights, arrivalStr);
                        break;
                    case "2":
                        flightEditor.EditFlight(flightEditor.DepartureFlights, departStr);
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




//Passenger pass = new Passenger(new Random())  ;
//Console.WriteLine(pass.FirstName + "  " + pass.SecondName + "  " + pass.Nationality + "  " + pass.Passport + "  " + $"{pass.DateOfBirth.ToString("D")}" + "   " + pass.Sex + "   " + pass.PassClass);      


//Flight flight = new Flight(new Random());           

//foreach (var item in flight.PassengerList)
//{                
//    item.GetPassengerFieldsDescription();
//    Console.WriteLine("--------------");
//}