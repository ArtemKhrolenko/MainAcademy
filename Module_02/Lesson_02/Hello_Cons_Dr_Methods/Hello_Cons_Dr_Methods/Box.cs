using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Box
    {
        

        //1.  Implement public  auto-implement properties for start position (point position)
        //auto-implement properties for width and height of the box
        //and auto-implement properties for a symbol of a given set of valid characters (*, + ,.) to be used for the border 
        //and a message inside the box
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Char BorderSymbol { get; set; }
        public string MessageInsideBox { get; set;}
        
        //2.  Implement public Draw() method
        //to define start position, width and height, symbol, message  according to properties
        //Use Math.Min() and Math.Max() methods
        //Use draw() to draw the box with message


        //3.  Implement private method draw() with parameters 
        //for start position, width and height, symbol, message
        //Change the message in the method to return the Box square
        //Use Console.SetCursorPosition() method
        //Trim the message if necessary
        private void Draw(int _startX, int _startY, int _height, int _width, char _borderSymbol, string _messageInsideBox)
        {
            //Upper line
            Console.SetCursorPosition(_startX, StartY);
            Console.WriteLine(new string(_borderSymbol, _width));
            //Bottom line
            Console.SetCursorPosition(_startX, StartY + Height);
            Console.WriteLine(new string(_borderSymbol, _width));
            //Left, Right  vertical  
            for (int i = 0; i < _height - 1; i++)
            {
                Console.SetCursorPosition(_startX, StartY + 1 + i);
                Console.WriteLine(_borderSymbol + new string(' ', _width - 2) + _borderSymbol);
            }
            //Insert the Message
            Console.SetCursorPosition(_startX + 1, StartY + Height/2);
            Console.WriteLine(_messageInsideBox);

        }

        public void Draw()
        {
            var startX = Math.Min(Math.Max(0, StartX), Console.WindowWidth - 5);
            var startY = Math.Min(Math.Max(0, StartY), Console.WindowHeight - 5);
            var height = Math.Max(5, Height);
            var width  = Math.Max(5, Width);
            var borderSymbol = BorderSymbol;

            #region Message handling
            var messageStr = MessageInsideBox;
            messageStr = messageStr.Substring(0, Math.Min(messageStr.Length, width - 2));            

            var freeString = new string(' ', Math.Max(0, width - 2 - messageStr.Length) / 2);
            messageStr = string.Concat(freeString, messageStr, freeString);
            #endregion



            Draw(startX, startY, height, width, borderSymbol, messageStr);
        }


    }
}
