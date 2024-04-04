namespace EmployeeManagement.Api.Models
{
    public class EmployeePostModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Identity { get; set; }

        public bool IsMale { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public float Credits { get; set; }

        public DateTime StartJob { get; set; }

        public List<PositionEmployeePostModel> Positions{ get; set; }

    }
}
