using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    internal class FarmerGOne 
    {
        //Implementation with arrays
                      
        private bool isOnTheRightBank;                              //is farmer on the right bank?        
        private char[] leftBankStuff, rightBankStuff, currentStuff; //arrays with signs of stuff
        private string[] stuff = { "Wolf", "Goat", "Cabbage", "Farmer alone" }; //only for printing variants of choice on the next step

        internal FarmerGOne()
        {
            leftBankStuff = new char[] { 'w', 'g', 'c', 'f' };
            rightBankStuff = new char[] { '0', '0', '0', '0' };

            isOnTheRightBank = false;            //farmer is on the left bank
        }

        //display vars (choice)
        private void PrintVariants(char[] _currentBankStuff)
        {
            Console.WriteLine(isOnTheRightBank ? "<======" : "======>");
            for (int i = 0; i < _currentBankStuff.Length; i++)
            {
                if(_currentBankStuff[i] != '0')
                {
                    Console.WriteLine(String.Format("{0, -12} ----- {1}", stuff[i], i+1));
                    //Console.WriteLine($"{stuff[i]} ------ {i+1}");
                }
            }            
        }

        
        private void CheckChoice(string _choiceStr)
        {
            Int32.TryParse(_choiceStr, out int currentChoice);

            Console.ForegroundColor = ConsoleColor.Red;

            if (currentChoice <= 0 || currentChoice > 5)        //Checking for incorrect input
                Console.WriteLine("Incorrect data!");

            else if ((currentChoice == 1 || currentChoice == 4) && currentStuff[1] == 'g' && currentStuff[2] == 'c') //if choice is Wolf
            {
                Console.WriteLine("OOps! The Goat eats the Cabbage!!!");
            }

            else if ((currentChoice == 3 || currentChoice == 4) && currentStuff[0] == 'w' && currentStuff[1] == 'g')  //If choice is Cabbage
            {
                Console.WriteLine("OOps! The Wolf eats the Goat!!!");
            }
            
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have made a riht choice!");

                //Transfer item from one bank to another
                if (isOnTheRightBank)
                {
                    leftBankStuff[currentChoice - 1] = currentStuff[currentChoice - 1];
                    leftBankStuff[3] = currentStuff[3]; //Farmer arrives on the left bank

                }
                else
                {
                    rightBankStuff[currentChoice - 1] = currentStuff[currentChoice - 1];
                    rightBankStuff[3] = currentStuff[3]; //Farmer arrives on the right bank
                }
                currentStuff[currentChoice - 1] = '0';
                currentStuff[3] = '0'; //Framer leavs from the bank

                isOnTheRightBank = !isOnTheRightBank; ;
            }

        }
        
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


            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Please,  type numbers by step ");


            string choiceStr;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;

                currentStuff = isOnTheRightBank ? rightBankStuff : leftBankStuff;
                PrintVariants(currentStuff);           //Print stuff on the current bank

                Console.WriteLine("Please Make your choice:");

                choiceStr = Console.ReadLine();        //Receive choice from User

                CheckChoice(choiceStr);                //Checking the choice


                Console.WriteLine("Press any key to cintinue");
                Console.ReadLine();

            }

            while (!rightBankStuff.SequenceEqual(new char[] {'w','g','c','f'})); //Untill right bank will be filled with all of items (walf, goat and cabbage)

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Congratulations!! You are win!!");

            Console.ReadLine();

        }
            
    }
    
}
