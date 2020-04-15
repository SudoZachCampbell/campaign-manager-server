using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DDCatalogue.Model
{
    public class DDContext : DbContext
    {
        public DbSet<CharacterBase> Characters { get; set; }
        public DbSet<Character> Players { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Npc> Npcs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armour> Armours { get; set; }
        public DbSet<Treasure> Treasures { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Server=192.168.0.41;Database=DDCatalogue;User Id=sa;Password=Microsoft1!");

    }

    public class CharacterBase
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int? Str { get; set; }
        public int? Dex { get; set; }
        public int? Con { get; set; }
        public int? Int { get; set; }
        public int? Wis { get; set; }
        public int? Cha { get; set; }
        public bool? Acrobatics { get; set; }
        public bool? AnimalHandling { get; set; }
        public bool? Arcana { get; set; }
        public bool? Athletics { get; set; }
        public bool? Deception { get; set; }
        public bool? History { get; set; }
        public bool? Insight { get; set; }
        public bool? Intimidation { get; set; }
        public bool? Investigations { get; set; }
        public bool? Medicine { get; set; }
        public bool? Nature { get; set; }
        public bool? Perception { get; set; }
        public bool? Performance { get; set; }
        public bool? Persuasion { get; set; }
        public bool? Religion { get; set; }
        public bool? SleightOfHand { get; set; }
        public bool? Stealth { get; set; }
        public bool? Survival { get; set; }
        public bool? SavStr { get; set; }
        public bool? SavDex { get; set; }
        public bool? SavCon { get; set; }
        public bool? SavInt { get; set; }
        public bool? SavWis { get; set; }
        public bool? SavCha { get; set; }
        public int Ac { get; set; }
        public int Hp { get; set; }
        public string HitDice { get; set; }
        public string Speed { get; set; }
        public string Languages { get; set; }
        public List<string> Traits { get; set; }
        public Alignment Alignment { get; set; }
    }

    public class Character : CharacterBase
    {
        public bool Player { get; set; }
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public string Background { get; set; }
        public string Faction { get; set; }
        public string Race { get; set; }
        public int Xp { get; set; }
        public bool Inspiration { get; set; }
    }

    public enum Alignment
    {
        LG,
        LN,
        LE,
        NG,
        TN,
        NE,
        CG,
        CN,
        CE
    }

    public class Monster : CharacterBase
    {
        public string Senses { get; set; }
        public double Challenge { get; set; }
        public int DefeatXp { get; set; }
        public List<string> Actions { get; set; }
        public List<string> LegendaryActions { get; set; }
    }

    public class Npc
    {

    }


    public class Item
    {
        public int ItemId { get; set; }
    }

    public class Weapon : Item
    {

    }

    public class Armour : Item
    {

    }

    public class Treasure : Item
    {

    }


    public class Municipality
    {
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Building> Buildings { get; set; }
        public byte[] Map { get; set; }
    }

    public class Building
    {
        public int BuildingId { get; set; }
        public Municipality Municipality { get; set; }
        public byte[] Map { get; set; }
    }

    public class Dungeon
    {
        public int DungeonId { get; set; }
    }

    public class Country
    {
        public int CountryId { get; set; }
        public List<Municipality> Municipalities { get; set; }
        public Continent Continent { get; set; }
        public byte[] Map { get; set; }
    }

    public class Continent
    {
        public int ContinentId { get; set; }
        public List<Country> Countries { get; set; }
        public byte[] Map { get; set; }
    }
}
