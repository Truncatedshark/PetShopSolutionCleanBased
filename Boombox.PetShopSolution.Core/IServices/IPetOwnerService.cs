using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.Core.IServices
{
    public interface IPetOwnerService
    {
        List<PetOwner> ReadAll();

    }
}