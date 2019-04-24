using System;
using System.Threading;

namespace Hello_Class_stud
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix : String_matrix, Imorse_crypt
    {
        public const int Size_2 = Alphabet.Size;
        private int offset_key = 0;

        //Implement Morse_matrix constructor with the int parameter for offset
        //Use fd(Alphabet.Dictionary_arr) and sd() methods

        public Morse_matrix(int offset_key)
        {
            this.offset_key = offset_key;
            fd(Alphabet.Dictionary_arr);
            sd();
        }
        //Implement Morse_matrix constructor with the string [,] Dict_arr and int parameter for offset
        //Use fd(Dict_arr) and sd() methods
        public Morse_matrix(string[,] Dict_arr, int offset_key)
        {
            this.offset_key = offset_key;
            fd(Dict_arr);
            sd();
        }

        public Morse_matrix()
        {
            fd(Alphabet.Dictionary_arr);
        }



        


        //!Feel the matrix
        private void fd(string[,] Dict_arr)
        {
            for (int ii = 0; ii < Size1; ii++)
                for (int jj = 0; jj < Size_2; jj++)
                    this[ii, jj] = Dict_arr[ii, jj];
        }


        //!Shifting colimn 1 of MAtrix with offset_key
        private void sd()
        {
            int off = Size_2 - offset_key;
            for (int jj = 0; jj < off; jj++)
                this[1, jj] = this[1, jj + offset_key];
            for (int jj = off; jj < Size_2; jj++)
                this[1, jj] = this[1, jj - off];
        }

        //Implement Morse_matrix operator +


        //Realize crypt() with string parameter
        //Use indexers
        public string crypt(string stringItem)
        {
            string resStr = String.Empty;
            for (int i = 0; i < stringItem.Length; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    if (Char.Parse(this[0, j]) == stringItem[i])
                        resStr += this[1, j].ToString();
                }
            }
            return resStr;
        }

        //Realize decrypt() with string array parameter
        //Use indexers
        public string decrypt(string[] stringArray)
        {
            string resStr = string.Empty;
            for (int i = 0; i < stringArray.Length; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    if (stringArray[i] == this[1, j])
                        resStr += this[0, j];
                }
            }
            return resStr;
        }


        //Implement Res_beep() method with string parameter to beep the string
        internal void Res_beep(string strItemToBeep)
        {
            foreach (char beepItem in strItemToBeep.ToCharArray())
            {

                if (beepItem == '.')
                {
                    Console.Beep(1000, 100);
                    Thread.Sleep(10);
                }
                else if (beepItem == '-')
                {
                    Console.Beep(1000, 250);
                    Thread.Sleep(10);
                }
                else if (beepItem == ' ')
                    Thread.Sleep(300);

                Console.Write(beepItem);
            }

        }


    }
}

