﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Airport
{   
    internal struct Flight : IComparable
    {        
        internal string       flightID;      //Flight ID
        internal DateTime     time;          //Time of arrival (departure)
        internal string       cityName;      //Destanation(departure) city
        internal string       airCompany;    //Air Company ID
        internal char         terminal;      //Airport terminal
        internal string       gateID;        //Airport Gate ID
        internal FlightStatus flightStatus;  //Status of Flight     
        internal DateTime     statusTime;    //Status Time
        private Random rnd;

        //For random implicit fields initalization
        public Flight(Random _rnd) : this()
        {
            rnd = _rnd;
            RandomInitalizeFlight(_rnd);
            
        }

        //For explicit fields initalization
        public Flight(string flightID, DateTime time, string cityName, string airCompany, char terminal, string gateID, FlightStatus flightStatus) : this()
        {           
            this.flightID = flightID;
            this.time = time;
            this.cityName = cityName;
            this.airCompany = airCompany;
            this.terminal = terminal;
            this.gateID = gateID;
            this.flightStatus = flightStatus;
        }

        public int CompareTo(object obj)
        {
            if (obj is Flight)
                return this.time.CompareTo(((Flight)obj).time);
            else
                return -1;
        }
        
        //Random initalization
        private void RandomInitalizeFlight(Random rnd)
        {   
            
            flightID = AirportData.flights[rnd.Next(AirportData.flights.Length)];
            
            cityName = AirportData.cities[rnd.Next(AirportData.cities.Length)];
            
            airCompany = AirportData.airComps[rnd.Next(AirportData.airComps.Length)];
            
            terminal = (char)rnd.Next(65, 91);
            
            gateID = terminal.ToString() + rnd.Next(1, 99);
            
            DateTime now = DateTime.Now;
            time = new DateTime(now.Year, now.Month, now.Day, rnd.Next(0, 24), rnd.Next(0, 60), 0);
            
            Array flightStsItems = Enum.GetValues(typeof(FlightStatus));
            flightStatus = (FlightStatus)flightStsItems.GetValue(rnd.Next(flightStsItems.Length));
            
        }

    }
}
