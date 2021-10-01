using System;
using System.Collections.Generic;
using System.Linq;
using Boombox.PetShopSolution.Core.Filtering;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.IRepositories;

namespace Boombox.PetShopSolution.Domain.Services
{
    public class PetService : IPetService
    {
        
        private readonly IPetRepository _repo;

        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }
        public Pet CreatePet(Pet pet)
        {
            return _repo.CreatePet(pet);
        }
        public Pet ReadSinglePet(int id)
        {
            throw new System.NotImplementedException();
            /* return _petServicePets.Find(pet => pet.Id == id); */
        }
        public List<Pet> ReadAll(Filter filter)
        {
            if (filter.Count <= 0 || filter.Count > 500)
            {
                throw new ArgumentException("You need to punt in a filter count");
            }

            var totalCount = _repo.Count();
            if (filter.Page < 1 || filter.Count * (filter.Page - 1) > totalCount)
            {
                throw new ArgumentException($"You need to put in a filter page between 1 and max page size, max page size allowed now: {(totalCount / filter.Count) + 1}");
            }
            return _repo.GetPets(filter);
        }

        public Pet GetPetById(int id)
        {
          return _repo.GetPetbyId(id);
        }

        public List<Pet> SearchByName()
        {
           throw new System.NotImplementedException();
        }

        public List<Pet> SearchByType(string typeToSearchFor)
        {


          /*  var searchResultsEnumerable = _petServicePets.Where(pet => pet.PetType == typeToSearchFor);
            List<Pet> searchResults = searchResultsEnumerable.ToList();
            return searchResults; */
          throw new System.NotImplementedException();

        }

        public Pet EditPet(int id, Pet editedPet)
        {
          /*  var originalPet = ReadSinglePet(id);
            originalPet.PetName = editedPet.PetName;
            
            originalPet.PetType = editedPet.PetType;
            
            originalPet.BirthDate = editedPet.BirthDate;
            
            originalPet.SoldDate = editedPet.SoldDate;
            
            originalPet.Color = editedPet.Color;
            
            originalPet.Price = editedPet.Price;
            
            int index = _petServicePets.FindIndex(item => item.Id == id);

            _petServicePets[index] = originalPet;

            return originalPet; */
          throw new System.NotImplementedException();
        }
        

        public void DeletePet(int id)
        {
          //  _petServicePets.RemoveAll(Pet => Pet.Id == id);
          throw new System.NotImplementedException();
        }

        public List<Pet> SortByPrice(int upOrDown)
        {
           /* List<Pet> sortedList = new List<Pet>();
            if (upOrDown == 1)
            {
                sortedList = _petServicePets.OrderBy(p => p.Price).ToList();
                
            }
            else if (upOrDown == 2)
            {
                sortedList = _petServicePets.OrderByDescending(p => p.Price).ToList();
            }
            return sortedList; */
           throw new System.NotImplementedException();
        }

        public List<Pet> GetFiveCheapestPets()
        {
            
          /*  List<Pet> cheapestPets = ReadAll();
            cheapestPets = cheapestPets.OrderBy(p => p.Price).ToList();
            cheapestPets = cheapestPets.GetRange(0, 5);
            return cheapestPets; */
          throw new System.NotImplementedException();
        }
    }
}