using System;

namespace ClassWork_01
{
    class StringMatrix
    {
        public static int Size1 = 3, Size2 = 3;
        private readonly string[,] strMatrix;
        
        public string this[int x, int y]
        {
            get => strMatrix[x, y];
            set => strMatrix[x, y] = value;
        }

        public StringMatrix()
        {
            strMatrix = new[,] {{"A1", "B1", "C1"}, {"A2", "B2", "C2"},{"A3","B3","C3"}};

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
                for (int j = 0; j < Size2 - 1; j++)
                {
                    resStrMatrix[i, j] = tbl1[i, j] + " " + tbl1[i, j + 1];
                    resStrMatrix[i, Size2 - 1] = tbl1[i, Size2 - 1] + " " + tbl1[i, 0];

                }
            }

            return resStrMatrix;
        }
    }
}