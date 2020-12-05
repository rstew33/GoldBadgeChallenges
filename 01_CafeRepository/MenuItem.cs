using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class MenuItem
    {
        //menu POCO - number, name, desc, list, price - properties, constructors, and fields
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public List<string> _listOfIngredients = new List<string>();
        public double ItemPrice { get; set; }

        public MenuItem() { }

        public MenuItem(int itemNumber, string itemName, string itemDescription, List<string> itemIngredients, double itemPrice)
        {
            ItemNumber = itemNumber;
            ItemName = itemName;
            ItemDescription = itemDescription;
            _listOfIngredients = itemIngredients;
            ItemPrice = itemPrice;

        }

    }
}
