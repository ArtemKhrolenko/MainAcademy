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
