namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            TestEagerLoadingSingleton();
            TestLazyLoadingWithLockSingleton();
            TestLazyLoadingWithLazyClassSingleton();
        }

        static void TestEagerLoadingSingleton()
        {
            EagerLoading.Singleton s1 = EagerLoading.Singleton.Instance;
            EagerLoading.Singleton s2 = EagerLoading.Singleton.Instance;

            if (s1 == s2)
                System.Console.WriteLine("Equals");
            else
                System.Console.WriteLine("Not equals");
        }

        static void TestLazyLoadingWithLockSingleton()
        {
            LazyLoadingWithLock.Singleton s1 = LazyLoadingWithLock.Singleton.Instance;
            LazyLoadingWithLock.Singleton s2 = LazyLoadingWithLock.Singleton.Instance;

            if (s1 == s2)
                System.Console.WriteLine("Equals");
            else
                System.Console.WriteLine("Not equals");
        }

        static void TestLazyLoadingWithLazyClassSingleton()
        {
            LazyLoadingWithLazyClass.Singleton s1 = LazyLoadingWithLazyClass.Singleton.Instance;
            LazyLoadingWithLazyClass.Singleton s2 = LazyLoadingWithLazyClass.Singleton.Instance;

            if (s1 == s2)
                System.Console.WriteLine("Equals");
            else
                System.Console.WriteLine("Not equals");
        }
    }
}

namespace EagerLoading
{
    /* Singleton */

    // Eager loading
    // Prefer if the singleton object is needed in any case
    sealed class Singleton
    {
        private Singleton() { }

        public static Singleton Instance { get; } = new Singleton();
    }
}

namespace LazyLoadingWithLock
{
    // Lazy loading (classic way)
    // Prefer if the singleton object is not needed in any case
    sealed class Singleton
    {
        private Singleton() { }
        private static volatile Singleton instance;

        public static Singleton Instance
        {
            get
            {
                if (instance == null) // this line is a performance improvement only
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }

                return instance;
            }
        }

        private static readonly object _lock = new object();
    }
}

namespace LazyLoadingWithLazyClass
{
    // Lazy loading (with Lazy class)
    using System;

    sealed class Singleton
    {
        private Singleton() { }
        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance => instance.Value;
    }
}

/* Singleton vs. Static class */

// A singleton can inherit from interfaces or a base class, a static class cannot
