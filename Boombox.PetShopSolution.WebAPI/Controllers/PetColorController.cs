using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.WebAPI.Dtos;
using Boombox.PetShopSolution.WebAPI.Dtos.PetColor;
using Microsoft.AspNetCore.Mvc;

namespace Boombox.PetShopSolution.WebAPI.Controllers
{
    [ApiController]
    [Route("petShopApi/[controller]")]

    public class PetColorController
    {
        private readonly IPetColorService _petColorService;
        private readonly PetColorTransformer _tr;

        public PetColorController(IPetColorService petColorService)
        {
            _petColorService = petColorService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Core.Models.PetColor>> Get()
        {
            return _petColorService.ReadAll();
        }

        [HttpPost]
        public void Post([FromBody] PostPetColorDto postPetColorDto)
        {
            var petColor = _tr.PostPetColorTransformer(postPetColorDto);
           // _petColorService.CreateColor(PetColor color);  // Why code no work? am very tired could probably figure this out if i wasnt so fuckn tired
        }
    }
    
    
}