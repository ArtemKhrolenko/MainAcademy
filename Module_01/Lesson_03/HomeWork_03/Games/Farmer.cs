using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    internal class Farmer
    {

        private int currentChoice;
        private string whoAreOnTheBank; //String with staff
        private bool isOnTheRightBank;  //is farmer on the right bank?
        private string[] stuff = { "Wolf", "Goat", "Cabbage", "Farmer alone" };

        internal Farmer()
        {
            whoAreOnTheBank = "wgcf|0000";
            isOnTheRightBank = false;
            currentChoice = -1;
        }

        //display vars (choice)
        private void ShowVariants()
        {
            int j = isOnTheRightBank ? 5 : 0;

            for (int i = 0 + j; i < 4 + j; i++)
            {
                if (whoAreOnTheBank[i] != '0')
                    Console.WriteLine($"{i-j + 1}. {stuff[i-j]}");
            }
            
        }

        private bool CheckTheChoice()
        {
            int _currentChoice = -1;
            string _currentString = "";
            try
            {
                //In dependency on where farmer is chose staff what on the exat bank
                _currentString = isOnTheRightBank ? whoAreOnTheBank.Substring(5,4) : whoAreOnTheBank.Substring(0, 4);

                //Receive number of choice from user
                Console.WriteLine("Please, make your choice!");
                _currentChoice = Int32.Parse(Console.ReadLine());

                //Checking for the valid of data
                if (_currentChoice == -1 || _currentChoice > 4 )
                {
                    throw new Exception();
                }
                else if (_currentString[_currentChoice - 1] == '0')
                {
                    Console.WriteLine("This item is not on the bank!!!");
                    return false;
                }                    
                else //Choice is correct. Logic checking
                {
                    StringBuilder strb = new StringBuilder(_currentString);
                    strb.Replace(strb[_currentChoice - 1], '0');                    
                    Console.WriteLine(strb.ToString());

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (strb.ToString() == "wg0f")
                    {
                        Console.WriteLine("Oops! Wolf eats the Goat!");
                    }
                    else if (strb.ToString() == "0gcf")
                    {
                        Console.WriteLine("Oops! Goat eats the Cabbage!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Good Operation!!!!!");
                    }
                }

            }
            catch
            {                
                Console.WriteLine("Incorrect data!");
                return false;
            }      

            return true;
        }



        //private void printVariants(ref bool _isBack)
        //{
        //    if (!_isBack)
        //    {
        //        Console.WriteLine("There: farmer and wolf - 1");
        //        Console.WriteLine("There: farmer and cabbage - 2");
        //        Console.WriteLine("There: farmer and goat - 3");
        //        Console.WriteLine("There: farmer  - 4");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Back: farmer and wolf - 5");
        //        Console.WriteLine("Back: farmer and cabbage - 6");
        //        Console.WriteLine("Back: farmer and goat - 7");
        //        Console.WriteLine("Back: farmer  - 8");                
        //    }
        //    Console.ForegroundColor = ConsoleColor.Blue;
        //    Console.WriteLine("Please,  type numbers by step ");
        //}
        internal void StartGame()
        {
            #region The Task
            //Key sequence: 3817283 or 3827183
            // Declare 7 int variables for the input numbers and other variables
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"From one bank to another should carry a wolf, goat and cabbage. 
At the same time can neither carry nor leave together on the banks of a wolf and a goat, 
a goat and cabbage. You can only carry a wolf with cabbage or as each passenger separately. 
You can do whatever how many flights. How to transport the wolf, goat and cabbage that all went well?");

            #endregion

            
            ShowVariants();

            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Please,  type numbers by step ");
            Console.ForegroundColor = ConsoleColor.Gray;

            if (CheckTheChoice())
            {
                //doSomeOperation
            }
            else
            {
                //continue
            }


        }
            
    }
    
}
