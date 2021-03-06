﻿// <auto-generated />
using CovidTP.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CovidTP.DAL.Migrations
{
    [DbContext(typeof(CovidTPContext))]
    [Migration("20200416225827_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CovidTP.DAL.EntityModels.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "We have a fun Shiny Hiney song...",
                            Name = "Charmin Ultra",
                            Price = 25.69m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ironic because it feels like Hell.",
                            Name = "Angel Soft",
                            Price = 24.25m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Because you're desperate.",
                            Name = "Scotts",
                            Price = 15.75m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Almost as good as Charmin, but not as shiny",
                            Name = "Meijer Brand",
                            Price = 23.33m
                        });
                });

            modelBuilder.Entity("CovidTP.DAL.EntityModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AccountBalance");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FavoriteBrand");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("NumberOfPurchases");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
