using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO_Service
{
    public class KhachHangDTO
    {
        public string ID { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string FullName => $"{Ho} {Ten}"; // Gộp họ tên để hiển thị
        public KhachHangDTO() { }
        public KhachHangDTO(string id, string ho, string ten)
        {
            ID = id;
            Ho = ho;
            Ten = ten;
        }
    }
    public class PhongDTO
    {
        public string ID { get; set; }

    }
    public class DichVuDTO
    {
        public string ID { get; set; }
        public string TenDichVu { get; set; }
        public decimal GiaDichVu { get; set; }

       
    }

}
