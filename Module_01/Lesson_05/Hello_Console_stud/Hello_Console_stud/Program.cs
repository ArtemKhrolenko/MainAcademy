using System;
using System.Threading;

namespace Hello_Console_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            try
            {
                do
                {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"Please,  type the number:
                    1.  f(a,b) = |a-b| (unary)
                    2.  f(a) = a (binary)
                    3.  music
                    4.  morse sos
          
                    ");
                    try
                    {
                        a = (int)uint.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                My_strings();
                                Console.WriteLine("");
                                break;
                            case 2:
                                My_Binary();
                                Console.WriteLine("");
                                break;
                            case 3:
                                My_music();
                                Console.WriteLine("");
                                break;
                            case 4:
                                Morse_code();
                                Console.WriteLine("");
                                break;                   
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error"+e.Message);
                    }                   
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #region ToFromBinary
        static void My_Binary()
        {
            Console.Clear();

            //Implement positive integer variable input
            //Present it like binary string
            //   For example, 4 as 100

            //Use modulus operator to obtain the remainder  (n % 2) 
            //and divide variable by 2 in the loop

            //Use the ToCharArray() method to transform string to chararray
            //and Array.Reverse() method

            Console.Write("Enter positive number: ");
            Int32.TryParse(Console.ReadLine(), out int num);
            string str = "";

            #region while loop
            //do
            //{
            //    str = str.Insert(0, (num % 2).ToString());
            //    num /= 2;
            //}
            //while (num != 0)

            #endregion

            //Recursion
            getBinary(num, ref str);
            Console.WriteLine($"Binary string from {num} = {str.PadLeft(((str.Length - 1) / 4 + 1) * 4 , '0')}");
            
        }
        #endregion

        #region ToFromUnary
        static void My_strings()
        {
            //Declare int and string variables for decimal and binary presentations
            int a, b;
            string aStr = string.Empty, bStr = string.Empty, resStr = string.Empty;

            //Implement two positive integer variables input
            Console.WriteLine("Enter first positive number: ");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            a = (int)uint.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Yellow;

            b = (int)uint.Parse(Console.ReadLine());

            //To present each of them in the form of unary string use for loop

            //Use concatenation of these two strings 
            //Note it is necessary to use some symbol ( for example “#”) to separate

            //Check the numbers on the equality 0
            //Realize the  algorithm for replacing '1#1' to '#' by using the for loop 
            //Delete the '#' from algorithm result
            

            for (int i = 0; i < a; i++)
            {
                aStr += "1";
            }

            for (int i = 0; i < b; i++)
            {
                bStr += "1";
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            resStr = aStr + "#" + bStr;
            Console.WriteLine($"aSTr + bSTr = {resStr}");            

            Console.WriteLine();                       
            
            while (resStr.Contains("#"))
            {
                resStr = resStr.Contains("1#1") ? resStr.Replace("1#1", "#") : resStr.Replace("#", string.Empty);
            }

            //Output the result 
            Console.WriteLine($"Unary result: {resStr}");

        }
        #endregion

        #region My_music
        static void My_music()
        {
            //HappyBirthday
            Thread.Sleep(2000);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(2642, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
        }
        #endregion

        #region Morse
        static void Morse_code()
        {
            //Create string variable for 'sos'      
            string str = "Mama mila ramu";

            //Use string array for Morse code
            string[,] Dictionary_arr = new string [,] { { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" },
            { ".-   ", "-... ", "-.-. ", "-..  ", ".    ", "..-. ", "--.  ", ".... ", "..   ", ".--- ", "-.-  ", ".-.. ", "--   ", "-.   ", "---  ", ".--. ", "--.- ", ".-.  ", "...  ", "-    ", "..-  ", "...- ", ".--  ", "-..- ", "-.-- ", "--.. ", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." }};
            //Use ToCharArray() method for string to copy charecters to Unicode character array
            //Use foreach loop for character array in which

            //Implement Console.Beep(1000, 250) for '.'
            // and Console.Beep(1000, 750) for '-'

            
            foreach (char item in str.ToLower().ToCharArray())
            {                
                for (int i = 0; i < Dictionary_arr.GetLength(1); i++)
                {
                    if (char.Parse(Dictionary_arr[0, i]) == item)
                    {
                        string someStr = Dictionary_arr[1, i].Trim();
                        foreach (char beepItem in someStr.ToCharArray())
                        {

                            if (beepItem == '.')
                            {
                                Console.Beep(1000, 250);
                                Thread.Sleep(10);
                            }
                            else if(beepItem == '-')
                            {
                                Console.Beep(1000, 750);
                                Thread.Sleep(10);
                            }                            
                            
                            Console.Write(new string(beepItem, 1));                            
                        }
                        Console.Write(" ");
                    }
                    Thread.Sleep(20);
                }
                if (item == ' ') Console.Write("   ");
            }

                //Use Thread.Sleep(50) to separate sounds
            //                  
        }

        #endregion

        //For ToBinary String recursion
        static void getBinary(int a, ref string str)
        {
            if (a > 1)
                getBinary(a / 2, ref str);
            str += (a % 2).ToString();
        }
    }

    
}
