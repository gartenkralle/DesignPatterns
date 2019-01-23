namespace FactorySimple
{
    interface IFactory
    {
        IFactory Create(int id);
    }
}
