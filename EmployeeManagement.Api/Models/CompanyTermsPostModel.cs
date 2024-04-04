namespace EmployeeManagement.Api.Models
{
    public class CompanyTermsPostModel
    {
        public double Meals { get; set; }

        public double NightShiftPrecent { get; set; }

        public double ShabbatShiftPrecent { get; set; }

        public int Gifts { get; set; }

        public int Clothing { get; set; }

        public int Recovery { get; set; }

        public int BirthDays { get; set; }

        public int DaySalariesCalculation { get; set; }
    }
}
