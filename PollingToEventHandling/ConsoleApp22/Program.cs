using WeaterStation.Model;
using System;

namespace WeaterStation
{
    class Program
    {
        static void Main()
        {
            Humidity humidity = new Humidity();
            Temperature temperature = new Temperature();
            Pressure pressure = new Pressure();

            Console.WriteLine("Initial Humunidity: " + humidity.Data);
            Console.WriteLine("Initial Temperature: " + temperature.Data);
            Console.WriteLine("Initial Pressure: " + pressure.Data);

            humidity.Changed += Humidity_Changed;
            temperature.Changed += Temperature_Changed;
            pressure.Changed += Pressure_Changed;

            Console.ReadKey();
        }

        private static void Humidity_Changed(ValueType data)
        {
            Console.WriteLine("Spontaeous Humunidity: " + data);
        }

        private static void Temperature_Changed(ValueType data)
        {
            Console.WriteLine("Spontaeous Temperature: " + data);
        }

        private static void Pressure_Changed(ValueType data)
        {
            Console.WriteLine("Spontaeous Pressure: " + data);
        }
    }
}
