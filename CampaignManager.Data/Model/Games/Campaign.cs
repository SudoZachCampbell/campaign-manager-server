using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Joins;

namespace CampaignManager.Data.Model.Games
{
    [Table("campaigns")]
    public class Campaign : Owned
    {
        public string? Name { get; set; }
        public CampaignType Type { get; set; }

        public List<AccountCampaign>? Players { get; set; }
    }

    public enum CampaignType
    {
        FiveE,
        PathFinderOne,
        PathFinderTwo
    }
}