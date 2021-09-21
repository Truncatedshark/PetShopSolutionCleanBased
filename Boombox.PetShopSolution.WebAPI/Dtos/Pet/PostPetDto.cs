using System;

namespace Boombox.PetShopSolution.WebAPI.Pet
{
    public class PostPetDto
    {
        public int PetTypeId { get; set; }
        public string PetName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}