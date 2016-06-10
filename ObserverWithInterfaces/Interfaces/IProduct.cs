namespace ObserverWithInferfaces
{
    interface IProduct
    {
        string Name { get; }

        IProducer Producer { get; }

        void AddProducer(IProducer producer);
    }
}
