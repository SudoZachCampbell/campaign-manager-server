using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Model
{
    public interface IOwned : IBase
    {
        public Guid OwnerId { get; set; }
        public Account? Owner { get; set; }
    }
}