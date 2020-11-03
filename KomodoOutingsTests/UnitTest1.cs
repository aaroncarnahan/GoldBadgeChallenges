using System;
using System.Text;
using System.Collections.Generic;
using KomodoOutingsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KomodoOutingsTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void AddOutingToOutingsDirectory()
		{
			// Arrange
			KomodoOutings outing = new KomodoOutings();
			KomodoOutingsRepo repository = new KomodoOutingsRepo();

			//Act
			bool addResult = repository.AddOutingToDirectory(outing);

			//Assert
			Assert.IsTrue(addResult);
		}

		[TestMethod]
		public void GetEntireOutingDirectory()
		{
			//Arrange
			KomodoOutings outing = new KomodoOutings();
			KomodoOutingsRepo repository = new KomodoOutingsRepo();

			repository.AddOutingToDirectory(outing);

			//Act
			List<KomodoOutings> outings = repository.GetOutings();

			bool directoryHasContent = outings.Contains(outing);

			//Assert
			Assert.IsTrue(directoryHasContent);
		}

		// (NOT REQUIRED IN PROMPT)
		[TestMethod]
		public void GetOutingByDate()
		{
			//Arrange
			KomodoOutingsRepo repository = new KomodoOutingsRepo();
			KomodoOutings newOuting = new KomodoOutings("Bowling", 76, new DateTime(1986, 02, 26), 131.11M);
			repository.AddOutingToDirectory(newOuting);
			DateTime outingDate = new DateTime(1986, 02, 26);

			//Act
			KomodoOutings searchResult = repository.GetOutingByDate(outingDate);

			//Assert
			Assert.AreEqual(searchResult.EventDate, outingDate);
		}

		// (NOT REQUIRED IN PROMPT)
		[TestMethod]
		public void DeleteExistingContent_ShouldReturnTrue()
		{
			//Arrange
			KomodoOutingsRepo repository = new KomodoOutingsRepo();
			KomodoOutings newOuting = new KomodoOutings("Bowling", 76, new DateTime(1986, 02, 26), 131.11M);
			repository.AddOutingToDirectory(newOuting);
			DateTime outingDate = new DateTime(1986, 02, 26);

			//Act
			KomodoOutings searchResult = repository.GetOutingByDate(outingDate);

			bool removeResult = repository.DeleteExistingOuting(searchResult);

			//Assert
			Assert.IsTrue(removeResult);
		}

		// (NOT REQUIRED IN PROMPT)
		[TestMethod]
		public void UpdateExistingContent_ShouldReturnTrue()
		{
			//Arrange
			KomodoOutingsRepo repo = new KomodoOutingsRepo();
			KomodoOutings oldOuting = new KomodoOutings("Bowling", 76, new DateTime(1986, 02, 26), 131.11M);
			repo.AddOutingToDirectory(oldOuting);

			KomodoOutings newOuting = new KomodoOutings("Golf", 16, new DateTime(1987, 03, 21), 101.11M);

			//Act
			bool updateResult = repo.UpdateExistingOuting(oldOuting.EventDate, newOuting);

			//Assert
			Assert.IsTrue(updateResult);
		}
	}
}
