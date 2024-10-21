using HR_System.BLL.DTOs.HR_System.BLL.DTOs;
using HR_System.BLL.Sarvices.Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
    public class PayrollPdfService : IPayrollPdfService
    {
        public byte[] GeneratePayrollPdf(PayrollDTO payroll)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, ms);
                document.Open();

                // Header
                document.Add(new Paragraph("Payroll Slip"));
                document.Add(new Paragraph($"Employee Name: {payroll.EmployeeFullName}"));
                document.Add(new Paragraph($"Basic Salary: {payroll.BasicSalary:C}"));
                document.Add(new Paragraph($"Bonus: {payroll.Bonus:C}"));
                document.Add(new Paragraph($"Deductions: {payroll.Deductions:C}"));
                document.Add(new Paragraph($"Net Salary: {payroll.NetSalary:C}"));
                document.Add(new Paragraph($"Payment Date: {payroll.PaymentDate.ToString("dd-MM-yyyy")}"));
                document.Add(new Paragraph($"Payment Status: {payroll.PaymentStatus}"));

                document.Close();
                return ms.ToArray();
            }
        }
    }
}
