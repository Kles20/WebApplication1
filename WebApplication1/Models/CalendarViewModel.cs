namespace WebApplication1.Models
{
    public class CalendarViewModel
    {
        public List<List<Day>> Days { get; set; }

        public CalendarViewModel()
        {
            Days = new List<List<Day>>();
        }

        public void GenerateCalendar(int year, int month)
        {
            var days = new List<List<Day>>();
            var firstDayOfMonth = new DateTime(year, month, 1);
            var daysInMonth = DateTime.DaysInMonth(year, month);
            var currentDay = firstDayOfMonth;
            var week = new List<Day>();

            // Dodaj puste dni na początku miesiąca
            for (int i = 0; i < (int)currentDay.DayOfWeek; i++)
            {
                week.Add(null);
            }

            // Wypełnij kalendarz rzeczywistymi dniami
            for (int day = 1; day <= daysInMonth; day++)
            {
                if (week.Count == 7)
                {
                    days.Add(week);
                    week = new List<Day>();
                }
                week.Add(new Day { Date = currentDay });
                currentDay = currentDay.AddDays(1);
            }

            // Dodaj pozostałe dni do ostatniego tygodnia
            if (week.Count > 0)
            {
                while (week.Count < 7)
                {
                    week.Add(null);
                }
                days.Add(week);
            }

            Days = days;
        }
    }

    public class Day
    {
        public DateTime Date { get; set; }
        public List<string> Events { get; set; } = new List<string>();
    }
}