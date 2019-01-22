using System;

namespace FactorySimple
{
    class Program
    {
        static void Main(string[] args)
        {
            IBird americanBird = BirdFactory.CreateBird(1);
            IBird europeanBird = BirdFactory.CreateBird(2);
            IBird africanBird = BirdFactory.CreateBird(3);

            Console.WriteLine(americanBird.GetVelocity());
            Console.WriteLine(europeanBird.GetVelocity());
            Console.WriteLine(africanBird.GetVelocity());
        }
    }
}
