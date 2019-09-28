using System;
using System.Threading;
using System.Threading.Tasks;

namespace WeaterStation
{
    internal class Helper
    {
        ValueType lastValue;

        public void Poll(Func<ValueType> value, Action<ValueType> valueChanged)
        {
            int delay = 100;

            using (CancellationTokenSource cancellationTokenSource = new CancellationTokenSource())
            {
                CancellationToken cancellationToken = cancellationTokenSource.Token;
                
                lastValue = value();

                Task listener = Task.Factory.StartNew(() =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        if (!lastValue.Equals(value()))
                        {
                            valueChanged?.Invoke(value());
                        }

                        lastValue = value();
                        Thread.Sleep(delay);
                    }
                }, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }
    }
}
