using HR_System.BLL.DTOs.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
    public interface IComplianceReportService
    {
        Task<List<PayrollReportDTO>> GenerateYearEndTaxReportAsync(int year);
    }
}
