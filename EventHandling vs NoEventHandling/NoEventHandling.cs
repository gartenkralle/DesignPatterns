using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Kanal kanal = new Kanal();
            kanal.Upload(new Video("1"));

            Abonnent abonnent = new Abonnent();
            abonnent.Abonniere(kanal);

            Abonnent abonnent2 = new Abonnent();
            abonnent2.Abonniere(kanal);

            kanal.Upload(new Video("2"));
        }
    }

    class Kanal
    {
        private List<Video> videos = new List<Video>();
        private List<Abonnent> abonnenten = new List<Abonnent>();

        public void Upload(Video video)
        {
            videos.Add(video);

            foreach (Abonnent abonnent in abonnenten)
            {
                abonnent.HeyNeuesVideo(video);
            }
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

        public void Abonniere(Kanal kanal)
        {
            kanäle.Add(kanal);
            kanal.Add(this);
        }

        public void HeyNeuesVideo(Video video)
        {
            Console.WriteLine("Es gibt ein neues Video: " + video.Name);
        }
    }
}
