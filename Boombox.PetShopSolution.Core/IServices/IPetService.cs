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

        Pet EditPet(Pet editedPet);

        Pet RemovePet(int id);

        List<Pet> SortByPrice(int upOrDown);

        List<Pet> GetFiveCheapestPets();
        
        
    }
}