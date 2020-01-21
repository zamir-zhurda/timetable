namespace timetable.Resources
{
    public class OrariResource
    {
        public int Id { get; set; }

        public string Dega { get; set; }
        public int Viti { get; set; }

        public string Paraleli { get; set; }

        public string Lenda { get; set; }

        public string Tipi { get; set; }

        public string Pedagog { get; set; }
        public int Dita { get; set; }
        public int Klasa { get; set; }
        public int Ora { get; set; }
        public int? Zgjedhje { get; set; }
        public bool? Final { get; set; }
    }
}