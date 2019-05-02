using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Project.Flight_Data;

namespace Airport_Project.Menu_Data
{
    class FlightEditor
    {
        public List<Flight> ArrivalFlights { get; set; }
        public List<Flight> DepartureFlights { get; set; }
        private const byte deskTableLength = 10;
        private FlightPrinter flightPrinter;

        public FlightEditor(FlightPrinter _flightPrinter)
        {
            flightPrinter = _flightPrinter;
            ArrivalFlights = new List<Flight>();
            DepartureFlights = new List<Flight>();
            flightPrinter = new FlightPrinter();
        }

        //Initalize lists
        public FlightEditor(bool isRandomInitalization, FlightPrinter _flightPrinter) : this(_flightPrinter) //True - Random data Initialization 
        {            
            if (isRandomInitalization)
            {
                Random rnd = new Random();
                for (int i = 0; i < deskTableLength; i++)
                {
                    ArrivalFlights.Add(new Flight(rnd));
                    DepartureFlights.Add(new Flight(rnd));                   
                }                
                ArrivalFlights.Sort();                
            }
        }        

        internal void EditFlight(List<Flight> flights, string direction)
        {
            flightPrinter.PrintTable(flights, direction);
        }

        

    }
}
