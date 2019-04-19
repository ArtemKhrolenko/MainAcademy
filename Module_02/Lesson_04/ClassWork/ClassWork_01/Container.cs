using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class Container
    {
        private int container_var;
        public Container(int nested_var)
        {
            Nested1 n1 = new Nested1();
            n1.nestedVar = nested_var;

        }

        public class Nested1
        {
            public int nestedVar;
        }

        public class Nested2
        {
            private Container container;

            public Nested2(Container container, int containerVar)
            {
                this.container = container;
                this.container.container_var = containerVar;
            }
        }
    }
}
