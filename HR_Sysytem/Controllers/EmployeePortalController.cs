using HR_System.BLL.DTOs;
using HR_System.BLL.Sarvices;
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePortalController : ControllerBase
    {
        private readonly IPayrollService _payrollService;
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly IBenefitService _benefitService;
        private readonly IEmployeeService _employeeService;

        public EmployeePortalController(
            IPayrollService payrollService,
            ILeaveRequestService leaveRequestService,
            IBenefitService benefitService,
            IEmployeeService employeeService)
        {
            _payrollService = payrollService;
            _leaveRequestService = leaveRequestService;
            _benefitService = benefitService;
            _employeeService = employeeService;
        }
        [HttpGet("{employeeId}/leave-balance")]
        public async Task<IActionResult> GetLeaveBalance(int employeeId)
        {
            var leaveBalance = await _leaveRequestService.GetLeaveBalanceAsync(employeeId);
            return Ok(leaveBalance);
        }
        [HttpGet("{employeeId}/payroll-history")]
        public async Task<IActionResult> GetPayrollHistory(int employeeId)
        {
            var payrollHistory = await _payrollService.GetPayrollHistoryAsync(employeeId);
            return Ok(payrollHistory);
        }
        [HttpGet("{employeeId}/benefits")]
        public async Task<IActionResult> GetEmployeeBenefits(int employeeId)
        {
            var benefits = await _benefitService.GetEmployeeBenefitsAsync(employeeId);
            return Ok(benefits);
        }
        [HttpPut("{employeeId}/update-info")]
        public  IActionResult UpdateEmployeePersonalInfo(int employeeId, [FromForm] EmployeeDTO employeeDTO)
        {
              _employeeService.UpdateEmployee(employeeId, employeeDTO);
            return Ok("Employee personal information updated successfully.");
        }
    }
}
