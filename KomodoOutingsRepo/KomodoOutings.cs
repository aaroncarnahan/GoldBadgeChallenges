using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsRepository
{
	public class KomodoOutings
	{
		public string EventType { get; set; }
		public int NumberOfAttendees { get; set; }
		public DateTime EventDate { get; set; }
		public decimal CostPerPerson { get; set; }
        public decimal TotalCostOfEvent
        {
            get
            {
                return CostPerPerson * NumberOfAttendees;
            }
        }

        public KomodoOutings() { }

        public KomodoOutings(string eventType, int numberOfAttendees, DateTime eventDate, decimal costPerPerson) 
        {
            EventType = eventType;
            NumberOfAttendees = numberOfAttendees;
            EventDate = eventDate;
            CostPerPerson = costPerPerson;
        }
    }
}
