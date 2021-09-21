using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class PetColorRepository : IPetColorRepository
    {
        private readonly PetShopSolutionContext _ctx;
        
        public PetColorRepository(PetShopSolutionContext ctx)
        {
            _ctx = ctx;
            
        }

        List<PetColor> IPetColorRepository.GetColors()
        {
            return _ctx.PetColorTable.ToList();
        }
        public PetColor CreateColor(PetColor color)
        {
            return _ctx.PetColorTable.Add(color).Entity;
        }
        
    }
    
}