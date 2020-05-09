namespace DDCatalogue.Model.Locations
{
    public class Dungeon
    {
        public int DungeonId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public byte[] Map { get; set; }
        public Building Building { get; set; }
        public Locale Municipality { get; set; }
    }
}
