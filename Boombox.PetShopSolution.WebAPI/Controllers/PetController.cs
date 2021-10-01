using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Filtering;
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

        [HttpGet("{id}")]
        public ActionResult<GetPetById> GetPetById(int id)
        {
            Core.Models.Pet resultPet = _petService.GetPetById(id);
            return _tr.ToGetPetTransformer(resultPet);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Core.Models.Pet>> Get(Filter filter)
        {
            return _petService.ReadAll(filter);
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