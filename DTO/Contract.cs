using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Contract
    {
       
            public string ContractID { get; set; }
            public string HouseID { get; set; }
            public string TenantID { get; set; }
            public string CreateDate { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string MonthlyRent { get; set; }
            public string PaymentSchedule { get; set; }
            public string Deposit { get; set; }
            public string Status { get; set; }
            public string Notes { get; set; }
            public string AutoRenew { get; set; }
            public string TerminationReason { get; set; }
            public string ContractFilePath { get; set; }
    }
}
