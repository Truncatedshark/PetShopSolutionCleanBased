using System;

namespace Boombox.PetShopSolution.EFSQL.Entities
{
    public class PetEntity
    {
        public int? Id { get; set; }
        
        public string PetName { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public DateTime SoldDate { get; set; }
        public double Price { get; set; }
        
        public int ColorId { get; set; }
        public PetColorEntity Color { get; set; }
        
        public int PetTypeBId { get; set; }
        
        public PetTypeEntity PetTypeB { get; set; }
        
        public int PetOwnerId { get; set; }

        public PetOwnerEntity PetOwner { get; set; }
        
    }
}