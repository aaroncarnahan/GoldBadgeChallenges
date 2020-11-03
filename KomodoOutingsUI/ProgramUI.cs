using KomodoOutingsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsUI
{
    public class ProgramUI
    {
        private KomodoOutingsRepo _repo = new KomodoOutingsRepo();
        decimal totalCost = 0.00m;
        decimal totalGolfCost = 0.00m;
        decimal totalBowlingCost = 0.00m;
        decimal totalAmusementPartCost = 0.00m;
        decimal totalConcertCost = 0.00m;


        public void Run()
        {
            SeedContent();
            Menu();
        }

        private void SeedContent()
        {
            KomodoOutings outing1 = new KomodoOutings(
                "Golf",
                120,
                new DateTime(1986, 05, 21),
                25.24M
            );
            KomodoOutings outing2 = new KomodoOutings(
               "Bowling",
               14,
               new DateTime(1986, 07, 02),
               71.33M
           );
            KomodoOutings outing3 = new KomodoOutings(
               "Amusement Park",
               110,
               new DateTime(1986, 10, 31),
               120.45M
           );
            KomodoOutings outing4 = new KomodoOutings(
               "Concert",
               10,
               new DateTime(1986, 12, 12),
               99.99M
           );
            _repo.AddOutingToDirectory(outing1);
            _repo.AddOutingToDirectory(outing2);
            _repo.AddOutingToDirectory(outing3);
            _repo.AddOutingToDirectory(outing4);
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Show all Komodo Outings\n" +
                    "2. Add a new outing\n" +
                    "3. See combined cost for all outings \n" +
                    "4. See cost per outing type\n" +
                    "5. See outing by date\n" +
                    "6. Delete outing by date\n" +
                    "7. Update outing by date\n" +
                    "8. Exit");


                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Show all outings
                        ShowAllOutings();
                        break;
                    case "2":
                        //Create a new outing
                        CreateNewOuting();
                        break;
                    case "3":
                        //See combined cost for all outings
                        CombinedCostAll();
                        break;
                    case "4":
                        // See cost per outing type
                        CombinedCostByEventType();
                        break;
                    case "5":
                        // Show outing by date (NOT REQUIRED IN PROMPT)
                        ShowOutingByDate();
                        break;
                    case "6":
                        // Delete outing by date (NOT REQUIRED IN PROMPT)
                        DeleteOutingByDate();
                        break;
                    case "7":
                        // Delete outing by date (NOT REQUIRED IN PROMPT)
                        UpdateOuting();
                        break;
                    case "8":
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

        private void ShowAllOutings()
        {
            Console.Clear();

            List<KomodoOutings> listOfOutings = _repo.GetOutings();

            foreach (KomodoOutings outing in listOfOutings)
            {
                DisplayOutings(outing);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // Show outing by date (NOT REQUIRED IN PROMPT)
        private void ShowOutingByDate()
        {
            Console.Clear();

            Console.WriteLine("Enter the date of the outing you'd like to see.");

            Console.Write("Enter a month (XX): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day (XX): ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year (XXXX): ");
            int year = int.Parse(Console.ReadLine());

            DateTime inputtedDate = new DateTime(year, month, day);

            KomodoOutings outing = _repo.GetOutingByDate(inputtedDate);

            if (outing != null)
            {
                Console.WriteLine();
                DisplayOutings(outing);
            }
            else
            {
                Console.WriteLine("That outing doesn't exist.");
            }
            Console.ReadKey();
        }

        // Delete outing by date (NOT REQUIRED IN PROMPT)
        private void DeleteOutingByDate()
        {
            ShowAllOutings();
            Console.WriteLine("Enter the date for the content you would like to delete.");
            Console.Write("Enter a month (XX): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day (XX): ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year (XXXX): ");
            int year = int.Parse(Console.ReadLine());

            DateTime dateToDelete = new DateTime(year, month, day);

            KomodoOutings outingToDelete = _repo.GetOutingByDate(dateToDelete);
            bool wasDeleted = _repo.DeleteExistingOuting(outingToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This outing was successfully deleted. Press ENTER to continue.");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Outing could not be deleted Press ENTER to continue.");
                Console.ReadKey();
            }
        }

        // Update an outing (NOT REQUIRED IN PROMPT)
        private void UpdateOuting()
        {
            Console.Clear();
            ShowAllOutings();
            Console.WriteLine("Enter the date of the outing you'd like to update.");
            Console.Write("Enter a month (XX): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day (XX): ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year (XXXX): ");
            int year = int.Parse(Console.ReadLine());

            DateTime dateToUpdate = new DateTime(year, month, day);

            KomodoOutings oldOuting = _repo.GetOutingByDate(dateToUpdate);

            if (oldOuting == null)
            {
                Console.WriteLine("Outing not found. Press any key to continue");
                Console.ReadKey();
                return;
            }

            KomodoOutings newOuting = new KomodoOutings(
                oldOuting.EventType,
                oldOuting.NumberOfAttendees,
                oldOuting.EventDate,
                oldOuting.CostPerPerson
                );

            Console.WriteLine("Which property would you like to update:\n" +
                    "1. Event type\n" +
                    "2. Number of attendess \n" +
                    "3. Date\n" +
                    "4. Cost per person\n" +
                    "5. Exit (don't update anything)");

            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    bool gettingInput = true;
                    while (gettingInput == true)
                    {
                        Console.WriteLine("Enter an updated outing type(Golf, Bowling, Amusement Park, or Concert)");
                        string typeEvent = Console.ReadLine();

                        if (typeEvent.ToLower() == "golf")
                        {
                            newOuting.EventType = typeEvent;
                            gettingInput = false;
                        }
                        else if (typeEvent.ToLower() == "bowling")
                        {
                            newOuting.EventType = typeEvent;
                            gettingInput = false;
                        }
                        else if (typeEvent.ToLower() == "amusement park")
                        {
                            newOuting.EventType = typeEvent;
                            gettingInput = false;
                        }
                        else if (typeEvent.ToLower() == "concert")
                        {
                            newOuting.EventType = typeEvent;
                            gettingInput = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid event type (Golf, Bowling, Amusement Park, or Concert)");
                            Console.ReadLine();
                        }
                    }

                    bool wasSuccessful = _repo.UpdateExistingOuting(dateToUpdate, newOuting);

                    if (wasSuccessful)
                    {
                        Console.WriteLine("Menu number successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {dateToUpdate}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Enter a updated number of attendees");
                    string newAttendeesAmountAsString = Console.ReadLine();
                    int newAttendeesAmountAsInt = Int32.Parse(newAttendeesAmountAsString);
                    newOuting.NumberOfAttendees = newAttendeesAmountAsInt;

                    bool wasSuccessful1 = _repo.UpdateExistingOuting(dateToUpdate, newOuting);

                    if (wasSuccessful1)
                    {
                        Console.WriteLine("Menu name successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {dateToUpdate}");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter an updated date for the outing you'd like to update.");
                    Console.Write("Enter a month (XX): ");
                    int month1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day (XX): ");
                    int day1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year (XXXX): ");
                    int year1 = int.Parse(Console.ReadLine());

                    DateTime dateToUpdate1 = new DateTime(year1, month1, day1);
                    
                    newOuting.EventDate = dateToUpdate1;

                    bool wasSuccessful2 = _repo.UpdateExistingOuting(dateToUpdate, newOuting);

                    if (wasSuccessful2)
                    {
                        Console.WriteLine("Menu description successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {dateToUpdate}");
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter an updated cost per person");
                    string newOutingCostPerPersonAsString = Console.ReadLine();
                    decimal newOutingCostPerPersonAsDecimal = decimal.Parse(newOutingCostPerPersonAsString);
                    newOuting.CostPerPerson = newOutingCostPerPersonAsDecimal;

                    bool wasSuccessful3 = _repo.UpdateExistingOuting(dateToUpdate, newOuting);

                    if (wasSuccessful3)
                    {
                        Console.WriteLine("Menu description successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {dateToUpdate}");
                    }
                    break;
                case "5":
                    break;
                default:
                    break;
            }
        }

        private void CombinedCostAll()
        {
            Console.Clear();

            List<KomodoOutings> listOfOutings = _repo.GetOutings();

            foreach (KomodoOutings outing in listOfOutings)
            {
                totalCost = totalCost + outing.TotalCostOfEvent;
            }

            Console.WriteLine($"{"Total cost for all outings "}{"$"}{totalCost}");
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
        }

        private void CombinedCostByEventType()
        {
            Console.Clear();

            List<KomodoOutings> listOfOutings = _repo.GetOutings();

            foreach (KomodoOutings outing in listOfOutings)
            {
                if (outing.EventType.ToLower() == "golf")
                {
                    totalGolfCost = totalGolfCost + outing.TotalCostOfEvent;
                }
                else if (outing.EventType.ToLower() == "bowling")
                {
                    totalBowlingCost = totalBowlingCost + outing.TotalCostOfEvent;
                }
                else if (outing.EventType.ToLower() == "amusement park")
                {
                    totalAmusementPartCost = totalAmusementPartCost + outing.TotalCostOfEvent;
                }
                else if (outing.EventType.ToLower() == "concert")
                {
                    totalConcertCost = totalConcertCost + outing.TotalCostOfEvent;
                }

            }

            Console.WriteLine($"{"Total cost for golf outings           "}{"$"}{totalGolfCost}");
            Console.WriteLine($"{"Total cost for bowling outings        "}{"$"}{totalBowlingCost}");
            Console.WriteLine($"{"Total cost for amusement park outings "}{"$"}{totalAmusementPartCost}");
            Console.WriteLine($"{"Total cost for concert outings        "}{"$"}{totalConcertCost}");
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
        }

        private void CreateNewOuting()
        {
            Console.Clear();

            KomodoOutings newOuting = new KomodoOutings();

            // Get Event Type
            bool gettingInput = true;
            while (gettingInput == true)
            {
                Console.WriteLine("Enter an outing type(Golf, Bowling, Amusement Park, or Concert)");
                string typeEvent = Console.ReadLine();

                if (typeEvent.ToLower() == "golf")
                {
                    newOuting.EventType = typeEvent;
                    gettingInput = false;
                }
                else if (typeEvent.ToLower() == "bowling")
                {
                    newOuting.EventType = typeEvent;
                    gettingInput = false;
                }
                else if (typeEvent.ToLower() == "amusement park")
                {
                    newOuting.EventType = typeEvent;
                    gettingInput = false;
                }
                else if (typeEvent.ToLower() == "concert")
                {
                    newOuting.EventType = typeEvent;
                    gettingInput = false;
                }
                else
                {
                    Console.WriteLine("Enter a valid event type (Golf, Bowling, Amusement Park, or Concert)");
                    Console.ReadLine();
                }
            }

            // Get Claim Amount
            Console.WriteLine("Enter the number of attendees");
            string AttendeesAsString = Console.ReadLine();
            int AttendeesCountAsInt = Int32.Parse(AttendeesAsString);
            newOuting.NumberOfAttendees = AttendeesCountAsInt;

            // Get Date of Event
            Console.WriteLine("Enter date of the event");

            Console.Write("Enter a month (XX): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day (XX): ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year (XXXX): ");
            int year = int.Parse(Console.ReadLine());

            DateTime inputtedDate = new DateTime(year, month, day);

            newOuting.EventDate = inputtedDate;

            // Total cost per person for the event

            Console.WriteLine("Enter total cost per person");
            string costPerPersonAsString = Console.ReadLine();
            decimal costPerPersonAsDecimal = Decimal.Parse(costPerPersonAsString);
            newOuting.CostPerPerson = costPerPersonAsDecimal;

            bool wasAdded = _repo.AddOutingToDirectory(newOuting);
            if (wasAdded == true)
            {
                Console.WriteLine("Your outing was succesfully added. Press ENTER to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Oops something went wrong. Your outing was not added. Press ENTER to continue");
                Console.ReadKey();
            }

        }

   //     public void CombinedCostAll(KomodoOutings outing)
   //     {
			//Console.WriteLine(GetTotalCost());
   //     }

        private void DisplayOutings(KomodoOutings outing)
        {
            Console.WriteLine($"{"Type of outing:      "}{outing.EventType}");
            Console.WriteLine($"{"Number of attendees: "}{outing.NumberOfAttendees}");
            Console.WriteLine($"{"Event date:          "}{outing.EventDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"{"Cost per person:     "}{'$'}{outing.CostPerPerson}");
            Console.WriteLine($"{"Total cost of event: "}{'$'}{outing.TotalCostOfEvent}");
			Console.WriteLine();
        }


    }

	
}
