using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Items;
using DDCatalogue.Model.Joins;
using DDCatalogue.Model.Locations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DDCatalogue.Model
{
    public class DDContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
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
            modelBuilder.AddConversions();
            modelBuilder.DefineKeys();
            modelBuilder.BuildRelationships();
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
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            string baseSeedPath = $"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}Model{Path.DirectorySeparatorChar}Seeds";

            DirectoryInfo dObjectInfo = new DirectoryInfo($"{baseSeedPath}{Path.DirectorySeparatorChar}Objects");

            Dictionary<Type, IList<IModel>> objectSeeds = new Dictionary<Type, IList<IModel>>();
            foreach (var file in dObjectInfo.GetFiles("*.json"))
            {
                string[] splitName = file.Name.Split("_");
                Tuple<string, string> fileDetails = new Tuple<string, string>(splitName[0], splitName[1].Split(".")[0]);
                Type type = Type.GetType($"DDCatalogue.Model.{fileDetails.Item1}.{fileDetails.Item2}");
                IList<IModel> genericList = CreateTypeList<IModel>(type);
                JArray aOfObjects = JArray.Parse(file.OpenText().ReadToEnd());
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy { ProcessDictionaryKeys = true }
                    },
                    Formatting = Formatting.Indented
                };
                foreach (JToken token in aOfObjects)
                {
                    var obj = JsonConvert.DeserializeObject(token.ToString(), type, settings);
                    genericList.Add((IModel)obj);
                }
                objectSeeds.Add(type, genericList);
            }

            if (!objectSeeds.Count.Equals(0))
            {
                foreach (var modelList in objectSeeds)
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

            DirectoryInfo dJoinsInfo = new DirectoryInfo($"{baseSeedPath}{Path.DirectorySeparatorChar}Joins");

            Dictionary<Type, IList<IJoin>> joinSeeds = new Dictionary<Type, IList<IJoin>>();
            foreach (var file in dJoinsInfo.GetFiles("*.json"))
            {
                string[] splitName = file.Name.Split("_");
                Tuple<string, string> fileDetails = new Tuple<string, string>(splitName[0], splitName[1].Split(".")[0]);
                Type type = Type.GetType($"DDCatalogue.Model.{fileDetails.Item1}.{fileDetails.Item2}");
                IList<IJoin> genericList = CreateTypeList<IJoin>(type);
                JArray aOfObjects = JArray.Parse(file.OpenText().ReadToEnd());
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy { ProcessDictionaryKeys = true }
                    },
                    Formatting = Formatting.Indented
                };
                foreach (JToken token in aOfObjects)
                {
                    var obj = JsonConvert.DeserializeObject(token.ToString(), type, settings);
                    genericList.Add((IJoin)obj);
                }
                joinSeeds.Add(type, genericList);
            }

            if (!joinSeeds.Count.Equals(0))
            {
                foreach (var modelList in joinSeeds)
                {
                    modelBuilder.Entity(modelList.Key).HasData(modelList.Value);
                }
            }
        }

        public static void BuildRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Npc>()
                .HasOne(a => a.Monster)
                .WithMany(a => a.Npcs)
                .HasForeignKey(n => n.MonsterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Npc>()
                .HasOne(n => n.Locale)
                .WithMany(l => l.Npcs)
                .HasForeignKey(n => n.LocaleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Npc>()
                .HasOne(n => n.Building)
                .WithMany(b => b.Npcs)
                .HasForeignKey(n => n.BuildingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Building)
                .WithMany(b => b.Players)
                .HasForeignKey(p => p.BuildingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Locale)
                .WithMany(l => l.Players)
                .HasForeignKey(p => p.LocaleId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public static void DefineKeys(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildingMap>()
                .HasKey(bm => new { bm.BuildingId, bm.MapId });     

            modelBuilder.Entity<MonsterBuilding>()
                .HasKey(mb => new { mb.MonsterId, mb.BuildingId });

            modelBuilder.Entity<MonsterLocale>()
                .HasKey(ml => new { ml.MonsterId, ml.LocaleId });
        }

        private static IList<T> CreateTypeList<T>(Type type)
        {
            Type listType = typeof(List<>);
            Type constructedListType = listType.MakeGenericType(type);
            IEnumerable<T> instance = (IEnumerable<T>)Activator.CreateInstance(constructedListType);
            return instance.ToList();
        }

        public static void AddConversions(this ModelBuilder modelBuilder)
        {

            // Creature
            modelBuilder.Entity<Creature>().Property(c => c.Speed).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            modelBuilder.Entity<Creature>().Property(c => c.Proficiencies).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            modelBuilder.Entity<Creature>().Property(c => c.Reactions).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            // Monster
            modelBuilder.Entity<Monster>().Property(c => c.Actions).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            modelBuilder.Entity<Monster>().Property(c => c.LegendaryActions).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            modelBuilder.Entity<Monster>().Property(c => c.SpecialAbilities).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            modelBuilder.Entity<Monster>().Property(c => c.Senses).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<JObject>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            // NPC
            modelBuilder.Entity<Npc>().Property(c => c.NoteableEvents).HasConversion(
               v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
               v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            modelBuilder.Entity<Npc>().Property(c => c.Beliefs).HasConversion(
               v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
               v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            modelBuilder.Entity<Npc>().Property(c => c.Passions).HasConversion(
               v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
               v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            modelBuilder.Entity<Npc>().Property(c => c.Flaws).HasConversion(
               v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
               v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            // Map
            modelBuilder.Entity<Map>().Property(c => c.Center).HasConversion(
              v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
              v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            // Building Map
            modelBuilder.Entity<BuildingMap>().Property(c => c.Coords).HasConversion(
             v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
             v => JsonConvert.DeserializeObject<JArray>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
