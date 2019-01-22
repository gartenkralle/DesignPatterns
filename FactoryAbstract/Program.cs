using System;

namespace FactoryAbstract
{
    class Program
    {
        static void Main(string[] args)
        {
            IBirdBoxFactory europeanBirdBoxFactory = new EuropeanBirdBoxFactory();

            IBird europeanBird = europeanBirdBoxFactory.CreateBird();
            IBirdFood europeanBirdFood = europeanBirdBoxFactory.CreateBirdFood();

            Console.WriteLine(europeanBird.GetVelocity());
            Console.WriteLine(europeanBirdFood.GetName());


            IBirdBoxFactory americanBirdBoxFactory = new AmericanBirdBoxFactory();

            IBird americanBird = americanBirdBoxFactory.CreateBird();
            IBirdFood americanBirdFood = americanBirdBoxFactory.CreateBirdFood();

            Console.WriteLine(americanBird.GetVelocity());
            Console.WriteLine(americanBirdFood.GetName());
        }
    }
}
