using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;

namespace Boombox.PetShopSolution.Domain.Services
{
    public class PetColorService : IPetColorService
    {
        private readonly IPetColorRepository _repo;

        public PetColorService(IPetColorRepository repo)
        {
            _repo = repo;
        }

        public List<PetColor> ReadAll()
        {
            return _repo.GetColors();
        }
    }
    
}
