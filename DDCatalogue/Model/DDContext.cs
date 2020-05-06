using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Items;
using DDCatalogue.Model.Locations;
using Microsoft.EntityFrameworkCore;
using System;

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
            .HasForeignKey<Character>(c => c.CreatureId);

            modelBuilder.Entity<Player>()
            .HasOne(a => a.Character)
            .WithOne(a => a.Player)
            .HasForeignKey<Character>(c => c.CreatureId);

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
            modelBuilder.Entity<Monster>().HasData(new Monster("Drawf Warrior", 16, 39, Alignment.LG)
            {
                CreatureId = 1,
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
            });

            modelBuilder.Entity<Npc>(e =>
            {
                e.HasOne(m => m.Monster)
                .WithMany(n => n.Npcs)
                .HasForeignKey(m => m.CreatureId);
            });

            modelBuilder.Entity<Npc>().HasData(
                new Npc("Engrad Longbones")
                {
                    NpcId = 1,
                    CreatureId = 1
                });
        }

        public static void ArraySplitting(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creature>()
            .Property(e => e.Traits)
            .HasConversion(
                v => string.Join('/', v),
                v => v.Split('/', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Creature>()
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
}
