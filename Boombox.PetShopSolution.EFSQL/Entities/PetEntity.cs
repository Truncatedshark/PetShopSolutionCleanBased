using System;

namespace Boombox.PetShopSolution.EFSQL.Entities
{
    public class PetEntity
    {
        public int? Id { get; set; }

        public int PetTypeId { get; set; }
        
        public PetTypeEntity PetTypeB { get; set; }
        
        public int OwnerId { get; set; }

        public string PetOwner { get; set; }
        public string PetType { get; set; }
        public string PetName { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public DateTime SoldDate { get; set; }
        
        public string Color { get; set; }
        public double Price { get; set; }
    }
}