using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repo1
{
	public class MenuRepo1
	{
		private List<Menu1> _menuRepo1 = new List<Menu1>();

		// add a menu item
		public bool AddMenuItem(Menu1 menuItem)
		{
			int startingCount = _menuRepo1.Count;

			_menuRepo1.Add(menuItem);

			bool wasAdded = (_menuRepo1.Count > startingCount) ? true : false;
			return wasAdded;
		}

		

		// Get menu item by ID
		public Menu1 GetMenuItemById(int id)
		{
			foreach (Menu1 menuItem in _menuRepo1)
			{
				if (menuItem.MealNumber == id)
				{
					return menuItem;
				}
			}
			return null;
		}

		// Get all menu items
		public List<Menu1> GetMenuItems()
		{
			return _menuRepo1;
		}

		//Update (NOT REQUIRED BY PROMPT)
		public bool UpdateExistingMenuItem(int originalId, Menu1 newMenuItem) {

			Menu1 oldMenuItem = GetMenuItemById(originalId);

			if (oldMenuItem != null)
			{
				oldMenuItem.MealNumber = newMenuItem.MealNumber;
				oldMenuItem.MealName = newMenuItem.MealName;
				oldMenuItem.MealDescription = newMenuItem.MealDescription;
				oldMenuItem.MealIngredients = newMenuItem.MealIngredients;
				oldMenuItem.MealPrice = newMenuItem.MealPrice;
				return true;
			}
			else
			{
				return false;
			}
		}


		// Delete a menu item by name or other versions
		public bool DeleteExistingMenuItem(Menu1 exitingMenuItem)
		{
			bool deleteResult = _menuRepo1.Remove(exitingMenuItem);
			return deleteResult;
		}
	}
}

