﻿namespace HR_Sysytem.Models
{
    public class EmployeeDepartment
    {
        public int EmployeeId { get; set; }
        public   Employee Employee { get; set; } 
        public int DepartmentId { get; set; }
        public   Department Department { get; set; } 
    }
}
