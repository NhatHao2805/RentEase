using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.dal_service;
using DTO;
using DTO.dto_service;
namespace BLL.bll_service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DAL;
    using DTO;

    public class FeedbackBLL
    {
        // Đồng bộ dữ liệu từ Google Sheet vào Database
        public static bool SyncFeedbacksFromGoogleSheet()
        {
            try
            {
                // Lấy dữ liệu từ Google Sheet
                List<FeedbackDTO> googleSheetFeedbacks = FeedbackAccess.GetFeedbacksFromGoogleSheet();

                if (googleSheetFeedbacks == null || googleSheetFeedbacks.Count == 0)
                {
                    return false;
                }

                // Xóa toàn bộ dữ liệu feedback cũ trước khi thêm dữ liệu mới
                bool clearResult = FeedbackAccess.ClearAllFeedbacks();
                if (!clearResult)
                {
                    Console.WriteLine("Không thể xóa dữ liệu cũ!");
                    return false;
                }

                // Lọc và lưu vào database
                int successCount = 0;
                foreach (FeedbackDTO feedback in googleSheetFeedbacks)
                {
                    if (FeedbackAccess.SaveFeedbackToDatabase(feedback))
                    {
                        successCount++;
                    }
                }

                return successCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đồng bộ dữ liệu: " + ex.Message);
                return false;
            }
        }

        // Lấy tất cả phản hồi
        public static List<FeedbackDTO> GetAllFeedbacks()
        {
            return FeedbackAccess.GetAllFeedbacksFromDatabase();
        }

       
        // Thêm hàm lấy phản hồi theo ID tòa nhà
        public static List<FeedbackDTO> GetFeedbacksByBuildingID(string buildingID)
        {
            if (string.IsNullOrEmpty(buildingID))
            {
                return new List<FeedbackDTO>();
            }

            return FeedbackAccess.GetFeedbacksByBuildingID(buildingID);

        }
        // Cập nhật hàm lọc để thêm tham số buildingID
        public static List<FeedbackDTO> GetFeedbacksByFilter(string buildingID, string status, DateTime fromDate, DateTime toDate, string searchText)
        {
            if (string.IsNullOrEmpty(buildingID))
            {
                return new List<FeedbackDTO>();
            }

            return FeedbackAccess.GetFeedbacksByFilter(buildingID, status, fromDate, toDate, searchText);
        }
        // Lọc phản hồi theo trạng thái
        public static List<FeedbackDTO> GetFeedbacksByStatus(string status)
        {
            if (string.IsNullOrEmpty(status) || status == "Tất cả")
            {
                return FeedbackAccess.GetAllFeedbacksFromDatabase();
            }

            List<FeedbackDTO> allFeedbacks = FeedbackAccess.GetAllFeedbacksFromDatabase();
            return allFeedbacks.FindAll(f => f.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        // Cập nhật trạng thái phản hồi
        public static bool UpdateFeedbackStatus(string feedbackID, string status)
        {
            if (string.IsNullOrEmpty(feedbackID) || string.IsNullOrEmpty(status))
            {
                return false;
            }

            return FeedbackAccess.UpdateFeedbackStatus(feedbackID, status);
        }

        // Xuất dữ liệu ra Excel
        public static bool ExportToExcel(List<FeedbackDTO> feedbacks, string filePath)
        {
            try
            {
                // Sử dụng thư viện EPPlus hoặc NPOI để xuất Excel
                // Code xuất Excel

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xuất Excel: " + ex.Message);
                return false;
            }
        }

        // Tìm kiếm phản hồi
        public static List<FeedbackDTO> SearchFeedbacks(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return FeedbackAccess.GetAllFeedbacksFromDatabase();
            }

            List<FeedbackDTO> allFeedbacks = FeedbackAccess.GetAllFeedbacksFromDatabase();
            searchText = searchText.ToLower();

            return allFeedbacks.FindAll(f =>
                f.Content.ToLower().Contains(searchText) ||
                f.Email.ToLower().Contains(searchText));
        }
    }
    

}
