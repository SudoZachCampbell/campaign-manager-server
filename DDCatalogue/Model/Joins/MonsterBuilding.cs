using System;
using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Locations;

namespace DDCatalogue.Model.Joins
{
    public class MonsterBuilding : IJoin
    {
        public Guid MonsterId { get; set; }
        public Monster Monster { get; set; }
        public Guid BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
