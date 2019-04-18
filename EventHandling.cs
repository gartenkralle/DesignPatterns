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
        }

        private static void Database_TemperatureChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is Database database)
            {
                Console.WriteLine("New Temperature is: " + database.Temperature);
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
                    TemperatureChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temperature)));
                }
            }
        }
    }
}
