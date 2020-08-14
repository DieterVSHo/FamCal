using Microsoft.EntityFrameworkCore;
using FamCal_backend.Models;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FamCal_backend.Data
{
    public class FamCalContext : IdentityDbContext<IdentityUser>
    {
        public FamCalContext(DbContextOptions<FamCalContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*builder.Entity<Event>()
                .IsRequired()
                .HasForeignKey("Id"); //Shadow property
            builder.Entity<Event>().Property(r => r.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Events>().Property(r => r.Chef).HasMaxLength(50);
            builder.Entity<Ingredient>().Property(r => r.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Ingredient>().Property(r => r.Unit).HasMaxLength(10);

            //Another way to seed the database
            builder.Entity<Events>().HasData(
                 new Events { Id = 1, Name = "Spaghetti", Created = DateTime.Now, Chef = "Piet" },
                 new Events { Id = 2, Name = "Tomato soup", Created = DateTime.Now }
  );

            builder.Entity<Ingredient>().HasData(
                    //Shadow property can be used for the foreign key, in combination with anaonymous objects
                    new { Id = 1, Name = "Tomatoes", Amount = (double?)0.75, Unit = "liter", RecipeId = 1 },
                    new { Id = 2, Name = "Minced Meat", Amount = (double?)500, Unit = "grams", RecipeId = 1 },
                    new { Id = 3, Name = "Onion", Amount = (double?)2, RecipeId = 1 }
                 );*/
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

    }
}