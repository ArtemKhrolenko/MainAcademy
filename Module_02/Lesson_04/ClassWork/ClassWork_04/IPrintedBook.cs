using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_04
{
    interface IPrintedBook
    {
        int Pages {get;}
        void Publish();
    }

    interface IEbook
    {
        int Pages { get;}
        void Publish();
    }

    abstract class SomeClass
    {
        int someInt;

        protected SomeClass(int someInt)
        {
            this.someInt = someInt;
        }
    }

    class DerClass : SomeClass
    {
        public DerClass(int someInt) : base(someInt)
        {
        }
    }
}
