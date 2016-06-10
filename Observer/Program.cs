using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Kanal kanal1 = new Kanal("Channel1");

            Video video1 = new Video("Sandmann1");
            Video video2 = new Video("Sandmann2");

            Abonnent abonent1 = new Abonnent("Abonent1");
            Abonnent abonent2 = new Abonnent("ABonent2");


            kanal1.AddVideo(video1);

            kanal1.AddAbonnent(abonent1);
            kanal1.AddAbonnent(abonent2);

            kanal1.AddVideo(video2);


            Console.WriteLine();


            foreach (Abonnent abonent in kanal1.Abonents)
                Console.WriteLine(abonent.Name);

            Console.WriteLine();

            foreach (Video video in kanal1.Videos)
                Console.WriteLine(video.Name);
        }
    }
}
