﻿using HR_System.BLL.DTOs.HR_System.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
    public interface IPayrollPdfService
    {
        byte[] GeneratePayrollPdf(PayrollDTO payroll);
    }
}