using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class Farmer
    {
        private void printVariants(ref bool _isBack)
        {
            if (!_isBack)
            {
                Console.WriteLine("There: farmer and wolf - 1");
                Console.WriteLine("There: farmer and cabbage - 2");
                Console.WriteLine("There: farmer and goat - 3");
                Console.WriteLine("There: farmer  - 4");
            }
            else
            {
                Console.WriteLine("Back: farmer and wolf - 5");
                Console.WriteLine("Back: farmer and cabbage - 6");
                Console.WriteLine("Back: farmer and goat - 7");
                Console.WriteLine("Back: farmer  - 8");                
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please,  type numbers by step ");
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


            bool isBackFlight = false; //Does farmer swim back 
            string str = "LwgcR___"; //Left bank - wolf, goat, cabbage (Lwgc); Right bank - nothing, nothing, nothing (R___)         
            int choice;
            int countOnTheLeftBank = 3; //Count of items on the left bank

            while (true)
            {
                printVariants(ref isBackFlight); //Show variant before making a choice
                
                Int32.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        if (str == "L_gcR___" || str == "L___R_gc")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("There are goat and cabbage are on the bank. Goat will eat the cabbage!!! \nMake an another chioce!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            
                            if (!isBackFlight)
                            {
                                str = "L_R";
                            }
                        }
                        
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There are goat and wolf are on the bank. Wolf will eat the goat!!! \nMake an another chioce!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case 3:
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There are goat, cabbage and wolf are on the bank. Goat will eat cabbage!!! \nMake an another chioce!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    default:
                        Console.WriteLine("Youe have entered a wrong number!!!");
                        break;
                }
            }
            
        }

    }
}
