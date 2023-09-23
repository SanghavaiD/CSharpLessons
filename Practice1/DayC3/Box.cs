using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayThree
{
    internal class Box
    {
        public int Height;
        public int Length;
        public int Width;

        public Box(int X)
        {
            Console.WriteLine("Box is Created");
        }

        public void Open()
        {
            Console.WriteLine("Box is Open");
        }
        public void Close()
        {
            Console.WriteLine("Box is Closed");
        }
        public override string ToString()
        {
            return $"Height.{Height},Width.{Width},Length{Length}";
        }
    }
    internal class WoodenBox : Box
    {
        public int Area;
        public WoodenBox() : base(1)
        {
            Console.WriteLine("woodenbox constructor");
        }
        public WoodenBox(int x) : base(x)
        {
            Console.WriteLine("woodenbox constructor");
        }
        public WoodenBox(int x, int y) : base(x)
        {
            Console.WriteLine("woodenbox constructor");
        }
        public void Move()
        {
            Console.WriteLine("Wooden box shifted");
        }
        public override string ToString()
        {
            return $"TOM AND JERRY";
        }
    }
    internal class BoxTester
    {
        public static void TestOne()
        {
            Box box = new Box(1);
            box.Height = 10;
            box.Width = 5;
            box.Length = 20;
            box.Open();
            box.Close();
            String output = box.ToString();
            Console.WriteLine(output);
        }
        public static void TestTwo()
        {
            WoodenBox box = new WoodenBox();
            box.Height = 10;
            box.Width = 5;
            box.Length = 20;
            box.Open();
            box.Close();
            String output = box.ToString(); //TOM AND JERRY
            Console.WriteLine(output);
            box.Area = 300;
            box.Move();
        }
        public static void TestThree()
        {
            Box box = new WoodenBox();
            box.Height = 10;
            box.Width = 5;
            box.Length = 20;
            box.Open();
            box.Close();
            String output = box.ToString();
            Console.WriteLine(output);
            //box.Area = 300;
            //box.Move();
        }
    }
}