

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using CampaignManager.API.Model.Creatures;
using AutoMapper;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.API.Model.Auth
{
    [AutoMap(typeof(Account), ReverseMap = true)]
    public class AccountDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }

        #region Foreign Keys

        public List<MonsterDto>? Monsters { get; set; }

        #endregion

    }
}
