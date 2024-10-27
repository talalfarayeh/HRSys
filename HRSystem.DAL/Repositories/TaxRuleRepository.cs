using HRSystem.DAL.Date;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories
{
    public class TaxRuleRepository : ITaxRuleRepository
    {
        private readonly ApplicationDbContext _context;

        public TaxRuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaxRule> GetTaxRuleForSalaryAsync(decimal salary)
        {
            return await _context.TaxRules
                .Where(tr => salary >= tr.MinSalary && salary <= tr.MaxSalary)
                .FirstOrDefaultAsync();
        }
    }
}
