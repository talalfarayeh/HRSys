using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs
{
    public class LeaveBalanceDTO
    {
        public int TotalLeaves { get; set; }  // مجموع الإجازات السنوية
        public int UsedLeaves { get; set; }   // الإجازات التي تم استخدامها
        public int RemainingLeaves { get; set; }  // الإجازات المتبقية
    }
}
