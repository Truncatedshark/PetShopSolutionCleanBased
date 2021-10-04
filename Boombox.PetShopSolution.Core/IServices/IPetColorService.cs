using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.Core.IServices
{
    public interface IPetColorService
    {
        List<PetColor> ReadAll();

        public PetColor CreateColor(string name);
        PetColor RemoveColor(int id);
    }
}