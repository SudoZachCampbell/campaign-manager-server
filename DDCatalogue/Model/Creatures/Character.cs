using System.Collections.Generic;

namespace DDCatalogue.Model.Creatures
{
    public class Character : Creature
    {
        public Character(string name, int ac, int hp, Alignment alignment) : base(name, ac, hp, alignment) { }
        public string PlayerName { get; set; }
        public int Level = 1;
        public string Background { get; set; }
        public string Faction { get; set; }
        public string Race { get; set; }
        public int Xp = 0;
        public bool Inspiration = false;
        public Player Player { get; set; }
        public Npc Npc { get; set; }
    }
}
