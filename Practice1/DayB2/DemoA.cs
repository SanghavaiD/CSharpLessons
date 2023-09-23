using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayTwo
{
    internal class DemoA
    {
        //GLOBAL VARIABLE
        int x = 123;//MEMBER VARIABLE/ CLASS VARIABLE/ FIELD
        static int y = 567;
        public static void FirstMethod()
        {
            //LOCAL VARIABLE
            int y= 5000;
            // Console.WriteLine(x);//NON STATIC MEMBER can not be accessed
            Console.WriteLine(y) ;//LOCAL Variable
            Console.WriteLine(DemoA.y);//Global Static variable
        }
        int variableA = 0;
        public static void SecondMethod() //Non static method
        {
            //LOCAL VARIABLES
            int y = 5000;
            //Console.WriteLine(x) ; //NON STATIC MEMBER can be accessed
            Console.WriteLine(y); // LOCAL variable
            Console.WriteLine(DemoA.y); // GLOBAL STATIC variable
        }
    }
    internal class DemoB
    {
    }
}

namespace Practice1.Gavs
{
    internal class DemoA
    {
    }
}
