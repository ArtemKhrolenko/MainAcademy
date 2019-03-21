using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    internal class Farmer
    {

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
            int j = isOnTheRightBank ? 5 : 0;

            for (int i = 0 + j; i < 4 + j; i++)
            {
                Console.WriteLine($"{i + 1}. {stuff[i]}");
            }
            
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
            
        }
            
    }
    
}
