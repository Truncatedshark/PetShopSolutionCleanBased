namespace Boombox.PetShopSolution.WebAPI.Pet
{
    public class PutPetDto
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int ColorId { get; set; }
        public double Price { get; set; }
    }
}