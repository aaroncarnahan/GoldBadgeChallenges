using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoClaimsRepo;


namespace KomodoClaimsTests
{
	[TestClass]
	public class KomodoClaimsRepoTests
	{
		[TestMethod]
		public void AddClaimToDirectory()
		{
			//Arrange
			Claim claim = new Claim();
			ClaimRepo repository = new ClaimRepo();

			//Act
			bool addResult = repository.AddClaimToDirectory(claim);

			//Assert
			Assert.IsTrue(addResult);
		}

		[TestMethod]
		public void GetTheEntireDirectory()
		{
			//Arrange
			Claim claim = new Claim();
			ClaimRepo repository = new ClaimRepo();

			repository.AddClaimToDirectory(claim);

			//Act
			List<Claim> contents = repository.GetClaims();

			bool directoryHasContent = contents.Contains(claim);

			//Assert
			Assert.IsTrue(directoryHasContent);
		}

		[TestMethod]
		public void DeleteAClaimFromTheDirectory()
		{
			//Arrange
			ClaimRepo repository = new ClaimRepo();
			Claim claim = new Claim(1, "Home", "House fire", 21683.42M, new DateTime(1986, 02, 26), new DateTime(1986, 02, 28)); 
			repository.AddClaimToDirectory(claim);

			//Act
			bool removeResult = repository.DeleteExistingClaim(claim);

			//Assert
			Assert.IsTrue(removeResult);
		}

		// Get Claim by ID (NOT REQUIRED IN PROMPT)
		[TestMethod]
		public void GetClaimByIdShouldBeEqual()
		{
			//Arrange
			ClaimRepo repository = new ClaimRepo();
			Claim claim = new Claim(1, "Home", "House fire", 21683.42M, new DateTime(1986, 02, 26), new DateTime(1986, 02, 28));
			repository.AddClaimToDirectory(claim);
			int id = 1;

			//Act
			Claim searchResult = repository.GetClaimById(id);
			//Assert
			Assert.AreEqual(searchResult.ClaimID, id);
		}

		// Update claim (NOT REQUIRED IN PROMPT)
		[TestMethod]
		public void UpdateExistingContent_ShouldReturnTrue()
		{
			//Arrange
			ClaimRepo repo = new ClaimRepo();
			Claim oldClaim = new Claim(1, "Home", "House fire", 21683.42M, new DateTime(1986, 02, 26), new DateTime(1986, 02, 28));
			repo.AddClaimToDirectory(oldClaim);

			Claim newClaim = new Claim(2, "Car", "Car fire", 1683.42M, new DateTime(1986, 04, 22), new DateTime(1985, 01, 21));

			//Act
			bool updateResult = repo.UpdateExistingClaim(oldClaim.ClaimID, newClaim);

			//Assert
			Assert.IsTrue(updateResult);
		}

		// Couldn't get this one figured out :-(
		//[TestMethod]
		//public void GetNextClaimFromDirectory()
		//{
		//	int claimIndex = 0;


		//	ClaimRepo repository = new ClaimRepo();
		//	List<Claim> contents = repository.GetNextClaim(0);
		//	Claim claim1 = new Claim(1, "Home", "House fire", 21683.42M, new DateTime(1986, 02, 26), new DateTime(1986, 02, 28));
		//	Claim claim2 = new Claim(1, "Home", "House fire", 21683.42M, new DateTime(1986, 02, 26), new DateTime(1986, 02, 28));
		//	repository.AddClaimToDirectory(claim1);
		//	repository.AddClaimToDirectory(claim2);

		//	if (repository.AddClaimToDirectory.)
		//	{

		//	}

		//	//Assert
		//	Assert.IsTrue();
		//}

		//public Claim GetNextClaim(int x)
		//{
		//	int count = claimDirectory.Count;
		//	if (x < count)
		//	{
		//		return claimDirectory[x];
		//	}
		//	else
		//	{
		//		Console.WriteLine("Out of bounds!!");
		//		return null;
		//	}
		//}
	}
}
