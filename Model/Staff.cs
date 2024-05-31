namespace Staff_API.Model
{
    public class Staff
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public string SurName { get; set; } = string.Empty;
        public required string DateOfBirth { get; set; }
        public bool isActive { get; set; } = true;

        public StaffAddres[] Address { get; set; }

    }

    public class StaffAddres
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string HouseNumber { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
    }
}
