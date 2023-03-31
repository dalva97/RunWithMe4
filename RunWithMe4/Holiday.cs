using System;

namespace RunwithMe
{
    public class Holiday
    {
        private List<DateTime> holidayList = new List<DateTime>()
        {
            new DateTime(2023,1,1),
            new DateTime(2023,4,1),
            new DateTime(2023,12,25),
            new DateTime(2023,2,14),
        };

        public bool IsTodayAHoliday()
        {
            var isHoliday = holidayList.Any(h => h.Equals(DateTime.Today));
            return isHoliday;
        }
        
        

         

        

    }
}

