using System.Collections.Generic;
using System.Drawing;
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
        public PetColor CreateColor(string name)
        {
            var newPetColor = new PetColorEntity() {Name = name};
            _ctx.Add(newPetColor);
            _ctx.SaveChanges();
            var createdColor = _ctx.PetColorTable
                .Where(col => col.Name.Equals(name))
                .Select(col => new PetColor
                {
                    Id = col.Id,
                    Name = col.Name
                })
                .FirstOrDefault();
            return createdColor;
        }

        public PetColor RemoveColor(int id)
        {
            var removedColor = _ctx.PetColorTable
                .Where(col => col.Id == id)
                .Select(col => new PetColor()
                {
                    Id = col.Id,
                    Name = col.Name
                }).FirstOrDefault();
            _ctx.PetColorTable.Remove(new PetColorEntity() {Id = id});
            _ctx.SaveChanges();
            return removedColor;
        }
    }
    
}