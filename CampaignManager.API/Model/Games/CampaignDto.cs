using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Joins;
using AutoMapper;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.API.Model.Games
{
    [AutoMap(typeof(Campaign), ReverseMap = true)]
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