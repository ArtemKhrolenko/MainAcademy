using System;

namespace CSharp_Net_module1_4_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) Create an array of Animal objects and object of Animals    
            // print animals with foreach operator for object of Animals 
           
            Animal[] animals = { new Animal("Tiger", 180), new Animal("Lioin", 30), new Animal("Zebra", 120) };
            Animals animalsObj = new Animals(animals);

            Console.WriteLine("Objext od Animals: ");
            foreach (Animal item in animalsObj)
            {
                Console.WriteLine($"Animal: {item.Genus} -- Weight: {item.Weight}");
            }
            Console.WriteLine(new string('-', 30));

            // 11) Invoke 3 types of sorting 
            // and print results with foreach operator for array of Animal objects  

            Array.Sort(animals, Animal.SortGenusDescending());
            foreach (var item in animals)
            {
                Console.WriteLine($"Animal: {item.Genus} -- Weight: {item.Weight}");
            }
            Console.WriteLine(new string('-', 30));


            Array.Sort(animals, Animal.SortWeightAccending());
            foreach (var item in animals)
            {
                Console.WriteLine($"Animal: {item.Genus} -- Weight: {item.Weight}");
            }
            Console.WriteLine(new string('-', 30));

            Array.Sort(animals);
            foreach (var item in animals)
            {
                Console.WriteLine($"Animal: {item.Genus} -- Weight: {item.Weight}");
            }
            Console.WriteLine(new string('-', 30));



            Console.ReadLine();
        }
    }
}
