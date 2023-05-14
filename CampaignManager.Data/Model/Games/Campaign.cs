using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Joins;

namespace CampaignManager.Data.Model.Games
{
    [Table("campaigns")]
    public class Campaign : Owned
    {
        public List<AccountCampaign>? Players { get; set; }
    }
}