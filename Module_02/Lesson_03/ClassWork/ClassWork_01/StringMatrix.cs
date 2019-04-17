
using System;

namespace ClassWork_01
{
    class StringMatrix
    {
        public static int Size1 = 3, Size2 = 3;
        private readonly string[,] _strMatrix;
        
        public string this[int x, int y]
        {
            get => _strMatrix[x, y];
            set => _strMatrix[x, y] = value;
        }

        public StringMatrix()
        {
            _strMatrix = new[,] {{"A1", "B1", "C1"}, {"A2", "B2", "C2"},{"A3","B3","C3"}};

        }

        public static StringMatrix operator +(StringMatrix tbl1, StringMatrix tbl2)
        {
            StringMatrix resStrMatrix = new StringMatrix();
            for (var i = 0; i < Size1; i++)
            {
                for (var j = 0; j < Size2; j++)
                {
                    resStrMatrix[i, j] = tbl1[i, j] + tbl2[i, j];
                }
                
            }
            return resStrMatrix;
        }

        public static StringMatrix operator ++(StringMatrix tbl1)
        {
            StringMatrix resStrMatrix = new StringMatrix();
            for (var i = 0; i < Size1; i++)
            {
                for (var j = 0; j < Size2 - 1; j++)
                {
                    resStrMatrix[i, j] = tbl1[i, j] + " " + tbl1[i, j + 1];
                    resStrMatrix[i, Size2 - 1] = tbl1[i, Size2 - 1] + " " + tbl1[i, 0];

                }
            }

            return resStrMatrix;
        }

        public string StrColumn()
        {
            string column = null;
            for (int j = 0; j < Size2; j++)
            {
                column += this[0, j];
            }

            return column;
        }

        public static bool operator >=(StringMatrix tbl1, StringMatrix tbl2)
        {
            bool resStrMatrix = String.CompareOrdinal(tbl1.StrColumn(), tbl2.StrColumn()) >= 0 ? true : false;
            return resStrMatrix;
        }

        public static bool operator <=(StringMatrix tbl1, StringMatrix tbl2)
        {
            bool resStrMatrix = String.CompareOrdinal(tbl2.StrColumn(), tbl1.StrColumn()) >= 0 ? true : false;
            return resStrMatrix;
        }
    }
}