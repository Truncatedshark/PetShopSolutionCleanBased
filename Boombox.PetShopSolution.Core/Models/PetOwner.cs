using System.Collections.Generic;

namespace Boombox.PetShopSolution.Core.Models
{
    public class PetOwner
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Pet> PetsOfOwner { get; set; }

    }
}