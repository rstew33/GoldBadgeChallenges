using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesRepository
{
    public class BadgesRepo //create a dictionary of badges, key is badgeID, value is badge
    {
        public Dictionary<int, List<String>> _discOfBadges = new Dictionary<int, List<String>>(); //new dictionary

        public Dictionary<int, List<String>> GetDictionary() //Get Dictionary
        {
            return _discOfBadges;
        }

        public void AddBadge(Badge badge)
        {
            _discOfBadges.Add(badge.BadgeID, badge.DoorNames);
        }

        public void GiveDoorAccess(int badgeID, string doorAccess)
        {
            List<string> doorList = _discOfBadges[badgeID];
            doorList.Add(doorAccess);
        }
        public void RemoveDoorAccess(int badgeID, string doorAccess)
        {
            List<string> doorList = _discOfBadges[badgeID];
            doorList.Remove(doorAccess);
        }
        public void SeedBadges()
        {
            Badge badgeOne = new Badge(01, new List<string> { "Door_1" });
            Badge badgeTwo = new Badge(02, new List<string> { "Door_2" });
            AddBadge(badgeOne);
            AddBadge(badgeTwo);
        }
        public int GetID() //Get ID
        {
            string input = Console.ReadLine();
            int inputAsInt = int.Parse(input);
            return inputAsInt;
        }
    }


}
