using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) declare 2 objects
            Money moneyFirst  = new Money(5, CurrencyTypes.Eur);
            Money moneySecond = new Money(100, CurrencyTypes.Eur);


            // 11) do operations
            // add 2 objects of Money
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Adding two objects money1 and money2...");
            Console.ResetColor();
            Console.WriteLine($"money1 (amount = {moneyFirst.Amount}) + money2 (amount = {moneySecond.Amount}) = money3 (amount = {(moneyFirst + moneySecond).Amount})");
            moneyFirst += moneySecond;
            Console.WriteLine(moneyFirst.Amount);

            // add 1st object of Money and double
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Adding objects money1 and double...");
            Console.ResetColor();
            double doubleVal = 5;
            Console.WriteLine($"money1 (amount = {moneyFirst.Amount}) + double (doubleVal = {5}) = money3 (amount = {(moneyFirst + (Money)doubleVal).Amount})");

            // decrease 2nd object of Money by 1 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Decreasing amount of money2...");
            Console.ResetColor();
            Console.WriteLine($"money2 (amount = {moneySecond.Amount}) = money3 (amount = {(--moneySecond).Amount})");

            // increase 1st object of Money
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Increasing amount of money1...");
            Console.ResetColor();
            Console.WriteLine($"money1 (amount = {moneyFirst.Amount})  = money3 (amount = {(moneyFirst *= 3).Amount})"); //!!!!!! same object

            // compare 2 objects of Money
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Comparision  money1 and money2...");
            Console.ResetColor();
            Console.WriteLine($"money1 (amount = {moneyFirst.Amount}) > money2 (amount = {moneySecond.Amount})? == {moneyFirst > moneySecond}");
            Console.WriteLine($"money1 (amount = {moneyFirst.Amount}) < money2 (amount = {moneySecond.Amount})? == {moneyFirst < moneySecond}");


            // compare 2nd object of Money and string
            Console.ForegroundColor = ConsoleColor.Green;
            string strValue = "22";
            Console.WriteLine($"Comparision money2 and string ...");
            Console.ResetColor();
            Console.WriteLine($"money2 (amount {moneySecond.Amount}) > strValue {strValue} ? {moneySecond > strValue} ");
            Console.WriteLine($"money2 (amount {moneySecond.Amount}) < strValue {strValue} ? {moneySecond < strValue} ");


            // check CurrencyType of every object
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Checking currencyType of objects...");
            Console.ResetColor();
            Console.WriteLine(moneyFirst ? "Currency is valid" : "Currency is invalid");
            Console.WriteLine(moneySecond ? "Currency is valid" : "Currency is invalid");


            // convert 1st object of Money to string
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Converting money1 to string...");
            Console.ResetColor();
            string stringValue = (string)moneyFirst;
            Console.WriteLine($"money1 (amount = {stringValue})");

        }
    }
}
