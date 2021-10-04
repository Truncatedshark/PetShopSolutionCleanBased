using System;

namespace Boombox.PetShopSolution.WebAPI.Pet
{
    public class PostPetDto
    {
        public int PetTypeId { get; set; }
        public string PetName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ColorId { get; set; }
        public int PetOwnerId { get; set; }
        public double Price { get; set; }
    }
}