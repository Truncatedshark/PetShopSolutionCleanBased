using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
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
    }
}