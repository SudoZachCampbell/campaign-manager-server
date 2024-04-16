using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Joins;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.Data.Model.Games
{
    [Table("campaigns")]
    public class Campaign : Base
    {
        public string Name { get; set; }
        public CampaignType Type { get; set; }

        public List<AccountCampaign>? Players { get; set; }
        public List<World>? Worlds { get; set; }
        public List<Continent>? Continents { get; set; }
        public List<Region>? Regions { get; set; }
        public List<Locale>? Locales { get; set; }
        public List<Building>? Buildings { get; set; }
        public List<Dungeon>? Dungeons { get; set; }
    }

    public enum CampaignType
    {
        FiveE,
        PathFinderOne,
        PathFinderTwo
    }
}