﻿// <auto-generated />
using System;
using System.Collections.Generic;
using CampaignManager.Data.Contexts;
using CampaignManager.Data.Model.Attributes;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Model.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    [DbContext(typeof(DDContext))]
    partial class DDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CampaignManager.Data.Model.Auth.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Creatures.Monster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<CreatureAction>>("Actions")
                        .HasColumnType("jsonb");

                    b.Property<int>("Alignment")
                        .HasColumnType("integer");

                    b.Property<int>("ArmorClass")
                        .HasColumnType("integer");

                    b.Property<double>("ChallengeRating")
                        .HasColumnType("double precision");

                    b.Property<int>("Charisma")
                        .HasColumnType("integer");

                    b.Property<int>("Constitution")
                        .HasColumnType("integer");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer");

                    b.Property<string>("HitDice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<string>("Languages")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<CreatureAction>>("LegendaryActions")
                        .HasColumnType("jsonb");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<Proficiencies>>("Proficiencies")
                        .HasColumnType("jsonb");

                    b.Property<List<CreatureAction>>("Reactions")
                        .HasColumnType("jsonb");

                    b.Property<List<Sense>>("Senses")
                        .HasColumnType("jsonb");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<List<CreatureAction>>("SpecialAbilities")
                        .HasColumnType("jsonb");

                    b.Property<List<Speed>>("Speed")
                        .HasColumnType("jsonb");

                    b.Property<int>("Strength")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("Wisdom")
                        .HasColumnType("integer");

                    b.Property<int>("Xp")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("monsters");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Creatures.Npc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Background")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Beliefs")
                        .HasColumnType("text");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<string>("Flaws")
                        .HasColumnType("text");

                    b.Property<Guid?>("LocaleId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MonsterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NoteableEvents")
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Passions")
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("LocaleId");

                    b.HasIndex("MonsterId");

                    b.HasIndex("OwnerId");

                    b.ToTable("npcs");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Creatures.Pc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Alignment")
                        .HasColumnType("integer");

                    b.Property<int>("ArmorClass")
                        .HasColumnType("integer");

                    b.Property<string>("Background")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uuid");

                    b.Property<int>("Charisma")
                        .HasColumnType("integer");

                    b.Property<int>("Constitution")
                        .HasColumnType("integer");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer");

                    b.Property<string>("Faction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HitDice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<string>("Languages")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("LocaleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("PcName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<List<Proficiencies>>("Proficiencies")
                        .HasColumnType("jsonb");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<CreatureAction>>("Reactions")
                        .HasColumnType("jsonb");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<List<Speed>>("Speed")
                        .HasColumnType("jsonb");

                    b.Property<int>("Strength")
                        .HasColumnType("integer");

                    b.Property<int>("Wisdom")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("LocaleId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("pcs");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Games.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("campaigns");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Items.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.AccountCampaign", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId", "CampaignId");

                    b.HasIndex("CampaignId");

                    b.ToTable("accounts_campaigns");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.BuildingMap", b =>
                {
                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MapId")
                        .HasColumnType("uuid");

                    b.Property<List<int>>("Coords")
                        .HasColumnType("jsonb");

                    b.HasKey("BuildingId", "MapId");

                    b.HasIndex("MapId");

                    b.ToTable("buildings_maps");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.CampaignMonster", b =>
                {
                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MonsterId")
                        .HasColumnType("uuid");

                    b.HasKey("CampaignId", "MonsterId");

                    b.HasIndex("MonsterId");

                    b.ToTable("campaigns_monsters");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.MonsterBuilding", b =>
                {
                    b.Property<Guid>("MonsterId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uuid");

                    b.HasKey("MonsterId", "BuildingId");

                    b.HasIndex("BuildingId");

                    b.ToTable("monsters_buildings");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.MonsterLocale", b =>
                {
                    b.Property<Guid>("MonsterId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocaleId")
                        .HasColumnType("uuid");

                    b.HasKey("MonsterId", "LocaleId");

                    b.HasIndex("LocaleId");

                    b.ToTable("monsters_locales");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("LocaleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Map")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LocaleId");

                    b.HasIndex("OwnerId");

                    b.ToTable("buildings");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Continent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Map")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("continents");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Dungeon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("LocaleId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Map")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("LocaleId");

                    b.HasIndex("OwnerId");

                    b.ToTable("dungeons");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Locale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RegionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RegionId");

                    b.ToTable("locales");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Map", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Center")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LocaleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Variation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocaleId");

                    b.HasIndex("OwnerId");

                    b.ToTable("maps");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ContinentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Map")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.HasIndex("OwnerId");

                    b.ToTable("regions");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Items.Armour", b =>
                {
                    b.HasBaseType("CampaignManager.Data.Model.Items.Item");

                    b.ToTable("items");

                    b.HasDiscriminator().HasValue("Armour");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Items.Treasure", b =>
                {
                    b.HasBaseType("CampaignManager.Data.Model.Items.Item");

                    b.ToTable("items");

                    b.HasDiscriminator().HasValue("Treasure");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Items.Weapon", b =>
                {
                    b.HasBaseType("CampaignManager.Data.Model.Items.Item");

                    b.ToTable("items");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Creatures.Monster", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany("Monsters")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Creatures.Npc", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Locations.Building", "Building")
                        .WithMany("Npcs")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CampaignManager.Data.Model.Locations.Locale", "Locale")
                        .WithMany("Npcs")
                        .HasForeignKey("LocaleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CampaignManager.Data.Model.Creatures.Monster", "Monster")
                        .WithMany("Npcs")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Locale");

                    b.Navigation("Monster");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Creatures.Pc", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Locations.Building", "Building")
                        .WithMany("Pcs")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CampaignManager.Data.Model.Games.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignManager.Data.Model.Locations.Locale", "Locale")
                        .WithMany("Pcs")
                        .HasForeignKey("LocaleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.Navigation("Building");

                    b.Navigation("Campaign");

                    b.Navigation("Locale");

                    b.Navigation("Owner");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Games.Campaign", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Items.Item", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.AccountCampaign", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignManager.Data.Model.Games.Campaign", "Campaign")
                        .WithMany("Players")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.BuildingMap", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Locations.Building", "Building")
                        .WithMany("Maps")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignManager.Data.Model.Locations.Map", "Map")
                        .WithMany("Buildings")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Map");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.CampaignMonster", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Games.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignManager.Data.Model.Creatures.Monster", "Monster")
                        .WithMany()
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.MonsterBuilding", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Locations.Building", "Building")
                        .WithMany("Monsters")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignManager.Data.Model.Creatures.Monster", "Monster")
                        .WithMany("Buildings")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Joins.MonsterLocale", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Locations.Locale", "Locale")
                        .WithMany("Monsters")
                        .HasForeignKey("LocaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignManager.Data.Model.Creatures.Monster", "Monster")
                        .WithMany("Locales")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locale");

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Building", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Locations.Locale", "Locale")
                        .WithMany("Buildings")
                        .HasForeignKey("LocaleId");

                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locale");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Continent", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Dungeon", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Locations.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId");

                    b.HasOne("CampaignManager.Data.Model.Locations.Locale", "Locale")
                        .WithMany("Dungeons")
                        .HasForeignKey("LocaleId");

                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Locale");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Locale", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignManager.Data.Model.Locations.Region", "Region")
                        .WithMany("Locales")
                        .HasForeignKey("RegionId");

                    b.Navigation("Owner");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Map", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Locations.Locale", "Locale")
                        .WithMany("Maps")
                        .HasForeignKey("LocaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locale");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Region", b =>
                {
                    b.HasOne("CampaignManager.Data.Model.Locations.Continent", "Continent")
                        .WithMany("Regions")
                        .HasForeignKey("ContinentId");

                    b.HasOne("CampaignManager.Data.Model.Auth.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Auth.Account", b =>
                {
                    b.Navigation("Monsters");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Creatures.Monster", b =>
                {
                    b.Navigation("Buildings");

                    b.Navigation("Locales");

                    b.Navigation("Npcs");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Games.Campaign", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Building", b =>
                {
                    b.Navigation("Maps");

                    b.Navigation("Monsters");

                    b.Navigation("Npcs");

                    b.Navigation("Pcs");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Continent", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Locale", b =>
                {
                    b.Navigation("Buildings");

                    b.Navigation("Dungeons");

                    b.Navigation("Maps");

                    b.Navigation("Monsters");

                    b.Navigation("Npcs");

                    b.Navigation("Pcs");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Map", b =>
                {
                    b.Navigation("Buildings");
                });

            modelBuilder.Entity("CampaignManager.Data.Model.Locations.Region", b =>
                {
                    b.Navigation("Locales");
                });
#pragma warning restore 612, 618
        }
    }
}
