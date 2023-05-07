using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManager.Data.Model
{
    public class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
