using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Auth;
using CampaignManager.API.Model.Games;

namespace CampaignManager.API.Model.Joins
{
    public class AccountCampaignDto
    {
        public Guid AccountId { get; set; }
        public AccountDto Account { get; set; }
        public Guid CampaignId { get; set; }
        public CampaignDto Campaign { get; set; }
    }
}
