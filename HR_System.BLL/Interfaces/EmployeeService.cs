﻿using HR_System.BLL.DTOs;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories;
using HRSystem.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HRSystem.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll().OrderBy(e => e.FirstName);
            return employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                Position = e.Position,
                DateHired = e.DateHired
            }).ToList();
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Position = employee.Position,
                DateHired = employee.DateHired
            };
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Position = employee.Position,
                DateHired = employee.DateHired
            };
            _employeeRepository.Add(newEmployee);
        }

        public void UpdateEmployee(int id, EmployeeDTO employee)
        {
            var existingEmployee = _employeeRepository.GetById(id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Email = employee.Email;
                existingEmployee.DateOfBirth = employee.DateOfBirth;
                existingEmployee.Position = employee.Position;
                existingEmployee.DateHired = employee.DateHired;
                _employeeRepository.Update(existingEmployee);
            }
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(id);
        }
    }
}
