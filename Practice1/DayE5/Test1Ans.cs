using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayFive
{
    internal class Test1Ans
    {
        public interface IServiceA
        {
            void Fly();
        }
        public interface IServiceB
        {
            void Run();
            void Swim();
        }
        public class ABServices : IServiceA, IServiceB
        {
            public void Fly()
            {
                Console.WriteLine("Fly");
            }

            public void Run()
            {
                Console.WriteLine("Run");
            }

            public void Swim()
            {
                Console.WriteLine("Swim");
            }
        }
        public static void QuestionEight()
        {
            IServiceA serviceA = new ABServices();
            serviceA.Fly();
            IServiceB serviceB = new ABServices();
            serviceB.Swim();
            serviceB.Run();
        }
    }
   
}
