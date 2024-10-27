﻿using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
    public interface ISalaryComponentRepository
    {
        Task AddAsync(SalaryComponent salaryComponent);
        Task<List<SalaryComponent>> GetSalaryComponentsByEmployeeIdAsync(int employeeId);

    }
}
