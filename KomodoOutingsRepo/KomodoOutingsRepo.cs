using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsRepository
{
    public class KomodoOutingsRepo
    {
        // field
        private List<KomodoOutings> outingsDirectory = new List<KomodoOutings>();
       
        // add an outing to the directory
        public bool AddOutingToDirectory(KomodoOutings outing) 
        {
            int startingCount = outingsDirectory.Count;

            outingsDirectory.Add(outing);

            bool wasAdded = (outingsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        // get entire directory
        public List<KomodoOutings> GetOutings()
        {
            return outingsDirectory;
        }

        // Get outing by date (NOT REQUIRED IN PROMPT)
        public KomodoOutings GetOutingByDate(DateTime outingDate)
        {
            foreach (KomodoOutings outing in outingsDirectory)
            {
                if (outing.EventDate == outingDate)
                {
                    return outing;
                }
            }
            return null;
        }

		// Delete an outing (NOT REQUIRED IN PROMPT)
		public bool DeleteExistingOuting(KomodoOutings existingOuting)
		{
			bool deleteResult = outingsDirectory.Remove(existingOuting);
			return deleteResult;
		}

        // Update an outing (NOT REQUIRED IN PROMPT)
        public bool UpdateExistingOuting(DateTime originalDate, KomodoOutings newOuting)
        {
            KomodoOutings oldOuting = GetOutingByDate(originalDate);

            if (oldOuting != null)
            {
                oldOuting.EventType = newOuting.EventType;
                oldOuting.NumberOfAttendees = newOuting.NumberOfAttendees;
                oldOuting.EventDate = newOuting.EventDate;
                oldOuting.CostPerPerson = newOuting.CostPerPerson;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
