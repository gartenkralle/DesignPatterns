namespace Factory
{
    class Bird
    {
        private string name;

        public Bird(string name)
        {
            this.name = name;
        }
        public static EuropeanBird CreateEuropeanBird()
        {
            return new EuropeanBird("European");
        }

        public static AfricanBird CreateAfricanBird()
        {
            return new AfricanBird("African");
        }

        public static AmericanBird CreateAmericanBird()
        {
            return new AmericanBird("American");
        }

    }

    enum BirdType
    {
        African, European, American
    }
}
