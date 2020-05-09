namespace DDCatalogue.Model.Creatures
{
    public class Npc : ICreature
    {
        public Npc(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
    }
}
