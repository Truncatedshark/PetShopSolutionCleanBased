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
                .HasOne(p => p.PetOwner)
                .WithMany()
                .HasForeignKey(p => new {OwnerOdId = p.PetOwner});

            

            modelBuilder.Entity<PetTypeEntity>()
                .HasData(new PetTypeEntity {Id = 1, Name = "Dog"});
            
            modelBuilder.Entity<PetTypeEntity>()
                .HasData(new PetTypeEntity {Id = 2, Name = "Goldfish"});
            
            modelBuilder.Entity<PetTypeEntity>()
                .HasData(new PetTypeEntity {Id = 3, Name = "Gorilla"});
            
            modelBuilder.Entity<PetTypeEntity>()
                .HasData(new PetTypeEntity {Id = 4, Name = "Owl"});

            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity {Id = 1, PetName = "Snoop Dogg", PetTypeId = 1, Price = 420});
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity {Id = 2, PetName = "Ice Cube", PetTypeId = 2,Price = 323});
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity {Id = 3, PetName = "Dr. Dre", PetTypeId = 3, Price = 213});
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity {Id = 4, PetName = "Drake", PetTypeId = 4, Price = 213});
         
        }
        


 


    }
}