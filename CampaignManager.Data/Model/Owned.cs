using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Model
{
    public class Owned : Base, IOwned
    {
        public Account Owner { get; set; }
    }
}