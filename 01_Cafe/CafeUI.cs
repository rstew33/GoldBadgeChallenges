using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeRepository;

namespace _01_Cafe
{
    class CafeUI
    {
        private MenuRepository _menuRepo = new MenuRepository(); //new up repository

        //console app UI to display options to add, delete, or see all items

        public void Run()
        {
            _menuRepo.SeedMenuItems();
            Menu();
        }

        //Menu

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display the options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a new menu item\n" +
                    "2. See all menu items\n" +
                    "3. Update menu item\n" +
                    "4. Delete a menu item\n" +
                    "5. Exit");

                // Get user input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly 

                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        UpdateMenuItem();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        //Create new menu item
        private void CreateNewMenuItem()
        {
            Console.Clear();
            //number

            Console.WriteLine("Enter the number for the menu item (xx): ");
            int newMenuID = _menuRepo.GetID();

            //name
            Console.WriteLine("Enter the name of the menu item");
            string newMenuName = Console.ReadLine();

            // desc
            Console.WriteLine("Enter the description of the menu item");
            string newMenuDesc = Console.ReadLine();

            //ingredients
            List<string> newMenuIngredients = new List<string>();
            Console.WriteLine("Enter the first ingredient for the item. Enter no value to continue: ");
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                newMenuIngredients.Add(input);
                Console.WriteLine("Please add another ingredient");
                input = Console.ReadLine();
            }
            // newMenuIngredients.Add(Console.ReadLine());

            //price
            Console.WriteLine("Enter the price of the item (x.xx)");
            string priceAsString = Console.ReadLine();
            double newMenuPrice = double.Parse(priceAsString);

            _menuRepo.AddMenuItemToList(newMenuID, newMenuName, newMenuDesc, newMenuIngredients, newMenuPrice);
        }
        //View menu items
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> listofMenuItems = _menuRepo.GetMenuItems();

            foreach (MenuItem menuItem in listofMenuItems)
            {
                Console.WriteLine("\nNumber: " + menuItem.ItemNumber); //number
                Console.WriteLine("\nItem Item: " + menuItem.ItemName); //item
                Console.WriteLine("\nItem Desc: " + menuItem.ItemDescription); //desc
                foreach (string ingredient in menuItem.ListIngredients) //ingredients
                {
                    Console.WriteLine("\nItem ingredients: " + ingredient);
                }
                Console.WriteLine("\nItem price: " + menuItem.ItemPrice); //price
            }
        }

        //update menu item

        private void UpdateMenuItem()
        {
            Console.Clear();
            List<MenuItem> listOfMenuItems = _menuRepo.GetMenuItems();

            foreach (MenuItem menuItem in listOfMenuItems)
            {
                Console.WriteLine("\nNumber: " + menuItem.ItemNumber); //number
                Console.WriteLine("\nItem Item: " + menuItem.ItemName); //item
                Console.WriteLine("\nItem Desc: " + menuItem.ItemDescription); //desc
                foreach (string ingredient in menuItem.ListIngredients) //ingredients
                {
                    Console.WriteLine("\nItem ingredients: " + ingredient);
                }
                Console.WriteLine("\nItem price: " + menuItem.ItemPrice); //price
            }

            Console.WriteLine("\nEnter the menu ID of the item you want to update: ");
            int menuID = _menuRepo.GetID();

            MenuItem newMenuItem = new MenuItem();

            //Number
            Console.WriteLine("Enter new item number: ");
            int newMenuItemID = _menuRepo.GetID();
            newMenuItem.ItemNumber = newMenuItemID;

            //name
            Console.WriteLine("Enter the item's new name: ");
            string newMenuItemName = Console.ReadLine();
            newMenuItem.ItemName = newMenuItemName;

            //desc
            Console.WriteLine("Enter the item's new description: ");
            string newmenuItemDesc = Console.ReadLine();
            newMenuItem.ItemDescription = newmenuItemDesc;

            //ingredients
            Console.WriteLine("Enter the item's new ingredients: ");
            List<string> newMenuIngredients = new List<string>();
            newMenuIngredients.Add(Console.ReadLine());
            newMenuItem.ListIngredients = newMenuIngredients;

            //price
            Console.WriteLine("Enter the item's new price:  ");
            string priceAsString = Console.ReadLine();
            double newMenuPrice = double.Parse(priceAsString);
            newMenuItem.ItemPrice = newMenuPrice;

            bool wasUpdated = _menuRepo.UpdateExistingItem(menuID, newMenuItem);
            if (wasUpdated == true)
            {
                Console.WriteLine("Item Updated");
            }
            else
            {
                Console.WriteLine("Item was not updated");
            }

        }
        // delete menu items

        private void DeleteMenuItem()
        {
            Console.Clear();

            //get the team

            List<MenuItem> listOfMenuItem = _menuRepo.GetMenuItems();

            foreach (MenuItem menuItem in listOfMenuItem)
            {
                Console.WriteLine("Menu Item Name: " + menuItem.ItemName);
                Console.WriteLine("Menu Item Number: " + menuItem.ItemNumber);
            }
            Console.WriteLine("Enter the item number of the menu item you want to delete: ");
            int menuItemID = _menuRepo.GetID();

            //call the delete method
            bool wasDeleted = _menuRepo.RemoveMenuItems(menuItemID);

            //if it was deleted - say so
            if (wasDeleted == true)
            {
                Console.WriteLine("The item was deleted");
            }
            else
            {
                Console.WriteLine("The item was not deleted");
            }

        }
    }
}
