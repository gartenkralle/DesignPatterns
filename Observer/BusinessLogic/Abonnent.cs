using System;
using System.Collections.Generic;

namespace Observer
{
    class Abonnent
    {
        public string Name { get; }

        private List<Kanal> channels { get; set; }
        public IReadOnlyList<Kanal> Channels { get { return channels.AsReadOnly(); } }

        public Abonnent(string name)
        {
            Name = name;

            channels = new List<Kanal>();
        }

        public void AddChannel(Kanal kanal)
        {
            channels.Add(kanal);
        }

        public void Update(Video video)
        {
            Console.WriteLine(Name + " has " + video.Name + " from " + video.Kanal.Name);
        }
    }
}
