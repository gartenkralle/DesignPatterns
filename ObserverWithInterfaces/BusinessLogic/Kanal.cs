using System.Collections.Generic;

namespace ObserverWithInterfaces
{
    class Kanal : IProducer
    {
        public string Name { get; }

        private List<IProduct> videos { get; set; }
        public IReadOnlyList<IProduct> Products { get { return videos.AsReadOnly(); } }

        private List<IConsumer> abonents { get; set; }
        public IReadOnlyList<IConsumer> Consumers { get { return abonents.AsReadOnly(); } }

        public void AddProduct(IProduct video)
        {
            videos.Add(video);
            video.AddProducer(this);

            foreach (IConsumer abonnent in abonents)
                abonnent.Update(video);
        }

        public void AddConsumer(IConsumer abonent)
        {
            abonents.Add(abonent);
            abonent.AddProducer(this);
        }

        public Kanal(string name)
        {
            Name = name;

            videos = new List<IProduct>();
            abonents = new List<IConsumer>();
        }
    }
}
