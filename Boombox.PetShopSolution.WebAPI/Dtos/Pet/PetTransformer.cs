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
                PetTypeB = new PetType {Id = ppd.PetTypeId},
                BirthDate = ppd.BirthDate,
                Color = new Core.Models.PetColor(){Id = ppd.ColorId},
                PetOwner = new Core.Models.PetOwner(){Id = ppd.PetOwnerId},
                Price = ppd.Price
            };
            return pet;
        }

        public GetPetById ToGetPetTransformer(Core.Models.Pet pet)
        {
            GetPetById getPet = new GetPetById()
            {
                PetName = pet.PetName,
                Price = pet.Price,
                Color = pet.Color.Name,
                Owner = pet.PetOwner.Name,
                PetType = pet.PetTypeB.Name
            };
            return getPet;
        }

        public Core.Models.Pet PutPetDto(PutPetDto putPd)
        {
            return new Core.Models.Pet()
            {
                Id = putPd.PetId,
                PetName = putPd.PetName,
                Color = new Core.Models.PetColor() {Id = putPd.ColorId},
                Price = putPd.Price
            };
        }
    }
}