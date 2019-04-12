using System;


namespace Hello_Cons_Dr_Methods
{
    class Program
    {
        static void Main()
        {
            try
            {
                //Implement start position, width and height, symbol, message input

                //Create Box class instance
                Box box = new Box()
                {
                    StartX = 50,
                    StartY = 10,
                    Height = 10,
                    Width = 20,
                    BorderSymbol = '*',
                    MessageInsideBox = "Message jhygmfjhytjhyrjhrjhtrjhyrjmytmjhfkjyt"
                };                

                //Use  Box.Draw() method

                box.Draw();
                Console.WriteLine("Press any key...");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
