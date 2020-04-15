using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model
{
    public class DDContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Npc> Npcs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armour> Armours { get; set; }
        public DbSet<Treasure> Treasures { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Server=192.168.0.41;Database=DDCatalogue;User Id=sa;Password=Microsoft1!");

    }

    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
    }

    public class Player : Character
    {
        public string PlayerName { get; set; }
    }

    public class Monster : Character
    {

    }

    public class Npc : Character
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
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
