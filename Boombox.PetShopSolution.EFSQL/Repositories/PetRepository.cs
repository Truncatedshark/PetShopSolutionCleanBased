using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopSolutionContext _ctx;

        public PetRepository(PetShopSolutionContext ctx)
        {
            _ctx = ctx;
            
        }

        public List<Pet> GetPets()
        {
            return _ctx.PetTable.ToList();
        }

        public Pet CreatePet(Pet pet)
        {
           return _ctx.PetTable.Add(pet).Entity;
        }
    }
}