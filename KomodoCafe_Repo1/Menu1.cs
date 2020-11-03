using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repo1
{
	public class Menu1
	{
		// Menu properties
		public int MealNumber { get; set; }
		public string MealName { get; set; }
		public string MealDescription { get; set; }
		public List<string> MealIngredients { get; set; }
		public decimal MealPrice { get; set; }

		// Constructor for MealNumber (because it has no setter)


		//Constructor

		public Menu1() 
		{
		}

		public Menu1(int mealNumber, string mealName, string mealDescription, List<string> mealIngredients, decimal mealPrice)
		{
			MealNumber = mealNumber;
			MealName = mealName;
			MealDescription = mealDescription;
			MealIngredients = mealIngredients;
			MealPrice = mealPrice;
		}

	}
}
