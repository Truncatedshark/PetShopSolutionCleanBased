using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.EFSQL.Entities;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class PetOwnerRepository
    {
        private readonly PetShopSolutionContext _ctx;
        private readonly EntityTransformer _transform;

        public PetOwnerRepository(PetShopSolutionContext ctx)
        {
            _ctx = ctx;
            _transform = new EntityTransformer();
        }

        public List<PetOwner> GetPets()
        {
            List<PetOwner> listOwners = new List<PetOwner>();
            foreach (var petOwner in _ctx.PetOwnerTable.ToList())
            {
                listOwners.Add(_transform.FromPetOwnerEntity(petOwner));
            }
            return listOwners;
        }

        public PetOwner CreateOwner(PetOwner owner)
        {
            return _transform.FromPetOwnerEntity(_ctx.PetOwnerTable.Add(_transform.ToPetOwnerEntity(owner)).Entity);
        }
    }
}