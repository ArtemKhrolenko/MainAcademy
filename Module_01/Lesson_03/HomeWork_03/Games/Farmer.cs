using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    internal class Farmer
    {

        //private int currentChoice;
        private string whoAreOnTheBank; //String with staff
        private bool isOnTheRightBank;  //is farmer on the right bank?
        private string[] stuff = { "Wolf", "Goat", "Cabbage", "Farmer alone" };

        internal Farmer()
        {
            whoAreOnTheBank = "wgcf|0000";
            isOnTheRightBank = false;            
        }

        //display vars (choice)
        private void ShowVariants()
        {
            Console.WriteLine(isOnTheRightBank ? "<======" : "======>");
            int j = isOnTheRightBank ? 5 : 0;

            for (int i = 0 + j; i < 4 + j; i++)
            {
                if (whoAreOnTheBank[i] != '0')
                    Console.WriteLine($"{i-j + 1}. {stuff[i-j]}");
            }
            
        }

        private bool CheckTheChoice()
        {
            StringBuilder strbCurrent, strbAnother;
            int _currentChoice = -1;
            string _currentBankString = "", _currentAnotherBankString = "";
            try
            {
                //In dependency on where farmer is chose staff what on the exat bank
                _currentBankString = isOnTheRightBank ? whoAreOnTheBank.Substring(5,4) : whoAreOnTheBank.Substring(0, 4);
                _currentAnotherBankString = isOnTheRightBank ? whoAreOnTheBank.Substring(0, 4) : whoAreOnTheBank.Substring(5, 4);

                //Receive number of choice from user                
                _currentChoice = Int32.Parse(Console.ReadLine());

                //Checking for the valid of data
                if (_currentChoice == -1 || _currentChoice > 4 )
                {
                    throw new Exception();
                }
                else if (_currentBankString[_currentChoice - 1] == '0')
                {
                    Console.WriteLine("This item is not on the bank!!!");
                    return false;
                }                    
                else //Choice is correct. Logic checking
                {
                    strbCurrent = new StringBuilder(_currentBankString);
                    strbCurrent.Replace(strbCurrent[_currentChoice - 1], '0', _currentChoice - 1, 1); //Remove the current stuff
                    strbCurrent.Replace(strbCurrent[3], '0', 3, 1);   //Remove the farmer                                

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (strbCurrent.ToString() == "wg00")
                    {
                        Console.WriteLine("Oops! Wolf eats the Goat!");
                    }
                    else if (strbCurrent.ToString() == "0gc0")
                    {
                        Console.WriteLine("Oops! Goat eats the Cabbage!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Good Operation!!!!!");

                        strbAnother = new StringBuilder(_currentAnotherBankString);
                        strbAnother.Replace(strbAnother[_currentChoice - 1], _currentBankString[_currentChoice - 1], _currentChoice-1, 1); //Get the current stuff
                        strbAnother.Replace(strbAnother[3], 'f', 3, 1); //Get the farmer

                        //Invert the bank
                        isOnTheRightBank = !isOnTheRightBank;

                        //Combine the result BankString;
                        whoAreOnTheBank = isOnTheRightBank ? strbCurrent.ToString() + "|" + strbAnother.ToString() : strbAnother.ToString() + "|" + strbCurrent.ToString();

                        Console.WriteLine(whoAreOnTheBank);                        

                    }
                }

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect data!");
                return false;
            }      

            return true;
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
            

            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Please make a choice!!");
                ShowVariants();

                CheckTheChoice();
            }
            while (whoAreOnTheBank != "0000|wgcf");

            Console.WriteLine("Congratulations!!! You WIN!!!");
            Console.ReadKey();

        }
            
    }
    
}
