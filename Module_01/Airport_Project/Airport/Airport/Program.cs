using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
                                    
        static void Main(string[] args)
        {
            Flight flight = new Flight(FlightDirection.DEPARTURE);
            Console.WriteLine(flight.flightID + " | " + (flight.time.Hour).ToString("D2") + ":" + flight.time.Minute.ToString("D2") + " | " + flight.cityName + " | " + flight.airCompany + " | " + flight.terminal + " | " + flight.gateID + " | " + flight.flightStatus.GetDescription() );
            
            #region printValues
            //foreach(var item in Enum.GetValues(typeof(FlightStatus)))
            //{
            //    Console.WriteLine(((FlightStatus)item).GetDescription());
            //}

            //ConsoleKeyInfo cki;
            //do
            //{

            //}
            //while (Console.ReadKey().Key != ConsoleKey.Spacebar);           
            #endregion

        }

        internal void printTable(Flight[] flightDesk)
        {
            foreach (var flightItem in flightDesk)
            {
                Console.WriteLine(flightItem.flightID + "  " + flightItem.gateID);
            }
        }

        internal void DeskTableInit()
        {

        }


    }
}
