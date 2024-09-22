namespace HR_System.BLL.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; } = string.Empty;
        public DateTime DateHired { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Departments { get; set; } = new List<string>();

    }
}
