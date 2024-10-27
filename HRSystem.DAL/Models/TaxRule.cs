using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Models
{
    public class TaxRule
    {
        public int TaxRuleId { get; set; }  // Primary Key
        public decimal MinSalary { get; set; }  // أقل راتب لتطبيق هذه الشريحة
        public decimal MaxSalary { get; set; }  // أعلى راتب لتطبيق هذه الشريحة
        public decimal TaxPercentage { get; set; }  // نسبة الضريبة لهذه الشريحة
    }
}
