using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Kanal kanal = new Kanal();
            kanal.Upload(new Video("1"));

            Abonnent abonnent = new Abonnent();
            abonnent.Abonniere(kanal);
            abonnent.InformiereMich(kanal, true);

            Abonnent abonnent2 = new Abonnent();
            abonnent2.Abonniere(kanal);
            abonnent2.InformiereMich(kanal, true);
            abonnent2.InformiereMich(kanal, true);
            abonnent2.InformiereMich(kanal, false);

            Abonnent abonnent3 = new Abonnent();
            abonnent3.InformiereMich(kanal, true);

            kanal.Upload(new Video("3"));
        }
    }

    class Kanal
    {
        private List<Video> videos = new List<Video>();
        private List<Abonnent> abonnenten = new List<Abonnent>();

        public event Action<Video> VideoAdded;

        public void Upload(Video video)
        {
            videos.Add(video);

            VideoAdded?.Invoke(video);
        }

        public void Add(Abonnent abonnent)
        {
            abonnenten.Add(abonnent);
        }
    }

    class Video
    {
        private Kanal kanal;
        public string Name { get; }

        public Video(string name)
        {
            Name = name;
        }

        public void SetKanal(Kanal kanal)
        {
            this.kanal = kanal;
        }
    }

    class Abonnent
    {
        private List<Kanal> kanäle = new List<Kanal>();
        private bool notify = false;

        public void Abonniere(Kanal kanal)
        {
            kanäle.Add(kanal);
            kanal.Add(this);
        }

        public void InformiereMich(Kanal kanal, bool notify)
        {
            if (kanäle.Contains(kanal))
            {
                if (!this.notify && notify)
                    kanal.VideoAdded += HeyNeuesVideo;
                else if (this.notify && !notify)
                    kanal.VideoAdded -= HeyNeuesVideo;

                this.notify = notify;
            }
        }

        public void HeyNeuesVideo(Video video)
        {
            Console.WriteLine("Es gibt ein neues Video: " + video.Name);
        }
    }
}
