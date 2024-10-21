using HRSystem.DAL.Date;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories
{
    public class BenefitRepository : IBenefitRepository
    {
        private readonly ApplicationDbContext _context;

        public BenefitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Benefit>> GetAllBenefitsAsync()
        {
           return await _context.Benefits.ToListAsync();
        }

        public async Task<Benefit> GetBenefitByIdAsync(int benefitId)
        {
            return await _context.Benefits.FindAsync(benefitId);
        }
        public async Task AddBenefitAsync(Benefit benefit)
        { 
            await _context.Benefits.AddAsync(benefit);
            await _context.SaveChangesAsync();  
        }

        public async Task UpdateBenefitAsync(Benefit benefit)
        {
           _context.Benefits.Update(benefit);
            await _context.SaveChangesAsync();
        }
    }
}
