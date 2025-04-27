using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.dto_service
{
    public class EmailDTO
    {
        public string From { get; set; }
        public string Password { get; set; } // Mật khẩu ứng dụng
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; } = false; // Thêm thuộc tính IsHtml với giá trị mặc định là false
    }

}
