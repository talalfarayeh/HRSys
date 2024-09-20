using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
     public interface IAuthRepository
    {
        Employee GetEmployeeByUsernameAndPassword(string username, string passwordHash);
    }
}
