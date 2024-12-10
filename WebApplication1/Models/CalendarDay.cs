namespace WebApplication1.Models
{
    public class CalendarDay
    {
        public DateTime Date { get; set; }
        public List<string> Events { get; set; } = new List<string>();
    }
}
