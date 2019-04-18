using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Polling
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper helper = new Helper();

            Database database = new Database();

            database.Temperature = 10;
            helper.Poll(() => database.Temperature, nameof(Database.Temperature), Database_TemperatureChanged);
            database.Temperature = 20;
            Thread.Sleep(400);
            database.Temperature = 30;
            Thread.Sleep(400);
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
        ValueType lastValue;

        public void Poll(Func<ValueType> value, string nameofProperty, PropertyChangedEventHandler valueChanged)
        {
            int delay = 100;
            CancellationToken token = new CancellationTokenSource().Token;

            lastValue = value();

            Task listener = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    if (!lastValue.Equals(value()))
                    {
                        valueChanged?.Invoke(value(), new PropertyChangedEventArgs(nameofProperty));
                    }

                    lastValue = value();
                    Thread.Sleep(delay);
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }
}
