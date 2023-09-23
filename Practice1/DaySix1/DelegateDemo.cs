using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;
public delegate void MethodHandlerA();
public delegate int MethodHandlerB(int x, int y);

namespace Practice1.DaySix1
{
    public class MathCalculator
    {
        public void DoTask()
        {
            Console.WriteLine("Calculator Do Task");
        }
        public int Add(int x, int y)
        {
            Console.WriteLine(x + "," + y);
            return x + y;
        }
        public int Multiply(int x, int y)
        {
            Console.WriteLine(x + "," + y);
            return x * y;

        }
        public int Divide(int x, int y)
        {
            Console.WriteLine(x + "," + y);
            return x / y;

        }
        public String GetMode()
        {
            return "X500";
        }


    }
    internal class DelegateDemo
    {
        public static void TestOne()
        {
            MathCalculator mc = new MathCalculator();
            MethodHandlerA methodHandlerA = mc.DoTask; 
            MethodHandlerB methodHandlerB = mc.Add;//MethodHandlerB methodHandlerB = new MethodHandlerB(mc.Multiply);
            methodHandlerB  = mc.Multiply; //MultiCast//methodhandlerB performs both add and multiply here.
            //MethodHandlerB methodHandlerThree = new MethodHandlerB(mc.Divide);
            methodHandlerA();
            int addResult = methodHandlerB(100, 50);
            Console.WriteLine(addResult);
            //int multiplyResult = methodHandlerTwo(20, 5);
            //Console.WriteLine(multiplyResult);
        }
    }
}
