namespace HRSystem.DAL.Models
{
    public class EmployeeRole
    {
        public int EmployeeId { get; set; }
        public required Employee Employee { get; set; }
        public int RoleId { get; set; }
        public required Role Role { get; set; }
    }
}
