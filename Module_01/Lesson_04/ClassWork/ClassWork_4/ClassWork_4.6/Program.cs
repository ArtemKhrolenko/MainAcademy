using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4._6
{
    public struct Animal
    {
        public string species;
        public string name;
        public int age;
        public Sex sex;

        public void Write()
        {
            Console.WriteLine($"Species: {species}\nName: {name}\nAge: {age}\nSex: {sex}");
        }
    }

    public enum Sex { Male, Female};

    class Program
    {
        static void Main(string[] args)
        {
            //Declare and initalize struct Animal objects
            Animal lion;

            lion.species = "lion";
            lion.name = "leo";
            lion.age = 7;
            lion.sex = Sex.Male;
            lion.Write();

            Animal lion2 = new Animal();
            lion2.species = lion.species;
            lion2.name = "king";
            lion2.age = 5;
            lion2.sex = Sex.Male;
            
            Console.WriteLine("-----------------");
            lion2.Write();

            Console.WriteLine(new string('4', 34));


        }
    }
}
