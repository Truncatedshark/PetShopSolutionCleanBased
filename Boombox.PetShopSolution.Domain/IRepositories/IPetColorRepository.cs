﻿using System.Collections.Generic;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.Domain.IRepositories
{
    public interface IPetColorRepository
    {
        public List<PetColor> GetColors();

        public PetColor CreateColor(PetColor color);
    }
}