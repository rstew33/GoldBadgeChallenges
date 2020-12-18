using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _02_ClaimsRepository;
using System.Collections.Generic;

namespace _02_ClaimsTest
{
    [TestClass]
    public class ClaimsTest 
    {
        [TestMethod]
        public void AddClaimToListShouldBeNonNull() //AddClaimToQueue
        {
            ClaimsRepo _claimsRepo = new ClaimsRepo();
            Queue<ClaimClass> _queueOfClaimClass = new Queue<ClaimClass>();
            ClaimClass claimClass = new ClaimClass(1, ClaimType.Car, "Car accident on 464", 400.00, DateTime.Parse("4/25/18"), DateTime.Parse("4/27/2020"), false);
            _claimsRepo.AddClaimToList(claimClass);
            int numberOfClaims = _queueOfClaimClass.Count;

            Assert.IsNotNull(numberOfClaims); //assert
        }
        public void GetClaimsQueueShouldBeNotNull() //GetClaims
        {
            ClaimsRepo _claimsRepo = new ClaimsRepo();
            Queue<ClaimClass> _queueOfClaimClass = _claimsRepo.GetClaimClassQueue();
            Assert.IsNotNull(_queueOfClaimClass);
        }
    }
}
