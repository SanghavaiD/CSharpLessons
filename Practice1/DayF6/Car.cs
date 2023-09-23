using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DaySix
{
    public class Car
    {
        public string RegistrationNo { get; set; }
        public string Model { get; set; }
        public FuelType Fuel { get; set; }
        public Wheel[] Wheels { get; } = new Wheel[4];
        public Engine CarEngine { get; } = new Engine();



        public Car(string registrationNo, string model, FuelType fuel)
        {
            RegistrationNo = registrationNo;
            Model = model;
            Fuel = fuel;



            for (int i = 0; i < 4; i++)
            {
                Wheels[i] = new Wheel();
            }
        }



        public enum FuelType
        {
            Petrol,
            Diesel,
            Electric,
            Hybrid
        }



        public class Wheel
        {
            // Wheel properties, methods, etc.
        }



        public class Engine
        {
            // Engine properties, methods, etc.
        }
    }



    public class Tester
    {
        public static   void Test()
        {
            Car myCar = new Car("ABC123", "Sedan", Car.FuelType.Petrol);



            Console.WriteLine($"Registration No: {myCar.RegistrationNo}");
            Console.WriteLine($"Model: {myCar.Model}");
            Console.WriteLine($"Fuel Type: {myCar.Fuel}");



            foreach (var wheel in myCar.Wheels)
            {
                Console.WriteLine($"Wheel: {wheel}");
            }
        }
    }   
}







