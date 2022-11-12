using System;
using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Locations;

namespace DDCatalogue.Model.Joins
{
    public class MonsterLocale : IJoin
    {
        public Guid MonsterId { get; set; }
        public Monster Monster { get; set; }
        public Guid LocaleId { get; set; }
        public Locale Locale { get; set; }
    }
}
