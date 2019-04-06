using System;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphore
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomethingCristicalRepeatedlyAsync().Wait();
        }

        public static async Task DoSomethingCristicalRepeatedlyAsync()
        {
            await DoSomethingCriticalAsync(DoSomethingAsync);
            await DoSomethingCriticalAsync(DoSomethingAsync);
        }
        public static async Task DoSomethingCriticalAsync(Func<Task> func)
        {
            SemaphoreSlim sem = new SemaphoreSlim(1);
            await sem.WaitAsync();

            try
            {
                await func();
            }
            finally
            {
                sem.Release();
            }

            Console.WriteLine(1);
        }

        public static async Task DoSomethingAsync()
        {
            Task task = new Task(DoSomething);
            task.Start();
            await task;
        }

        public static void DoSomething()
        {
            Thread.Sleep(2000);
        }
    }
}
