using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;

namespace Boombox.PetShopSolution.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly IPetTypeRepository _repo;

        public PetTypeService(IPetTypeRepository repo)
        {
            _repo = repo;
        }

        public List<PetType> ReadAll()
        {
            return _repo.GetTypes();
        }

        public PetType CreateType(PetType type)
        {
            return _repo.CreateType(type);
        }
    }
}