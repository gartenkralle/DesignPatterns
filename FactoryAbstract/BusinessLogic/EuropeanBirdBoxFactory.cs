namespace FactoryAbstract
{
    public class EuropeanBirdBoxFactory : IBirdBoxFactory
    {
        public IBird CreateBird()
        {
            return new EuropeanBird();
        }

        public IBirdFood CreateBirdFood()
        {
            return new EuropeanBirdFood();
        }
    }
}
