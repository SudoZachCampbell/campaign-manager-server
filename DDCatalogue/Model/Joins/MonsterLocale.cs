using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Locations;

namespace DDCatalogue.Model.Joins
{
    public class MonsterLocale : IJoin
    {
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int LocaleId { get; set; }
        public Locale Locale { get; set; }
    }
}
