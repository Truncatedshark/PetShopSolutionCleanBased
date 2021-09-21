using System;

namespace Boombox.PetShopSolution.Core.Models
{
    public class Pet
    {
        
        public int? Id { get; set; }
        
        public PetType PetTypeB { get; set; }
        public string PetType { get; set; }
        public string PetName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}