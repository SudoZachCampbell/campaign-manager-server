using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Joins
{
    [Table("accounts_campaigns")]
    public class AccountCampaign : IJoin
    {
        public Guid AccountId { get; set; }
        public Account? Account { get; set; }
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}
