using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.WebAPI.Dtos.PetColor;

namespace Boombox.PetShopSolution.WebAPI.Dtos
{
    public class PetColorTransformer
    {
        public Core.Models.PetColor PostPetColorTransformer(PostPetColorDto ppd)
        {
            Core.Models.PetColor color = new Core.Models.PetColor
            {
                Id = 0,
                Name = ppd.Name
            };
            return color;
        }

        public Core.Models.PetColor PostColor(PostColorDto colorDto)
        {
            return new Core.Models.PetColor() {Name = colorDto.Name};
        }
    }
}