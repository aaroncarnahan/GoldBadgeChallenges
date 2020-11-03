using System;
using System.Collections.Generic;
using System.ComponentModel;
using KomodoCafe_Repo1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafeTests1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void AddAMenuItem()
		{
			
			//Arrange
			Menu1 menuItem = new Menu1();
			MenuRepo1 repository = new MenuRepo1();

			//Act				
			bool addResult = repository.AddMenuItem(menuItem);

			//Assert
			Assert.IsTrue(addResult);
			
		}

		[TestMethod]
		public void GetEntireMenuRepository()
		{
			//Arrange
			Menu1 menuItem = new Menu1();
			MenuRepo1 repository = new MenuRepo1();

			repository.AddMenuItem(menuItem);

			//Act
			List<Menu1> menuItems = repository.GetMenuItems();

			bool directoryHasContent = menuItems.Contains(menuItem);

			//Assert
			Assert.IsTrue(directoryHasContent);
		}

		[TestMethod]
		public void GetMenuItemById()
		{ 
			//Arrange
			var Ingredients1 = new List<string>()
					{
						"Croutons",
						"Cucumber",
						"Tomatoes",
						"Cheese"
					};

			MenuRepo1 repository = new MenuRepo1();
			Menu1 newMenuItem = new Menu1(
				1,
				"Salad",
				"A delicious salad!",
				Ingredients1,
				1.99M
			);
			
			repository.AddMenuItem(newMenuItem);
			int id = 1;

			//Act
			Menu1 searchResult = repository.GetMenuItemById(1);

			//Assert
			Assert.AreEqual(searchResult.MealNumber, id);
		}

		[TestMethod]
		public void DeleteExistingMenuItem()
		{
			//Arrange
			var Ingredients1 = new List<string>()
					{
						"Croutons",
						"Cucumber",
						"Tomatoes",
						"Cheese"
					};

			MenuRepo1 repository = new MenuRepo1();
			Menu1 newMenuItem = new Menu1(
				1,
				"Salad",
				"A delicious salad!",
				Ingredients1,
				1.99M
			);

			repository.AddMenuItem(newMenuItem);
			
			//Act
			Menu1 item = repository.GetMenuItemById(1); ;

			bool removeResult = repository.DeleteExistingMenuItem(item);

			//Assert
			Assert.IsTrue(removeResult);
		}

		// Update (NOT REQUIRED BY PROMPT)
		[TestMethod]
		public void UpdateExistingMenuItem()
		{
			//Arrange
			var Ingredients1 = new List<string>()
					{
						"Croutons",
						"Cucumber",
						"Tomatoes",
						"Cheese"
					};


			MenuRepo1 repo = new MenuRepo1();
			Menu1 oldMenuItem = new Menu1(1, "Salad", "A delicious salad!", Ingredients1, 1.99M);
			repo.AddMenuItem(oldMenuItem);

			Menu1 newMenuItem = new Menu1(2, "Cheeseburger", "A delicious cheeseburger!", Ingredients1, 4.99M);

			//Act
			bool updateResult = repo.UpdateExistingMenuItem(oldMenuItem.MealNumber, newMenuItem);

			//Assert
			Assert.IsTrue(updateResult);
		}
	}
}
