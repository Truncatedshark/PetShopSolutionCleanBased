using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.WebAPI.Dtos.PetOwner;
using Microsoft.AspNetCore.Mvc;

namespace Boombox.PetShopSolution.WebAPI.Controllers
{
    [ApiController]
    [Route("petShopApi/[controller]")]
    
    public class PetOwnerController
    {
        private readonly IPetOwnerService _petOwnerService;

        public PetOwnerController(IPetOwnerService petOwnerService)
        {
            _petOwnerService = petOwnerService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Core.Models.PetOwner>> Get()
        {
            return _petOwnerService.ReadAll();
        }
        
        [HttpPost]
        public PetOwner PostPetOwner([FromBody] PostPetOwnerDto postPetOwner)
        {
            return _petOwnerService.AddPetOwner(postPetOwner.OwnerName);
        }

        [HttpDelete("{id}")]
        public PetOwner Remove(int id)
        {
            return _petOwnerService.RemoveOwner(id);
        }
    }
}