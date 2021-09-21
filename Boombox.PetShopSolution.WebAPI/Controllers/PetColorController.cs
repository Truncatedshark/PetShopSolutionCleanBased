using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Boombox.PetShopSolution.WebAPI.Controllers
{
    [ApiController]
    [Route("petShopApi/[controller]")]

    public class PetColorController
    {
        private readonly IPetColorService _petColorService;

        public PetColorController(IPetColorService petColorService)
        {
            _petColorService = petColorService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Core.Models.PetColor>> Get()
        {
            return _petColorService.ReadAll();
        }
    }
    
    
}