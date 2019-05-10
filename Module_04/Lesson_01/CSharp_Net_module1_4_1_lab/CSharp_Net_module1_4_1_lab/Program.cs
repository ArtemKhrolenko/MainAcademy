using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_4_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 9) declare object of OnlineShop 
            OnlineShop shop = new OnlineShop();

            // 10) declare several objects of Customer
            Customer customer1 = new Customer("Jack");
            Customer customer2 = new Customer("John");
            Customer customer3 = new Customer("Jimm");


            // 11) subscribe method GotNewGoods() of every Customer instance 
            // to event NewGoodsInfo of object of OnlineShop
            shop.someEvent += customer1.GotNewGoods;
            shop.someEvent += customer2.GotNewGoods;
            shop.someEvent += customer3.GotNewGoods;

            // 12) invoke method NewGoods() of object of OnlineShop
            shop.NewGoods("Malina");
            // discuss results

        }
    }
}
