using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.Data.Model.Joins
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
