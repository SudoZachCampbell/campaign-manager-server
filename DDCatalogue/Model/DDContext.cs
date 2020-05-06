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
        public DbSet<Character> Characters { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Npc> Npcs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armour> Armours { get; set; }
        public DbSet<Treasure> Treasures { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Dungeon> Dungeons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Server=192.168.0.41;Database=DDCatalogue;User Id=sa;Password=Microsoft1!");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterBase>()
            .Property(e => e.Traits)
            .HasConversion(
                v => string.Join('/', v),
                v => v.Split('/', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Monster>()
            .Property(e => e.Actions)
            .HasConversion(
                v => string.Join('/', v),
                v => v.Split('/', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Monster>()
            .Property(e => e.LegendaryActions)
            .HasConversion(
                v => string.Join('/', v),
                v => v.Split('/', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Npc>()
            .HasOne(a => a.Character)
            .WithOne(a => a.Npc)
            .HasForeignKey<Character>(c => c.CharacterId);

            modelBuilder.Entity<Player>()
            .HasOne(a => a.Character)
            .WithOne(a => a.Player)
            .HasForeignKey<Character>(c => c.CharacterId);
        }
    }

    public class CharacterBase
    {
        public CharacterBase(string name, int ac, int hp, Alignment alignment)
        {
            Name = name;
            Ac = ac;
            Hp = hp;
            Alignment = alignment;
        }
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
        public string[] Traits { get; set; }
        public Alignment Alignment { get; set; }
        public Municipality Location { get; set; }
        public Building Building { get; set; }

    }

    public class Character : CharacterBase
    {
        public Character(string name, int ac, int hp, Alignment alignment) : base(name, ac, hp, alignment) { }
        public string PlayerName { get; set; }
        public int Level = 1;
        public string Background { get; set; }
        public string Faction { get; set; }
        public string Race { get; set; }
        public int Xp = 0;
        public bool Inspiration = false;
        public Player Player { get; set; }
        public Npc Npc { get; set; }
    }

    public class Player
    {
        public int PlayerId { get; set; }
        public Character Character { get; set; }
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
        public Monster(string name, int ac, int hp, Alignment alignment) : base(name, ac, hp, alignment) { }
        public string Senses { get; set; }
        public double Challenge { get; set; }
        public int DefeatXp { get; set; }
        public string[] Actions { get; set; }
        public string[] LegendaryActions { get; set; }
    }

    public class Npc
    {
        public int NpcId { get; set; }
        public Character Character { get; set; }
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

    public class Dungeon
    {
        public int DungeonId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public byte[] Map { get; set; }
        public Building Building { get; set; }
        public Municipality Municipality { get; set; }
    }

    public class Building
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public Municipality Municipality { get; set; }
        public List<Character> Characters { get; set; }
        public byte[] Map { get; set; }
    }

    public class Municipality
    {
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Building> Buildings { get; set; }
        public byte[] Map { get; set; }
        public List<Character> Characters { get; set; }
    }

    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<Municipality> Municipalities { get; set; }
        public Continent Continent { get; set; }
        public byte[] Map { get; set; }
    }

    public class Continent
    {
        public int ContinentId { get; set; }
        public string Name { get; set; }
        public List<Country> Countries { get; set; }
        public byte[] Map { get; set; }
    }
}
