using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayOne
{
    internal class Ques7
    {
        public static void Three5Fifteen()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0) { Console.WriteLine("GRAPES"); }
                else if (i % 3 == 0) { Console.WriteLine("APPLE"); }
                else if (i % 5 == 0) { Console.WriteLine("ORANGE"); }
                else { Console.WriteLine(i); }
            }
        }
    }
}

