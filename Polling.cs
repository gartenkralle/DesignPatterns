using ConsoleApp5;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Polling
{
    class Program
    {
        static Database database;

        static void Main(string[] args)
        {
            database = new Database();

            database.Temperature = 10;
            Helper.Poll(() => database.Temperature, nameof(Database.Temperature), Database_TemperatureChanged);
            database.Temperature = 20;
            Thread.Sleep(400);
            database.Temperature = 30;

            Thread.Sleep(1000000); //Program does not end
        }

        private static void Database_TemperatureChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is int temperature)
            {
                Console.WriteLine("New Temperature is: " + temperature);
            }
        }
    }

    public class Database
    {
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
                }
            }
        }
    }

    public class Helper
    {
        static ValueType lastValue;

        public static void Poll(Func<ValueType> intValue, string nameofProperty, PropertyChangedEventHandler valueChanged)
        {
            int delay = 100;
            CancellationToken token = new CancellationTokenSource().Token;

            lastValue = intValue();

            Task listener = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                        break;

                    if (!lastValue.Equals(intValue()))
                        valueChanged?.Invoke(intValue(), new PropertyChangedEventArgs(nameofProperty));

                    lastValue = intValue();
                    Thread.Sleep(delay);
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }
}
