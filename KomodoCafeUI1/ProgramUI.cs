using KomodoCafe_Repo1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KomodoCafeUI1
{
	public class ProgramUI
	{
		private MenuRepo1 _menuRepo = new MenuRepo1();

		public void Run()
		{
			SeedContent();
			ProgramNavigation();
			
		}


		// Create a console navigation menu
		public void ProgramNavigation()
		{
			bool responseIsValid = false;
			while (!responseIsValid)
			{
				Console.Clear();
				Console.WriteLine("Select an option:\n" +
					"1. See all menu items\n" +
					"2. Add a menu item\n" +
					"3. Delete a menu item\n" +
					"4. Update a menu item\n" +
					"5. Exit");


				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						SeeAllMenuItems();
						break;
					case "2":
						AddMenuItem();
						break;
					case "3":
						DeleteContentByMenuNumber();
						break;
					case "4":
						// (NOT REQUIRED BY PROMPT)
						UpdateMenuItem();
						break;
					case "5":
						responseIsValid = true;
						break;
					default:
						break;

				}
			}
		}

		private void SeedContent()
		{
			var Ingredients1 = new List<string>()
					{
						"Lettuce",
						"Onions",
						"Pickles",
						"Cheese"
					};

			var Ingredients2 = new List<string>()
					{
						"Croutons",
						"Cucumber",
						"Tomatoes",
						"Cheese"
					};

			Menu1 menuItem1 = new Menu1(
				1,
				"Hamburger",
				"A tasty burger!",
				Ingredients1,
				4.99M
			);

			Menu1 menuItem2 = new Menu1(
				2,
				"Salad",
				"A delicious salad!",
				Ingredients1,
				1.99M
			);

			_menuRepo.AddMenuItem(menuItem1);
			_menuRepo.AddMenuItem(menuItem2);
		}

		public void SeeAllMenuItems()
		{
			Console.Clear();

			List<Menu1> listOfMenuItems = _menuRepo.GetMenuItems();

			foreach (Menu1 menuItem in listOfMenuItems)
				{
				DisplayMenuItem(menuItem);
				}

			Console.WriteLine("Press ENTER to continue");
			Console.ReadKey();
			
		}

		public void AddMenuItem()
		{
			Menu1 newMenuItem = new Menu1();

			Console.WriteLine("Enter a meal number for the menu item");
			int mealNumber = Int32.Parse(Console.ReadLine());

			Console.WriteLine("Enter the name for the new Menu item");
			string mealName = Console.ReadLine();
			Console.WriteLine("Enter the description for the new Menu item");
			string mealDescription = Console.ReadLine();

			// fill a List with user input 
			Console.WriteLine("Enter a list of ingredients");
			List<string> mealIngredients = new List<string>();


			while (true)
			{
				Console.WriteLine("Enter ingredient or type 'exit' to finish");
				string input = Console.ReadLine();
				if (input == "exit")
				{

					break;
				}
				mealIngredients.Add(input);
			}

			Console.WriteLine("Enter a price for the menu item");
			decimal mealPrice = decimal.Parse(Console.ReadLine());
			Console.WriteLine("Press Enter to continue to main menu");

			//int id = _menuRepo.();
			//Menu menu = new Menu(id);
			newMenuItem.MealNumber = mealNumber;
			newMenuItem.MealName = mealName;
			newMenuItem.MealDescription = mealDescription;
			newMenuItem.MealIngredients = mealIngredients;
			newMenuItem.MealPrice = mealPrice;

			// in this method we've only asked for the mealName so far but
			// would add other things like description later

			_menuRepo.AddMenuItem(newMenuItem);
			Console.ReadKey();
		}

		private void DeleteContentByMenuNumber()
		{
			SeeAllMenuItems();
			Console.WriteLine("Enter the menu item you would like to delete.");
			string menuNumberToDelete = Console.ReadLine();
			int itemToDelete = Convert.ToInt32(menuNumberToDelete);

			Menu1 menuItemToDelete = _menuRepo.GetMenuItemById(itemToDelete);
			bool wasDeleted = _menuRepo.DeleteExistingMenuItem(menuItemToDelete);

			if (wasDeleted)
			{
				Console.WriteLine("This content was successfully deleted.");
			}
			else
			{
				Console.WriteLine("Content could not be deleted");
			}
		}

		// Update menu items (NOT REQUIRED BY PROMPT)
		private void UpdateMenuItem() 
		{
			Console.Clear();
			SeeAllMenuItems();
			Console.WriteLine("Enter the Menu Number of the menu item you'd like to update.");
			string menuItemAsString = Console.ReadLine();
			int menuItemAsInt = Int32.Parse(menuItemAsString);
			Menu1 oldMenuItem = _menuRepo.GetMenuItemById(menuItemAsInt);

			if (oldMenuItem == null) 
			{
				Console.WriteLine("Menu item not found. Press any key to continue");
				Console.ReadKey();
				return;
			}

			Menu1 newMenuItem = new Menu1(
				oldMenuItem.MealNumber,
				oldMenuItem.MealName,
				oldMenuItem.MealDescription,
				oldMenuItem.MealIngredients,
				oldMenuItem.MealPrice
			);

			Console.WriteLine("Which property would you like to update:\n" +
					"1. Meal number\n" +
					"2. Meal name\n" +
					"3. Meal description\n" +
					"4. Meal ingredients\n" +
					"5. Meal price\n" +
					"6. Exit (don't update anything)");

			string selection = Console.ReadLine();
			switch (selection)
			{
				case "1":
					Console.WriteLine("Enter a new meal number");
					string newMealNumberAsString = Console.ReadLine();
					int newMealNumberAsInt = Int32.Parse(newMealNumberAsString);
					newMenuItem.MealNumber = newMealNumberAsInt;

					bool wasSuccessful = _menuRepo.UpdateExistingMenuItem(menuItemAsInt, newMenuItem);

					if (wasSuccessful)
					{
						Console.WriteLine("Menu number successfully updated");
					}
					else
					{
						Console.WriteLine($"Error: Could not update {menuItemAsInt}");
					}
					break;
				case "2":
					Console.WriteLine("Enter a new meal name");
					string newMealName = Console.ReadLine();
					
					newMenuItem.MealName = newMealName;

					bool wasSuccessful1 = _menuRepo.UpdateExistingMenuItem(menuItemAsInt, newMenuItem);

					if (wasSuccessful1)
					{
						Console.WriteLine("Menu name successfully updated");
					}
					else
					{
						Console.WriteLine($"Error: Could not update {menuItemAsInt}");
					}
					break;
				case "3":
					Console.WriteLine("Enter a new meal description");
					string newMealDescription = Console.ReadLine();

					newMenuItem.MealDescription = newMealDescription;

					bool wasSuccessful2 = _menuRepo.UpdateExistingMenuItem(menuItemAsInt, newMenuItem);

					if (wasSuccessful2)
					{
						Console.WriteLine("Menu description successfully updated");
					}
					else
					{
						Console.WriteLine($"Error: Could not update {menuItemAsInt}");
					}
					break;
				case "4":
					Console.WriteLine("Enter a new list of meal ingredients");

					Console.WriteLine("Enter a list of ingredients");
					List<string> newMealIngredients = new List<string>();


					while (true)
					{
						Console.WriteLine("Enter ingredient or type 'exit' to finish");
						string input = Console.ReadLine();
						if (input == "exit")
						{

							break;
						}
						newMealIngredients.Add(input);
					}

					newMenuItem.MealIngredients = newMealIngredients;

					bool wasSuccessful3 = _menuRepo.UpdateExistingMenuItem(menuItemAsInt, newMenuItem);

					if (wasSuccessful3)
					{
						Console.WriteLine("Menu description successfully updated");
					}
					else
					{
						Console.WriteLine($"Error: Could not update {menuItemAsInt}");
					}
					break;
				case "5":
					Console.WriteLine("Enter a new meal price");
					string newMealPriceAsString = Console.ReadLine();
					decimal newMealPriceAsDecimal = decimal.Parse(newMealPriceAsString);

					newMenuItem.MealPrice = newMealPriceAsDecimal;

					bool wasSuccessful4 = _menuRepo.UpdateExistingMenuItem(menuItemAsInt, newMenuItem);

					if (wasSuccessful4)
					{
						Console.WriteLine("Menu description successfully updated");
					}
					else
					{
						Console.WriteLine($"Error: Could not update {menuItemAsInt}");
					}
					break;
				case "6":
					break;
				default:
					break;
			}
		}

		private void DisplayMenuItem(Menu1 menuItem)
		{
			Console.WriteLine($"{"Meal number: "}{menuItem.MealNumber}");
			Console.WriteLine($"{"Name:        "}{menuItem.MealName}");
			Console.WriteLine($"{"Description: "}{menuItem.MealDescription}");
			Console.Write("Ingredients: ");
			foreach (var item in menuItem.MealIngredients)
			{
				Console.Write(item + ' ');
			}
			Console.WriteLine();
			Console.WriteLine($"{"Price:       "}{"$"}{menuItem.MealPrice}");
			Console.WriteLine();
			
		}

		//MealNumber = mealNumber;
		//	MealName = mealName;
		//	MealDescription = mealDescription;
		//	MealIngredients = mealIngredients;
		//	MealPrice = mealPrice;
	}
}


