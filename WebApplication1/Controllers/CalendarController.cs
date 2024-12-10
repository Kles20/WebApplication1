using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CalendarController : Controller
    {
        // Wydarzenia będą przechowywane w pamięci serwera
        public static List<(DateTime Date, string Title)> EventStore = new List<(DateTime Date, string Title)>();

        public IActionResult Index()
        {
            var model = new CalendarViewModel();
            model.GenerateCalendar(DateTime.Now.Year, DateTime.Now.Month);

            // Dodaj wydarzenia do dni kalendarza
            foreach (var eventItem in EventStore)
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

        [HttpPost]
        public IActionResult AddEvent([FromBody] EventRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Title) || request.Date == default)
            {
                return BadRequest();
            }

            // Dodaj wydarzenie do listy EventStore
            EventStore.Add((request.Date, request.Title));
            return Ok();
        }
    }

    public class EventRequest
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
}