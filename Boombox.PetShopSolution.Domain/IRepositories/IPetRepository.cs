using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.Domain.IRepositories
{
    public interface IPetRepository
    {
        public List<Pet> GetPets();
        Pet CreatePet(Pet pet);
    }
}