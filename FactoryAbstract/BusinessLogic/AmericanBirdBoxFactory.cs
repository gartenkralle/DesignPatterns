namespace FactoryAbstract
{
    class AmericanBirdBoxFactory : IBirdBoxFactory
    {
        public IBird CreateBird()
        {
            return new AmericanBird();
        }

        public IBirdFood CreateBirdFood()
        {
            return new AmericanBirdFood();
        }
    }
}
