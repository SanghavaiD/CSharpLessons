using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayThree
{
    internal interface IMessageService
    {
        void SendMessage(string message);
        void SendAudioMessage(string message);
        void SendVideoMessage(string message);
        void ReceiveMessage();
        void DeleteMessage();
    }
    public interface IPayments
    {
        void MakePayment(float amount);
    }
    internal class WhatsApp : IMessageService , IPayments
    {
        public void DeleteMessage()
        {
            Console.WriteLine("Message Deleted");
        }
        public void MakePayment(float amount)
        {
            Console.WriteLine($"Paid Amount {amount}");

        }
        public void ReceiveMessage()
        {
            Console.WriteLine("Method Not Implemented");
        }
        public void SendAudioMessage(string message)
        {
            Console.WriteLine("Method Not Implemented");
        }
        public void SendMessage(string message)
        {
            Console.WriteLine("Method Not Implemented");
        }
        //Public abstract void SendVideoMessage(string message);
        public void SendVideoMessage(string message)
        {
            Console.WriteLine("Method Not Implemented");
        }
        
        //END OF CLASS
    }
    public class MessageTester
    {
        public static void TestOne()
        {
            IMessageService messageservice = new WhatsApp();
            messageservice.SendMessage("hello");
            messageservice.ReceiveMessage();
        }
    }
}
