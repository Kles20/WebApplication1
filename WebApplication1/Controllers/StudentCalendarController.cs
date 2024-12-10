using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentCalendarController : Controller
    {
        // Odczytujemy wydarzenia z globalnego EventStore
        public IActionResult Index()
        {
            var model = new CalendarViewModel();
            model.Days = GenerateCalendar(DateTime.Now.Year, DateTime.Now.Month);

            // Dodajemy wydarzenia do odpowiednich dni w kalendarzu
            foreach (var eventItem in CalendarController.EventStore)
            {
                foreach (var week in model.Days)
                {
                    foreach (var day in week)
                    {
                        if (day != null && day.Date.Date == eventItem.Date.Date)
                        {
                            day.Events.Add(eventItem.Title);
                        }
                    }
                }
            }

            return View(model);
        }

        private List<List<Day>> GenerateCalendar(int year, int month)
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

            return days;
        }
    }
}