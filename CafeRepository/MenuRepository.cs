using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class MenuRepository
    {
        //methods CRUD

        public List<MenuItem> _listOfMenuItems = new List<MenuItem>();

        //create

        public void AddMenuItemToList(int itemNumber, string itemName, string itemDescription, List<string> itemIngredients, double itemPrice)
        {
            MenuItem menuItem = new MenuItem(itemNumber, itemName, itemDescription, itemIngredients, itemPrice);
            _listOfMenuItems.Add(menuItem);
        }

        public void AddMenuItem (MenuItem menuItem)
        {
            _listOfMenuItems.Add(menuItem);
        }
        //read
        public List<MenuItem> GetMenuItems()
        {
            return _listOfMenuItems;
        }
        //update
        public bool UpdateExistingItem(int menuID, MenuItem newMenuItem)
        {
            //find the menu item
            MenuItem oldMenuItem = GetMenuByID(menuID);

            //update the item
            if( oldMenuItem != null)
            {
                oldMenuItem.ItemNumber = newMenuItem.ItemNumber;
                oldMenuItem.ItemName = newMenuItem.ItemName;
                oldMenuItem.ItemDescription = newMenuItem.ItemDescription;
                oldMenuItem._listOfIngredients = newMenuItem._listOfIngredients;
                oldMenuItem.ItemPrice = newMenuItem.ItemPrice;
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete
        public bool RemoveMenuItems(int menuID)
        {
            MenuItem menuName = GetMenuByID(menuID);
            if ( menuName == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menuName);

            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
                return false;
        }

        //helper method

        public MenuItem GetMenuByID(int menuID)
        {
            foreach(MenuItem menuItem in _listOfMenuItems)
                {
                    if(menuItem.ItemNumber == menuID)
                {
                    return menuItem;
                }
                }
            return null;
        }

        public int GetID()
        {
            string input = Console.ReadLine();
            int inputAsInt = int.Parse(input);
            return inputAsInt;
        }

        public void SeedMenuItems()
        {
            MenuItem burger = new MenuItem(1, "Burger", "A burger", new List<string> { "onions", "pickles" }, 4.56);

            AddMenuItem(burger);
        }

    }
}
