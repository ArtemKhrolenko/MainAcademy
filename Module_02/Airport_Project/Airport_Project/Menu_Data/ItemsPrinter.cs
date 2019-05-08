using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Airport_Project.Flight_Data;
using Airport_Project.Passenger_Data;
using System.ComponentModel;

namespace Airport_Project.Menu_Data
{
    class ItemsPrinter
    {
        //Method for printing Desk Table
        internal void PrintTable(List<Flight> flightDesk, string description)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(description);
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

        internal void PrintItemsList<T>(List<T> listForPrint, int lightItem, string description) where T : IPrintable
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(description);
            Console.ForegroundColor = ConsoleColor.Gray;
            
            //Select all properties with description attribute            
            var properyList = typeof(T).GetProperties().Where(p => Attribute.IsDefined(p, typeof(DescriptionAttribute))).ToList();

            //Printing Header of table
            StringBuilder strb = new StringBuilder("| No |");
            for (int i = 0; i < properyList.Count(); i++)
            {
                strb.Append($"  {(Attribute.GetCustomAttribute(properyList[i], typeof(DescriptionAttribute)) as DescriptionAttribute).Description,-3} {" |"}");
            }
            //Console.WindowWidth = strb.Length + 2;
            Console.WriteLine(new string('-', strb.Length));
            Console.WriteLine(strb.ToString());
            Console.WriteLine(new string('-', strb.Length));

            //Printing Data
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string value;
            int attributeLength;
            object o;
            for (int i = 0; i < listForPrint.Count; i++)
            {
                if (i == lightItem - 1)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"| {i + 1,-2} |");
                foreach (var prop in properyList)
                {
                    attributeLength = (Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute)) as DescriptionAttribute).Description.Length + 4;
                    value = prop.GetValue(listForPrint[i]).ToString();
                    value = value.PadLeft(value.Length + (attributeLength - value.Length) / 2);
                    value = value.Substring(0, Math.Min(attributeLength, value.Length));

                    Console.Write($"{value.PadRight((Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute)) as DescriptionAttribute).Description.Length + 4)}|");
                }
                Console.WriteLine();
                if (Console.ForegroundColor != ConsoleColor.DarkGreen)
                    Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            //Printing Bottom border of table
            Console.ResetColor();
            Console.WriteLine(new string('-', strb.Length));
        }
    }
}
