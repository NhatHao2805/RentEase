using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Room
    {
        public string RoomId { get; set; }
        public string BuildingId { get; set; }
        public string Type { get; set; }
        public string Convenient { get; set; }
        public string Area { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public string LastMaintenanceDate { get; set; }
    }
}
