using System;
using System.ComponentModel.DataAnnotations.Schema;
using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Locations;

namespace DDCatalogue.Model.Joins
{
    [Table("monsters_locales")]
    public class MonsterLocale : IJoin
    {
        public Guid MonsterId { get; set; }
        public Monster Monster { get; set; }
        public Guid LocaleId { get; set; }
        public Locale Locale { get; set; }
    }
}
