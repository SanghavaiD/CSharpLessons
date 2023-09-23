using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DaySix1
{
    internal class Sample
    {
        //public static void Practice()
        //{
        //    String strFriends = "Tom And Jerry are good friends";
        //   int strLength= strFriends.Length;
        //    Console.WriteLine($"The number of characters is : {strLength}");
        //}
        public static void QuestionThreeC()
        {
            String strFriends = "Tom and Jerry are good friends";
            Console.WriteLine($"Char Count: {strFriends.Length} ");
        }
        public static void QuestionFourC()
        {
            String strFriends = "Tom and Jerry are good friends";
            string strInUpper = strFriends.ToUpper();
            Console.WriteLine(strFriends);
            Console.WriteLine(strInUpper);
        }
        public static void QuestionThreeE()
        {
            String strFriends = "Tom and Jerry are good friends";
            string strPart = strFriends.Substring(10, 5);
            Console.WriteLine(strFriends);
            Console.WriteLine(strPart);
        }
        public static void QuestionFour()
        {
            Console.WriteLine("Enter a NAME");
            String name = $"{Console.ReadLine()}";
            int len = name.Trim().Length;
            if (len < 8)
            {
                String errorMessage = "Name is Lessthan 8 Char. Try Again...";
                throw new Exception(errorMessage);
            }
            char[] nameCharArray = name.Trim().ToUpper().ToCharArray();
            foreach (var item in nameCharArray)
            {
                int asciiValue = item;
                if (asciiValue < 65 || asciiValue > 90)
                {
                    String errorMessage = "Name Must contain ONLY Alphabets. Try Again...";
                    throw new Exception(errorMessage);
                }
            }
            Console.WriteLine($"Correct Input {name}");
        }
    }
}

