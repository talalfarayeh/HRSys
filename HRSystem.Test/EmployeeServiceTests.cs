using HRSystem.BLL.Services;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_System.BLL.DTOs;

namespace HRSystem.Tests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly IEmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_mockEmployeeRepository.Object);
        }
        [Fact]
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            var employees = new List<Employee>
            {
              new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", Position = "Developer" },
                new Employee { EmployeeId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Position = "Manager" }

            };
            _mockEmployeeRepository.Setup(repo => repo.GetAll()).Returns(employees);

            var result = _employeeService.GetAllEmployees().ToList();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public void GetEmployeeById_ExistingId_ShouldReturnEmployee()
        {
            var employee = new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", Position = "Developer" };
            _mockEmployeeRepository.Setup(repo => repo.GetById(1)).Returns(employee);

            var result = _employeeService.GetEmployeeById(1);

            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
        }

        [Fact]
        public void AddEmployee_ValidEmployee_ShouldCallAddMethod()
        {
            var employeeDTO = new EmployeeDTO { EmployeeId = 3, FirstName = "Sam", LastName = "Wilson", Email = "sam@example.com", Position = "Tester" };

            _employeeService.AddEmployee(employeeDTO);

            _mockEmployeeRepository.Verify(repo => repo.Add(It.IsAny<Employee>()), Times.Once);




        }


        [Fact]
        public void UpdateEmployee_ValidEmployee_ShouldCallUpdateMethod()
        {
            var employeeDTO = new EmployeeDTO { EmployeeId = 1, FirstName = "Updated", LastName = "Doe", Email = "updated@example.com", Position = "Developer" };

            _mockEmployeeRepository.Setup(repo => repo.GetById(1)).Returns(new Employee { EmployeeId = 1 });
            _employeeService.UpdateEmployee(1, employeeDTO);

            _mockEmployeeRepository.Verify(repo => repo.Update(It.IsAny<Employee>()), Times.Once);


        }

        [Fact]
        public void DeleteEmployee_ExistingEmployee_ShouldCallDeleteMethod()
        {
            
            _mockEmployeeRepository.Setup(repo => repo.GetById(1)).Returns(new Employee { EmployeeId = 1 });

             
            _employeeService.DeleteEmployee(1);

            
            _mockEmployeeRepository.Verify(repo => repo.Delete(1), Times.Once);
        }
        [Fact]
        public void SearchEmployees_WithMatchingCriteria_ShouldReturnFilteredEmployees()
        {
             
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", Position = "Developer" },
                new Employee { EmployeeId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Position = "Manager" }
            };

            _mockEmployeeRepository.Setup(repo => repo.GetAll()).Returns(employees);

             
            var result = _employeeService.SearchEmployees("John", null, null, null, null).ToList();

            
            Assert.NotNull(result);
            Assert.Single(result);  
            Assert.Equal("John", result[0].FirstName);
        }
    }
}
