using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Boombox.PetShopSolution.WebAPI.Controllers
{
    [ApiController]
    [Route("petShopApi/[controller]")]
    public class PetTypeController
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Core.Models.PetType>> Get()
        {
            return _petTypeService.ReadAll();
        }

        [HttpPost]
        public PetType CreatePet(PostPetTypeDto postPetTypeDto)
        {
            return _petTypeService.createPetType(postPetTypeDto.PetTypeName);
        }

        [HttpDelete("{id}")]
        public PetType RemovePetType(int id)
        {
            return _petTypeService.RemovePetType(id);
        }
    }
}