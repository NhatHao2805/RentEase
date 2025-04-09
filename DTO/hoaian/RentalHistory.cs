using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RentalHistory
    {
        public string RoomId { get; set; }
        public string OldTenantId { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Convenient { get; set; }
        public string Area { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ReasonForLeaving { get; set; }
    }
}
