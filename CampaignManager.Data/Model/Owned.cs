using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Model
{
    public class Owned : Base, IOwned
    {
        public Guid OwnerId { get; set; }
        public Account? Owner { get; set; }
    }
}