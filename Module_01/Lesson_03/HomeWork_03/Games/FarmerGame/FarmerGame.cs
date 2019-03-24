using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Games.FarmerGame
{
    internal class FarmerGame
    {
        private ArrayList leftBankStuff = new ArrayList();  // Stuff on the LEft bank
        private ArrayList rightBankStuff = new ArrayList(); // Stuff on the Right bank
        ArrayList currentStuff;                             // What staff on the current bank?
        private bool isOnTheRightBank;                      //is Farmer on the right bank?

        internal FarmerGame()
        {
            //Initalize Left Bank Stuff
            leftBankStuff.Add(new Wolf());
            leftBankStuff.Add(new Goat());
            leftBankStuff.Add(new Cabbage());
            leftBankStuff.Add(new Farmer());

            //Initalize Right Bank Stuff (Empty Bank)
            for (int i = 0; i < 4; i++)
            {
                rightBankStuff.Add(0);
            }

            isOnTheRightBank = false; // Stuff are on the left Bnk

        }

        internal void PrintVariants(ArrayList _stuff) 
        {
            Console.WriteLine(isOnTheRightBank ? "<======" : "======>");

            for (int i = 0; i < _stuff.Count; i++)
            {
               if (_stuff[i] is Stuff)
                {                    
                    Console.WriteLine(String.Format("{0, -12} ----- {1}", ((Stuff)_stuff[i]).Name, i + 1));
                }
            }
        }

        internal void CheckChoice(string _choiceStr)
        {
            Int32.TryParse(_choiceStr, out int currentChoice);

            Console.ForegroundColor = ConsoleColor.Red;

            if (currentChoice <= 0 || currentChoice > 5)        //Checking for incorrect input
                Console.WriteLine("Incorrect data!");

            else if ((currentChoice == 1 || currentChoice == 4) && currentStuff[1] is Goat && currentStuff[2] is Cabbage) //if choice is Wolf
            {
                Console.WriteLine("OOps! The Goat eats the Cabbage!!!");
            }

            else if ((currentChoice == 3 || currentChoice == 4) && currentStuff[0] is Wolf && currentStuff[1] is Goat)  //If choice is Cabbage
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
                currentStuff[currentChoice - 1] = 0;
                currentStuff[3] = 0; //Framer leavs from the bank

                isOnTheRightBank = !isOnTheRightBank; ;
            }

        }

        internal bool isAllOnTheRightBank(ArrayList _stuff)
        {
            foreach (var item in _stuff)
            {
                if (!(item is Stuff))
                    return false;                
            }        
            return true;
        }

        public void StartGame()
        {            
            string choiceStr;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                
                currentStuff = isOnTheRightBank? rightBankStuff : leftBankStuff;
                PrintVariants(currentStuff);           //Print stuff on the current bank

                Console.WriteLine("Please Make your choice:");

                choiceStr = Console.ReadLine();        //Receive choice from User

                CheckChoice(choiceStr);                //Checking the choice


                Console.WriteLine("Press any key to cintinue");
                Console.ReadLine();
                
            }
            while (!isAllOnTheRightBank(rightBankStuff)); //Untill right bank will be filled with all of items (walf, goat and cabbage)

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Congratulations!! You are win!!");

            Console.ReadLine();
            
           
        }
    }
}
