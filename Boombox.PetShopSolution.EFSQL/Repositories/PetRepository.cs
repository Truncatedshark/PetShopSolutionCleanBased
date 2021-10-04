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
            List<Pet> listPettos = new List<Pet>();
            foreach (var petEntity in _ctx.PetTable
                .Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count)
                .ToList())
            {
                listPettos.Add(_transformer.FromPetEntity(petEntity));
            }
            return listPettos;
            
        }

        public Pet GetPetbyId(int id)
        {
            return _transformer.FromPetEntity(_ctx.PetTable
                .Include(c => c.Color)
                .Include(c=> c.PetOwner)
                .Include(c => c.PetTypeB)
                .FirstOrDefault(c => c.Id == id));
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

        public int Count()
        {
            return _ctx.PetTable.Count();
        }
    }
}