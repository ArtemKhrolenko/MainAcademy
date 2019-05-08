using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_02
{
    class Publisher
    {
        public delegate void MyDelegate();
        private void Method1(object o, EventArgs arg)
        {
            Console.WriteLine("Method 1", new EventArgs());
        }

        private void Method2(object o, EventArgs arg)
        {
            Console.WriteLine("Method 2");
        }

        private void buttonClick(object sender, EventArgs e)
        {
            EventHandler myptr = null;

            myptr += Method1;
            myptr += Method2;

            myptr(sender, e);

        }
        public void Start()
        {
            buttonClick(this, new EventArgs());
            Console.WriteLine(this.GetType());
        }
    }
}
