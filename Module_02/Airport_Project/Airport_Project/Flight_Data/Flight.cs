using System;
using System.Collections.Generic;
using Airport_Project.Airport_Data;
using Airport_Project.Passenger_Data;


namespace Airport_Project.Flight_Data
{
    class Flight : IComparable
    {
        internal string FlightID { get; set; }      //Flight ID
        internal DateTime Time { get; set; }      //Time of arrival (departure)
        internal string CityName { get; set; }      //Destanation(departure) city
        internal string AirCompany { get; set; }      //Air Company ID
        internal char Terminal { get; set; }      //Airport terminal
        internal string GateID { get; set; }      //Airport Gate ID
        internal FlightStatus FlightStatus { get; set; }      //Status of Flight     
        internal DateTime StatusTime { get; set; }      //Status Time
        internal List<Passenger> PassengerList { get; set; }      //List of Passengers

        private Random rnd;
        private int _passengerCount = 10; //Count of passengers on a flight for Random initialization

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

            FlightID = AirportData.flights[rnd.Next(AirportData.flights.Length)];

            CityName = AirportData.cities[rnd.Next(AirportData.cities.Length)];

            AirCompany = AirportData.airComps[rnd.Next(AirportData.airComps.Length)];

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
    }
}
