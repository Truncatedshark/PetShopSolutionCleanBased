using System;
using Boombox.PetShopSolution.Core.Models;

namespace Boombox.PetShopSolution.EFSQL.Entities
{
  public class EntityTransformer
  {
    public Pet FromPetEntity(PetEntity petEntity)
    {
      Pet pet = new Pet()
      {
        Id = petEntity.Id,
        BirthDate = petEntity.BirthDate,
        PetName = petEntity.PetName,
        Color = new PetColor(){Name = petEntity.Color.Name, Id = petEntity.Color.Id},
        PetTypeB = new PetType(){Id = petEntity.PetTypeB.Id, Name = petEntity.PetTypeB.Name},
        Price = petEntity.Price,
        SoldDate = petEntity.SoldDate
      };
      return pet;
    }
    
    public PetEntity ToPetEntity(Pet pet)
    {
      PetEntity petEntity = new PetEntity()
      {
        BirthDate = pet.BirthDate,
        PetName = pet.PetName,
        Price = pet.Price,
        SoldDate = DateTime.Now,
        
        ColorId = pet.Color.Id,
        PetTypeBId = pet.PetTypeB.Id,
        PetOwnerId = pet.PetOwner.Id
        
      };
      return petEntity;
    }

    public PetOwner FromPetOwnerEntity(PetOwnerEntity petOwnerEntity)
    {
      PetOwner petOwner = new PetOwner()
      {
        Id = petOwnerEntity.Id,
        Name = petOwnerEntity.Name
      };
      return petOwner;
    }

    public PetOwnerEntity ToPetOwnerEntity(PetOwner petOwner)
    {
      PetOwnerEntity petOwnerEntity = new PetOwnerEntity()
      {
        Id = petOwner.Id,
        Name = petOwner.Name
      };
      return petOwnerEntity;
    }

    public PetColor FromPetColorEntity(PetColorEntity petColorEntity)
    {
      PetColor petColor = new PetColor()
      {
        Id = petColorEntity.Id,
        Name = petColorEntity.Name
      };
      return petColor;
    }

    public PetColorEntity ToPetColorEntity(PetColor petColor)
    {
      PetColorEntity petColorEntity = new PetColorEntity()
      {
        Id = petColor.Id,
        Name = petColor.Name
      };
      return petColorEntity;
    }

    public PetType FromPetTypeEntity(PetTypeEntity petTypeEntity)
    {
      PetType petType = new PetType()
      {
        Id = petTypeEntity.Id,
        Name = petTypeEntity.Name
      };
      return petType;
    }

    public PetTypeEntity ToPetTypeEntity(PetType petType)
    {
      PetTypeEntity petTypeEntity = new PetTypeEntity()
      {
        Id = petType.Id,
        Name = petType.Name
      };
      return petTypeEntity;
    }

    public Pet FromPetEntityLite(PetEntity entity)
    {
      Pet pet = new Pet()
      {
        Id = entity.Id,
        PetName = entity.PetName,
        Color = new PetColor() {Id = entity.ColorId},
        Price = entity.Price,
      };
      return pet;
    }
  }
}