using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_02
{
    public class Bird
    {
        public string Genus { get; set;}

        public void Fly()
        {
        }

        public Bird(string Genius)
        {
            this.Genus = Genus;
        }

        public Bird()
        {
            Genus = "bird";
        }

        public virtual void Voice()
        {
            Console.WriteLine("Bird");
        }



    }

    class Duck : Bird
    {

        public Duck(string Genus) : base(Genus)
        {

        }
        public void Swim()
        {
           
        }

        public override void Voice()
        {
           
            Console.WriteLine("Duck says CraCRa");
        }
        
    }

    class SomeDuck : Duck
    {
        public SomeDuck(string Genus) : base(Genus)
        {
        }

        public new void Voice()
        {
            Console.WriteLine("SomeDuck");
        }
    }
}
