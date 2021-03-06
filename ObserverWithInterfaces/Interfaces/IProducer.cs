﻿using System.Collections.Generic;

namespace ObserverWithInferfaces
{
    interface IProducer
    {
        string Name { get; }

        IReadOnlyList<IProduct> Products { get; }
        IReadOnlyList<IConsumer> Consumers { get; }

        void AddProduct(IProduct product);
        void AddConsumer(IConsumer consumer);
    }
}
