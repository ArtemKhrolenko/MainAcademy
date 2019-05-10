using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Airport_Project.Menu_Data
{
    class Editor
    {
        protected string ReceiveUserChoice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Incorrect Input. {Environment.NewLine} 1 - To previous menu {Environment.NewLine} 2 - To exit editing {Environment.NewLine} Any key - Try again");
            Console.ResetColor();
            return Console.ReadLine();
        }

        //Method for changing string Items in Flight Structure
        protected (bool succeed, string result) ChangeItemInDesk(string itemName, string oldItemValue, string pattern, int length)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Editing {itemName}");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write($"Change {itemName} from {oldItemValue} to...:  ");

            string strNewValue = Console.ReadLine();
            if (!Regex.IsMatch(strNewValue, pattern))
                return (false, "Error");

            if (strNewValue.Length > length)
            {
                strNewValue = strNewValue.Substring(0, length);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{itemName} was changed to {strNewValue}. Press any key to Continue...");
            Console.ResetColor();
            Console.ReadKey();
            return (true, strNewValue);
        }

        //Method for changing character Items in Flight Structure
        protected (bool succeed, char result) ChangeItemInDesk(string itemName, char oldItemValue)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Editing {itemName}");
            Console.ForegroundColor = ConsoleColor.Gray;
            (bool succeed, char result) charItem;

            Console.Write($"Change {itemName} from {oldItemValue} to...:  ");

            //If Terminal ID is char [A-Z]
            if (Char.TryParse(Console.ReadLine(), out charItem.result) && charItem.result > 64 && charItem.result < 91)
            {
                charItem.succeed = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{itemName} was changed to {charItem.result}. Press any key to Continue...");
                Console.ReadKey();
            }
            else
            {
                charItem.succeed = false;
                charItem.result = oldItemValue;
            }

            Console.ResetColor();
            return charItem;
        }

        //Method for changing time Items in Flight Structure
        protected (bool succeed, DateTime result) ChangeItemInDesk(string itemName, DateTime oldItemValue, string pattern)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Editing {itemName}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Change item from {oldItemValue.ToString(pattern)} to (in {pattern} format)...:  ");
            //Console.Write($"Change item from {oldItemValue.Hour.ToString("D2")}:{oldItemValue.Minute.ToString("D2")} to (in HH:mm format)...:  ");

            (bool succeed, DateTime result) _newDateTime;
            try
            {
                //_newDateTime.result = DateTime.ParseExact(Console.ReadLine() + ":00", "HH:mm:ss", CultureInfo.InvariantCulture);
                _newDateTime.result = DateTime.ParseExact(Console.ReadLine(), pattern, CultureInfo.InvariantCulture);

                _newDateTime.succeed = true;
                Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine($"Time changed to {_newDateTime.result.Hour.ToString("D2")}:{_newDateTime.result.Minute.ToString("D2")}. Press any key to continue...");
                Console.WriteLine($"Time changed to {_newDateTime.result.ToString(pattern)}. Press any key to continue...");

                Console.ReadKey();

            }
            catch (Exception)
            {
                _newDateTime = (false, new DateTime());
            }
            return _newDateTime;
        }

        //Method for changing Enum value
        protected void ChangeItemInDesk(string itemName, Enum oldItemValue)
        {
            (bool succeed, Enum result) _enumValue;
            Console.WriteLine($"Editing {itemName}...");

            //Printing All of statuses
            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (var item in Enum.GetValues(oldItemValue.GetType()))
            {
                Console.WriteLine((int)item + 1 + ". " + item.ToString());
            }
            Console.WriteLine("0. To return to previous menu");
            Console.ResetColor();
            Console.WriteLine($"Chose the {itemName} to set...");

            bool isEnumValue = Int32.TryParse(Console.ReadLine(), out int _sexIndex);

            if (isEnumValue && _sexIndex == 0)
            {
                _enumValue.succeed = true;
                _enumValue.result = oldItemValue;
            }


            //Checking for correct input for the status of Flight
            //if (isEnumValue && _sexIndex > 0 && _sexIndex <= Enum.GetValues(oldItemValue.GetType()).Length)
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine($"{itemName} changed from \"{oldItemValue.ToString()}\" to \"{((typeof(oldItemValue))(_sexIndex - 1)).ToString()}\". Press any key to Continue...");
            //    //passengers[numOfPassToEdit - 1].Sex = (PassengerSex)_sexIndex - 1;
            //    Console.ReadKey();
            //}
        }

    }
}
