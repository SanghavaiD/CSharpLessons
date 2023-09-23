using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayTwo
{
    internal class Box
    {
        public int height;
        public int width;
        public const String type = "Wooden";
        public int GetHeight()
        { return height; }
    }
    internal class TestBox
    {
        public static void TestOne() 
        {
            Box box = new Box();    
            box.height = 100;
            //Box.width = 200;
            Box firstBox = new Box();
            Box secondBox = new Box();
            firstBox.width = 12345;
            secondBox.width = 98765;
            Console.WriteLine($"First Box={firstBox.width},{firstBox.GetHeight()}");
            Console.WriteLine($"Second Box={secondBox.width},{secondBox.GetHeight()}");
            Console.WriteLine(Box.type);
            box.height = 777;
            Console.WriteLine($"First Box={firstBox.width},{firstBox.GetHeight()}");
            Console.WriteLine($"Second Box={secondBox.width},{secondBox.GetHeight()}");

         
        }

    }
}
