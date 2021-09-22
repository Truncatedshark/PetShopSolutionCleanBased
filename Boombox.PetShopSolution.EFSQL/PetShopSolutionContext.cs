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


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        
        {

            
        }
        


 


    }
}