using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Joins;

namespace CampaignManager.API.Model.Games
{
    public class CampaignDto : BaseDto
    {
        public string Name { get; set; }
        public CampaignTypeDto Type { get; set; }

        public List<AccountCampaignDto>? Players { get; set; }
    }

    public enum CampaignTypeDto
    {
        FiveE,
        PathFinderOne,
        PathFinderTwo
    }
}