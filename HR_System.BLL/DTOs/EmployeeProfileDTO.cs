using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs
{
     public class EmployeeProfileDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Username { get; set; }  
        public string? PasswordHash { get; set; }  
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public DateTime DateHired { get; set; }

        public List<string> Departments { get; set; } = new List<string>();
        public List<string> Roles { get; set; } = new List<string>();
    }
}
