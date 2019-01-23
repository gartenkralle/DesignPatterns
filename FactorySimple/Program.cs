using System;

namespace FactorySimple
{
    class Program
    {
        static void Main(string[] args)
        {
            IBird americanBird = BirdFactory.Create(1);
            IBird europeanBird = BirdFactory.Create(2);
            IBird africanBird = BirdFactory.Create(3);

            Console.WriteLine(americanBird.GetVelocity());
            Console.WriteLine(europeanBird.GetVelocity());
            Console.WriteLine(africanBird.GetVelocity());
        }
    }
}
