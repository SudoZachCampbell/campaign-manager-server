using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Model
{
    public class InCampaign : Owned, IInCampaign
    {
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}