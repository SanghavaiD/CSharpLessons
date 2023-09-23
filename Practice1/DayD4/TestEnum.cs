using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayFour
{
        class TestEnum
        {
            public static void TestMovieRating()
            {
                Type t1 = typeof(MovieRating);
                String[] enumNames = Enum.GetNames(t1);
                String name = String.Empty;
                int len = enumNames.Length;
                for (int i = 0; i < len; i++)
                {
                    name = enumNames[i];
                    MovieRating movies = (MovieRating)Enum.Parse(t1, name);
                    Console.WriteLine(name + " " + (int)movies);
                }
            }
        }
    
}
