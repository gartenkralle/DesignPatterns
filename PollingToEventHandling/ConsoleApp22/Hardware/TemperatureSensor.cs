using System;
using System.Threading;
using System.Threading.Tasks;

namespace WeaterStation
{
    internal static class TemperatureSensor
    {
        private readonly static Random random;

        public static double Data { get; private set; }

        static TemperatureSensor()
        {
            random = new Random(DateTime.Now.Millisecond);
            Data = random.NextDouble();

            Task.Run(() =>
            {
                while (true)
                {
                    Data = random.NextDouble();
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
