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
                // Lấy dữ liệu từ Google Sheet và đồng bộ vào cơ sở dữ liệu
                return FeedbackAccess.SyncFeedbacksFromGoogleSheet();
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
        // Trong FeedbackBLL
        public static List<FeedbackDTO> GetFeedbacksByBuildingID(string buildingID)
        {
            if (string.IsNullOrEmpty(buildingID))
            {
                return new List<FeedbackDTO>();
            }

            // QUAN TRỌNG: Chỉ lấy dữ liệu từ DATABASE, không đồng bộ
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

        // Trong FeedbackBLL
        // Trong FeedbackBLL
        // Trong FeedbackBLL
        public static (bool success, List<FeedbackDTO> syncedFeedbacks, int newCount) SyncFeedbacksFromGoogleSheetAndReturn()
        {
            try
            {
                Console.WriteLine("Bắt đầu đồng bộ dữ liệu từ Google Sheet");

                // Lấy dữ liệu từ Google Sheet
                List<FeedbackDTO> googleSheetFeedbacks = FeedbackAccess.GetFeedbacksFromGoogleSheet();

                Console.WriteLine($"Đã lấy {googleSheetFeedbacks?.Count ?? 0} feedback từ Google Sheet");

                if (googleSheetFeedbacks == null || googleSheetFeedbacks.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu từ Google Sheet");
                    return (false, null, 0);
                }

                // In log thời gian từ Google Sheet để kiểm tra
                foreach (var feedback in googleSheetFeedbacks)
                {
                    Console.WriteLine($"Sheet data: {feedback.Email} - {feedback.Content} - Time: {feedback.DateSend}");
                }

                // Lấy danh sách feedback hiện có trong database
                List<FeedbackDTO> existingFeedbacks = FeedbackAccess.GetAllFeedbacksFromDatabase();
                Console.WriteLine($"Đã lấy {existingFeedbacks.Count} feedback từ database");

                // Tạo HashSet để kiểm tra trùng lặp
                HashSet<string> existingFeedbackKeys = new HashSet<string>();

                foreach (var feedback in existingFeedbacks)
                {
                    // Tạo key duy nhất từ email và nội dung
                    string uniqueKey = $"{feedback.Email?.Trim().ToLower() ?? ""}|{feedback.Content?.Trim() ?? ""}";
                    existingFeedbackKeys.Add(uniqueKey);

                    Console.WriteLine($"Existing feedback: {uniqueKey} - Time: {feedback.DateSend}");
                }

                // Lọc chỉ lấy feedback từ khách hàng có hợp đồng đang có hiệu lực
                // Chỉ lưu những feedback có TenantID và đang có hợp đồng hiệu lực
                List<FeedbackDTO> validFeedbacks = new List<FeedbackDTO>();
                foreach (var feedback in googleSheetFeedbacks)
                {
                    // Kiểm tra xem người dùng này có TenantID không
                    if (!string.IsNullOrEmpty(feedback.TenantID))
                    {
                        // Kiểm tra xem tenant này có hợp đồng hợp lệ không
                        bool hasTenantWithContract = FeedbackAccess.HasValidContract(feedback.TenantID);
                        if (hasTenantWithContract)
                        {
                            validFeedbacks.Add(feedback);
                            Console.WriteLine($"Valid feedback from tenant with contract: {feedback.Email}");
                        }
                        else
                        {
                            Console.WriteLine($"Skipping feedback from tenant without active contract: {feedback.Email}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Skipping feedback without tenantID: {feedback.Email}");
                    }
                }

                Console.WriteLine($"Có {validFeedbacks.Count}/{googleSheetFeedbacks.Count} feedback hợp lệ từ khách hàng có hợp đồng");

                // Danh sách feedback mới (không trùng lặp)
                List<FeedbackDTO> newFeedbacks = new List<FeedbackDTO>();

                // Kiểm tra từng feedback hợp lệ
                foreach (var feedback in validFeedbacks)
                {
                    // Tạo key tương tự để kiểm tra trùng lặp
                    string uniqueKey = $"{feedback.Email?.Trim().ToLower() ?? ""}|{feedback.Content?.Trim() ?? ""}";

                    // Kiểm tra nếu đã tồn tại trong database
                    if (existingFeedbackKeys.Contains(uniqueKey))
                    {
                        Console.WriteLine($"Duplicate found: {uniqueKey} - Skipping");
                    }
                    else
                    {
                        Console.WriteLine($"New feedback found: {uniqueKey} - Adding with time: {feedback.DateSend}");
                        newFeedbacks.Add(feedback);
                    }
                }

                Console.WriteLine($"Phát hiện {newFeedbacks.Count} feedback mới cần thêm vào database");

                // Nếu không có dữ liệu mới, trả về danh sách hiện tại
                if (newFeedbacks.Count == 0)
                {
                    Console.WriteLine("Không có feedback mới để thêm");
                    return (false, existingFeedbacks, 0);
                }

                // Thêm các feedback mới vào database
                int successCount = 0;
                foreach (var feedback in newFeedbacks)
                {
                    Console.WriteLine($"Saving new feedback: {feedback.Email} - Time: {feedback.DateSend}");
                    if (FeedbackAccess.SaveFeedbackToDatabase(feedback))
                    {
                        successCount++;
                    }
                }

                Console.WriteLine($"Đã thêm thành công {successCount}/{newFeedbacks.Count} feedback mới");

                // Lấy lại danh sách cập nhật từ database
                List<FeedbackDTO> updatedFeedbacks = FeedbackAccess.GetAllFeedbacksFromDatabase();

                return (successCount > 0, updatedFeedbacks, successCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đồng bộ dữ liệu: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        // Hàm helper để tạo key duy nhất cho mỗi feedback
        private static string GetUniqueKey(FeedbackDTO feedback)
        {
            // Chuẩn hóa các trường dữ liệu trước khi tạo key
            string email = (feedback.Email ?? "").Trim().ToLower();
            string name = (feedback.TenantName ?? "").Trim().ToLower();
            string content = (feedback.Content ?? "").Trim();
            string date = feedback.DateSend.ToString("yyyy-MM-dd HH:mm");

            // Tạo key từ các thông tin chuẩn hóa
            return $"{email}|{name}|{content}|{date}";
        }


    }


}
