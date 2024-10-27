using HR_System.BLL.DTOs.Payroll;
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
    public class SalaryComponentService : ISalaryComponentService
    {
        private readonly ISalaryComponentRepository _salaryComponentRepository;

        public SalaryComponentService(ISalaryComponentRepository salaryComponentRepository)
        {
            _salaryComponentRepository = salaryComponentRepository;
        }

        public async Task AddSalaryComponentAsync(SalaryComponentDTO salaryComponentDto)
        {
            var salaryComponent = new SalaryComponent
            {
                EmployeeId = salaryComponentDto.EmployeeId,
                ComponentName = salaryComponentDto.ComponentName,
                Amount = salaryComponentDto.Amount
            };

            await _salaryComponentRepository.AddAsync(salaryComponent);
        }
    }

}
