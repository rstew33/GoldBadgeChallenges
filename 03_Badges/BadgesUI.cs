using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_BadgesRepository;

namespace _03_Badges
{
    public class BadgesUI
    {
        public BadgesRepo _badgesRepo = new BadgesRepo();

        public void Run()
        {
            _badgesRepo.SeedBadges();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display the options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                // Get user input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly 

                switch (input)
                {
                    case "1":
                        CreateBadge(); // add a badge
                        break;
                    case "2":
                        EditBadge(); // edit a badge
                        break;
                    case "3":
                        ListAll(); // list all badges
                        break;
                    case "4":
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
        public void CreateBadge()
        {
            Badge badge = new Badge();
            badge.DoorNames = new List<string>();

            Console.Clear();
            Console.WriteLine("Please enter a new badge number: \n");
            badge.BadgeID = _badgesRepo.GetID();

            Console.WriteLine("Enter the door name that the user will need access to: \n");
            badge.DoorNames.Add(Console.ReadLine());

            Console.WriteLine("Badge successfully added");

            bool yes = true;

            while (yes == true)
            {
                Console.WriteLine("Would you like to add another door? (y/n) \n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "y":
                        Console.WriteLine("Enter the next door name that the user will need access to: \n");
                        badge.DoorNames.Add(Console.ReadLine());
                        break;
                    case "n":
                        yes = false;
                        break;
                }
            }

            _badgesRepo.AddBadge(badge);

            Console.Clear();
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }
        public void EditBadge()
        {
            Badge badge = new Badge();
            badge.DoorNames = new List<string>();

            Console.Clear();
            Console.WriteLine("Please enter the badge number of the badge you need to edit: \n");
            badge.BadgeID = _badgesRepo.GetID();

            Console.WriteLine("What do you need to edit?" +
                    "1. Add a door\n" +
                    "2. Remove a door\n" +
                    "3. Return to menu\n");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddDoorEdit(badge.BadgeID);
                    break;
                case "2":
                    RemoveDoorEdit(badge.BadgeID);
                    break;
                case "3":
                    Menu();
                    break;
                default:
                    Menu();
                    break;
            }
        }
        public void AddDoorEdit(int badgeID)
        {
            Console.WriteLine("Enter a door to add: ");
            string door = Console.ReadLine();
            _badgesRepo.GiveDoorAccess(badgeID, door);
            Console.WriteLine("Door access added, press any key to continue ");
            Console.ReadKey();
        }

        public void RemoveDoorEdit(int badgeID)
        {
            Console.WriteLine("Enter a door to remove: ");
            string door = Console.ReadLine();
            _badgesRepo.RemoveDoorAccess(badgeID, door);
            Console.WriteLine("Door access removed, press any key to continue ");
            Console.ReadKey();
        }
        public void ListAll()
        {
            Dictionary<int, List<string>> badgeDict = _badgesRepo.GetDictionary();

            foreach (KeyValuePair<int, List<string>> badge in badgeDict)
            {
                Console.WriteLine("\n Badge " + badge.Key);

                foreach (string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
            }
            Console.ReadKey();
        }
    }
}
