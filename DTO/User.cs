using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Birth { get; set; }  // Lưu ý: sẽ khó xử lý ngày tháng
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
