using System;
using System.Collections.Generic;

namespace ConsoleApp3
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

            kanal1.Add(video1);

            kanal1.Add(abonennt1);
            kanal1.Add(video2);

            kanal1.Add(abonnent2);
            kanal1.Add(video3);

            kanal2.Add(abonnent3);
            kanal2.Add(video4);

            kanal1.Add(abonnent4);
            kanal2.Add(abonnent4);

            kanal1.Add(video5);
            kanal2.Add(video6);
        }
    }

    internal class Abonennt : IObservable<Abonennt>
    {
        public string Name { get; }

        private IList<IObserver<Abonennt>> kanäle;

        public Abonennt(string name)
        {
            Name = name;

            kanäle = new List<IObserver<Abonennt>>();
        }

        public IDisposable Subscribe(IObserver<Abonennt> kanal)
        {
            kanäle.Add(kanal);
            ((Kanal)kanal).Add(this);

            return (Kanal)kanal;
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

    internal class Kanal : IObserver<Abonennt>, IDisposable
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

        internal void Add(Video video)
        {
            videos.Add(video);

            foreach (Abonennt abonennt in abonennten)
            {
                Console.WriteLine(abonennt.Name + " -> " + video.Name);
            }
        }

        internal void Add(Abonennt abonennt)
        {
            abonennten.Add(abonennt);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Abonennt value)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
