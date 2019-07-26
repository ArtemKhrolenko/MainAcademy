using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Airports.Models.PassengerData;
using System.Data.Entity;

namespace Airports.Models.FlightData
{
    public class FlightDbInitializer : DropCreateDatabaseAlways<FlightContext>
    {
        internal static string[] flights = { "KC 4060", "PQ 7119", "7W 1030", "PS 9003", "FZ 7280", "BT 4030", "JU 7676", "PS 9413", "PS 9556", "TK 1256", "LO 8312", "PS 5673", "LH 2545" };
        internal static string[] cities = { "Kyiv", "Moscow", "Alma-Aty", "Riga", "Istambul", "Munich", "Dnipro ", "Warsaw ", "Frankfurt", "Tallin", "Dubai", "Kharkiv", "Tel-Aviv" };
        internal static string[] airComps = { "FLYUIA", "Lufthansa", "Wind Rose", "KLM", "Delta", "Air France" };

        protected override void Seed(FlightContext db)
        {


            db.Flights.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
            db.Flights.Add(new Flight { }


            base.Seed(db);
        }

        //Random initalisation of Flight instance
        private void RandomInitalizeFlight(Random rnd)
        {

            var FlightID = flights[rnd.Next(Flight.flights.Length)];

            var CityName = cities[rnd.Next(Flight.cities.Length)];

            var AirCompany = airComps[rnd.Next(Flight.airComps.Length)];

            var Terminal = (char)rnd.Next(65, 91);

            var GateID = Terminal.ToString() + rnd.Next(1, 99);

            Array flightStsItems = Enum.GetValues(typeof(FlightStatus));
            var FlightStatus = (FlightStatus)flightStsItems.GetValue(rnd.Next(flightStsItems.Length));

            DateTime now = DateTime.Now;
            var Time = new DateTime(now.Year, now.Month, now.Day, rnd.Next(0, 24), rnd.Next(0, 60), 0);

            DateTime StatusTime;

            if (FlightStatus == FlightStatus.DEPARTED_AT || FlightStatus == FlightStatus.EXPECTED_AT)
            {
                StatusTime = new DateTime(now.Year, now.Month, now.Day, rnd.Next(now.Hour, 24), rnd.Next(now.Minute, 60), 0);
            }
            
            List<PassengerData.Passenger> PassengerList = new List<PassengerData.Passenger>();
            //Passenger List initialization
            for (int i = 0; i < 10; i++)
            {
                PassengerList.Add(new Passenger(rnd, this));
            }

        }
    }
}