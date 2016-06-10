using System;
using System.Collections.Generic;

namespace ObserverWithInterfaces
{
    class Abonnent : IConsumer
    {
        public string Name { get; }

        private List<IProducer> channels { get; set; }
        public IReadOnlyList<IProducer> Producers { get { return channels.AsReadOnly(); } }

        public Abonnent(string name)
        {
            Name = name;

            channels = new List<IProducer>();
        }

        public void AddProducer(IProducer kanal)
        {
            channels.Add(kanal);
        }

        public void Update(IProduct video)
        {
            Console.WriteLine(Name + " has " + video.Name + " from " + video.Producer.Name);
        }
    }
}
