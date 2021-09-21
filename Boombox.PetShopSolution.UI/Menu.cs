using System;
using System.Collections.Generic;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.Core.Models;
using Boombox.PetShopSolution.Domain.Services;

namespace Boombox.PetShopSolution.UI
{
    public class Menu
    {
        
        private IPetService _service;
        private int idOfPet = 1;
      
        
        public Menu()
        {
            
            //_service = new PetService();

        }
        public void Start()
        {
            ShowWelcomeGreeting();
            StartLoop();
   
        }
        //Loop runs and executes methods based on user input
        public void StartLoop()
        {
            ShowMainMenu();
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    CreatePet();
                } else if (choice == 2)
                {
                    ReadAll();
                } 
                else if (choice == 3)
                {
                    SearchPets();
                }
                else if (choice == 4)
                {
                    DeletePet();
                }
                else if (choice == 5)
                {
                    EditPet();
                }
                
                else if (choice == 6)
                {
                    SortByPrice();
                }
                
                else if (choice == 7)
                {
                    GetFiveCheapestPets();
                }

                else if (choice == -1 )
                {
                    PleaseTryAgain();
                }
            }
        }
        

        private void CreatePet()
        {
            var petName = "None";
            var petType = "None";
            var petColor = "None";
            Double petPrice = Convert.ToDouble("0.0");
            DateTime birthDate = Convert.ToDateTime("2000,01,01");
            DateTime soldDate = Convert.ToDateTime("2000,01,01");
            Console.WriteLine("");
            Print(StringConstants.CreatePetGreeting);
            Print(StringConstants.PetName);
            
            var name = Console.ReadLine();
            if (name != null && name.GetType() == typeof(string))
            {
                petName = name;
            }
            
            Print(StringConstants.PetType);
            var type = Console.ReadLine();
            if (type != null && type.GetType() == typeof(string))
            {
                petType = type;
            }
            
            Print(StringConstants.PetColor);
            var color = Console.ReadLine();
            if (color != null && color.GetType() == typeof(string))
            {
                petColor = color;
            }
            Print(StringConstants.PetPrice);
            var petPriceInput = Console.ReadLine();

            if (petPriceInput != null && petPriceInput.GetType() == typeof(string))
            {
                Double price = Convert.ToDouble(petPriceInput);
                petPrice = price;
            }
            Print(StringConstants.PetBirthDay);
            var birthDateInput = Console.ReadLine();
            DateTime bDate = Convert.ToDateTime(birthDateInput);
            if (bDate != null && bDate.GetType() == typeof(DateTime))
            {
                birthDate = bDate;
            }
            Print(StringConstants.PetSoldDate);
            var soldDateInput = Console.ReadLine();
            DateTime sDate = Convert.ToDateTime(soldDateInput);
            if (sDate != null && sDate.GetType() == typeof(double))
            {
                soldDate = sDate;
            }
            //Call Service
            Pet pet = new Pet
            {
                Id = idOfPet,
                PetName = petName,
                PetType = petType,
                Color = petColor,
                Price = petPrice,
                BirthDate = birthDate,
                SoldDate = soldDate
            };
            Console.WriteLine($"Name: {pet.PetName} Type: {pet.PetType} Color: {pet.Color} Price: {pet.Price} Birthday: {pet.BirthDate} Date Sold: {pet.SoldDate}");
            _service.CreatePet(pet);
            Print($"Pet With Following Properties Created - Id: {pet.Id} Name: {pet.PetName} Type: {pet.PetType} Color: {pet.Color} Price: {pet.Price} Birthday: {pet.BirthDate} Date Sold: {pet.SoldDate}");
            Console.WriteLine("");
            idOfPet++;
            ShowMainMenu();
        }
        
        

        private void DeletePet()
        {
            Print("Write the ID of the pet you want to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            _service.DeletePet(id);
            Print("Pet Deleted");
            ShowMainMenu();
        }
        
        
        private void ReadAll()
        {
          
                Print("Here are all available Pets");
                var pets = _service.ReadAll();
                foreach (var pet in pets)
                {
                    Print($"Id: {pet.Id},Name: {pet.PetName},Type: {pet.PetType},Price: {pet.Price},Color: {pet.Color}, Birthday: {pet.BirthDate}, Date Sold: {pet.SoldDate}");
                }
            
        }

        private void SearchPets()
        {
            Print("What type of animal are you looking for? For example, you can try typing 'Cat'");
            var typeToSearchFor = Console.ReadLine();
           List<Pet> searchResult = _service.SearchByType(typeToSearchFor);
            foreach (var Pet in searchResult)
            {
                Print($"Id: {Pet.Id},Name: {Pet.PetName},Type: {Pet.PetType},Price: {Pet.Price}");
            }

        }

        private void PleaseTryAgain()
        {
            Print("Something went wrong, probably a wrong input, try again");
        }
        
        

        //Returns the input of the user, returns -1 if it fails
        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }
        
        //Prints the welcome greeting
        private void ShowWelcomeGreeting()
        {
            Console.WriteLine(StringConstants.WelcomeGreeting);
        }
        
        //Method that prints its parameters
        private void Print(string value)
        {
            Console.WriteLine(value);
        }

        private void EditPet()
        {
            Print("Type the ID of the pet you wish to edit");
            Console.WriteLine("");

            var id = Convert.ToInt32(Console.ReadLine());
            
            
            Print(StringConstants.EditPetGreeting);
            Print(StringConstants.PetName);
            var petName = Console.ReadLine();
            Print(StringConstants.PetType);
            var petType = Console.ReadLine();
            Print(StringConstants.PetColor);
            var petColor = Console.ReadLine();
            Print(StringConstants.PetPrice);
            var petPriceInput = Console.ReadLine();
            Double petPrice = Convert.ToDouble(petPriceInput);
            Print(StringConstants.PetBirthDay);
            var birthDateInput = Console.ReadLine();
            DateTime birthDate = Convert.ToDateTime(birthDateInput);
            Print(StringConstants.PetSoldDate);
            var soldDateInput = Console.ReadLine();
            DateTime soldDate = Convert.ToDateTime(soldDateInput);
            //Call Service
            Pet pet = new Pet
            {
                PetName = petName,
                PetType = petType,
                Color = petColor,
                Price = petPrice,
                BirthDate = birthDate,
                SoldDate = soldDate
            };
            Pet editedPet = _service.EditPet(id, pet);
            Print($"Pet With Following Properties Created - Id: {editedPet.Id} Name: {editedPet.PetName} Type: {editedPet.PetType} Color: {editedPet.Color} Price: {editedPet.Price} Birthday: {editedPet.BirthDate} Date Sold: {editedPet.SoldDate}");

        }
        private void ShowMainMenu()
        {
            Console.WriteLine("");
            Print(StringConstants.PleaseSelectMain);
            Print(StringConstants.CreatePetMenuText);
            Print(StringConstants.ShowAllPetMenuText);
            Print(StringConstants.SearchPetMenuText);
            Print(StringConstants.DeletePetMenuText);
            Print(StringConstants.EditPetMenuText);
            Print(StringConstants.SortByPriceMenuText);
            Print(StringConstants.SalesPetMenuText);
            Print(StringConstants.ExitMainMenuText);
        }

        private void SortByPrice()
        {
            Print("Do you want to sort by Price Ascending or Descending?");
            Print("Choose 1 for Ascending");
            Print("Choose 2 for Descending");
            int upOrDown = Convert.ToInt32(Console.ReadLine());
            List<Pet> sortedList = _service.SortByPrice(upOrDown);
            foreach (var Pet in sortedList)
            {
                Print($"Id: {Pet.Id},Name: {Pet.PetName},Type: {Pet.PetType},Price: {Pet.Price}");
            }
        }

        private void GetFiveCheapestPets()
        {
            List<Pet> cheapestPets = _service.GetFiveCheapestPets();
            
            Print("Here are our 5 cheapest Pets!");
            foreach (var Pet in cheapestPets)
            {
                Print($"Id: {Pet.Id},Name: {Pet.PetName},Type: {Pet.PetType},Price: {Pet.Price}");
            }
        }
    }
}