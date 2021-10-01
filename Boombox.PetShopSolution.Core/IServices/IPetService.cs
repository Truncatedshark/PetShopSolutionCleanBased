using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Filtering;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.Core.IServices
{
    public interface IPetService
    {
        
        Pet CreatePet(Pet pet);

        List<Pet> ReadAll(Filter filter);
        Pet GetPetById(int id);
        
        List<Pet> SearchByName();
        
        List<Pet> SearchByType(string typeToSearchFor);

        Pet EditPet(int id, Pet editedPet);

        void DeletePet(int id);

        List<Pet> SortByPrice(int upOrDown);

        List<Pet> GetFiveCheapestPets();
        
        
    }
}