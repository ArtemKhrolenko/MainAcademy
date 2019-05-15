using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClassWork_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);
            queue.Enqueue("Four");


            Console.WriteLine($"Number of Elements in Queue {queue.Count}");

            foreach (var item in queue.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Number of Elements in Queue {queue.Count}");

           

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }



            Console.WriteLine($"Number of Elements in Queue {queue.Count}");



        }
    }
}
