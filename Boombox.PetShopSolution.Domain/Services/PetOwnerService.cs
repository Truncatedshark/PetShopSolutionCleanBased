using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;

namespace Boombox.PetShopSolution.Domain.Services
{
    public class PetOwnerService : IPetOwnerService
    {
        private readonly IPetOwnerRepository _repo;

        public PetOwnerService(IPetOwnerRepository repo)
        {
            _repo = repo;
        }

      

        public List<PetOwner> GetOwners()
        {
           return _repo.GetOwners();
        }

        public PetOwner CreateOwner(PetOwner owner)
        {
            return _repo.CreateOwner(owner);
        }

        public List<PetOwner> ReadAll()
        {
            return _repo.GetOwners();
        }
    }
}