﻿using System;
using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Joins;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDCatalogue.Model.Locations
{
    [Table("buildings")]
    public class Building : Base, ILocation
    {
        public Guid? LocaleId { get; set; }
        public Locale Locale { get; set; }
        public string Map { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<MonsterBuilding> Monsters { get; set; }
        public List<Player> Players { get; set; }
        public List<BuildingMap> Maps { get; set; }
    }
}
