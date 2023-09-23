using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayFour
{
    class DateDemo
    {
        public static void FirstMethod()
        {
            Console.WriteLine(DateTime.Now);

            DateTime d1 = new DateTime(2018, 04, 10); //YYYY,MM,DD
            Console.WriteLine(d1.ToLongDateString());
            Console.WriteLine(d1.ToShortTimeString());
        }
        public static void SecondMethod()
        {
            Console.WriteLine("What is your Date of Birth (yyyy/mm/dd)");
            String strdob = Console.ReadLine();
            DateTime d1 = DateTime.Parse(strdob);
            int year = d1.Year;
            Console.WriteLine("Year OF Dob " + year);
            int month = d1.Month;
            Console.WriteLine("Month OF Dob " + month);
            int day = d1.Day;
            Console.WriteLine("Day OF Dob " + day);
            DateTime d2 = d1.AddMonths(10);
            Console.WriteLine("AddMonths(10) " + d2.ToShortDateString());
            DateTime d3 = d1.AddDays(5);
            Console.WriteLine("AddDays(5) " + d3.ToShortDateString());
            DateTime d4 = d1.AddYears(58);
            Console.WriteLine("AddYears(58) " + d4.ToShortDateString());
            DateTime d5 = d1.AddYears(-5);
            Console.WriteLine("AddYears(-5) " + d5.ToShortDateString());
        }

        public static void FindAgeOfaPerson()
        {
            Console.WriteLine("What is your Date of Birth (yyyy/mm/dd)");
            String strdob = Console.ReadLine();
            try
            {
                Console.ReadLine();
                DateTime d1 = DateTime.Parse(strdob);
                DateTime d2 = DateTime.Now;
                TimeSpan ts = d2.Subtract(d1);
                DateTime age = new DateTime(ts.Ticks);
                Console.WriteLine("Age in date" + age.ToShortDateString());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            // Prompt the user for their date of birth
            Console.WriteLine("Enter your date of birth (YYYY-MM-DD):");
            string dobString = String.Empty;
            try
            {
                dobString = Console.ReadLine();
                if (dobString == null)
                {
                    Console.WriteLine("Date Of Birth is NULL!!!");
                    return;
                }
                // Parse the date of birth
                DateTime dob = DateTime.Parse(dobString);

                // Calculate the age
                DateTime now = DateTime.Now;
                int ageYears = now.Year - dob.Year;
                if (now < dob.AddYears(ageYears))
                {
                    ageYears--;
                }
                int ageMonths = now.Month - dob.Month;
                if (now < dob.AddMonths(ageMonths).AddDays(now.Day - dob.Day))
                {
                    ageMonths--;
                }
                int ageDays = now.Day - dob.Day;
                if (now.Day < dob.Day)
                {
                    ageDays += DateTime.DaysInMonth(now.Year, now.Month);
                }
                // Print the age
                Console.WriteLine(
                    $"You are {ageYears} years, {ageMonths} months, and {ageDays} days old."
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RetirementDay()
        {
            Console.WriteLine("What is your Date of Birth (yyyy/mm/dd)");
            String strdob = String.Empty;
            try
            {
                strdob = $"{Console.ReadLine()}";
                DateTime dob = DateTime.Parse(strdob);
                DateTime nextMonthDate = dob.AddYears(60).AddMonths(1);
                DateTime retirementdate = new DateTime(nextMonthDate.Year, nextMonthDate.Month, 1).AddDays(-1);
                Console.WriteLine("Your Retirement Date is" + retirementdate.ToShortDateString());

            }
            catch (Exception err)
            {
                Console.WriteLine($"ERROR:{err.Message}");
            }
        }
        public static void TestMultipleNestedTry()
        {
            try // try1
            {
                try // try2
                {
                    try //try3
                    {
                        try //try4
                        {
                            throw new Exception("bla bla");
                        }
                        catch (Exception ex0)
                        {
                            throw new ApplicationException("ex0" + ex0.Message);
                        }//end of try4
                    }
                    catch (ApplicationException ex1)
                    {
                        throw new IndexOutOfRangeException("ex1" + ex1.Message);
                    }
                    catch (Exception ex2)
                    {
                        throw new Exception("ex2" + ex2.Message);
                    }//end of try3
                }
                catch (ApplicationException ex3)
                {
                    throw new DllNotFoundException("ex3" + ex3.Message);
                }
                catch (IndexOutOfRangeException ex4)
                {
                    throw new ArgumentNullException("ex4" + ex4.Message);
                }
                catch (Exception ex5)
                {
                    throw new Exception("ex5" + ex5.Message);
                }// end of try2
            }
            catch (ApplicationException ex6)
            {
                throw new ArgumentNullException("ex6" + ex6.Message);
            }
            catch (DllNotFoundException ex7)
            {
                throw new DllNotFoundException("ex7" + ex7.Message);
            }
            catch (ArgumentNullException ex8)
            {
                throw new ArgumentNullException("ex8" + ex8.Message);
            }
            catch (Exception ex9)
            {
                throw new ArgumentNullException("ex9" + ex9.Message);
            }// end of try1
        }

    }
}
