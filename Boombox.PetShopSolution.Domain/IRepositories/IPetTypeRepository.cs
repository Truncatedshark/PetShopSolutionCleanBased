using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        public List<PetType> GetTypes();

        public PetType CreateType(string type);
        public PetType RemovePetType(int id);
    }
}