using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
    public interface INotificationService
    {
        Task NotifyManager(int employeeId, string message);
        Task NotifyEmployee(int employeeId, string message);


    }
}
