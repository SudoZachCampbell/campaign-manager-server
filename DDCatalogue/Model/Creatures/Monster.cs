using DDCatalogue.Model.Joins;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DDCatalogue.Model.Creatures
{
    public class Monster : Creature
    {
        public double ChallengeRating { get; set; }
        public int PassivePerception { get; set; }
        public JArray Actions { get; set; }
        public JArray LegendaryActions { get; set; }        
        public JArray SpecialAbilities { get; set; }
        public JObject Senses { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<MonsterLocale> Locales { get; set; }
        public List<MonsterBuilding> Buildings { get; set; }
    }
}
