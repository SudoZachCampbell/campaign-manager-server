using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Locations;

namespace DDCatalogue.Model.Joins
{
    public class MonsterBuilding
    {
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
