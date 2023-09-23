using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayG7
{
    internal class ThreadDemo
    {
        public static void DemoCurrentTH()
        {
            Thread t1 = Thread.CurrentThread;
            int id = t1.ManagedThreadId;
            Console.WriteLine("Thread Id =" +id);
            Console.WriteLine("IsAlive = "+ t1.IsAlive);
            Console.WriteLine("Priority="+ t1.Priority);
            Console.WriteLine("ThreadState=" + t1.ThreadState);
            Console.WriteLine("CurrentCulture=" + t1.CurrentCulture);
            Console.WriteLine(DateTime.Now.ToLongDateString());
            t1.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
            Console.WriteLine("CurrentCulture=" + t1.CurrentCulture);
            Console.WriteLine(DateTime.Now.ToLongDateString());
            t1.CurrentCulture = new CultureInfo("de-DE");
            Console.WriteLine("CurrentCulture=" + t1.CurrentCulture);
            Console.WriteLine(DateTime.Now.ToLongDateString());
            t1.CurrentCulture = new CultureInfo("ta-IN");
            Console.WriteLine("CurrentCulture=" + t1.CurrentCulture);
            Console.WriteLine(DateTime.Now.ToLongDateString());

        }
        public static  void DemoA()
        {
            Thread t1 = Thread.CurrentThread;
            int id = t1.ManagedThreadId;
            Console.WriteLine("MainTh ID"+id);
            ServiceA a1 = new ServiceA();
            a1.DoTaskA();
            //ServiceA.DoTaskA();
        }

        //Multiple Threads
        public static void DemoB()
        {
            Thread t = Thread.CurrentThread;
            int id = t.ManagedThreadId;
            Console.WriteLine("MainTh ID"+id);
            ServiceA a1 = new ServiceA();
            Thread t1 = new Thread(a1.DoTaskA);//Delegate
            Console.WriteLine(t1.ManagedThreadId+"T1 State"+ t1.ThreadState);
            t1.Start();
            Console.WriteLine(t1.ManagedThreadId + "State after start" + t1.ThreadState);
            Thread.Sleep(6000);
            Console.WriteLine(t1.ManagedThreadId + "State after sleep" + t1.ThreadState);

            //a1.DoTaskA();
            Console.WriteLine(".............End of DemoB............");
        }
        public static void DemoC()
        {
            Thread t = Thread.CurrentThread;
            int id = t.ManagedThreadId;
            Console.WriteLine("MainTh ID" + id);
            ServiceA a1 = new ServiceA();
            ThreadStart ts = a1.DoTaskA;
            Thread t1 = new Thread(ts);
            Thread t2 = new Thread(ts);
            t1.Start();
            t2.Start();
            t1.Join(3000);
            //if (t1.IsAlive) t1.Abort();  //Thread Abort obsolete
            t2.Join(3000);
            //if (t2.IsAlive) t2.Abort();//Thread Abort obsolete
            Console.WriteLine(".............End of DemoC............");

        }


    }
}
