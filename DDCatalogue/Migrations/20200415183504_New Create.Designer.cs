﻿// <auto-generated />
using System;
using DDCatalogue.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DDCatalogue.Migrations
{
    [DbContext(typeof(DDContext))]
    [Migration("20200415183504_New Create")]
    partial class NewCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DDCatalogue.Model.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Map")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.HasKey("BuildingId");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("DDCatalogue.Model.CharacterBase", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ac")
                        .HasColumnType("int");

                    b.Property<bool?>("Acrobatics")
                        .HasColumnType("bit");

                    b.Property<int>("Alignment")
                        .HasColumnType("int");

                    b.Property<bool?>("AnimalHandling")
                        .HasColumnType("bit");

                    b.Property<bool?>("Arcana")
                        .HasColumnType("bit");

                    b.Property<bool?>("Athletics")
                        .HasColumnType("bit");

                    b.Property<int?>("Cha")
                        .HasColumnType("int");

                    b.Property<int?>("Con")
                        .HasColumnType("int");

                    b.Property<bool?>("Deception")
                        .HasColumnType("bit");

                    b.Property<int?>("Dex")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("History")
                        .HasColumnType("bit");

                    b.Property<string>("HitDice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<bool?>("Insight")
                        .HasColumnType("bit");

                    b.Property<int?>("Int")
                        .HasColumnType("int");

                    b.Property<bool?>("Intimidation")
                        .HasColumnType("bit");

                    b.Property<bool?>("Investigations")
                        .HasColumnType("bit");

                    b.Property<string>("Languages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Medicine")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Nature")
                        .HasColumnType("bit");

                    b.Property<bool?>("Perception")
                        .HasColumnType("bit");

                    b.Property<bool?>("Performance")
                        .HasColumnType("bit");

                    b.Property<bool?>("Persuasion")
                        .HasColumnType("bit");

                    b.Property<bool?>("Religion")
                        .HasColumnType("bit");

                    b.Property<bool?>("SavCha")
                        .HasColumnType("bit");

                    b.Property<bool?>("SavCon")
                        .HasColumnType("bit");

                    b.Property<bool?>("SavDex")
                        .HasColumnType("bit");

                    b.Property<bool?>("SavInt")
                        .HasColumnType("bit");

                    b.Property<bool?>("SavStr")
                        .HasColumnType("bit");

                    b.Property<bool?>("SavWis")
                        .HasColumnType("bit");

                    b.Property<bool?>("SleightOfHand")
                        .HasColumnType("bit");

                    b.Property<string>("Speed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Stealth")
                        .HasColumnType("bit");

                    b.Property<int?>("Str")
                        .HasColumnType("int");

                    b.Property<bool?>("Survival")
                        .HasColumnType("bit");

                    b.Property<string>("Traits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Wis")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.ToTable("CharacterBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CharacterBase");
                });

            modelBuilder.Entity("DDCatalogue.Model.Continent", b =>
                {
                    b.Property<int>("ContinentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Map")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ContinentId");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("DDCatalogue.Model.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContinentId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Map")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("CountryId");

                    b.HasIndex("ContinentId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DDCatalogue.Model.Dungeon", b =>
                {
                    b.Property<int>("DungeonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("DungeonId");

                    b.ToTable("Dungeons");
                });

            modelBuilder.Entity("DDCatalogue.Model.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("DDCatalogue.Model.Municipality", b =>
                {
                    b.Property<int>("MunicipalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Map")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MunicipalityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("DDCatalogue.Model.Npc", b =>
                {
                    b.Property<string>("NpcId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NpcId");

                    b.ToTable("Npcs");
                });

            modelBuilder.Entity("DDCatalogue.Model.Character", b =>
                {
                    b.HasBaseType("DDCatalogue.Model.CharacterBase");

                    b.Property<string>("Background")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Inspiration")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<bool>("Player")
                        .HasColumnType("bit");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Xp")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Character");
                });

            modelBuilder.Entity("DDCatalogue.Model.Monster", b =>
                {
                    b.HasBaseType("DDCatalogue.Model.CharacterBase");

                    b.Property<string>("Actions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Challenge")
                        .HasColumnType("float");

                    b.Property<int>("DefeatXp")
                        .HasColumnType("int");

                    b.Property<string>("LegendaryActions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senses")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Monster");
                });

            modelBuilder.Entity("DDCatalogue.Model.Armour", b =>
                {
                    b.HasBaseType("DDCatalogue.Model.Item");

                    b.HasDiscriminator().HasValue("Armour");
                });

            modelBuilder.Entity("DDCatalogue.Model.Treasure", b =>
                {
                    b.HasBaseType("DDCatalogue.Model.Item");

                    b.HasDiscriminator().HasValue("Treasure");
                });

            modelBuilder.Entity("DDCatalogue.Model.Weapon", b =>
                {
                    b.HasBaseType("DDCatalogue.Model.Item");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("DDCatalogue.Model.Building", b =>
                {
                    b.HasOne("DDCatalogue.Model.Municipality", "Municipality")
                        .WithMany("Buildings")
                        .HasForeignKey("MunicipalityId");
                });

            modelBuilder.Entity("DDCatalogue.Model.Country", b =>
                {
                    b.HasOne("DDCatalogue.Model.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId");
                });

            modelBuilder.Entity("DDCatalogue.Model.Municipality", b =>
                {
                    b.HasOne("DDCatalogue.Model.Country", "Country")
                        .WithMany("Municipalities")
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}
