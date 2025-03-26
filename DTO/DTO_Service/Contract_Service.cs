using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO_Service
{
    class Contract_Service
    {
        public string ContractID { get; set; }
        public string RoomID { get; set; }
        public string TenantID { get; set; }
    }
    public class ServiceDTO
    {
        public string RoomId { get; set; }
        public string TenantName { get; set; }
        public string ServiceName { get; set; }
        public decimal UnitPrice { get; set; }
    }
    
}
