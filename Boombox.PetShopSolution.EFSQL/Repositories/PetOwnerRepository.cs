using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;
using Boombox.PetShopSolution.EFSQL.Entities;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public class PetOwnerRepository : IPetOwnerRepository
    {
        private readonly PetShopSolutionContext _ctx;
        private readonly EntityTransformer _transform;

        public PetOwnerRepository(PetShopSolutionContext ctx)
        {
            _ctx = ctx;
            _transform = new EntityTransformer();
        }

        public List<PetOwner> GetPets()
        {
            List<PetOwner> listOwners = new List<PetOwner>();
            foreach (var petOwner in _ctx.PetOwnerTable.ToList())
            {
                listOwners.Add(_transform.FromPetOwnerEntity(petOwner));
            }
            return listOwners;
        }

        public List<PetOwner> GetOwners()
        {
            List<PetOwner> listOwners = new List<PetOwner>();
            foreach (var PetOwnerEntity in _ctx.PetOwnerTable)
            {
                listOwners.Add(_transform.FromPetOwnerEntity(PetOwnerEntity));
            }

            return listOwners;
        }

        public PetOwner CreateOwner(string name)
        {
            var petOEnt = _ctx.PetOwnerTable.Add(new PetOwnerEntity(){Name = name}).Entity;
            var createdOwner = _ctx.PetOwnerTable
                .Where(o => o.Name.Equals(name))
                .Select(o => new PetOwner()
                {
                    Name = o.Name,
                    Id = o.Id
                }).FirstOrDefault();
            return createdOwner;
        }

        public PetOwner RemoveOwner(int id)
        {
            var petOwnerDel = _ctx.PetOwnerTable
                .Where(o => o.Id == id)
                .Select(o => new PetOwner()
                {
                    Name = o.Name,
                    Id = o.Id
                }).FirstOrDefault();
            _ctx.PetOwnerTable.Remove(new PetOwnerEntity() {Id = id});
            _ctx.SaveChanges();
            return petOwnerDel;
        }
    }
}