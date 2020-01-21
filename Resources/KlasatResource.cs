namespace timetable.Resources
{
    public class KlasatResource
    {
        public int Id { get; set; }

        public string Klasa { get; set; }
        public int? Kapaciteti { get; set; }
        public int? Tipi { get; set; }

        public string Godina { get; set; }
        public int? Kati { get; set; }
        public bool Perdoret { get; set; }

        public string KlasaNew { get; set; }
    }
}