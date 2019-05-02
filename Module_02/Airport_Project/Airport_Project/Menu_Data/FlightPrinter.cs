using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Project.Flight_Data;

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

            Console.WriteLine(new String('-', 90));

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
