using System.Collections.Generic;

namespace Test2
{
    interface IConsumer
    {
        string Name { get; }

        IReadOnlyList<IProducer> Producers { get; }

        void AddProducer(IProducer producer);
        void Update(IProduct product);
    }
}
