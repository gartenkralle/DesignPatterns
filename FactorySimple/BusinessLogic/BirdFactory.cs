namespace FactorySimple
{
    public class BirdFactory
    {
        public static IBird Create(int id)
        {
            IBird bird = null;

            if (id == 1)
            {
                bird = new AmericanBird();
            }
            else if (id == 2)
            {
                bird = new EuropeanBird();
            }
            else if (id == 3)
            {
                bird = new AfricanBird();
            }

            return bird;
        }
    }
}
