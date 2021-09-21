using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.WebAPI.Pet;

namespace Boombox.PetShopSolution.WebAPI.Dtos
{
    public class PetTransformer
    {
        public Core.Models.Pet PostPetTransformer(PostPetDto ppd)
        {
            Core.Models.Pet pet = new Core.Models.Pet
            {
                PetName = ppd.PetName,
                PetTypeB = new PetType
                {
                    Id = ppd.PetTypeId
                },
                BirthDate = ppd.BirthDate,
                Color = ppd.Color,
                Price = ppd.Price
            };
            return pet;
        }
    }
}