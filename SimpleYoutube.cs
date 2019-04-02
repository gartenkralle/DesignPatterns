using System;
using System.Collections.Generic;

namespace SimpleYoutube
{
    class Program
    {
        static void Main(string[] args)
        {
            Kanal kanal1 = new Kanal("kanal1");
            Kanal kanal2 = new Kanal("kanal2");

            Video video1 = new Video("video1");
            Video video2 = new Video("video2");
            Video video3 = new Video("video3");
            Video video4 = new Video("video4");
            Video video5 = new Video("video5");
            Video video6 = new Video("video6");

            Abonennt abonennt1 = new Abonennt("abonnent1");
            Abonennt abonnent2 = new Abonennt("abonnent2");
            Abonennt abonnent3 = new Abonennt("abonnent3");
            Abonennt abonnent4 = new Abonennt("abonnent4");

            kanal1.Upload(video1);

            abonennt1.Abonniere(kanal1);
            kanal1.Upload(video2);

            abonnent2.Abonniere(kanal1);
            kanal1.Upload(video3);

            abonnent3.Abonniere(kanal2);
            kanal2.Upload(video4);

            abonnent4.Abonniere(kanal1);
            abonnent4.Abonniere(kanal2);

            kanal1.Upload(video5);
            kanal2.Upload(video6);
        }
    }

    internal class Abonennt
    {
        public string Name { get; }

        private IList<Kanal> kanäle;

        public Abonennt(string name)
        {
            Name = name;

            kanäle = new List<Kanal>();
        }

        internal void Abonniere(Kanal kanal)
        {
            kanäle.Add(kanal);
            kanal.Add(this);
        }

        internal void Notify(Video video)
        {
            Console.WriteLine(Name + " -> " + video.Name);
        }
    }

    internal class Video
    {
        public string Name { get; }

        public Video(string name)
        {
            Name = name;
        }
    }

    internal class Kanal
    {
        public string Name { get; }

        private IList<Abonennt> abonennten;
        private IList<Video> videos;

        public Kanal(string name)
        {
            Name = name;

            abonennten = new List<Abonennt>();
            videos = new List<Video>();
        }

        internal void Upload(Video video)
        {
            videos.Add(video);

            foreach (Abonennt abonennt in abonennten)
            {
                abonennt.Notify(video);
            }
        }

        internal void Add(Abonennt abonennt)
        {
            abonennten.Add(abonennt);
        }
    }
}
