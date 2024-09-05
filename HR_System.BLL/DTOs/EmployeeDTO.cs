namespace HR_System.BLL.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; } = string.Empty;
        public DateTime DateHired { get; set; }
    }
}
