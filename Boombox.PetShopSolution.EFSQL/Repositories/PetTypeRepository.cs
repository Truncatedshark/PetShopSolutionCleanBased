using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;
using Boombox.PetShopSolution.EFSQL.Entities;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly PetShopSolutionContext _ctx;
        private readonly EntityTransformer _transformer;

        public PetTypeRepository(PetShopSolutionContext ctx)
        {
            _ctx = ctx;
            _transformer = new EntityTransformer();
        }

        public List<PetType> GetPets()
        {
            List<PetType> listPetType = new List<PetType>();
            foreach (var petType in _ctx.PetTypeTable.ToList())
            {
                listPetType.Add(_transformer.FromPetTypeEntity(petType));
            }
            return listPetType;
        }

        public List<PetType> GetTypes()
        {
            List<PetType> listTypes = new List<PetType>();
            foreach (var PetTypeEntity in _ctx.PetTypeTable)
            {
                listTypes.Add(_transformer.FromPetTypeEntity(PetTypeEntity));
            }

            return listTypes;        }

        public PetType CreateType(string type)
        {
            var petTypeEntity = _transformer.FromPetTypeEntity(_ctx.PetTypeTable.Add(new PetTypeEntity(){Name = type}).Entity);
            _ctx.SaveChanges();
            var createdPetType = _ctx.PetTypeTable
                .Where(pT => pT.Name == petTypeEntity.Name)
                .Select(pT => new PetType() {Name = pT.Name, Id = pT.Id})
                .FirstOrDefault();
            return createdPetType;
        }

        public PetType RemovePetType(int id)
        {
            var removedPetType = _ctx.PetTypeTable
                .Where(pt => pt.Id == id)
                .Select(pt => new PetType()
                {
                    Id = pt.Id,
                    Name = pt.Name
                }).FirstOrDefault();
            _ctx.PetTypeTable.Remove(new PetTypeEntity() {Id = id});
            _ctx.SaveChanges();
            return removedPetType;
        }
    }
}