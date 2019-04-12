using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class StringMatrix
    {
        public static int Size1 = 5, Size2 = 5;
        private string[,] strMatrix = new string[Size1, Size2];
        
        public string this[int x, int y]
        {
            get { return strMatrix[x, y]; }
            set { strMatrix[x,y] = value; }
        }

        public StringMatrix()
        {
            strMatrix =

        }

        public static StringMatrix operator +(StringMatrix tbl1, StringMatrix tbl2)
        {
            StringMatrix res_str_matrix = new StringMatrix();
            for (int i = 0; i < Size1; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    res_str_matrix[i, j] = tbl1[i, j] + tbl2[i, j];
                }
                
            }
            return res_str_matrix;
        }

        public static StringMatrix operator ++(StringMatrix tbl1)
        {
            StringMatrix resStrMatrix = new StringMatrix();
            for (int i = 0; i < Size1; i++)
            {
                for (int j = 0; j < Size2-1; j++)
                {
                    resStrMatrix[i, j] = tbl1[i, j] + " " + tbl1[i, j + 1];
                    resStrMatrix[i, Size2 - 1] = tbl1[i, Size2 - 1] + " " + tbl1[i, 0];

                }
            }

            return resStrMatrix;
        }
    }

    class StringColumn
    {
        public const int Size2 = 36;
        private string[] _strColumn = new string[Size2];

        public StringColumn()
        {
            for (int i = 0; i < Size2; i++)
            {
                this[i] = null;
            }
        }

        public string this[int x]
        {
            get { return _strColumn[x];  } 
            set { _strColumn[x] = value; }
        }

        public static StringMatrix operator +(StringMatrix tlb1, StringColumn tbl2)
        {
            StringMatrix _resStrMatrix = new StringMatrix();
            for (int i = 0; i < StringMatrix.Size1; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    _resStrMatrix[i, j] = tlb1[i, j] + " " + tbl2[j];
                }
            }

            return _resStrMatrix;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            StringMatrix tlb1 = new StringMatrix();

            //StringMatrix tbl2 = new StringMatrix();
            //StringMatrix tbl3 = tbl1 + tbl2;
            //tbl3 += tbl2;


        }
    }
}
