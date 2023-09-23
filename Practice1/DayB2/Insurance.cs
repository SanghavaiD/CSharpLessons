using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayTwo
{
    internal class Insurance
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Hospital { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public string Treatment { get; set; } = string.Empty;
        public long ClaimMoney { get; set; }
        public long Phone { get; set; }
        public override string ToString()
        {
            return $"ID:{this.Id}, Name:{FirstName} {LastName},\n" +
                $"Hospital:{Hospital},Address:{Address},\n" +
                $"Phone:{Phone},Treatment:{Treatment},ClaimMoney:{ClaimMoney}";
        }


    }
    internal class TestInsurance
    {
        public static void TestOne()
        {
            Insurance firstPerson = new Insurance();
            firstPerson.Id = 77;
            firstPerson.FirstName = "SANGHAVAI";
            firstPerson.LastName = "BHUVANESWARI";
            firstPerson.Address = "Thousand Lights";
            firstPerson.Hospital = "Global";
            firstPerson.ClaimMoney = 15000;
            firstPerson.Treatment = "Heart Surgery";
            firstPerson.Phone = 7200476769;
            String value = firstPerson.ToString();
            Console.WriteLine(value);
        }

    }
}


