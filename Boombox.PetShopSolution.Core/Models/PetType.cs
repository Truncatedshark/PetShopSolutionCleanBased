using System.Collections.Generic;

namespace Boombox.PetShopSolution.Core.Models
{
    public class PetType
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<Pet> listPets { get; set; }
    }
}