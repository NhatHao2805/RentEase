using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContractDTO
    {
       
            public string ContractID { get; set; }
            public string HouseID { get; set; }
            public string TenantID { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public float MonthlyRent { get; set; }
            public string PaymentSchedule { get; set; }
            public float Deposit { get; set; }
            public string Status { get; set; }
            public string Notes { get; set; }
            public bool AutoRenew { get; set; }
            public string TerminationReason { get; set; }
            public string ContractFilePath { get; set; }

            public ContractDTO(string contractID, string houseID, string tenantID, DateTime createDate,
                                DateTime startDate, DateTime endDate, float monthlyRent, string paymentSchedule,
                                float deposit, string status, string notes, bool autoRenew, string terminationReason,
                                string contractFilePath)
            {
                ContractID = contractID;
                HouseID = houseID;
                TenantID = tenantID;
                CreateDate = createDate;
                StartDate = startDate;
                EndDate = endDate;
                MonthlyRent = monthlyRent;
                PaymentSchedule = paymentSchedule;
                Deposit = deposit;
                Status = status;
                Notes = notes;
                AutoRenew = autoRenew;
                TerminationReason = terminationReason;
                ContractFilePath = contractFilePath;
            }
    }
}
