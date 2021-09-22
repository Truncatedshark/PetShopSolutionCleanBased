using System;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.EFSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boombox.PetShopSolution.EFSQL
{
    public class PetShopSolutionContext : DbContext
    {
        public PetShopSolutionContext(DbContextOptions<PetShopSolutionContext> opt)
        : base(opt)
        {
            
        }
        
        public DbSet<Pet> PetTable { get; set; }
        
        public DbSet<PetColor> PetColorTable { get; set; }

        public DbSet<PetOwner> PetOwnerTable { get; set; }
        
        public DbSet<PetType> PetTypeTable { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<PetEntity>()
                .HasOne(p => p.PetType)
                .WithMany()
                .HasForeignKey(p => new {TypeOdId = p.PetType});

            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity {Id = 1, PetName = "Snoop Dogg", Price = 420});
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity {Id = 2, PetName = "Ice Cube", Price = 323});
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity {Id = 3, PetName = "Dr. Dre", Price = 213});
         
        }
        


 


    }
}