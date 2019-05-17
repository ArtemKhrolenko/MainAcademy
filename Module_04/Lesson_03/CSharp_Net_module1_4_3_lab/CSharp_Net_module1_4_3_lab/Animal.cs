using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp_Net_module1_4_3_lab
{
    // 12) change methods of sorting to properties

    // 1) implement interface IComparable
    public class Animal : IComparable
    {
        // 2) declare properties and parameter constructor
        public string Genus { get; set; }
        public int Weight { get; set;   }

        public Animal(string genus, int weight)
        {
            Genus = genus;
            Weight = weight;
        }

        // 3) implement method ComareTo()
        // it comares Genus of type string - return result of method String.Compare 
        // for this.genus and argument object
        // don't forget to cast object to Animal
        public int CompareTo(object obj)
        {
            if (!(obj is Animal)) return -1;
            else return string.Compare(Genus, ((Animal)obj).Genus);                    
        }

        // 4) declare methods SortWeightAscending(), SortGenusDescending()
        // they are static and return IComparer
        // return type is custed from constructor of classes SortWeightAscendingHelper, 
        // SortGenusDescendingHelper calling 


        public static IComparer<Animal> SortWeightAccending()
        {
            return new SortWeightAscendingHelper();
        }

        public static IComparer<Animal> SortGenusDescending()
        {
            return new SortGenusDescendingHelper();
        }

        // 5) declare 2 nested private classes SortWeightAscendingHelper, SortGenusDescendingHelper 
        // they implement interface IComparer
        // every nested class has implemented method Comare with 2 parameters of object and return int
        // class SortWeightAscendingHelper sort weight by ascending        

        private class SortWeightAscendingHelper : IComparer<Animal>
        {
            public int Compare(Animal x, Animal y)
            {
                return x.Weight - y.Weight;
            }
        }

        // class SortGenusDescendingHelper sort genus by descending
        private class SortGenusDescendingHelper : IComparer<Animal>
        {
            public int Compare(Animal x, Animal y)
            {
                return string.Compare(y.Genus, x.Genus);
            }
        }

    }
}
