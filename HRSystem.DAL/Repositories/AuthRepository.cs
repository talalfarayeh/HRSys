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
    public class AuthRepository : IAuthRepository

    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Employee GetEmployeeByUsernameAndPassword(string username, string passwordHash)
        {
            return _context.Employees
         .Include(e => e.EmployeeRoles)
             .ThenInclude(er => er.Role)
         .FirstOrDefault(e => e.Username == username && e.PasswordHash == passwordHash);

        }
    }
}
