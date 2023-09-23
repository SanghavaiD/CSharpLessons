using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayOne
{
    internal class ValueTypeLesson
    {
        public static void TestValueTypes()
        {
            byte b1 = 255;
            Console.WriteLine(b1);
            Console.WriteLine(byte.MinValue);
            Console.WriteLine(byte.MaxValue);
            Console.WriteLine(sbyte.MinValue);
            Console.WriteLine(sbyte.MaxValue);
            Console.WriteLine(short.MaxValue);
            Console.WriteLine(short.MinValue);
            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(long.MinValue);
            Console.WriteLine(long.MaxValue);
            Console.WriteLine(double.MaxValue);
            Console.WriteLine(double.MinValue);
            Console.WriteLine(float.MaxValue);
            Console.WriteLine(float.MinValue);
            float f1 = 52.678f;
            long l1 = int.MaxValue + 1L;
            double d1 = 1234567890.123457890d;
            Console.WriteLine(f1);
            Console.WriteLine(l1);
            Console.WriteLine(d1);
            char c1 = 'S';
            Console.WriteLine(c1);
            int x = c1;
            Console.WriteLine(x);
            int y = 68;
            char c2 = (char)y;
            Console.WriteLine(c2);
            bool flag = true;
            Console.WriteLine(flag);
        }
        public static void TestMethod()
        {
            Console.WriteLine("Test");
        }
    }
}
