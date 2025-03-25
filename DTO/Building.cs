using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Building
    {
        public string BuildingId { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public int NumOfFloors { get; set; }
        public int NumOfRooms { get; set; }
    }
}
