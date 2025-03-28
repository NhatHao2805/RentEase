using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Quanlyphuongtien
{
    public class ParkingArea
    {
        public string AreaId { get; set; }
        public string BuildingId { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
    }
} 