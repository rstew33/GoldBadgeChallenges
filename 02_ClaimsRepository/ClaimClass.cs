using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public enum ClaimType //enum for claim type
    {
        Car = 1,
        Home = 2,
        Theft = 3

    }
    public class ClaimClass //POCO
    {
        public int ClaimID { get; set; }
        public ClaimType TypeofClaim { get; set; }

        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimClass() { }
        public ClaimClass(int claimID, ClaimType typeOfClaim, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeofClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            
        }




    }
}
