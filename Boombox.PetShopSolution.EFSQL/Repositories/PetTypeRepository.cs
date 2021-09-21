using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class PetTypeRepository
    {
        private readonly PetShopSolutionContext _ctx;

        public PetTypeRepository(PetShopSolutionContext ctx)
        {
            _ctx = ctx;
            
        }

        public List<PetType> GetPets()
        {
            return _ctx.PetTypeTable.ToList();
        }

        public PetType CreateType(PetType type)
        {
            return _ctx.PetTypeTable.Add(type).Entity;
        }
    }
}