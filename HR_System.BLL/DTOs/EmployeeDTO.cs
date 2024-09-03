﻿namespace HR_System.BLL.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public DateTime DateHired { get; set; }
       
    }
}
