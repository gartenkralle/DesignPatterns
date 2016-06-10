namespace Test2
{
    interface IProduct
    {
        string Name { get; }

        IProducer Producer { get; }

        void AddProducer(IProducer producer);
    }
}
