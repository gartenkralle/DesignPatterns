using System;
using WeaterStation.Model;
using WeatherStation.BusinessLogic;

namespace WeatherStation.View
{
    class MainView : IReport
    {
        public void Display(Pressure pressure, Temperature temperature, Humidity humidity)
        {
            Console.WriteLine("Initial Humunidity: " + humidity.Data);
            Console.WriteLine("Initial Temperature: " + temperature.Data);
            Console.WriteLine("Initial Pressure: " + pressure.Data);

            humidity.Changed += Humidity_Changed;
            temperature.Changed += Temperature_Changed;
            pressure.Changed += Pressure_Changed;
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
