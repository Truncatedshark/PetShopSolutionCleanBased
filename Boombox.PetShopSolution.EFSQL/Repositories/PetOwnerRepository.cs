using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class PetOwnerRepository
    {
        private readonly PetShopSolutionContext _ctx;

        public PetOwnerRepository(PetShopSolutionContext ctx)
        {
            _ctx = ctx;
            
        }

        public List<PetOwner> GetPets()
        {
            return _ctx.PetOwnerTable.ToList();
        }

        public PetOwner CreateOwner(PetOwner owner)
        {
            return _ctx.PetOwnerTable.Add(owner).Entity;
        }
    }
}