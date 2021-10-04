using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Filtering;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;
using Boombox.PetShopSolution.EFSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopSolutionContext _ctx;
        private readonly EntityTransformer _transformer;

        public PetRepository(PetShopSolutionContext ctx)
        {
            _ctx = ctx;
            _transformer = new EntityTransformer();
        }

        public List<Pet> GetPets(Filter filter)
        {
            var listPettos = _ctx.PetTable
                .Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count)
                .Select(pet => new Pet
                {
                    Id = pet.Id,
                    PetName = pet.PetName,
                    Price = pet.Price,
                    PetTypeB = new PetType {Name = pet.PetTypeB.Name},
                    Color = new PetColor() {Name = pet.Color.Name},
                    PetOwner = new PetOwner() {Name = pet.PetOwner.Name}
                })
                .ToList();
            
            return listPettos;
            
        }

        public Pet GetPetbyId(int id)
        {
            var entityWithRelation = _ctx.PetTable
                .Select(pet =>new Pet
                {
                    Id = pet.Id,
                    PetName = pet.PetName,
                    Price = pet.Price,
                    PetTypeB = new PetType{Name = pet.PetTypeB.Name},
                    Color = new PetColor(){Name = pet.Color.Name},
                    PetOwner = new PetOwner(){Name = pet.PetOwner.Name}
                });
            var petW =
                entityWithRelation.FirstOrDefault(p => p.Id == id);
            return petW;
        }


        public Pet CreatePet(Pet pet)
        {
            var petFromDB = _ctx.PetTable.Add(_transformer.ToPetEntity(pet)).Entity;
            _ctx.SaveChanges();
            var entityWithRelation = _ctx.PetTable
                .Select(pet =>new Pet
                {
                    Id = pet.Id,
                    PetName = pet.PetName,
                    Price = pet.Price,
                    PetTypeB = new PetType{Name = pet.PetTypeB.Name},
                    Color = new PetColor(){Name = pet.Color.Name},
                    PetOwner = new PetOwner(){Name = pet.PetOwner.Name}
                });
            var petW =
                entityWithRelation.FirstOrDefault(p => p.Id == petFromDB.Id);
            return petW;
        }

        public Pet EditPet(Pet pet)
        {
            var existingPet = _ctx.PetTable
                .Where(p => p.Id == pet.Id)
                .Select(pE => pE)
                .FirstOrDefault();
            existingPet.ColorId = pet.Color.Id;
            existingPet.PetName = pet.PetName;
            existingPet.Price = pet.Price;
            var updatedPetRes = _transformer.FromPetEntityLite(_ctx.Update(existingPet).Entity);
            _ctx.SaveChanges();
            return updatedPetRes;
        }

        public Pet RemovePet(int id)
        {
            var deletedPet = _ctx.PetTable
                .Where(p => p.Id == id)
                .Select(pE => new Pet()
                {
                    Id = pE.Id,
                    PetName = pE.PetName
                })
                .FirstOrDefault();
            _ctx.PetTable.Remove(new PetEntity() {Id = id});
            _ctx.SaveChanges();
            return deletedPet;
        }

        public int Count()
        {
            return _ctx.PetTable.Count();
        }
    }
}