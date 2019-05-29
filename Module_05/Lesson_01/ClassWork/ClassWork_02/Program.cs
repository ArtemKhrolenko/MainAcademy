using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_02
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter Str_wr = new StreamWriter("Hello_io_str_mess.txt", true))
            {
                Str_wr.Write(" Hello ");
                Str_wr.WriteLine("_IO_");
                Str_wr.WriteLine("StramWriter");

            }

            //Append
            using(StreamWriter Str_wr1 = new StreamWriter("Hello_io_str_mess.txt", true))
            {
                Str_wr1.WriteLine(" !");
                //Str_wr1.Close();
            }

            SomeMethod();

            BinarYReaderWriter();

        }

        static void SomeMethod()
        {
             using (FileStream fl_stream = new FileStream("Hello_io_str_mess.txt", FileMode.Open))
            {
               using(StreamReader rdr = new StreamReader(fl_stream))
                {
                    Console.WriteLine(rdr.ReadToEnd());
                    Console.WriteLine(rdr.BaseStream);
                }

            }

            
            using(StreamReader rdr2 = new StreamReader("Hello_io_str_mess.txt", Encoding.Default))
            {
                char[] array = new char[4];
                rdr2.Read(array,0,4);
                Console.WriteLine(array);

                
                
            }
        }

        static void BinarYReaderWriter()
        {
            FileInfo fl_inf = new FileInfo("Hello_io_binary.dat");
            using (BinaryWriter bwr = new BinaryWriter(fl_inf.OpenWrite()))
            {
                Console.WriteLine("Base stream is: {0}", bwr.BaseStream);
                double aDouble = 2015.6;
                int anInt = 20156;
                string aString = "C, s, h";
                bwr.Write(aDouble);
                bwr.Write(anInt);
                bwr.Write(aString);

            }

            Console.WriteLine("Ok!!");

            using (BinaryReader brd = new BinaryReader(fl_inf.OpenRead()))
            {
                
                Console.WriteLine(brd.ReadDouble());
                Console.WriteLine(brd.ReadInt32());
                Console.WriteLine(brd.ReadString());

            }
        }
    }
}
