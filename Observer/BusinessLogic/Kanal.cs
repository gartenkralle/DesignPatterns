using System.Collections.Generic;

namespace Observer
{
    class Kanal
    {
        public string Name { get; }

        private List<Video> videos { get; set; }
        public IReadOnlyList<Video> Videos { get { return videos.AsReadOnly(); } }

        private List<Abonnent> abonents { get; set; }
        public IReadOnlyList<Abonnent> Abonents { get { return abonents.AsReadOnly(); } }

        public void AddVideo(Video video)
        {
            videos.Add(video);
            video.AddKanal(this);

            foreach (Abonnent abonnent in abonents)
                abonnent.Update(video);
        }

        public void AddAbonnent(Abonnent abonent)
        {
            abonents.Add(abonent);
            abonent.AddChannel(this);
        }

        public Kanal(string name)
        {
            Name = name;

            videos = new List<Video>();
            abonents = new List<Abonnent>();
        }
    }
}
