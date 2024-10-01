using HR_System.BLL.Sarvices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
    public class NotificationService : INotificationService
    {
        public async Task NotifyManager(int employeeId, string message)
        { 
            Console.WriteLine($"Notification sent to Manager for Employee ID: {employeeId} - {message}");
            await Task.CompletedTask;
        }

        public async Task NotifyEmployee(int employeeId, string message)
        {
            
            Console.WriteLine($"Notification sent to Employee ID: {employeeId} - {message}");
            await Task.CompletedTask;
        }
    }
}
