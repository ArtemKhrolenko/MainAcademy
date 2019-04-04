using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_02
{
    struct Point_struct
    {
        public int x;
        public int y;

        public Point_struct(int x_struct, int y_struct)
        {
            x = x_struct;
            y = y_struct;
        }

        public void Inc_struct() //Addition 1
        {
            x++;
            y++;
        }

        public void Decr_struct()
        {
            x--;
            y--;
        }

        public void Disp_struct()
        {
            Console.WriteLine("Struct point x = {0}, y = {1}", x,y);
        }
        
        
    }

    class Point_class
    {
        public int x;
        public int y;

        public Point_class(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Incr_class()
        {
            x++;
            y++;
        }
        public void Decr_class()
        {
            x--;
            y--;
        }

        public void Disp_class()
        {
            Console.WriteLine("Class point x = {0}, y = {1}, x, y");
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            Point_struct pStr = new Point_struct(2, 4);
            Point_class pClass = new Point_class(2, 4);

            pStr.Inc_struct();
            pStr.Decr_struct();
            Console.WriteLine($"pstr.x = { pStr.x}, pstr.y = {pStr.y}");
        }
    }
}
