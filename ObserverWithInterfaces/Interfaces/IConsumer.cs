using System.Collections.Generic;

namespace ObserverWithInterfaces
{
    interface IConsumer
    {
        string Name { get; }

        IReadOnlyList<IProducer> Producers { get; }

        void AddProducer(IProducer producer);
        void Update(IProduct product);
    }
}
