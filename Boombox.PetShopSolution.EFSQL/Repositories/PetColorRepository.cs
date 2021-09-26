using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;
using Boombox.PetShopSolution.EFSQL.Entities;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class PetColorRepository : IPetColorRepository
    {
        private readonly PetShopSolutionContext _ctx;
        private readonly EntityTransformer _transformer;

        public PetColorRepository(PetShopSolutionContext ctx)
        {
            _ctx = ctx;
            _transformer = new EntityTransformer();
        }

        List<PetColor> IPetColorRepository.GetColors()
        {
            List<PetColor> listColors = new List<PetColor>();
            foreach (var petColor in _ctx.PetColorTable.ToList())
            {
                listColors.Add(_transformer.FromPetColorEntity(petColor));
            }
            return listColors;
        }
        public PetColor CreateColor(PetColor color)
        {
            return _transformer.FromPetColorEntity(_ctx.PetColorTable.Add(_transformer.ToPetColorEntity(color)).Entity);
        }
        
    }
    
}