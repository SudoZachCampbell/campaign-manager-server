﻿using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Items;
using DDCatalogue.Model.Locations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
        public DbSet<Locale> Locales { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Dungeon> Dungeons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Server=192.168.0.41;Database=DDCatalogue;User Id=sa;Password=Microsoft1!");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ArraySplitting();

            //modelBuilder.Entity<Npc>()
            //.HasOne(a => a.Character)
            //.WithOne(a => a.Npc)
            //.HasForeignKey<Character>(c => c.CreatureId);

            modelBuilder.Entity<Npc>(e =>
            {
                e.HasOne(m => m.Monster)
                .WithMany(n => n.Npcs)
                .HasForeignKey(m => m.CreatureId);
            });

            //modelBuilder.Entity<Player>()
            //.HasOne(a => a.Character)
            //.WithOne(a => a.Player)
            //.HasForeignKey<Character>(c => c.CreatureId);

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
            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                System.Diagnostics.Debugger.Launch();
            }
            DirectoryInfo dInfo = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\Model\\Seeds");

            Dictionary<Type, IList<IModel>> seeds = new Dictionary<Type, IList<IModel>>();
            foreach (var file in dInfo.GetFiles("*.json"))
            {
                string[] splitName = file.Name.Split("_");
                Tuple<string, string> fileDetails = new Tuple<string, string>(splitName[0], splitName[1].Split(".")[0]);
                Type type = Type.GetType($"DDCatalogue.Model.{fileDetails.Item1}.{fileDetails.Item2}");
                IList<IModel> genericList = CreateTypeList<IModel>(type);
                JArray aOfObjects = JArray.Parse(file.OpenText().ReadToEnd());
                foreach (JToken token in aOfObjects)
                {
                    genericList.Add((IModel)token.ToObject(type));
                }
                seeds.Add(type, genericList);
            }

            if (!seeds.Count.Equals(0))
            {
                foreach (var modelList in seeds)
                {
                    int i = 1;
                    foreach (var model in modelList.Value)
                    {
                        model.Id = i;
                        i++;
                    }
                    modelBuilder.Entity(modelList.Key).HasData(modelList.Value);
                }
            }
        }

        private static IList<T> CreateTypeList<T>(Type type)
        {
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(type);
            IEnumerable<T> instance = (IEnumerable<T>)Activator.CreateInstance(constructedListType);
            return instance.ToList();
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
