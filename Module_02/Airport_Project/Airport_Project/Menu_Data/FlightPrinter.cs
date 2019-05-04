using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Project.Flight_Data;
using Airport_Project.Passenger_Data;
using System.ComponentModel;

namespace Airport_Project.Menu_Data
{
    class FlightPrinter
    {
        //Method for printing Desk Table
        internal void PrintTable(List<Flight> flightDesk, string _direction)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(_direction);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new string('-', 90));
            Console.WriteLine(string.Format("{7, 2} | {0,-8} | {1, -5} | {2,-10} | {3,-12} | {4, -9} | {5,-4} | {6, -17} |", " Flight", " Time", "   City", " Air company", "Terminal", "Gate", "   Status", "#"));
            Console.WriteLine(new string('-', 90));
            Console.ForegroundColor = ConsoleColor.DarkGray;

            string tmpTimeStr;
            Flight flightItem;

            for (int i = 0; i < flightDesk.Count; i++)
            {
                flightItem = flightDesk[i];
                tmpTimeStr = flightItem.FlightStatus == FlightStatus.DEPARTED_AT || flightItem.FlightStatus == FlightStatus.EXPECTED_AT ? flightItem.StatusTime.Hour.ToString("D2") + ":" + flightItem.StatusTime.Minute.ToString("D2") : "";
                Console.WriteLine(String.Format("{8, 2} | {0,-8} | {1}:{2} | {3,-10} | {4,-12} | {5, -9} | {6,-4} | {7, -11} {9, -5} |",
                    flightItem.FlightID, flightItem.Time.Hour.ToString("D2"), flightItem.Time.Minute.ToString("D2"), flightItem.CityName, flightItem.AirCompany, flightItem.Terminal, flightItem.GateID, flightItem.FlightStatus.GetDescription(), i + 1, tmpTimeStr));
            }
            Console.ResetColor();
            Console.WriteLine(new String('-', 90));

            //Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal void PrintPassengerList(Flight flight)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"List og passengers of FLight # {flight}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new string('-', 94));
            Console.WriteLine($"|{" # ", -3}|{" First Name ", -3}|{" Last Name ", -3}|{" Nationality ", -3}|{" Passport Info ", -3}|{" Date of Birth ", -3}|{" Sex ", -6}|{" Class ", -10}|");
            Console.WriteLine(new string('-', 94));
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Passenger passanger;
            for (int i = 0; i < flight.PassengerList.Count; i++)
            {
                passanger = flight.PassengerList[i];
                Console.WriteLine($"| {i+1,-2}|{passanger.FirstName, -12}|{passanger.SecondName, -11}|{passanger.Nationality.Substring(0, Math.Min(13, passanger.Nationality.Length)), -13}|   {passanger.Passport, -12}|  {passanger.DateOfBirth.ToString("dd.MM.yyyy"), -13}|{passanger.Sex, -6}|{passanger.PassClass,-10}|");
            }
            Console.ResetColor();
            Console.WriteLine(new string('-', 94));




            //StringBuilder strb = new StringBuilder("| No |");
            //for (int i = 0; i < Passenger.listOffields.Length; i++)
            //{
            //    System.Reflection.PropertyInfo item = Passenger.listOffields[i];
            //    strb.Append($" {(Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute)) as DescriptionAttribute).Description,-3} {"|"}");
            //}
            //Console.WriteLine(new string('-', strb.Length));
            //Console.WriteLine(strb.ToString());
            //Console.WriteLine(new string('-', strb.Length));

            //for (int i = 0; i < passengerList.Count; i++)
            //{
            //    Console.Write($"| {i+1} |");         
            //    foreach (var prop in Passenger.listOffields)
            //    {                    
            //        string value = prop.GetValue(passengerList[i]).ToString();
            //        Console.Write($"{value.Substring(0, Math.Min(10, value.Length))} |");
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}
