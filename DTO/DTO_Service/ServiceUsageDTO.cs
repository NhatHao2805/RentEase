using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO_Service
{
    public class ServiceUsageDTO
    {
        public string TenantID { get; set; }
        public string ServiceID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ServiceUsageDTO(string tenantID, string serviceID)
        {
            TenantID = tenantID;
            ServiceID = serviceID;
            StartDate = DateTime.Today;
            EndDate = StartDate.AddDays(30); // Mặc định 30 ngày sau
        }
    }

}
