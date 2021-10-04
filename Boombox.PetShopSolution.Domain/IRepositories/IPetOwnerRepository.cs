using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.Domain.IRepositories
{
    public interface IPetOwnerRepository
    {
        public List<PetOwner> GetOwners();

        public PetOwner CreateOwner(string name);
        PetOwner RemoveOwner(int id);
    }
}