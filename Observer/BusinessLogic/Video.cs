namespace Observer
{
    class Video
    {
        public string Name { get; }
        public Kanal Kanal { get; private set; }

        public void AddKanal(Kanal kanal)
        {
            Kanal = kanal;
        }

        public Video(string name)
        {
            Name = name;
        }
    }
}
