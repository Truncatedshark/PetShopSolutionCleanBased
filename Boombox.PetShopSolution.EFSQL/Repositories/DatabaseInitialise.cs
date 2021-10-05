using System;
using System.Collections.Generic;
using Boombox.PetShopSolution.EFSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class DatabaseInitialise : IDatabaseInitialise
    {
        public void seedDatabase(DbContext ctx)
        {
            PetOwnerEntity petOwner = new PetOwnerEntity()
            {
                Id = 1, 
                Name = "Martin"
            };
            
            PetOwnerEntity petOwner1 = new PetOwnerEntity()
            {
                Id = 2, 
                Name = "Nedas"
            };
            
            PetOwnerEntity petOwner2 = new PetOwnerEntity()
            {
                Id = 3, 
                Name = "Maté"
            };
            
            PetColorEntity petColor = new PetColorEntity()
            {
                Id = 1, 
                Name = "Black"
            };
            PetColorEntity petColor1 = new PetColorEntity()
            {
                Id = 2, 
                Name = "Orange"
            };
            PetColorEntity petColor2 = new PetColorEntity()
            {
                Id = 3, 
                Name = "Kamo"
            };
            PetTypeEntity petTypeDog = new PetTypeEntity()
            {
                Id = 1, 
                Name = "Dog"
            };
            PetTypeEntity petTypeHippo = new PetTypeEntity()
            {
                Id = 2, 
                Name = "Dog"
            };
            PetTypeEntity petTypeDyno = new PetTypeEntity()
            {
                Id = 3, 
                Name = "Dog"
            };

            ctx.Add(petOwner);
            ctx.Add(petOwner1);
            ctx.Add(petOwner2);
            ctx.Add(petColor);
            ctx.Add(petColor1);
            ctx.Add(petColor2);
            ctx.Add(petTypeDog);
            ctx.Add(petTypeHippo);
            ctx.Add(petTypeDyno);
            
            for (int i = 1; i < 6969; i++)
            {
                PetEntity pet = new PetEntity()
                {
                    Id = i,
                    PetName = "sheesh",
                    BirthDate = DateTime.Now,
                    Price = 69,
                    PetOwnerId = 2,
                    PetTypeBId = 1,
                    ColorId = 1
                };
                ctx.Add(pet);
            }

            ctx.SaveChanges();

            /*var random = new Random();
            var names = new List<string> {"Snoop Dogg", "Ice Cube", "Dr. Dre"};
            for (var i = 1; i < 1000; i++)
            {
                
                var petName = $"{names[random.Next(0, 3)]}{i}";
                modelBuilder.Entity<PetEntity>()
                    .HasData(new PetEntity
                    {
                        Id = i,
                        PetName = petName,
                        ColorId = 1,
                        PetOwnerId = random.Next(0,3),
                        PetTypeId = 1
                        
                    });
            }*/
        }
    }
}