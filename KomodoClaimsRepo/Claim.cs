using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepo
{
	public class Claim
	{
		public int ClaimID { get; set; }
		public string ClaimType { get; set; }
		public string Description { get; set; }
		public decimal ClaimAmount { get; set; }
		public DateTime DateOfIncident { get; set; }
		public DateTime DateOfClaim { get; set; }
		public bool IsValid
		{
			get
			{
				if ((DateOfClaim - DateOfIncident).TotalDays <= 30)
				{
					return true;
				}
				else if ((DateOfClaim - DateOfIncident).TotalDays > 30)
				{
					return false;
				}
				else
				{
					return false;
				}
			}
		}

		//constructor
		public Claim() { }

		public Claim(int claimId, string claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim) 
		{
			ClaimID = claimId;
			ClaimType = claimType;
			Description = description;
			ClaimAmount = claimAmount;
			DateOfIncident = dateOfIncident;
			DateOfClaim = dateOfClaim;
		}
	}
}
