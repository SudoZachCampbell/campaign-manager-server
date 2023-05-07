using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Model
{
    public interface IOwned : IBase
    {
        Account Owner { get; set; }
    }
}