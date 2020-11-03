using KomodoClaimsRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimUI
{
	public class ProgramUI
	{
		private ClaimRepo _repo = new ClaimRepo();
        int index = 0;

        public void Run() 
		{
            SeedContent();
			Menu();
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Show claim by ID\n" +
                    "5. Delete claim by ID\n" +
                    "6. Update claim by ID\n" +
                    "7. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Show all content
                        ShowAllClaims();
                        break;
                    case "2":
                        //Get next claim
                        GetTheNextClaim();
                        break;
                    case "3":
                        // Create a new claim
                        CreateNewClaim();
                        break;
                    case "4":
                        // (NOT REQUIRED IN PROMPT)
                        ShowClaimById();
                        break;
                    case "5":
                        // (NOT REQUIRED IN PROMPT)
                        DeleteClaimById();
                        break;
                    case "6":
                        // (NOT REQUIRED IN PROMPT)
                        UpdateClaim();
                        break;
                    case "7":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void SeedContent()
        {
            Claim claim1 = new Claim(
                1,
                "Home",
                "House fire",
                21683.42M,
                new DateTime(1986, 02, 26),
                new DateTime(1986, 02, 28)
            );
            Claim claim2 = new Claim(
                2,
                "Car",
                "Head-on collision",
                1235.12M,
                new DateTime(1986, 03, 21),
                new DateTime(1986, 03, 23)
            );
            Claim claim3 = new Claim(
                3,
                "Theft",
                "Computer stolen",
                523.42M,
                new DateTime(1986, 04, 24),
                new DateTime(1986, 04, 27)
            );
            _repo.AddClaimToDirectory(claim1);
            _repo.AddClaimToDirectory(claim2);
            _repo.AddClaimToDirectory(claim3);
        }

        private void CreateNewClaim() 
        {
            Console.Clear();

            Claim newClaim = new Claim();

            // Get Claim ID
			Console.WriteLine("Enter the claim ID");
            string ClaimIdAsString = Console.ReadLine();
            int ClaimIdAsInt = Int32.Parse(ClaimIdAsString);
            newClaim.ClaimID = ClaimIdAsInt;

			// Get Claim Type
            bool gettingInput = true;
            while (gettingInput == true)
            {
                Console.WriteLine("Enter the claim type(Car, Home, or Theft)");
                string typeClaim = Console.ReadLine();

                if (typeClaim.ToLower() == "car")
                {
                    newClaim.ClaimType = typeClaim;
                    gettingInput = false;
                }
                else if (typeClaim.ToLower() == "home")
                {
                    newClaim.ClaimType = typeClaim;
                    gettingInput = false;
                }
                else if (typeClaim.ToLower() == "theft")
                {
                    newClaim.ClaimType = typeClaim;
                    gettingInput = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid claim type (car, home, or theft)");
                    Console.ReadLine();
                }
            }

			// Get Claim Description
			Console.WriteLine("Enter the claim's description");
            newClaim.Description = Console.ReadLine();

            // Get Claim Amount
            Console.WriteLine("Enter the claim Amount");
            string ClaimAmountAsString = Console.ReadLine();
            decimal ClaimAmountAsDecimal = Decimal.Parse(ClaimAmountAsString);
            newClaim.ClaimAmount = ClaimAmountAsDecimal;

            // Get Date of Incident
            Console.WriteLine("Enter date of incident");

            Console.Write("Enter a month (XX): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day (XX): ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year (XXXX): ");
            int year = int.Parse(Console.ReadLine());

            DateTime inputtedDate = new DateTime(year, month, day);

            newClaim.DateOfIncident = inputtedDate;

            // Get Date of Claim
            Console.WriteLine("Enter date of claim");

            Console.Write("Enter a month (XX): ");
            int month1 = int.Parse(Console.ReadLine());
            Console.Write("Enter a day (XX): ");
            int day1 = int.Parse(Console.ReadLine());
            Console.Write("Enter a year (XXXX): ");
            int year1 = int.Parse(Console.ReadLine());

            DateTime inputtedDate1 = new DateTime(year1, month1, day1);

            newClaim.DateOfClaim = inputtedDate1;

            bool wasAdded = _repo.AddClaimToDirectory(newClaim);
            if (wasAdded == true)
            {
                Console.WriteLine("Your content was succesfully added. Press ENTER to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Oops something went wrong. Your content was not added. Press ENTER to continue");
                Console.ReadKey();
            }
        }

        private void GetTheNextClaim()
        {
            Console.Clear();

            Claim myClaim = _repo.GetNextClaim(index);
           
            DisplayClaim(myClaim);
            Console.WriteLine("Do you want to deal with this claim now (type only 'yes' or 'no'?");
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                _repo.DeleteExistingClaim(myClaim);
                Console.WriteLine("You handled this claim and it was deleted from the list. Press ENTER to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You did not handle this claim. Nothing was deleted. Press ENTER to continue");
                Console.ReadLine();
            }
        }

        private void ShowAllClaims()
        {
            Console.Clear();
            Console.WriteLine("ClaimID  Type   Description              Amount     IncidentDate  ClaimDate     Valid");
            List<Claim> listOfClaims = _repo.GetClaims();

            foreach (Claim claim in listOfClaims)
            {
                DisplayClaims(claim);
            }

			Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // Get claim by ID (NOT REQUIRED IN PROMPT)
        private void ShowClaimById()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the content you'd like to see.");
            string idAsString = Console.ReadLine();
            int idAsInt = Int32.Parse(idAsString);

            Claim claim =  _repo.GetClaimById(idAsInt);

            if (claim != null)
            {
                DisplayClaim(claim);
            }
            else
            {
                Console.WriteLine("That claim doesn't exist.");
            }
            Console.ReadKey();
        }

        // Update a claim (NOT REQUIRED IN PROMPT)
        private void UpdateClaim()
        {
            Console.Clear();
            ShowAllClaims();
            Console.WriteLine("Enter the ID of the claim you'd like to update.");
            string claimIdAsString = Console.ReadLine();
            int claimIdAsInt = Int32.Parse(claimIdAsString);
            Claim oldClaim = _repo.GetClaimById(claimIdAsInt);

            if (oldClaim == null)
            {
                Console.WriteLine("Claim not found. Press any key to continue");
                Console.ReadKey();
                return;
            }

            Claim newClaim = new Claim(
                oldClaim.ClaimID,
                oldClaim.ClaimType,
                oldClaim.Description,
                oldClaim.ClaimAmount,
                oldClaim.DateOfIncident,
                oldClaim.DateOfClaim
            );

            Console.WriteLine("Which property would you like to update:\n" +
                    "1. Claim ID\n" +
                    "2. Claim Type\n" +
                    "3. Claim Description\n" +
                    "4. Claim Amount\n" +
                    "5. Date of Incident\n" +
                    "6. Date of Claim\n" +
                    "7. Exit (don't update anything)");

            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    Console.WriteLine("Enter a new Claim ID");
                    string idAsString = Console.ReadLine();
                    int idAsInt = Int32.Parse(idAsString);
                    newClaim.ClaimID = idAsInt;

                    bool wasSuccessful = _repo.UpdateExistingClaim(claimIdAsInt, newClaim);

                    if (wasSuccessful)
                    {
                        Console.WriteLine("Menu number successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {idAsInt}");
                    }
                    break;
                case "2":
                    bool gettingInput = true;
                    while (gettingInput == true)
                    {
                        Console.WriteLine("Enter the claim type(Car, Home, or Theft)");
                        string typeClaim = Console.ReadLine();

                        if (typeClaim.ToLower() == "car")
                        {
                            newClaim.ClaimType = typeClaim;
                            gettingInput = false;
                        }
                        else if (typeClaim.ToLower() == "home")
                        {
                            newClaim.ClaimType = typeClaim;
                            gettingInput = false;
                        }
                        else if (typeClaim.ToLower() == "theft")
                        {
                            newClaim.ClaimType = typeClaim;
                            gettingInput = false;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid claim type (car, home, or theft)");
                            Console.ReadLine();
                        }
                    }

                    bool wasSuccessful1 = _repo.UpdateExistingClaim(claimIdAsInt, newClaim);

                    if (wasSuccessful1)
                    {
                        Console.WriteLine("Menu name successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {claimIdAsInt}");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter a new claim description");
                    string newClaimDescription = Console.ReadLine();

                    newClaim.Description = newClaimDescription;

                    bool wasSuccessful2 = _repo.UpdateExistingClaim(claimIdAsInt, newClaim);

                    if (wasSuccessful2)
                    {
                        Console.WriteLine("Menu description successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {claimIdAsInt}");
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter a new claim amount");
                    string newClaimAmountAsString = Console.ReadLine();
                    decimal newClaimAmountAsDecimal = decimal.Parse(newClaimAmountAsString);
                    newClaim.ClaimAmount = newClaimAmountAsDecimal;

                    bool wasSuccessful3 = _repo.UpdateExistingClaim(claimIdAsInt, newClaim);

                    if (wasSuccessful3)
                    {
                        Console.WriteLine("Menu description successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {claimIdAsInt}");
                    }
                    break;
                case "5":
                    Console.WriteLine("Enter date of incident");

                    Console.Write("Enter a month (XX): ");
                    int month1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day (XX): ");
                    int day1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year (XXXX): ");
                    int year1 = int.Parse(Console.ReadLine());

                    DateTime inputtedDate1 = new DateTime(year1, month1, day1);

                    newClaim.DateOfIncident = inputtedDate1;

                    bool wasSuccessful4 = _repo.UpdateExistingClaim(claimIdAsInt, newClaim);

                    if (wasSuccessful4)
                    {
                        Console.WriteLine("Menu description successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {claimIdAsInt}");
                    }
                    break;
                case "6":
                    Console.WriteLine("Enter date of claim");

                    Console.Write("Enter a month (XX): ");
                    int month2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day (XX): ");
                    int day2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year (XXXX): ");
                    int year2 = int.Parse(Console.ReadLine());

                    DateTime inputtedDate2 = new DateTime(year2, month2, day2);

                    newClaim.DateOfClaim = inputtedDate2;

                    bool wasSuccessful5 = _repo.UpdateExistingClaim(claimIdAsInt, newClaim);

                    if (wasSuccessful5)
                    {
                        Console.WriteLine("Menu description successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {claimIdAsInt}");
                    }
                    break;
                default:
                    break;
            }
        }

        // Delete claim by ID (NOT REQUIRED IN PROMPT)
        private void DeleteClaimById()
        {
            ShowAllClaims();
            Console.WriteLine("Enter the ID for the claim you would like to delete.");
            string IdAsString = Console.ReadLine();
            int IdAsInt = Int32.Parse(IdAsString);

            Claim claimToDelete = _repo.GetClaimById(IdAsInt);
            bool wasDeleted = _repo.DeleteExistingClaim(claimToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This content was successfully deleted. Press ENTER to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Content could not be deleted Press ENTER to continue.");
                Console.ReadKey();
            }
        }
        private void DisplayClaims(Claim claim)
        {
            Console.Write($"{claim.ClaimID}".PadRight(9));
            Console.Write($"{claim.ClaimType}".PadRight(7));
			Console.Write($"{claim.Description}".PadRight(25));
            Console.Write($"{'$'}{claim.ClaimAmount}".PadRight(11));
            Console.Write($"{claim.DateOfIncident.ToString("dd/MM/yyyy")}".PadRight(14));
            Console.Write($"{claim.DateOfClaim.ToString("dd/MM/yyyy")}".PadRight(14));
            Console.Write($"{claim.IsValid}".PadRight(7));
			Console.WriteLine();
        }

        private void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"{"Claim ID: "}{claim.ClaimID}".PadRight(9));
            Console.WriteLine($"{"Claim Type: "}{claim.ClaimType}".PadRight(7));
			Console.WriteLine($"{"Claim Description: "}{claim.Description}".PadRight(25));
            Console.WriteLine($"{"Claim Amount: "}{'$'}{claim.ClaimAmount}".PadRight(11));
            Console.WriteLine($"{"Date of Incident: "}{claim.DateOfIncident.ToString("dd/MM/yyyy")}".PadRight(14));
            Console.WriteLine($"{"Date of Claim: "}{claim.DateOfClaim.ToString("dd/MM/yyyy")}".PadRight(14));
            Console.WriteLine($"{"Is Claim Valid? "}{claim.IsValid}".PadRight(7));
            Console.WriteLine();
        }

    }
}
