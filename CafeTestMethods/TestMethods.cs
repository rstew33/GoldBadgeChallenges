using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeRepository;
using System.Collections.Generic;

namespace CafeTestMethods
{
    [TestClass]
    public class TestMethods //AddMenuItemToList, GetMenuItems, UpdateExistingItem, RemoveMenuItems
    {
        private MenuRepository _menuRepo;
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepository();
            _menuItem = new MenuItem(1, "salad", "a salad", new List<string> { "lettuce", "onions" }, 4.99);

            _menuRepo.AddMenuItem(_menuItem);
        }
        [TestMethod]
        public void AddMenuItemToList_ShouldAddItem()
        {
            List<MenuItem> _listOfMenuItems = new List<MenuItem>(); //arrange

            _menuRepo.AddMenuItem(_menuItem); //act

            int numberofItems = _listOfMenuItems.Count;

            Assert.IsNotNull(numberofItems); //assert
        }
        [TestMethod]
        public void GetMenuItems_ShouldReturnItems()
        {

            _menuRepo.AddMenuItem(_menuItem);
            List<MenuItem> _listOfMenuItems = _menuRepo.GetMenuItems();

            Assert.IsNotNull(_listOfMenuItems);
        }
        [TestMethod]
        public void UpdateExistingItem_ShouldReturnTrue()
        {
            MenuItem newMenuItem = new MenuItem(1, "salad", "a salad", new List<string> { "lettuce", "onions" }, 6.00);
            bool updatedResult = _menuRepo.UpdateExistingItem(1, newMenuItem);

            Assert.IsTrue(updatedResult);
        }
        [TestMethod]
        public void RemoveMenuItems_ShouldReturnTrue()
        {
            bool deletedResult = _menuRepo.RemoveMenuItems(1);

            Assert.IsTrue(deletedResult);
        }
    }
}