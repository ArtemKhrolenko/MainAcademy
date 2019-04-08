using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_04
{
    class Car
    {
        internal string color;
        public Car()
        {
            color = "Red";
        }

        
        public Car(string color)
        {
            color = "Red";
        }

        ~Car()
        {
            Console.WriteLine("Destroy car");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Console.WriteLine(car.color);

        }
    }
}
