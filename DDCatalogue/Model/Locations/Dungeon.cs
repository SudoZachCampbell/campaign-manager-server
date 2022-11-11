namespace DDCatalogue.Model.Locations
{
    public class Dungeon : Base, ILocation
    {
        public string Type { get; set; }
        public byte[] Map { get; set; }
        public Building Building { get; set; }
        public Locale Locale { get; set; }
    }
}
