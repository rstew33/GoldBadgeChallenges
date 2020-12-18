using _02_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    class ClaimsUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo(); //new up repository

        //console app UI to see all claims, take care of next claim, or enter a new claim

        public void Run()
        {
            _claimsRepo.SeedClaims();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display the options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                // Get user input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly 

                switch (input)
                {
                    case "1":
                        DisplayAllClaims(); //see all claims
                        break;
                    case "2":
                        TakeCareofNextClaim(); //take care of next claim
                        break;
                    case "3":
                        AddClaim(); //enter a new claim
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
        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<ClaimClass> _queueOfClaimClass = _claimsRepo.GetClaimClassQueue();
            Console.WriteLine("ID" + "\t\tType of Claim"  + "\t\tAmount" + "\t\tDate of Incident" + "\t\tDate of Claim" + "\t\tValid" + "\t\tDescription");
            foreach (ClaimClass claim in _queueOfClaimClass)
            {
                Console.WriteLine($"{claim.ClaimID} \t\t{claim.TypeofClaim}  \t\t\t{claim.ClaimAmount} \t\t{claim.DateOfIncident.ToShortDateString()}" +
                    $"\t\t\t{claim.DateOfClaim.ToShortDateString()} \t\t{claim.IsValid} \t\t{claim.Description}");
                
            }
        }
        private void TakeCareofNextClaim()
        {
            Console.Clear();
            Queue<ClaimClass> _queueOfClaimClass = _claimsRepo.GetClaimClassQueue();
            Console.WriteLine("This is the next claim to handle: \n");
            ClaimClass nextClaim = _queueOfClaimClass.Peek();

            Console.WriteLine($"ID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.TypeofClaim}\n" +
                $"Amount ${nextClaim.ClaimAmount}\n" +
                $"Date of Incident: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"Is Valid: {nextClaim.IsValid}\n" +
                $"Description: {nextClaim.Description}\n" +
                "Would you like to take this claim? y/n\n");


            string input = Console.ReadLine();
            switch (input)
            {
                case "y":
                    _queueOfClaimClass.Dequeue();
                    Console.WriteLine("The claim is now assigned to you \n");
                    break;
                case "n":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please select y or n");
                    break;
            }
            Console.ReadLine();
        }
        private void AddClaim()
        {
            Console.Clear();
            ClaimClass newClaim = new ClaimClass();

            Console.WriteLine("Please enter the ID for the new claim: \n");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the number for the type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    newClaim.TypeofClaim = ClaimType.Car;
                        break;
                case "2":
                    newClaim.TypeofClaim = ClaimType.Home;
                    break;
                case "3":
                    newClaim.TypeofClaim = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please enter 1, 2, or 3");
                    break;
            }
            Console.WriteLine("Please enter the amount of the claim: \n");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the incident (mm/dd/yy):  \n");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date the claim was filed (mm/dd/yy):  \n");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            bool isValid;
            string validText;
            TimeSpan diff = newClaim.DateOfClaim - newClaim.DateOfIncident;
            if (diff.Days <= 30)
            {
                isValid = true;
                validText = "Valid";
            }
            else
            {
                isValid = false;
                validText = "not valid";
            }
            Console.WriteLine($"Your claim is {validText} \n");
            newClaim.IsValid = isValid;

            Console.WriteLine("Enter a description for the claim: \n");
            newClaim.Description = Console.ReadLine();

            _claimsRepo.AddClaimToList(newClaim);

            Console.WriteLine("Claim added! Press any key to continue");
            Console.ReadLine();
            Console.Clear();



        }
    }
}
