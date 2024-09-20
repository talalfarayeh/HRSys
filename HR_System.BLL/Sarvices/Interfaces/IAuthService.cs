using HR_System.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
    public interface IAuthService
    {
        EmployeeDTO Authenticate(string username, string password);
    }
}
