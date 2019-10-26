﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebScrapingRobot.Context;

namespace WebScrapingRobot.Migrations
{
    [DbContext(typeof(FBOContext))]
    partial class FBOContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebScrapingRobot.Model.AgencyOfficeLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agency");

                    b.Property<string>("Location");

                    b.Property<string>("Office");

                    b.HasKey("Id");

                    b.ToTable("AgencyOfficeLocations");
                });

            modelBuilder.Entity("WebScrapingRobot.Model.Opportunity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("Name");

                    b.Property<string>("SolicitationNumber");

                    b.HasKey("Id");

                    b.ToTable("Opportunities");
                });

            modelBuilder.Entity("WebScrapingRobot.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgencyOfficeLocationId");

                    b.Property<int?>("OpportunityId");

                    b.Property<DateTime>("PostedDate");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AgencyOfficeLocationId");

                    b.HasIndex("OpportunityId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("WebScrapingRobot.Model.Post", b =>
                {
                    b.HasOne("WebScrapingRobot.Model.AgencyOfficeLocation", "AgencyOfficeLocation")
                        .WithMany()
                        .HasForeignKey("AgencyOfficeLocationId");

                    b.HasOne("WebScrapingRobot.Model.Opportunity", "Opportunity")
                        .WithMany()
                        .HasForeignKey("OpportunityId");
                });
#pragma warning restore 612, 618
        }
    }
}