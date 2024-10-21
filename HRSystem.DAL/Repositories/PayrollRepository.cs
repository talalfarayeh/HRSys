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
   public class PayrollRepository : IPayrollRepository
{
    private readonly ApplicationDbContext _context;

    public PayrollRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddPayrollAsync(Payroll payroll)
    {
        await _context.Payrolls.AddAsync(payroll);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Payroll>> GetPayrollHistoryByEmployeeIdAsync(int employeeId)
    {
        return await _context.Payrolls
            .Where(p => p.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task<Payroll> GetPayrollByIdAsync(int payrollId)
    {
            return await _context.Payrolls
            .Include(p => p.Employee)
            .FirstOrDefaultAsync(p => p.PayrollId == payrollId);
        }

    public async Task ApprovePayrollAsync(int payrollId)
    {
        var payroll = await GetPayrollByIdAsync(payrollId);
        if (payroll == null) throw new Exception("Payroll not found");

        payroll.PaymentStatus = "Completed";
        await _context.SaveChangesAsync();
    }
}
}
