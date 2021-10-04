using System.Collections.Generic;

namespace Boombox.PetShopSolution.EFSQL.Entities
{
    public class PetOwnerEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<PetEntity> Pets { get; set; }
    }
}