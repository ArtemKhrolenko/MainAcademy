using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_03
{
    class Bird : IBird, ICloneable
    {
        

        public Bird()
        {
            Genus = "bird";
        }

        public Bird(string genus)
        {
            this.Genus = genus;
        }
        public string Genus { get; private set;}

        public object Clone()
        {
            Bird bird = new Bird(this.Genus);
            return bird;
        }

        public Bird ShalowCopy()
        {
            return (Bird)this.MemberwiseClone();
        }

        public virtual void Voice()
        {
            Console.WriteLine("Bird is singing...");
        }

        public static  void gt(ref int[] a , params int[] b)
        {

        }
    }

    class bird2
    {

    }
}
