using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter distance: ");
            double Distance = double.Parse(Console.ReadLine());
            Console.WriteLine("Automobile:");
            Automobile car = new Automobile(){ distance = Distance, speed = 50 };
            car.GetTime();
            car.GetPrice();
            Console.WriteLine("Bicycle:");
            Bicycle bike = new Bicycle() { distance = Distance, speed = 35 };
            bike.GetTime();
            bike.GetPrice();
            Console.WriteLine("Carriage:");
            Carriage carriage = new Carriage() { distance = Distance, speed = 70 };
            carriage.GetTime();
            carriage.GetPrice();
            Console.WriteLine("OneWheeledBicycle:");
            OneWheeledBicycle oneWheelBike = new OneWheeledBicycle() { distance = Distance, speed = 25 };
            oneWheelBike.GetTime();
            oneWheelBike.GetPrice();
        }

        abstract class Vehicle
        {
            public double distance { get; set; }
            public abstract int fuelCost { get; }
            public abstract double speed { get; set; }
            public virtual int counter { get { return 1; } }
            public virtual void GetTime()
            {
                double time = distance / speed;
                Console.WriteLine($"To pass {distance} kilometers," +
                    $" if you are moving with {speed} km/hour, it will take you: {Math.Round(time, 2)} hours.");
            }
            public virtual void GetPrice()
            {
                double price = speed / (counter * 175) * fuelCost * distance;
                Console.WriteLine($"To pass {distance} kilometers," +
                    $" if you are moving with {speed} km/hour, you will spend: {Math.Round(price, 2)}$.");
            }
        }

        class Automobile: Vehicle
        {
            public override double speed { get; set; }
            public override int counter { get { return 4; } }
            public override int fuelCost { get { return 25; } }
        }
        class Bicycle : Vehicle
        {
            public const int maxSpeed = 30;
            private double trueSpeed;
            public override double speed
            {
                get {return trueSpeed; }
                set
                {
                    if (value > maxSpeed)
                    {
                        Console.WriteLine($"Max speed is: {maxSpeed}");
                        trueSpeed = maxSpeed;
                    }
                    else trueSpeed = value;
                }
            }
            public override int fuelCost { get { return 0; } }
            
            public override void GetPrice()
            {
                Console.WriteLine($"As fuel for bicycles costs: {fuelCost}$ for now. You won't spend any money.");
            }
        }
        class Carriage : Vehicle
        {
            public override double speed { get; set; }
            public override int counter { get { return 7; } }
            public override int fuelCost { get { return 40; } }
            public override void GetTime()
            {
                var time = distance / speed;
                Console.WriteLine($"To pass {distance} kilometers," +
                    $" if carriage is moving with {speed} km/hour, the duration will be: {Math.Round(time, 2)} hours.");
            }
        }
        class OneWheeledBicycle : Vehicle
        {
            public const int maxSpeed = 20;
            private double trueSpeed;
            public override double speed
            {
                get { return trueSpeed; }
                set
                {
                    if (value > maxSpeed)
                    {
                        Console.WriteLine($"Max speed is: {maxSpeed}");
                        trueSpeed = maxSpeed;
                    }
                    else trueSpeed = value;
                }
            }
            public override int fuelCost { get { return 0; } }

            public override void GetPrice()
            {
                Console.WriteLine($"As fuel for bicycles costs: {fuelCost}$ for now. You won't spend any money.");
            }
        }
    }
}
