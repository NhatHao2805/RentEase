using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO_Service
{
    public class UserServiceDTO
    {
        public int STT { get; set; }
        public string RoomID { get; set; }
        public string RoomName { get; set; }
        public string TenantName { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
        //public DateTime Start {  get; set; }
        //public DateTime End { get; set; }
        // Thuộc tính chỉ đọc để lấy ngày đã định dạng
        // Sửa trong lớp UserServiceDTO
        public string StartedDay { get; set; } // Thêm setter
        public string EndDay { get; set; } // Thêm setter
    }
}
