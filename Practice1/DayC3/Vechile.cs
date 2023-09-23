using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayThree
{
    internal abstract class Vechile
    {
        public Vechile()
        {
            Console.WriteLine("Vechile Constructor");
        }
        public void Start()
        {
            Console.WriteLine("Vechile Started");
        }
    }
    //END OF CLASS

    internal class Car:Vechile
    {
        public Car()
        {
            Console.WriteLine("Car Constructor");
        }
    }
    class VechileTester
    {
        public static void TestOne()
        {
            //vechile tester=newVechile();
            Vechile tester = new Car();
            tester.Start();
            
        }
    }
}
