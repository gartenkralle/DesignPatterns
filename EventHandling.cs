using System;
using System.ComponentModel;

namespace EventHandling
{
    class Program
    {
        static Database database;

        static void Main(string[] args)
        {
            database = new Database();

            database.Temperature = 10;
            database.TemperatureChanged += Database_TemperatureChanged;
            database.Temperature = 20;
            database.Temperature = 30;
        }

        private static void Database_TemperatureChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Database.Temperature))
            {
                Console.WriteLine("New Temperature is: " + (int)sender);
            }
        }
    }

    public class Database
    {
        public event PropertyChangedEventHandler TemperatureChanged;

        private int temperature;

        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value != temperature)
                {
                    temperature = value;
                    TemperatureChanged?.Invoke(temperature, new PropertyChangedEventArgs(nameof(Temperature)));
                }
            }
        }
    }
}
