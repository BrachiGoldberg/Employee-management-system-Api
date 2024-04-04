namespace EmployeeManagement.Api.Models
{
    public class AttendanceJournalPostModel
    {
        public DateTime Date { get; set; }

        public int BeginHour { get; set; }

        public int BeginMinutes { get; set; }

        public int EndHour { get; set; }

        public int EndMinutes { get; set; }
    }
}
