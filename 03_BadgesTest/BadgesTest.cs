using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03_BadgesRepository;
using System.Collections.Generic;

namespace _03_BadgesTest
{
    [TestClass]
    public class BadgesTest
    {
        public BadgesRepo _repo;
        public Badge badge;

        [TestInitialize]
        public void Initialize()
        {
            List<string> listofDoor = new List<string>();
            listofDoor.Add("Door 01");
            _repo = new BadgesRepo();
            badge = new Badge(01, listofDoor);
        }

        [TestMethod]
        public void AddBadgeShouldNotBeVoid()
        {
            _repo.AddBadge(badge);
            Dictionary<int, List<String>> badgeFromMethod = _repo.GetDictionary();
            Assert.IsNotNull(badgeFromMethod);
        }
        [TestMethod]
        public void GiveDoorAccessShouldNotBeVoid()
        {
            _repo.AddBadge(badge);
            _repo.GiveDoorAccess(01, "Door 02");
            int count = badge.DoorNames.Count;
            Assert.AreEqual(count, 2);
        }
        [TestMethod]
        public void RemoveDoorAccessShouldNotBeVoid()
        {
            _repo.AddBadge(badge);
            _repo.RemoveDoorAccess(01, "Door 01");
            int count = badge.DoorNames.Count;
            Assert.AreEqual(count, 0);

        }
    }
}
