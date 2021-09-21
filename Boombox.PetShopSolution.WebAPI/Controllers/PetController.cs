using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.WebAPI.Dtos;
using Boombox.PetShopSolution.WebAPI.Pet;
using Microsoft.AspNetCore.Mvc;

namespace Boombox.PetShopSolution.WebAPI.Controllers
{
    [ApiController]
    [Route("petShopApi/[controller]")]
    
    public class PetController
    {
        private readonly IPetService _petService;
        private readonly PetTransformer _tr;

        public PetController(IPetService petService)
        {
            _tr = new PetTransformer();
            _petService = petService;
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<Core.Models.Pet>> Get()
        {
            return _petService.ReadAll();
        }
        
        // POST Pets
        [HttpPost]
        public void Post([FromBody] PostPetDto postPetDto)
        {
            var pet = _tr.PostPetTransformer(postPetDto);
             _petService.CreatePet(pet);
        }
    }
}