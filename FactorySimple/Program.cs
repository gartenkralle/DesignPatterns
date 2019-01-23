using System;

namespace FactorySimple
{
    class Program
    {
        static void Main(string[] args)
        {
            BirdFactory birdFactory = new BirdFactory();

            IBird americanBird = birdFactory.Create(1);
            IBird europeanBird = birdFactory.Create(2);
            IBird africanBird = birdFactory.Create(3);

            Console.WriteLine(americanBird.GetVelocity());
            Console.WriteLine(europeanBird.GetVelocity());
            Console.WriteLine(africanBird.GetVelocity());
        }
    }
}
