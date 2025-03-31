using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Quanlyphuongtien
{
    class Payment
    {
        public string PaymentId { get; set; }
        public string BillId { get; set; }
        public string Method { get; set; }
        public float Total { get; set; }
        public float PaymentTime { get; set; }
    }
}
