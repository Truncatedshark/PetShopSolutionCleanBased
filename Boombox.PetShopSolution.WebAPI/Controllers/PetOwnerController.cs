using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
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
    }
}