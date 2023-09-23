using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayFive
{
    internal class Anagrams
    {
        public static void Anagram()
        {

            String str = "He was at the 24 floor of the building. He saw 42 pots of flowers there. He stop to check if the pots are watered.";

            str = str.Replace(".", "");

            char[] temp1, temp2;

            String str1, str2;

            String[] far = str.Split(" ");

            for (int i = 0; i < far.Count(); i++)

            { temp1 = far[i].ToCharArray();

                Array.Sort(temp1);

                str1 = new String(temp1);

                for (int j = 0; j < far.Count(); j++)
                {
                    temp2 = far[j].ToCharArray();

                    Array.Sort(temp2);

                    str2 = new String(temp2);

                    if (far[i].Length == far[j].Length)
                    {
                        if (str1.Equals(str2) && !far[i].Equals(far[j]))

                        { 
                            System.Console.WriteLine(far[i] + " " + far[j]);
                        }

                    }

                }

            }

        }

    }

}
