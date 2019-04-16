using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class Program
    {
        static void Main(string[] args)
        {
            StringMatrix tlb1 = new StringMatrix();

            tlb1++;

            for (int i = 0; i < StringMatrix.Size1; i++)
            {
                for (int j = 0; j < StringMatrix.Size2; j++)
                {
                    Console.Write($"{tlb1[i, j]}  ");
                }

                Console.WriteLine();
            }

            StringColumn sol = new StringColumn();
            StringMatrix resStrMatrix = tlb1 + sol;

            Console.WriteLine("--------------");
            for (int i = 0; i < StringMatrix.Size1; i++)
            {
                for (int j = 0; j < StringMatrix.Size2; j++)
                {
                    Console.Write($"{resStrMatrix[i, j]}  ");
                }

                Console.WriteLine();
            }


        }
    }
}
