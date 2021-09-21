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
                Name = ppd.Name,
                
                    Id = ppd.Id
                
            };
            return color;
        }
    }
}