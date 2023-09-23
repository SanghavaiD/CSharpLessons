using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayFour
{
    public enum city { Chennai, Bangalore, Hyderabad, Pune }
    public enum Designation { Manager, Admin, Developer }
    internal class Employee
    {
        public readonly int Eid;
        public string Ename = String.Empty;
        public city Ecity;  //public string Ecity 
        public Designation JobTitle;  //public string jobtitle
        public Employee(int v1) { Eid = v1; }
        public override String ToString()
        {
            String output = String.Empty;
            output = $"Details of a a employee are: ID ={Eid} Name = {Ename} City: ={Ecity} Designation: = {JobTitle}";
            return output;
        }
    }
    class TestEmployee
    {
        public static void TestOne()
        {
            Employee e1 = new Employee(789);
            //e1.eid = 789
            e1.Ename = "John";
            e1.Ecity = city.Bangalore;    //ecity ="chennai";
            e1.JobTitle = Designation.Developer;//edept = "Testing";
            String output = e1.ToString();
            Console.WriteLine(output);
        }

    }
}






        

        
        

        
    

