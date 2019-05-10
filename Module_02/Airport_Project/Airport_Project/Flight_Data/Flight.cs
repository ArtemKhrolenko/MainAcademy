using System;
using System.Collections.Generic;
using Airport_Project.Passenger_Data;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;


namespace Airport_Project.Flight_Data
{
    class Flight : IPrintable,IComparable
    {
        #region Static Members
        internal static PropertyInfo[] listOffields; //List of Properies with Description attribute
        internal static string[] flights = { "KC 4060", "PQ 7119", "7W 1030", "PS 9003", "FZ 7280", "BT 4030", "JU 7676", "PS 9413", "PS 9556", "TK 1256", "LO 8312", "PS 5673", "LH 2545" };
        internal static string[] cities = { "Kyiv", "Moscow", "Alma-Aty", "Riga", "Istambul", "Munich", "Dnipro ", "Warsaw ", "Frankfurt", "Tallin", "Dubai", "Kharkiv", "Tel-Aviv" };
        internal static string[] airComps = { "FLYUIA", "Lufthansa", "Wind Rose", "KLM", "Delta", "Air France" };
        #endregion

        [Description("Flight")]
        public string FlightID { get; set; }      //Flight ID        
        public DateTime Time { get; set; }        //Time of arrival (departure)
        [Description("Time")]
        public string StringTime
        { get
            {
                return Time.ToString("HH:mm");
            }
        }
        [Description("City ")]
        public string CityName { get; set; }      //Destanation(departure) city
        [Description("Air Company")]
        public string AirCompany { get; set; }      //Air Company ID
        [Description("Terminal")]
        public char Terminal { get; set; }      //Airport terminal
        [Description("Gate")]
        public string GateID { get; set; }      //Airport Gate ID
        
        internal FlightStatus FlightStatus { get; set; }      //Status of Flight     
        [Description("    Status     ")]
        public string StrFligjtStatusTime {
            get
            {
                string tmpTimeStr = FlightStatus == FlightStatus.DEPARTED_AT || FlightStatus == FlightStatus.EXPECTED_AT ? StatusTime.ToString("HH:mm") : "";
                return $"{FlightStatus.GetDescription()} {tmpTimeStr}";
            }
        }

        internal DateTime StatusTime { get; set; }      //Status Time
        internal List<Passenger> PassengerList { get; set; }      //List of Passengers

        private Random rnd;
        private int _passengerCount = 10; //Count of passengers on a flight for Random initialization

        static Flight()
        {
            listOffields = InitProps();
        }
        
        //Default Constructor
        internal Flight()
        {   
            PassengerList = new List<Passenger>();
            
        }

        //For random implicit fields initalization
        public Flight(Random _rnd) : this()
        {
            rnd = _rnd;
            RandomInitalizeFlight(_rnd);

        }

        //For explicit fields initalization
        public Flight(string flightID, DateTime time, string cityName, string airCompany, char terminal, string gateID, FlightStatus flightStatus, DateTime statusTime) : this()
        {
            FlightID = flightID;
            Time = time;
            CityName = cityName;
            AirCompany = airCompany;
            Terminal = terminal;
            GateID = gateID;
            FlightStatus = flightStatus;
            StatusTime = statusTime;
            
        }


        //Random initalisation of Flight instance
        private void RandomInitalizeFlight(Random rnd)
        {

            FlightID = Flight.flights[rnd.Next(Flight.flights.Length)];

            CityName = Flight.cities[rnd.Next(Flight.cities.Length)];

            AirCompany = Flight.airComps[rnd.Next(Flight.airComps.Length)];

            Terminal = (char)rnd.Next(65, 91);

            GateID = Terminal.ToString() + rnd.Next(1, 99);

            Array flightStsItems = Enum.GetValues(typeof(FlightStatus));
            FlightStatus = (FlightStatus)flightStsItems.GetValue(rnd.Next(flightStsItems.Length));

            DateTime now = DateTime.Now;
            Time = new DateTime(now.Year, now.Month, now.Day, rnd.Next(0, 24), rnd.Next(0, 60), 0);

            if (FlightStatus == FlightStatus.DEPARTED_AT || FlightStatus == FlightStatus.EXPECTED_AT)
            {
                StatusTime = new DateTime(now.Year, now.Month, now.Day, rnd.Next(now.Hour, 24), rnd.Next(now.Minute, 60), 0);
            }
            
            //Passenger List initialization
            for (int i = 0; i < _passengerCount; i++)
            {
                PassengerList.Add(new Passenger(rnd, this));
            }

        }

        //For sorting in a Flights Table
        public int CompareTo(object obj)
        {
            if (obj is Flight)
            {
                return this.Time.CompareTo(((Flight)obj).Time);
            }
            else
            {
                return -1;
            }

        }

        public override string ToString()
        {
            return this.FlightID;
        }

        private static PropertyInfo[] InitProps()
        {
            PropertyInfo[] props = typeof(Passenger).GetProperties();
            var propList = new List<PropertyInfo>();
            foreach (var item in props)
            {
                if (Attribute.IsDefined(item, typeof(DescriptionAttribute)))
                {
                    propList.Add(item);
                }
            }
            return propList.ToArray();

        }

    }
}
