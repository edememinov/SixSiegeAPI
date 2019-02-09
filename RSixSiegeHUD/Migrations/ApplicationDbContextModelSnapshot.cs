﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RSixSiegeHUD.Data;

namespace RSixSiegeHUD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RSixSiegeHUD.Models.Death", b =>
                {
                    b.Property<int>("DeathId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KilledBy");

                    b.Property<int>("RoundId");

                    b.Property<string>("UserId");

                    b.HasKey("DeathId");

                    b.ToTable("Deaths");
                });

            modelBuilder.Entity("RSixSiegeHUD.Models.GameInfo", b =>
                {
                    b.Property<int>("GameInfoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MatchId");

                    b.Property<string>("Phase");

                    b.HasKey("GameInfoId");

                    b.ToTable("GameInfos");
                });

            modelBuilder.Entity("RSixSiegeHUD.Models.Kill", b =>
                {
                    b.Property<int>("KillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Headshot");

                    b.Property<int>("RoundId");

                    b.Property<int>("UserId");

                    b.HasKey("KillId");

                    b.ToTable("Kills");
                });

            modelBuilder.Entity("RSixSiegeHUD.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("MatchToken");

                    b.Property<int>("ScoreBlueTeam");

                    b.Property<int>("ScoreOrangeTeam");

                    b.HasKey("MatchId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("RSixSiegeHUD.Models.MatchOutcome", b =>
                {
                    b.Property<int>("MatchOutcomeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchId");

                    b.Property<string>("Outcome");

                    b.Property<int>("UserId");

                    b.HasKey("MatchOutcomeId");

                    b.ToTable("MatchOutcomes");
                });

            modelBuilder.Entity("RSixSiegeHUD.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsLocal");

                    b.Property<string>("Name");

                    b.Property<string>("UbisoftAccountToken");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Player");
                });

            modelBuilder.Entity("RSixSiegeHUD.Models.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlueTeamScore");

                    b.Property<int>("MatchId");

                    b.Property<int>("OrangeTeamScore");

                    b.Property<int>("RoundNumber");

                    b.Property<string>("UserId");

                    b.HasKey("RoundId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("RSixSiegeHUD.Models.RoundOutcome", b =>
                {
                    b.Property<int>("RoundOutcomeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Outcome");

                    b.Property<int>("RoundId");

                    b.Property<int>("UserId");

                    b.HasKey("RoundOutcomeId");

                    b.ToTable("RoundOutcomes");
                });

            modelBuilder.Entity("RSixSiegeHUD.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OverWolfId");

                    b.Property<string>("UbisoftId");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RSixSiegeHUD.Models.LocalPlayer", b =>
                {
                    b.HasBaseType("RSixSiegeHUD.Models.Player");

                    b.Property<int>("Deaths");

                    b.Property<int>("Health");

                    b.Property<int>("Kills");

                    b.Property<int>("MatchId");

                    b.Property<int>("RoundId");

                    b.Property<int>("Score");

                    b.ToTable("LocalPlayer");

                    b.HasDiscriminator().HasValue("LocalPlayer");
                });
#pragma warning restore 612, 618
        }
    }
}
