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
            modelBuilder.ArraySplitting();

            modelBuilder.Entity<Npc>()
            .HasOne(a => a.Character)
            .WithOne(a => a.Npc)
            .HasForeignKey<CharacterModel>(c => c.CharacterId);

            modelBuilder.Entity<Player>()
            .HasOne(a => a.Character)
            .WithOne(a => a.Player)
            .HasForeignKey<CharacterModel>(c => c.CharacterId);

            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Seed the Database with JSON
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Monster dwarf = new Monster("Drawf Warrior", 16, 39, Alignment.LG)
            //{
            //    CharacterId = 1,
            //    Str = 14,
            //    Dex = 11,
            //    Con = 14,
            //    Int = 10,
            //    Wis = 11,
            //    Cha = 10,
            //    Speed = "25ft",
            //    Challenge = 1,
            //    Languages = "Common, Dwarvish",
            //    Senses = "Darkvision 60ft",
            //    Pp = 10,
            //    DefeatXp = 200
            //};

            modelBuilder.Entity<Npc>().OwnsOne(n => n.Monster).HasData(
                new Npc("Engrad Longbones")
                {
                    NpcId = 1,
                    Monster = new Monster("Drawf Warrior", 16, 39, Alignment.LG)
                    {
                        CharacterId = 1,
                        Str = 14,
                        Dex = 11,
                        Con = 14,
                        Int = 10,
                        Wis = 11,
                        Cha = 10,
                        Speed = "25ft",
                        Challenge = 1,
                        Languages = "Common, Dwarvish",
                        Senses = "Darkvision 60ft",
                        Pp = 10,
                        DefeatXp = 200
                    }
                });
        }

        public static void ArraySplitting(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterBase>()
            .Property(e => e.Traits)
            .HasConversion(
                v => string.Join('/', v),
                v => v.Split('/', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<CharacterBase>()
            .Property(e => e.Reactions)
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
        }
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
        public List<CharacterModel> Characters { get; set; }
        public byte[] Map { get; set; }
    }

    public class Municipality
    {
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Building> Buildings { get; set; }
        public byte[] Map { get; set; }
        public List<CharacterModel> Characters { get; set; }
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
