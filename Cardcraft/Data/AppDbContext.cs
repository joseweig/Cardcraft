using Cardcraft.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cardcraft.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(
                new Card { 
                    Id = 1, 
                    Name = "Mayo", 
                    Description = "An unemployed programmer.", 
                    Attack = 3, 
                    Health = 2, 
                    Family = Enums.FamilyType.Humanoid,
                    Image = "images/buff_programmer.png",
                    IsActive = true
                },
                new Card { 
                    Id = 2, 
                    Name = "Bolo", 
                    Description = "A tiny berserker chihuahua.", 
                    Attack = 1, 
                    Health = 1, 
                    Family = Enums.FamilyType.Beast,
                    Image = "images/boloberto.png",
                    IsActive = true
                },
                new Card { 
                    Id = 3, 
                    Name = "Cami", 
                    Description = "An tall exotic voluptuous woman.", 
                    Attack = 2, 
                    Health = 3, 
                    Family = Enums.FamilyType.Humanoid,
                    Image = "images/exotic_island_girl.png",
                    IsActive = true
                }
            );
        }
    }
}
