using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Filtering;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.Domain.IRepositories
{
    public interface IPetRepository
    {
        List<Pet> GetPets(Filter filter);
        Pet GetPetbyId(int id);
        
        Pet CreatePet(Pet pet);

        int Count();
    }
}