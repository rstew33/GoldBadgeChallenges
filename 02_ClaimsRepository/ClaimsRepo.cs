using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public class ClaimsRepo
    {
        public Queue<ClaimClass> _queueOfClaimClass = new Queue<ClaimClass>();

        // Create
        public void AddClaimToList(ClaimClass claimClass)
        {
            _queueOfClaimClass.Enqueue(claimClass);
        }

        //Read
        public Queue<ClaimClass> GetClaimClassQueue()
        {
            return _queueOfClaimClass;
        }

        //Update
        public bool UpdateExistingClaim(int claimID, ClaimClass newClaimClass)
        {
            //find the menu item
            ClaimClass oldClaimClass = GetClaimClassByID(claimID);

            //update the item
            if (oldClaimClass != null)
            {
                oldClaimClass.ClaimID = newClaimClass.ClaimID;
                oldClaimClass.TypeofClaim = newClaimClass.TypeofClaim;
                oldClaimClass.Description = newClaimClass.Description;
                oldClaimClass.ClaimAmount = newClaimClass.ClaimAmount;
                oldClaimClass.DateOfIncident = newClaimClass.DateOfIncident;
                oldClaimClass.DateOfClaim = newClaimClass.DateOfClaim;
                oldClaimClass.IsValid = newClaimClass.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }

       //No delete needed

        //Helper Method
        public ClaimClass GetClaimClassByID(int claimID)
        {
            foreach (ClaimClass claimClass in _queueOfClaimClass)
            {
                if (claimClass.ClaimID == claimID)
                {
                    return claimClass;
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

        public void SeedClaims()
        {
            ClaimClass claim = new ClaimClass(1, ClaimType.Car, "Car accident on 464", 400.00, DateTime.Parse("4/25/18"), DateTime.Parse("4/27/2020"), false);
            ClaimClass claim2 = new ClaimClass(2, ClaimType.Car, "Car accident", 300.00, DateTime.Parse("4/22/18"), DateTime.Parse("4/29/2020"), false);

            AddClaimToList(claim);
            AddClaimToList(claim2);
        }
    }
}
