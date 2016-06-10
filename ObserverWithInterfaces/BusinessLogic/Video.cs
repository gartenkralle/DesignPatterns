namespace ObserverWithInterfaces
{
    class Video : IProduct
    {
        public string Name { get; }
        public IProducer Producer { get; private set; }

        public void AddProducer(IProducer kanal)
        {
            Producer = kanal;
        }

        public Video(string name)
        {
            Name = name;
        }
    }
}
