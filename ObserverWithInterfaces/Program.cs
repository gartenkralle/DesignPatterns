using System;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            IProducer kanal1 = new Kanal("Channel1");

            IProduct video1 = new Video("Sandmann1");
            IProduct video2 = new Video("Sandmann2");

            IConsumer abonent1 = new Abonnent("Abonent1");
            IConsumer abonent2 = new Abonnent("ABonent2");


            kanal1.AddProduct(video1);

            kanal1.AddConsumer(abonent1);
            kanal1.AddConsumer(abonent2);

            kanal1.AddProduct(video2);


            Console.WriteLine();


            foreach (IConsumer abonent in kanal1.Consumers)
                Console.WriteLine(abonent.Name);

            Console.WriteLine();

            foreach (IProduct video in kanal1.Products)
                Console.WriteLine(video.Name);
        }
    }
}
