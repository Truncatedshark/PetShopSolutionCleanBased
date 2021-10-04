using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> ReadAll();
        PetType createPetType(string name);
        PetType RemovePetType(int id);

    }
}