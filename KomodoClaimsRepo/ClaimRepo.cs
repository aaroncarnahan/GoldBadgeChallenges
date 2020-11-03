using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepo
{
    public class ClaimRepo
    {
        //field
        private List<Claim> claimDirectory = new List<Claim>();

        // Add a claim
        public bool AddClaimToDirectory(Claim claim) 
        {
            int startingCount = claimDirectory.Count;

            claimDirectory.Add(claim);

            bool wasAdded = (claimDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        // Get entire directory
        public List<Claim> GetClaims() 
        {
            return claimDirectory;
        }

		//Get next claim
		public Claim GetNextClaim(int x)
		{
			int count = claimDirectory.Count;
			if (x < count)
			{
				return claimDirectory[x];
			}
			else
			{
				Console.WriteLine("Out of bounds!!");
				return null;
			}
		}
		
        // Delete a claim
        public bool DeleteExistingClaim(Claim existingClaim) 
        {
            bool deleteResult = claimDirectory.Remove(existingClaim);
            return deleteResult;
        }

        // Get claim by ID (NOT REQUIRED IN PROMPT)
        public Claim GetClaimById(int id)
        {
            foreach (Claim claim in claimDirectory)
            {
                if (claim.ClaimID == id)
                {
                    return claim;
                }
            }
            return null;
        }

        //Update claim (NOT REQUIRED IN PROMPT)
        public bool UpdateExistingClaim(int originalId, Claim newClaim)
        {
            Claim oldClaim = GetClaimById(originalId);

            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.ClaimType = newClaim.ClaimType;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
