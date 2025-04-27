using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.dto_service
{

    public class FeedbackDTO
    {
        public string FeedbackID { get; set; }
        public string TenantID { get; set; }
        public string Email { get; set; }
        public bool HasFeedback { get; set; }
        public string Content { get; set; }
        public DateTime DateSend { get; set; }
        public string Status { get; set; }

        // Thêm các trường phụ để hiển thị thông tin bổ sung trên form
        public string TenantName { get; set; }        // Tên người thuê (nếu có)
        public string FormattedDateSend { get; set; } // Ngày gửi định dạng đẹp
        public string StatusDescription                // Mô tả trạng thái
        {
            get
            {
                return Status == "PENDING" ? "Chưa xử lý" : "Đã xử lý";
            }
        }

        // Constructor mặc định
        public FeedbackDTO() { }

        // Constructor đầy đủ tham số
        public FeedbackDTO(string feedbackID, string tenantID, string email,
                            bool hasFeedback, string content,
                            DateTime dateSend, string status)
        {
            FeedbackID = feedbackID;
            TenantID = tenantID;
            Email = email;
            HasFeedback = hasFeedback;
            Content = content;
            DateSend = dateSend;
            Status = status;
            FormattedDateSend = dateSend.ToString("dd/MM/yyyy HH:mm");
        }
    }


}
