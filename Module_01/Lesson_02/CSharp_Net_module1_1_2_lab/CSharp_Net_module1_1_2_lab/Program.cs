namespace CSharp_Net_module1_1_2_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use "Debugging" and "Watch" to study variables and constants

            //1) declare variables of all simple types:
            //bool, char, byte, sbyte, short, ushort, int, uint, long, ulong, decimal, float, double
            // their names should be: 
            //boo, ch, b, sb, sh, ush, i, ui, l, ul, de, fl, d0
            // initialize them with 1, 100, 250.7, 150, 10000, -25, -223, 300, 100000.6, 8, -33.1
            // Check results (types and values). Is possible to do initialization?
            // Fix compilation errors (change values for impossible initialization)
            
            bool    boo = true;
            char    ch  = 'A';
            byte    b   = 250;       //0..255
            sbyte   sb  = 127;       //-128..127
            short   sh  = 10000;     //-32 768 to 32 767
            ushort  ush = 25;        //0 to 65 535
            int     i   = -223;      //-2 147 483 648 to 2 147 483 647
            uint    ui  = 300;       //0 .. 4 294 967 295
            long    l   = 100000;    //-9 223 372 036 854 775 808 .. 9 223 372 036 854 775 807
            ulong   ul  = 8L;        //0 to 18 446 744 073 709 551 615
            decimal de  = -33.1M;    //±1.0 x 10^-28 .. ±7.9228 x 10^28
            float   f1  = 254.0F;    //±1.5 x 10^−45 to ±3.4 x 10^38                   
            double  d0  = 857.4D;    //±5.0 × 10−324 to ±1.7 × 10308


            //2) declare constants of int and double. Try to change their values.
            const int someIntConst = 25;
            const double someDoubleConst = 24.6;
            //someIntConst = 34;
            //someDoubleConst = 45.6;


            //3) declare 2 variables with var. Initialize them 20 and 20.5. Check types. 
            // Try to reinitialize by 20.5 and 20 (change values). What results are there?
            var someVar1 = 20;
            var someVar2 = 20.5;

            System.Console.WriteLine($"Type of SomeVar1 is {someVar1.GetType()}");
            System.Console.WriteLine($"Type of SomeVar2 is {someVar2.GetType()}");

            System.Console.WriteLine("Reinitalize vars...");

            //someVar1 = 20.5; Compilation Error
            someVar2 = 20;

            System.Console.WriteLine($"Type of SomeVar1 is {someVar1.GetType()}");
            System.Console.WriteLine($"Type of SomeVar2 is {someVar2.GetType()}");

            // 4) declare variables of System.Int32 and System.Double.
            // Initialize them by values of i and d0. Is it possible?

            //System.Int32 i = 25;      //i is already exists
            //System.Double d0 = 23.8;  //d0 is already exists

            if (true)
            {
                // 5) declare variables of int, char, double 
                // with names i, ch, do
                // is it possible?

                //int i;        //i is already exists
                //char ch;      //ch is already exists
                //double do;    //"do" - is the special word  


                // 6) change values of variables from 1)
                boo = false;
                ch = 'C';
                b = 251;      
                sb = 125;       
                sh = 10100;     
                ush = 24;        
                i = -221;      
                ui = 301;      
                l = 100400;   
                ul = 2L;       
                de = -31.1M;   
                f1 = 251.0F;    
                d0 = 856.4D;    


            }

            // 7)check values of variables from 1). Are they changed? Think, why
            System.Console.WriteLine(new string('-', 30));
            System.Console.WriteLine($" boo = {boo} \n ch = {ch} \n b = {b} \n sb = {sb} \n sh = {sh} \n ush = {ush} \n i = {i} \n ui = {ui} \n l = {l} \n ul = {ul} \n de = {de} \n f1 = {f1} \n d0 = {d0}");


            // 8) use implicit/ explicit conversion to convert variables from 1). 
            // Is it possible? 

            // Fix compilation errors (in case of impossible conversion commemt that line).
            // int -> char
            ch = (char)i;

            // bool -> short
            //sh = (short)boo; //Compilation Error

            // double -> long
            l = (long)d0;

            // float -> char 
            ch = (char)f1;

            // int to char
            ch = (char)i;

            // decimal -> double
            d0 = (double)de;

            // byte -> uint
            ui = b;

            // ulong -> sbyte
            sb = (sbyte)ul;

            // 9) and reverse conversion with fixing compilation errors.

            // char -> int
            i = ch;

            // short -> bool
            //boo = (bool)sh; //Compilation Error

            // long -> double
            d0 = l;

            // char -> float 
            f1 = ch;

            // char to int
            i = ch;

            // double -> decimal
            de = (decimal)d0;

            // uint -> byte
            b = (byte)ui;

            // sbyte -> ulong
            sb = (sbyte)ul;


            // 10) declare int nullable value. Initialize it with 'null'. 
            // Try to initialize variable i with 'null'. Is it possible?

            //int intVar = null; Compilation Error

            int? intVar = null;
            System.Nullable<int> invar2 = null;

            System.Console.WriteLine(intVar.GetValueOrDefault());


        }
    }
}
