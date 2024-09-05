﻿namespace HRSystem.DAL.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; } 

        public string? Description { get; set; } 
        public   ICollection<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();
    }
}
