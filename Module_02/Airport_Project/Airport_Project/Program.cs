using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Project.Flight_Data;
using Airport_Project.Passenger_Data;


namespace Airport_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Passenger pass = new Passenger(new Random())  ;
            //Console.WriteLine(pass.FirstName + "  " + pass.SecondName + "  " + pass.Nationality + "  " + pass.Passport + "  " + $"{pass.DateOfBirth.ToString("D")}" + "   " + pass.Sex + "   " + pass.PassClass);      
            
            
            Flight flight = new Flight(new Random());           

            foreach (var item in flight.PassengerList)
            {                
                item.GetPassengerFieldsDescription();
                Console.WriteLine("--------------");
            }

        }
    }
}
