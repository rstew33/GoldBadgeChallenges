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
        public Dictionary<int, List<String>> _discOfBadges;

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
            Dictionary<int, List<String>> _discOfBadges = new Dictionary<int, List<String>>();
            List<string> listofDoor = new List<string>();
            listofDoor.Add("Door 01");
            Badge badge2 = new Badge(01, listofDoor);
            _repo.AddBadge(badge2);
            int countOfBadges = _discOfBadges.Count;
            Assert.IsNotNull(countOfBadges);

        }
        [TestMethod]
        public void GiveDoorAccessShouldNotBeVoid()
        {
            List<string> listofDoor = new List<string>();
            listofDoor.Add("Door 01");
            Badge badge2 = new Badge(01, listofDoor);
            _repo.AddBadge(badge2);
            _repo.GiveDoorAccess(01, "Door 02");
            int count = listofDoor.Count;
            Assert.AreEqual(count, 2);
        }
        [TestMethod]
        public void RemoveDoorAccessShouldNotBeVoid()
        {
            List<string> listofDoor = new List<string>();
            listofDoor.Add("Door 01");
            Badge badge2 = new Badge(01, listofDoor);
            _repo.AddBadge(badge2);
            _repo.RemoveDoorAccess(01, "Door 01");
            int count = listofDoor.Count;
            Assert.AreEqual(count, 0);

        }
    }
}
