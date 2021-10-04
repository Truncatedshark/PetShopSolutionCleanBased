using System;
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
        public PetColor Post([FromBody] PostColorDto postPetColorDto)
        {
            return _petColorService.CreateColor(postPetColorDto.Name);
        }

        [HttpDelete("{id}")]
        public PetColor Remove(int id)
        {
            return _petColorService.RemoveColor(id);
        }
    }
    
    
}