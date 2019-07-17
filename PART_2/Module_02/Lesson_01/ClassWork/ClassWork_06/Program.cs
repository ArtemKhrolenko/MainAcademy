using System;
using System.Threading;


class TestClass
{
    public int Value;
}

class Program
{
    static void Main()
    {
        var test = new TestClass();

        var theThread = new Thread(TestMethod);
        theThread.Start(test);

        while (test.Value != 255) ;
        Console.WriteLine("OK");
    }

    static void TestMethod(Object obj)
    {
        Thread.Sleep(100);

        var test = (TestClass)obj;
        test.Value = 255;
    }
}