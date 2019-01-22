namespace FactoryAbstract
{
    interface IBirdBoxFactory
    {
        IBird CreateBird();
        IBirdFood CreateBirdFood();
    }
}
