using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using DTO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System.IO;
using DTO.dto_service;

namespace DAL.dal_service
{



    public class FeedbackAccess
    {
        private static readonly string SPREADSHEET_ID = "1s84h8F8gtSzbUu_OlLDN4OlJavJDPymj-ogUz98yxGo";
        private static readonly string SHEET_NAME = "FormSheet";
        // Tên mặc định của Google Form

        //private static readonly string CREDENTIALS_PATH = "rentease.json"; // Đường dẫn tới file credentials

        //private static readonly string CREDENTIALS_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rentease.json");


        // Thêm dòng này:
        private static readonly string API_KEY = "AIzaSyDyyWZhohtKlFn-IiaUaJerF_xQeEoSpzI";
        // Khởi tạo Google Sheet Service
        private static SheetsService InitializeGoogleSheetService()
        {
            try
            {
                // Tạo service với API Key thay vì Service Account
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    ApiKey = API_KEY,
                    ApplicationName = "Rentease"
                });

                return service;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing Google Sheets API: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
                throw;
            }
        }
        // Thêm hàm lấy phản hồi theo ID tòa nhà
        // Trong FeedbackAccess (DAL)
        public static List<FeedbackDTO> GetFeedbacksByBuildingID(string buildingID)
        {
            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return feedbacks;

                try
                {
                    // Câu truy vấn JOIN nhiều bảng để lấy phản hồi theo tòa nhà
                    string query = @"SELECT f.*, t.FIRSTNAME, t.LASTNAME, t.EMAIL as TENANT_EMAIL, r.ROOMNAME, r.ROOMID 
                          FROM FEEDBACK f 
                          LEFT JOIN TENANT t ON f.TENANTID = t.TENANTID 
                          LEFT JOIN ROOM r ON f.ROOMID = r.ROOMID 
                          WHERE r.BUILDINGID = @buildingID 
                          AND f.ISDELETED = 0
                          ORDER BY f.DATESEND DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@buildingID", buildingID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FeedbackDTO feedback = new FeedbackDTO();

                                feedback.FeedbackID = reader["FEEDBACKID"].ToString();
                                feedback.TenantID = reader["TENANTID"] != DBNull.Value ? reader["TENANTID"].ToString() : null;
                                feedback.RoomID = reader["ROOMID"] != DBNull.Value ? reader["ROOMID"].ToString() : null;
                                feedback.Email = reader["EMAIL"].ToString();
                                feedback.HasFeedback = Convert.ToBoolean(reader["HAS_FEEDBACK"]);
                                feedback.Content = reader["CONTENT"].ToString();
                                feedback.DateSend = Convert.ToDateTime(reader["DATESEND"]);
                                feedback.Status = reader["STATUS"].ToString();

                                // Thêm thông tin về tenant và room
                                if (reader["FIRSTNAME"] != DBNull.Value && reader["LASTNAME"] != DBNull.Value)
                                {
                                    feedback.TenantName = reader["FIRSTNAME"].ToString() + " " + reader["LASTNAME"].ToString();
                                }
                                if (reader["ROOMNAME"] != DBNull.Value)
                                {
                                    feedback.RoomName = reader["ROOMNAME"].ToString();
                                }

                                feedbacks.Add(feedback);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi lấy dữ liệu feedback theo tòa nhà: " + ex.Message);
                }
            }

            return feedbacks;
        }
        // Lấy dữ liệu từ Google Sheet
        public static List<FeedbackDTO> GetFeedbacksFromGoogleSheet()
        {
            try
            {
                var service = InitializeGoogleSheetService();
                if (service == null)
                {
                    throw new Exception("Không thể kết nối với Google Sheets API");
                }

                // Định nghĩa phạm vi dữ liệu cần đọc (thêm cột ROOMID)
                string range = $"{SHEET_NAME}!A:E"; // Mở rộng range để đọc thêm cột ROOMID

                // Thực hiện request
                SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(SPREADSHEET_ID, range);

                // Nhận response
                ValueRange response = request.Execute();
                IList<IList<object>> values = response.Values;

                if (values == null || values.Count <= 1) // Bỏ qua hàng header
                {
                    return new List<FeedbackDTO>();
                }

                List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();

                // Lặp qua từng hàng, bắt đầu từ hàng thứ 2 (bỏ qua header)
                for (int i = 1; i < values.Count; i++)
                {
                    var row = values[i];

                    // Kiểm tra có đủ dữ liệu không
                    if (row.Count >= 5) // Đã thêm kiểm tra cột ROOMID
                    {
                        DateTime submitTime;
                        string rawTimeString = row[0]?.ToString() ?? "";

                        try
                        {
                            if (DateTime.TryParse(rawTimeString, out submitTime))
                            {
                                Console.WriteLine($"Parsed time successfully: {rawTimeString} -> {submitTime}");
                            }
                            else
                            {
                                string[] formats = { "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm", "MM/dd/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm" };
                                submitTime = DateTime.ParseExact(rawTimeString, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                                Console.WriteLine($"Parsed time with format: {rawTimeString} -> {submitTime}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Không thể parse thời gian '{rawTimeString}': {ex.Message}");
                            submitTime = DateTime.Now;
                            Console.WriteLine($"Using current time instead: {submitTime}");
                        }

                        // Cột B: Địa chỉ email
                        string email = row.Count > 1 ? row[1].ToString() : "";

                        // Cột C: Quý khách có hài lòng về dịch vụ của tòa nhà (Có/Không)
                        bool hasFeedback = row.Count > 2 && row[2].ToString().Equals("Có", StringComparison.OrdinalIgnoreCase);

                        // Cột D: Nội dung phản ánh/nhận xét
                        string content = row.Count > 3 ? row[3].ToString() : "";

                        // Cột E: ROOMID
                        string roomId = row.Count > 4 ? row[4].ToString() : "";

                        // Tạo feedback DTO
                        FeedbackDTO feedback = new FeedbackDTO
                        {
                            Email = email,
                            HasFeedback = hasFeedback,
                            Content = content,
                            DateSend = submitTime,
                            Status = "PENDING",
                            TenantID = null,
                            TenantName = "",
                            RoomID = roomId // Thêm ROOMID từ sheet
                        };

                        feedbacks.Add(feedback);
                        Console.WriteLine($"Sheet data: {email} - {content} - Time: {submitTime}");
                    }
                }

                // Sau khi lấy tất cả dữ liệu, tìm TenantID và TenantName cho mỗi phản hồi
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn != null)
                    {
                        foreach (var feedback in feedbacks)
                        {
                            feedback.TenantID = FindTenantIdByEmail(feedback.Email, conn);
                            feedback.TenantName = GetTenantNameById(feedback.TenantID, conn);
                        }
                    }
                }

                return feedbacks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc dữ liệu từ Google Sheets: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }        // Thêm phương thức lấy tên tenant từ ID
        private static string GetTenantNameById(string tenantId, MySqlConnection conn)
        {
            if (string.IsNullOrEmpty(tenantId) || conn == null)
                return "";

            try
            {
                string query = "SELECT FIRSTNAME, LASTNAME FROM TENANT WHERE TENANTID = @tenantId AND ISDELETED = 0";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenantId", tenantId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["FIRSTNAME"].ToString();
                            string lastName = reader["LASTNAME"].ToString();
                            return $"{firstName} {lastName}".Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy tên tenant: {ex.Message}");
            }

            return "";
        }
        //// Thêm phương thức lấy tên tenant từ ID
        //private static string GetTenantNameById(string tenantId, MySqlConnection conn)
        //{
        //    if (string.IsNullOrEmpty(tenantId) || conn == null)
        //        return "";

        //    try
        //    {
        //        string query = "SELECT FIRSTNAME, LASTNAME FROM TENANT WHERE TENANTID = @tenantId";

        //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@tenantId", tenantId);

        //            using (MySqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    string firstName = reader["FIRSTNAME"].ToString();
        //                    string lastName = reader["LASTNAME"].ToString();
        //                    return $"{firstName} {lastName}".Trim();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi lấy tên tenant: {ex.Message}");
        //    }

        //    return "";
        //}
        // Tìm Tenant ID dựa trên email
        private static string FindTenantIdByEmail(string email, MySqlConnection conn)
        {
            try
            {
                string query = "SELECT TENANTID FROM TENANT WHERE EMAIL = @email AND ISDELETED = 0 LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm TenantID: " + ex.Message);
            }

            return null;
        }

        // Lưu một phản hồi vào database
        public static bool SaveFeedbackToDatabase(FeedbackDTO feedback)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return false;

                try
                {
                    // Tìm TenantID dựa vào Email (nếu chưa có)
                    if (string.IsNullOrEmpty(feedback.TenantID))
                    {
                        feedback.TenantID = FindTenantIdByEmail(feedback.Email, conn);
                    }

                    // Tìm ROOMID dựa vào TenantID (nếu có)
                    string roomId = null;
                    if (!string.IsNullOrEmpty(feedback.TenantID))
                    {
                        roomId = FindRoomIdByTenantId(feedback.TenantID, conn);
                    }
                    else
                    {
                        // Nếu không có TenantID, sử dụng ROOMID mặc định
                        roomId = "R001";
                    }

                    // Tạo FeedbackID mới
                    string feedbackId = GenerateNewFeedbackID(conn);

                    Console.WriteLine($"Saving feedback with time: {feedback.DateSend} (ID: {feedbackId}, RoomID: {roomId})");

                    // Thêm phản hồi mới
                    string insertQuery = @"INSERT INTO FEEDBACK 
                        (FEEDBACKID, TENANTID, ROOMID, EMAIL, HAS_FEEDBACK, CONTENT, DATESEND, STATUS, ISDELETED) 
                        VALUES 
                        (@feedbackId, @tenantId, @roomId, @email, @hasFeedback, @content, @dateSend, @status, 0)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@feedbackId", feedbackId);
                        cmd.Parameters.AddWithValue("@tenantId", string.IsNullOrEmpty(feedback.TenantID) ? DBNull.Value : (object)feedback.TenantID);
                        cmd.Parameters.AddWithValue("@roomId", roomId); // Luôn có giá trị, không null
                        cmd.Parameters.AddWithValue("@email", feedback.Email);
                        cmd.Parameters.AddWithValue("@hasFeedback", feedback.HasFeedback);
                        cmd.Parameters.AddWithValue("@content", feedback.Content);
                        cmd.Parameters.AddWithValue("@dateSend", feedback.DateSend);
                        cmd.Parameters.AddWithValue("@status", feedback.Status);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Console.WriteLine($"Đã lưu feedback ID {feedbackId} với thời gian {feedback.DateSend}");
                        }

                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi lưu feedback: " + ex.Message);
                    return false;
                }
            }
        }

        // Thêm phương thức mới để tìm ROOMID từ TenantID
        private static string FindRoomIdByTenantId(string tenantId, MySqlConnection conn)
        {
            try
            {
                // Tìm ROOMID từ bảng CONTRACT thay vì TENANT_ROOM
                string query = @"SELECT ROOMID FROM CONTRACT 
                               WHERE TENANTID = @tenantId 
                               AND ISDELETED = 0 
                               AND (ENDDATE IS NULL OR ENDDATE >= CURDATE())
                               ORDER BY STARTDATE DESC 
                               LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenantId", tenantId);
                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }

                // Nếu không tìm thấy trong CONTRACT, thử tìm phòng mặc định
                query = "SELECT ROOMID FROM ROOM WHERE ISDELETED = 0 LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        Console.WriteLine($"Sử dụng ROOMID mặc định: {result}");
                        return result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm ROOMID: " + ex.Message);
            }

            return "R001"; // Trả về một ROOMID mặc định nếu không tìm thấy
        }

        public static bool SyncFeedbacksFromGoogleSheet()
        {
            try
            {
                Console.WriteLine("Bắt đầu đồng bộ dữ liệu từ Google Sheet");

                // Lấy dữ liệu từ Google Sheet
                List<FeedbackDTO> googleSheetFeedbacks = GetFeedbacksFromGoogleSheet();

                Console.WriteLine($"Đã lấy {googleSheetFeedbacks?.Count ?? 0} feedback từ Google Sheet");

                if (googleSheetFeedbacks == null || googleSheetFeedbacks.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu từ Google Sheet");
                    return false;
                }

                // Lấy danh sách feedback hiện có trong database
                List<FeedbackDTO> existingFeedbacks = GetAllFeedbacksFromDatabase();
                Console.WriteLine($"Đã lấy {existingFeedbacks.Count} feedback từ database");

                // Tạo dictionary lưu trạng thái hiện tại để dễ tìm kiếm
                Dictionary<string, string> existingStatusMap = new Dictionary<string, string>();

                foreach (var feedback in existingFeedbacks)
                {
                    // Tạo key duy nhất từ email và thời gian (giữ trạng thái)
                    string uniqueKey = $"{feedback.Email.Trim().ToLower()}_{feedback.DateSend.ToString("yyyyMMddHHmm")}";
                    existingStatusMap[uniqueKey] = feedback.Status;
                }

                int successCount = 0;

                // Xóa toàn bộ dữ liệu feedback cũ
                bool clearResult = ClearAllFeedbacks();
                if (!clearResult)
                {
                    Console.WriteLine("Không thể xóa dữ liệu cũ!");
                    return false;
                }

                // Thêm lại dữ liệu mới, nhưng giữ nguyên trạng thái cũ nếu có
                foreach (FeedbackDTO googleFeedback in googleSheetFeedbacks)
                {
                    string uniqueKey = $"{googleFeedback.Email.Trim().ToLower()}_{googleFeedback.DateSend.ToString("yyyyMMddHHmm")}";

                    // Nếu feedback này đã tồn tại, sử dụng trạng thái cũ
                    if (existingStatusMap.ContainsKey(uniqueKey))
                    {
                        googleFeedback.Status = existingStatusMap[uniqueKey];
                        Console.WriteLine($"Giữ nguyên trạng thái: {googleFeedback.Status} cho {googleFeedback.Email}");
                    }

                    if (SaveFeedbackToDatabase(googleFeedback))
                    {
                        successCount++;
                    }
                }

                Console.WriteLine($"Kết quả đồng bộ: {successCount} thành công");
                return successCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đồng bộ dữ liệu: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
                return false;
            }
        }

        public static bool ReplaceAllFeedbacks(List<FeedbackDTO> newFeedbacks)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return false;

                // Bắt đầu transaction
                MySqlTransaction transaction = null;
                try
                {
                    transaction = conn.BeginTransaction();

                    // Xóa tất cả feedback cũ
                    string deleteQuery = "UPDATE FEEDBACK SET ISDELETED = 1, DELETED_DATE = CURDATE()";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Thêm feedback mới
                    int successCount = 0;
                    foreach (FeedbackDTO feedback in newFeedbacks)
                    {
                        // Tìm TenantID dựa vào Email (nếu chưa có)
                        if (string.IsNullOrEmpty(feedback.TenantID))
                        {
                            feedback.TenantID = FindTenantIdByEmail(feedback.Email, conn);
                        }

                        // Tạo FeedbackID mới
                        string feedbackId = GenerateNewFeedbackID(conn, transaction);

                        // Thêm phản hồi mới
                        string insertQuery = @"INSERT INTO FEEDBACK 
                                    (FEEDBACKID, TENANTID, ROOMID, EMAIL, HAS_FEEDBACK, CONTENT, DATESEND, STATUS) 
                                    VALUES 
                                    (@feedbackId, @tenantId, @roomId, @email, @hasFeedback, @content, @dateSend, @status)";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@feedbackId", feedbackId);
                            cmd.Parameters.AddWithValue("@tenantId", string.IsNullOrEmpty(feedback.TenantID) ? DBNull.Value : (object)feedback.TenantID);
                            cmd.Parameters.AddWithValue("@roomId", string.IsNullOrEmpty(feedback.RoomID) ? DBNull.Value : (object)feedback.RoomID);
                            cmd.Parameters.AddWithValue("@email", feedback.Email);
                            cmd.Parameters.AddWithValue("@hasFeedback", feedback.HasFeedback);
                            cmd.Parameters.AddWithValue("@content", feedback.Content);
                            cmd.Parameters.AddWithValue("@dateSend", feedback.DateSend);
                            cmd.Parameters.AddWithValue("@status", feedback.Status);

                            int result = cmd.ExecuteNonQuery();
                            if (result > 0) successCount++;
                        }
                    }

                    // Nếu thành công, commit transaction
                    if (successCount > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, rollback transaction
                    if (transaction != null)
                    {
                        try { transaction.Rollback(); } catch { /* ignore */ }
                    }
                    Console.WriteLine("Lỗi khi thay thế dữ liệu feedback: " + ex.Message);
                    return false;
                }
            }
        }

        // Cập nhật hàm GenerateNewFeedbackID để hỗ trợ transaction
        private static string GenerateNewFeedbackID(MySqlConnection conn, MySqlTransaction transaction = null)
        {
            string prefix = "FB";
            int lastID = 0;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT MAX(CAST(SUBSTRING(FEEDBACKID, 3) AS UNSIGNED)) FROM FEEDBACK", conn, transaction))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        lastID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tạo FeedbackID: " + ex.Message);
            }

            return prefix + (lastID + 1).ToString("D3");
        }
        // Lấy tất cả phản hồi từ database
        public static List<FeedbackDTO> GetAllFeedbacksFromDatabase()
        {
            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return feedbacks;

                try
                {
                    string query = @"SELECT f.*, t.FIRSTNAME, t.LASTNAME 
                                  FROM FEEDBACK f 
                                  LEFT JOIN TENANT t ON f.TENANTID = t.TENANTID
                                  WHERE f.ISDELETED = 0
                                  ORDER BY f.DATESEND DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FeedbackDTO feedback = new FeedbackDTO();

                                feedback.FeedbackID = reader["FEEDBACKID"].ToString();
                                feedback.TenantID = reader["TENANTID"] != DBNull.Value ? reader["TENANTID"].ToString() : null;
                                feedback.Email = reader["EMAIL"].ToString();
                                feedback.HasFeedback = Convert.ToBoolean(reader["HAS_FEEDBACK"]);
                                feedback.Content = reader["CONTENT"].ToString();
                                feedback.DateSend = Convert.ToDateTime(reader["DATESEND"]);
                                feedback.Status = reader["STATUS"].ToString();

                                // Thêm thông tin về tenant nếu có
                                if (reader["FIRSTNAME"] != DBNull.Value && reader["LASTNAME"] != DBNull.Value)
                                {
                                    feedback.TenantName = reader["FIRSTNAME"].ToString() + " " + reader["LASTNAME"].ToString();
                                }

                                feedbacks.Add(feedback);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi lấy dữ liệu feedback: " + ex.Message);
                }
            }

            return feedbacks;
        }

        // Lấy phản hồi theo điều kiện lọc
        // Cập nhật hàm GetFeedbacksByFilter để thêm điều kiện lọc theo tòa nhà
        // Trong FeedbackDAL.cs
        public static List<FeedbackDTO> GetFeedbacksByFilter(string buildingID, string status, DateTime fromDate, DateTime toDate, string searchText)
        {
            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return feedbacks;

                try
                {
                    // Câu truy vấn đơn giản
                    string query = @"SELECT f.*, t.FIRSTNAME, t.LASTNAME, t.EMAIL as TENANT_EMAIL 
                          FROM FEEDBACK f 
                          LEFT JOIN TENANT t ON f.TENANTID = t.TENANTID 
                      WHERE f.DATESEND BETWEEN @fromDate AND @toDate AND f.ISDELETED = 0";

                    if (!string.IsNullOrEmpty(status) && status != "Tất cả")
                    {
                        query += "AND f.STATUS = @status ";
                    }

                    // Tìm kiếm đơn giản: bất kỳ trường nào chứa từ khóa
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        query += @"AND (
                    f.CONTENT LIKE @search 
                    OR f.EMAIL LIKE @search 
                    OR t.EMAIL LIKE @search 
                    OR t.FIRSTNAME LIKE @search 
                    OR t.LASTNAME LIKE @search 
                    OR CONCAT(t.FIRSTNAME, ' ', t.LASTNAME) LIKE @search
                ) ";
                    }

                    query += "ORDER BY f.DATESEND DESC";

                    Console.WriteLine($"Debug - Query: {query}");

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate.AddDays(1).AddSeconds(-1));

                        if (!string.IsNullOrEmpty(status) && status != "Tất cả")
                        {
                            cmd.Parameters.AddWithValue("@status", status);
                        }

                        if (!string.IsNullOrEmpty(searchText))
                        {
                            // Tìm kiếm không phân biệt chữ hoa/thường
                            cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                            Console.WriteLine($"Debug - Search parameter: %{searchText}%");
                        }

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FeedbackDTO feedback = new FeedbackDTO();

                                feedback.FeedbackID = reader["FEEDBACKID"].ToString();
                                feedback.TenantID = reader["TENANTID"] != DBNull.Value ? reader["TENANTID"].ToString() : null;
                                feedback.Email = reader["EMAIL"].ToString();
                                feedback.HasFeedback = Convert.ToBoolean(reader["HAS_FEEDBACK"]);
                                feedback.Content = reader["CONTENT"].ToString();
                                feedback.DateSend = Convert.ToDateTime(reader["DATESEND"]);
                                feedback.Status = reader["STATUS"].ToString();

                                // Thêm thông tin về tenant nếu có
                                if (reader["FIRSTNAME"] != DBNull.Value && reader["LASTNAME"] != DBNull.Value)
                                {
                                    feedback.TenantName = reader["FIRSTNAME"].ToString() + " " + reader["LASTNAME"].ToString();
                                }
                                else
                                {
                                    feedback.TenantName = "Không xác định";
                                }

                                feedbacks.Add(feedback);
                                Console.WriteLine($"Debug - Added feedback: {feedback.FeedbackID}, Name: {feedback.TenantName}");
                            }
                        }
                    }

                    Console.WriteLine($"Debug - Total feedbacks found: {feedbacks.Count}");
                    return feedbacks;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi lấy dữ liệu feedback theo filter: " + ex.Message);
                    Console.WriteLine("Stack trace: " + ex.StackTrace);
                    return new List<FeedbackDTO>();
                }
            }
        }
        // Xóa toàn bộ dữ liệu feedback
        public static bool ClearAllFeedbacks()
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return false;

                try
                {
                    // Thực hiện câu truy vấn DELETE
                    string query = "UPDATE FEEDBACK SET ISDELETED = 1, DELETED_DATE = CURDATE()";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int result = cmd.ExecuteNonQuery();
                        // Thành công nếu câu lệnh thực thi không lỗi
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi xóa dữ liệu feedback: " + ex.Message);
                    return false;
                }
            }
        }
        // Cập nhật trạng thái phản hồi
        public static bool UpdateFeedbackStatus(string feedbackID, string status)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return false;

                try
                {
                    string query = "UPDATE FEEDBACK SET STATUS = @status WHERE FEEDBACKID = @feedbackId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@feedbackId", feedbackID);
                        cmd.Parameters.AddWithValue("@status", status);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi cập nhật trạng thái: " + ex.Message);
                    return false;
                }
            }
        }

        // Tạo ID mới cho phản hồi
        private static string GenerateNewFeedbackID(MySqlConnection conn)
        {
            string prefix = "FB";
            int lastID = 0;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT MAX(CAST(SUBSTRING(FEEDBACKID, 3) AS UNSIGNED)) FROM FEEDBACK", conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        lastID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tạo FeedbackID: " + ex.Message);
            }

            return prefix + (lastID + 1).ToString("D3");
        }

        // Trong FeedbackAccess (DAL)
        public static bool UpdateFeedbackContent(FeedbackDTO feedback)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null)
                {
                    Console.WriteLine("Không thể kết nối database");
                    return false;
                }

                try
                {
                    Console.WriteLine($"Cập nhật nội dung feedback ID: {feedback.FeedbackID}");

                    // Kiểm tra feedback ID có tồn tại không
                    string checkQuery = "SELECT COUNT(*) FROM FEEDBACK WHERE FEEDBACKID = @feedbackId AND ISDELETED = 0";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@feedbackId", feedback.FeedbackID);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count == 0)
                        {
                            Console.WriteLine($"Không tìm thấy feedback ID: {feedback.FeedbackID}");
                            return false;
                        }
                    }

                    // Cập nhật nội dung feedback nhưng giữ nguyên trạng thái
                    string updateQuery = @"UPDATE FEEDBACK 
                    SET CONTENT = @content, HAS_FEEDBACK = @hasFeedback 
                    WHERE FEEDBACKID = @feedbackId";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@feedbackId", feedback.FeedbackID);
                        cmd.Parameters.AddWithValue("@content", feedback.Content);
                        cmd.Parameters.AddWithValue("@hasFeedback", feedback.HasFeedback);

                        int result = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Kết quả cập nhật: {result} dòng thay đổi");
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi cập nhật nội dung feedback: " + ex.Message);
                    Console.WriteLine("Stack trace: " + ex.StackTrace);
                    return false;
                }
            }
        }


    }
}