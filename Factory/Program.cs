namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            EuropeanBird europeanBird = Bird.CreateEuropeanBird();
            AfricanBird africanBird = Bird.CreateAfricanBird();
            AmericanBird americanBird = Bird.CreateAmericanBird();
        }
    }
}
