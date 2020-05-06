namespace DDCatalogue.Model.Creatures
{
    public class Npc
    {
        public Npc(string name)
        {
            Name = name;
        }
        public int NpcId { get; set; }
        public string Name { get; set; }
        public Character Character { get; set; }
        public int CreatureId { get; set; }
        public Monster Monster { get; set; }
    }
}
