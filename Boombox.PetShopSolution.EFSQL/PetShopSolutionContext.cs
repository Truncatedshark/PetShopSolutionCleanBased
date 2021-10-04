using System;
using System.Collections.Generic;
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
        
        public DbSet<PetEntity> PetTable { get; set; }
        
        public DbSet<PetColorEntity> PetColorTable { get; set; }

        public DbSet<PetOwnerEntity> PetOwnerTable { get; set; }
        
        public DbSet<PetTypeEntity> PetTypeTable { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
          modelBuilder.Entity<PetEntity>()
            .HasOne(p => p.PetTypeB)
            .WithMany(p => p.Pets);

          modelBuilder.Entity<PetEntity>()
            .HasOne(p => p.PetOwner)
            .WithMany(p => p.Pets);
        }
       
    }
}