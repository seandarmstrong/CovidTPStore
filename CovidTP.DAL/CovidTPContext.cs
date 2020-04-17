using CovidTP.DAL.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTP.DAL
{
    public class CovidTPContext : DbContext
    {
        public CovidTPContext()
        {

        }

        public CovidTPContext(DbContextOptions<CovidTPContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Item> Items { get; set; }
		public virtual DbSet<UserItems> UserItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=LAPTOP-0FFESSLQ\\SQLEXPRESS;Initial Catalog=CovidTPShop;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }

		public static void Seed(ModelBuilder model)
		{
			model.Entity<Item>()
				.HasData((new Item[]
				{
					new Item()
					{
						Id = 1,
						Name = "Charmin Ultra",
						Description = "We have a fun Shiny Hiney song...",
						Price = 25.69M
					},
					new Item()
					{
						Id = 2,
						Name = "Angel Soft",
						Description = "Ironic because it feels like Hell.",
						Price = 24.25M
					},
					new Item()
					{
						Id = 3,
						Name = "Scotts",
						Description = "Because you're desperate.",
						Price = 15.75M
					},
					new Item()
					{
						Id = 4,
						Name = "Meijer Brand",
						Description = "Almost as good as Charmin, but not as shiny",
						Price = 23.33M
					}
				}));
		}
	}
}
