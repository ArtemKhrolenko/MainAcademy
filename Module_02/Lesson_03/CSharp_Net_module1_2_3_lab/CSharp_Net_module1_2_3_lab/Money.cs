using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    // 1) declare enumeration CurrencyTypes, values UAH, USD, EU
    enum CurrencyTypes
    {
        Uah,
        Usd,
        Eur
    }

    class Money
    {
        // 2) declare 2 properties Amount, CurrencyType
        public Decimal Amount { get; set;}
        public CurrencyTypes CurrencyType { get; set; }

        
        // 3) declare parameter constructor for properties initialization
        public Money(Decimal amount, CurrencyTypes currencyType)
        {
            this.Amount = amount;
            this.CurrencyType = currencyType;
        }

        public Money(Decimal amount)
        {
            this.Amount = amount;
        }

        // 4) declare overloading of operator + to add 2 objects of Money
        public static Money operator +(Money moneyFirst, Money moneySecond)
        {
            return new Money(moneyFirst.Amount + moneySecond.Amount, moneyFirst.CurrencyType);
        }

        // 5) declare overloading of operator -- to decrease object of Money by 1
        public static Money operator --(Money moneyOne)
        {
            return new Money(--moneyOne.Amount, moneyOne.CurrencyType);
        }

        //??????????????????
        // 6) declare overloading of operator * to increase object of Money 3 times
        public static Money operator *(Money moneyFirst, Money moneySecond)
        {
            return new Money(moneyFirst.Amount * moneySecond.Amount, moneyFirst.CurrencyType);
        }

        // 7) declare overloading of operator > and < to compare 2 objects of Money
        public static bool operator >(Money moneyFirst, Money moneySecond)
        {
            return moneyFirst.Amount > moneySecond.Amount;
        }

        public static bool operator <(Money moneyFirst, Money moneySecond)
        {
            return moneyFirst.Amount < moneySecond.Amount;
        }

        // 8) declare overloading of operator true and false to check CurrencyType of object
        public static bool operator true(Money money)
        {
            return money.CurrencyType is CurrencyTypes.Usd || money.CurrencyType is CurrencyTypes.Uah || money.CurrencyType is CurrencyTypes.Eur;
        }

        public static bool operator false(Money money)
        {
            return !(money.CurrencyType is CurrencyTypes.Usd && money.CurrencyType is CurrencyTypes.Uah && money.CurrencyType is CurrencyTypes.Eur);
        }


        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa
        public static implicit operator Money(double doubleValue)
        {
            return new Money((decimal)doubleValue);
        }

        public static explicit operator double(Money money)
        {
            return (double)money.Amount;
        }

        public static implicit operator Money(string stringValue)
        {
            decimal.TryParse(stringValue, out var decimalVal);
            return new Money(decimalVal);
        }

        public static explicit operator string(Money money)
        {
            return money.Amount.ToString();
        }

    }
}
