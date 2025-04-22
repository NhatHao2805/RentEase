// BLL/FingerprintBLL.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO;

using SourceAFIS.Simple;
//using OpenCvSharp;


//using OpenCvSharp.Extensions;
//using Cv = OpenCvSharp;
//using SD = System.Drawing;




namespace BLL
{
    public class FingerprintBLL
    {
        // Lấy danh sách vân tay đã đăng ký theo người dùng
        public DataTable GetFingerprintsList(string username)
        {
            // Kiểm tra thông tin đầu vào
            if (string.IsNullOrEmpty(username))
                return null;

            return FingerprintAccess.GetFingerprints(username);
        }

        // Đăng ký vân tay mới bằng cách tải ảnh
        public string EnrollFingerprint(string username, string tenantID, string areaPermission, string fingerprintImagePath)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(tenantID))
                    return "Thông tin không hợp lệ";

                if (string.IsNullOrEmpty(fingerprintImagePath) || !File.Exists(fingerprintImagePath))
                    return "Không tìm thấy ảnh vân tay";

                // Đọc dữ liệu ảnh vào byte array
                byte[] imageData = File.ReadAllBytes(fingerprintImagePath);

                // Tạo đối tượng FingerprintDTO
                FingerprintDTO fingerprint = new FingerprintDTO
                {
                    Username = username,
                    TenantID = tenantID,
                    AreaPermission = areaPermission,
                    EnrollmentDate = DateTime.Now,
                    FingerprintImage = imageData,
                    ImageName = Path.GetFileName(fingerprintImagePath)
                };

                // Lưu thông tin vân tay vào database
                bool result = FingerprintAccess.AddFingerprint(fingerprint);

                if (!result)
                    return "Đã xảy ra lỗi khi lưu thông tin vân tay";

                return "Đăng ký vân tay thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        // Xóa vân tay 
        public string DeleteFingerprint(string fingerprintID)
        {
            try
            {
                if (string.IsNullOrEmpty(fingerprintID))
                    return "ID vân tay không hợp lệ";

                bool result = FingerprintAccess.DeleteFingerprint(fingerprintID);

                if (!result)
                    return "Không thể xóa vân tay";

                return "Đã xóa vân tay thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        // Cập nhật quyền truy cập khu vực
        public string UpdateAccessPermission(string fingerprintID, string areaPermission)
        {
            try
            {
                if (string.IsNullOrEmpty(fingerprintID))
                    return "ID vân tay không hợp lệ";

                bool result = FingerprintAccess.UpdateAreaPermission(fingerprintID, areaPermission);

                if (!result)
                    return "Không thể cập nhật quyền truy cập";

                return "Đã cập nhật quyền truy cập thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        // Thêm khu vực mới
        public bool AddArea(string buildingID, string areaName, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(buildingID) || string.IsNullOrEmpty(areaName))
                    return false;

                return FingerprintAccess.AddArea(buildingID, areaName, description);
            }
            catch (Exception ex)
            {
                LogError("AddArea", ex.Message);
                return false;
            }
        }

        // Cập nhật thông tin khu vực
        public bool UpdateArea(string areaID, string areaName, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(areaID) || string.IsNullOrEmpty(areaName))
                    return false;

                return FingerprintAccess.UpdateArea(areaID, areaName, description);
            }
            catch (Exception ex)
            {
                LogError("UpdateArea", ex.Message);
                return false;
            }
        }

        // Xóa khu vực
        public bool DeleteArea(string areaID)
        {
            try
            {
                if (string.IsNullOrEmpty(areaID))
                    return false;

                return FingerprintAccess.DeleteArea(areaID);
            }
            catch (Exception ex)
            {
                LogError("DeleteArea", ex.Message);
                return false;
            }
        }
        // Cập nhật ảnh vân tay
        public string UpdateFingerprintImage(string fingerprintID, string newImagePath)
        {
            try
            {
                if (string.IsNullOrEmpty(fingerprintID))
                    return "ID vân tay không hợp lệ";

                if (string.IsNullOrEmpty(newImagePath) || !File.Exists(newImagePath))
                    return "Không tìm thấy ảnh vân tay mới";

                // Đọc dữ liệu ảnh mới vào byte array
                byte[] imageData = File.ReadAllBytes(newImagePath);
                string imageName = Path.GetFileName(newImagePath);

                // Cập nhật ảnh vân tay trong database
                bool result = FingerprintAccess.UpdateFingerprintImage(fingerprintID, imageData, imageName);

                if (!result)
                    return "Không thể cập nhật ảnh vân tay";

                return "Đã cập nhật ảnh vân tay thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        // Lấy ảnh vân tay
        // Lấy ảnh vân tay
        public Image GetFingerprintImage(string fingerprintID)
        {
            try
            {
                byte[] imageData = FingerprintAccess.GetFingerprintImage(fingerprintID);

                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        return Image.FromStream(ms);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting fingerprint image: {ex.Message}");
                return null;
            }
        }

        // Lấy danh sách người thuê
        // BLL/FingerprintBLL.cs
        public List<TenantDTO> GetTenants(string username, string buildingID)
        {
            return FingerprintAccess.GetTenantsByUsername(username, buildingID);
        }

        // Lấy danh sách khu vực có thể truy cập
        public List<AreaPermissionDTO> GetAvailableAreas(string buildingID)
        {
            return FingerprintAccess.GetAvailableAreas(buildingID);
        }

       




        public bool VerifyFingerprintFromImage(string fingerprintID, string testImagePath)
        {
            try
            {
                if (string.IsNullOrEmpty(fingerprintID) || string.IsNullOrEmpty(testImagePath))
                    return false;

                // Lấy dữ liệu vân tay từ database
                byte[] storedFingerprintData = FingerprintAccess.GetFingerprintImageData(fingerprintID);

                Console.WriteLine($"Retrieved image data size: {storedFingerprintData?.Length ?? 0} bytes");

                if (storedFingerprintData == null || storedFingerprintData.Length == 0)
                    return false;

                // THÊM CHẾ ĐỘ KIỂM TRA CHỈ DÀNH CHO KIỂM TRA (CHO TEST/DEBUG)
                // So sánh đường dẫn ảnh test với tên ảnh đang lưu trong database
                string storedImageName = FingerprintAccess.GetFingerprintImageName(fingerprintID);
                string testImageName = Path.GetFileName(testImagePath);
                // Lưu ảnh để kiểm tra
                if (storedFingerprintData != null && storedFingerprintData.Length > 0)
                {
                    try
                    {
                        string debugFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Debug");
                        if (!Directory.Exists(debugFolder))
                            Directory.CreateDirectory(debugFolder);

                        File.WriteAllBytes(Path.Combine(debugFolder, "stored_image.png"), storedFingerprintData);
                        File.Copy(testImagePath, Path.Combine(debugFolder, "test_image.png"), true);
                    }
                    catch
                    {

                    }
                }
                // Nếu chỉ cần so sánh tên file (cho mục đích test)
                //if (!string.IsNullOrEmpty(storedImageName) && storedImageName.Equals(testImageName, StringComparison.OrdinalIgnoreCase))
                //{
                //    Console.WriteLine("Matched by filename comparison!");
                //    return true;
                //}

                // Nếu phương thức trên không khớp, tiếp tục xử lý bằng SourceAFIS
                Person storedPerson = new Person();
                Fingerprint storedFingerprint = new Fingerprint();

                // Chuyển đổi dữ liệu byte[] thành hình ảnh
                using (MemoryStream ms = new MemoryStream(storedFingerprintData))


                using (Bitmap storedBitmap = new Bitmap(ms))
                {
                    // Tiền xử lý ảnh để cải thiện chất lượng
                    Bitmap enhancedBitmap = EnhanceFingerprintImage(storedBitmap);

                    // Thiết lập hình ảnh cho vân tay lưu trữ
                    storedFingerprint.AsBitmap = enhancedBitmap;
                    storedPerson.Fingerprints.Add(storedFingerprint);
                }

                // Tạo person object cho vân tay kiểm tra
                Person candidatePerson = new Person();
                Fingerprint candidateFingerprint = new Fingerprint();

                // Đọc hình ảnh kiểm tra
                using (Bitmap candidateBitmap = new Bitmap(testImagePath))
                {
                    // Tiền xử lý ảnh để cải thiện chất lượng
                    Bitmap enhancedBitmap = EnhanceFingerprintImage(candidateBitmap);

                    // Thiết lập hình ảnh cho vân tay kiểm tra
                    candidateFingerprint.AsBitmap = enhancedBitmap;
                    candidatePerson.Fingerprints.Add(candidateFingerprint);
                }





                // Tạo đối tượng so khớp vân tay
                AfisEngine afis = new AfisEngine();

                // Thiết lập các tham số cho thuật toán - THỬ GIẢM NGƯỠNG XUỐNG
                afis.Threshold = 12; // Giảm ngưỡng xuống thấp hơn (mặc định là 25)
                afis.MinMatches = 15; // Giảm số lượng điểm khớp tối thiểu
                afis.Dpi = 500; // Thiết lập DPI cho ảnh vân tay
                // Thử không dùng EnhanceFingerprintImage

                // Trích xuất đặc trưng từ cả hai vân tay
                afis.Extract(storedPerson);
                afis.Extract(candidatePerson);


                // Xác thực vân tay
                float matchScore = afis.Verify(candidatePerson, storedPerson);

                bool isMatch = matchScore >= afis.Threshold;

                // Ghi log kết quả xác thực
                Console.WriteLine($"Fingerprint verification score: {matchScore}, Threshold: {afis.Threshold}, Result: {isMatch}");

                LogFingerprintVerification(fingerprintID, testImagePath, isMatch, matchScore);

                Console.WriteLine($"Fingerprint verification result: {isMatch}");
                return isMatch;
            }

            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                string errorMessage = $"Error verifying fingerprint: {ex.Message}";
                Console.WriteLine(errorMessage);
                LogError("VerifyFingerprintFromImage", errorMessage);

                return false;
            }
        }
        //public bool VerifyFingerprintFromImage(string fingerprintID, string testImagePath)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(fingerprintID) || string.IsNullOrEmpty(testImagePath))
        //            return false;

            //        // Lấy dữ liệu vân tay từ database
            //        byte[] storedFingerprintData = FingerprintAccess.GetFingerprintImageData(fingerprintID);

            //        Console.WriteLine($"Retrieved image data size: {storedFingerprintData?.Length ?? 0} bytes");

            //        if (storedFingerprintData == null || storedFingerprintData.Length == 0)
            //            return false;

            //        // Lưu ảnh để kiểm tra
            //        SaveDebugImages(storedFingerprintData, testImagePath);

            //        // --- CẢI TIẾN: Tính toán chất lượng ảnh vân tay ---
            //        double storedImageQuality = CalculateImageQuality(storedFingerprintData);
            //        double testImageQuality;
            //        using (Bitmap testBitmap = new Bitmap(testImagePath))
            //        {
            //            testImageQuality = CalculateImageQuality(testBitmap);
            //        }

            //        // --- CẢI TIẾN: Sử dụng ngưỡng động dựa trên chất lượng ảnh ---
            //        double qualityFactor = Math.Min(storedImageQuality, testImageQuality) / 100.0;
            //        int dynamicThreshold = (int)(20 + (10 * (1 - qualityFactor))); // 20-30 dựa vào chất lượng
            //        int dynamicMinMatches = (int)(8 + (4 * (1 - qualityFactor)));  // 8-12 dựa vào chất lượng

            //        // Tạo đối tượng Person và Fingerprint cho ảnh đã lưu
            //        Person storedPerson = new Person();
            //        Fingerprint storedFingerprint = new Fingerprint();

            //        // --- CẢI TIẾN: Thêm thông tin fingerprint class ---
            //        FingerprintClass storedClass = FingerprintClass.Unknown;

            //        // Chuyển đổi dữ liệu byte[] thành hình ảnh
            //        using (MemoryStream ms = new MemoryStream(storedFingerprintData))
            //        using (Bitmap storedBitmap = new Bitmap(ms))
            //        {
            //            // --- CẢI TIẾN: Nâng cao tiền xử lý ảnh ---
            //            Bitmap enhancedBitmap = EnhancedPreprocessing(storedBitmap);

            //            // --- CẢI TIẾN: Phân loại vân tay ---
            //            storedClass = ClassifyFingerprint(enhancedBitmap);

            //            // Thiết lập hình ảnh cho vân tay lưu trữ
            //            storedFingerprint.AsBitmap = enhancedBitmap;
            //            storedPerson.Fingerprints.Add(storedFingerprint);
            //        }

            //        // Tạo person object cho vân tay kiểm tra
            //        Person candidatePerson = new Person();
            //        Fingerprint candidateFingerprint = new Fingerprint();
            //        FingerprintClass candidateClass = FingerprintClass.Unknown;

            //        // Đọc hình ảnh kiểm tra
            //        using (Bitmap candidateBitmap = new Bitmap(testImagePath))
            //        {
            //            // --- CẢI TIẾN: Nâng cao tiền xử lý ảnh ---
            //            Bitmap enhancedBitmap = EnhancedPreprocessing(candidateBitmap);

            //            // --- CẢI TIẾN: Phân loại vân tay ---
            //            candidateClass = ClassifyFingerprint(enhancedBitmap);

            //            // Thiết lập hình ảnh cho vân tay kiểm tra
            //            candidateFingerprint.AsBitmap = enhancedBitmap;
            //            candidatePerson.Fingerprints.Add(candidateFingerprint);
            //        }

            //        // --- CẢI TIẾN: Kiểm tra sơ bộ dựa trên loại vân tay ---
            //        if (storedClass != FingerprintClass.Unknown &&
            //            candidateClass != FingerprintClass.Unknown &&
            //            storedClass != candidateClass)
            //        {
            //            Console.WriteLine($"Early rejection: Fingerprint classes don't match ({storedClass} vs {candidateClass})");
            //            LogFingerprintVerification(fingerprintID, testImagePath, false, 0,
            //                $"Class mismatch: {storedClass} vs {candidateClass}");
            //            return false;
            //        }

            //        // Tạo đối tượng so khớp vân tay
            //        AfisEngine afis = new AfisEngine();

            //        // --- CẢI TIẾN: Thiết lập các tham số cho thuật toán ---
            //        afis.Threshold = dynamicThreshold;
            //        afis.MinMatches = dynamicMinMatches;
            //        // --- CẢI TIẾN: Thêm tham số DPI để cải thiện độ chính xác ---
            //        afis.Dpi = 500;

            //        // Trích xuất đặc trưng từ cả hai vân tay
            //        afis.Extract(storedPerson);
            //        afis.Extract(candidatePerson);

            //        // --- CẢI TIẾN: Phân tích bổ sung ---
            //        double patternSimilarity = CalculatePatternSimilarity(storedFingerprint, candidateFingerprint);
            //        double orientationSimilarity = CalculateOrientationSimilarity(storedFingerprint, candidateFingerprint);

            //        // Xác thực vân tay
            //        float matchScore = afis.Verify(storedPerson, candidatePerson);

            //        // --- CẢI TIẾN: Kiểm tra kết hợp ---
            //        bool isMatch = matchScore >= afis.Threshold;

            //        // --- CẢI TIẾN: Thêm bộ lọc chống giả mạo ---
            //        if (isMatch)
            //        {
            //            // Kiểm tra tính nhất quán giữa các điểm đặc trưng và các thông số khác
            //            bool consistentPattern = patternSimilarity > 0.6;
            //            bool consistentOrientation = orientationSimilarity > 0.7;

            //            // Nếu các thông số bổ sung không nhất quán, có thể là giả mạo
            //            if (!consistentPattern || !consistentOrientation)
            //            {
            //                Console.WriteLine($"Anti-spoofing check failed: Pattern similarity={patternSimilarity}, Orientation similarity={orientationSimilarity}");
            //                isMatch = false;
            //            }
            //        }

            //        // Ghi log kết quả xác thực
            //        string additionalInfo = $"Quality: {storedImageQuality:F1}/{testImageQuality:F1}, " +
            //                                $"Pattern: {patternSimilarity:F2}, Orientation: {orientationSimilarity:F2}, " +
            //                                $"Threshold: {dynamicThreshold}, MinMatches: {dynamicMinMatches}";

            //        Console.WriteLine($"Fingerprint verification score: {matchScore}, {additionalInfo}, Result: {isMatch}");
            //        LogFingerprintVerification(fingerprintID, testImagePath, isMatch, matchScore, additionalInfo);

            //        return isMatch;
            //    }
            //    catch (Exception ex)
            //    {
            //        // Xử lý ngoại lệ
            //        string errorMessage = $"Error verifying fingerprint: {ex.Message}";
            //        Console.WriteLine(errorMessage);
            //        LogError("VerifyFingerprintFromImage", errorMessage);

            //        return false;
            //    }
            //}

            //// --- CẢI TIẾN: Tiền xử lý ảnh nâng cao ---
            //private Bitmap EnhancedPreprocessing(Bitmap original)
            //{
            //    try
            //    {
            //        using (Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat(original))
            //        {
            //            // 1. Chuyển sang ảnh xám
            //            Mat gray = new Mat();
            //            if (src.Channels() == 3)
            //                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            //            else
            //                gray = src.Clone();

            //            // 2. Kiểm tra và điều chỉnh kích thước ảnh
            //            if (gray.Width > 500 || gray.Height > 500)
            //            {
            //                double scale = Math.Min(500.0 / gray.Width, 500.0 / gray.Height);
            //                Cv.Size newSize = new Cv.Size((int)(gray.Width * scale), (int)(gray.Height * scale));
            //                Cv2.Resize(gray, gray, newSize);
            //            }

            //            // 3. Chuẩn hóa độ sáng

            //            Mat grayNormalized = new Mat();
            //            Cv2.Normalize(gray, grayNormalized, 0, 255, NormTypes.MinMax);

            //            // 4. Áp dụng phép cân bằng histogram CLAHE
            //            var clahe = Cv2.CreateCLAHE(4.0, new Cv.Size(8, 8));
            //            Mat equalized = new Mat();
            //            clahe.Apply(gray, equalized);

            //            // 5. Tăng độ nét ảnh
            //            Mat sharpened = new Mat();
            //            float[,] kernelData = new float[3, 3] {
            //        { 0, -1, 0 },
            //        { -1, 5, -1 },
            //        { 0, -1, 0 }
            //    };
            //            Mat kernel = Mat.FromArray(kernelData);
            //            Cv2.Filter2D(equalized, sharpened, -1, kernel);

            //            // 6. Khử nhiễu với bộ lọc Bilateral (giữ lại chi tiết cạnh tốt hơn)
            //            Mat denoised = new Mat();
            //            Cv2.BilateralFilter(sharpened, denoised, 7, 20, 20);

            //            // --- CẢI TIẾN: Tăng cường phát hiện đường vân tay với nhiều hướng ---
            //            // 7. Kết hợp nhiều bộ lọc Gabor với các hướng khác nhau
            //            Mat enhanced = new Mat();
            //            denoised.CopyTo(enhanced);

            //            // Tăng số lượng hướng từ 8 lên 16
            //            for (int i = 0; i < 16; i++)
            //            {
            //                double theta = i * Math.PI / 16;

            //                Cv.Size kernelSize = new Cv.Size(11, 11);
            //                double sigma = 4.5;
            //                double lambda = 9.5;
            //                double gamma = 0.5;
            //                double psi = 0;
            //                int ktype = MatType.CV_32F;

            //                Mat gaborKernel = Cv2.GetGaborKernel(kernelSize, sigma, theta, lambda, gamma, psi, ktype);
            //                Mat filtered = new Mat();
            //                Cv2.Filter2D(denoised, filtered, -1, gaborKernel);

            //                // Chọn giá trị phản hồi lớn nhất cho mỗi pixel
            //                for (int y = 0; y < enhanced.Height; y++)
            //                {
            //                    for (int x = 0; x < enhanced.Width; x++)
            //                    {
            //                        if (filtered.Get<byte>(y, x) > enhanced.Get<byte>(y, x))
            //                        {
            //                            enhanced.Set(y, x, filtered.Get<byte>(y, x));
            //                        }
            //                    }
            //                }
            //            }

            //            // 8. Áp dụng ngưỡng thích ứng
            //            Mat binary = new Mat();
            //            Cv2.AdaptiveThreshold(enhanced, binary, 255, AdaptiveThresholdTypes.GaussianC,
            //                ThresholdTypes.Binary, 11, 3);

            //            // 9. Loại bỏ nhiễu nhỏ
            //            Mat kernel2 = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Cv.Size(2, 2));
            //            Mat clean = new Mat();
            //            Cv2.MorphologyEx(binary, clean, MorphTypes.Open, kernel2);

            //            // 10. Tạo viền biên đầy đủ của các đường vân
            //            Mat edges = new Mat();
            //            Cv2.Canny(clean, edges, 50, 150);

            //            // 11. Kết hợp hai kết quả để tăng độ chính xác
            //            Mat combined = new Mat();
            //            Cv2.BitwiseOr(clean, edges, combined);

            //            // 12. Làm mỏng các đường vân
            //            Mat thinned = combined.Clone();
            //            ApplyZhangSuenThinning(thinned);

            //            // 13. Loại bỏ các điểm nhiễu biên
            //            Mat result = thinned.Clone();
            //            RemoveBoundaryNoise(result, 5);

            //            return BitmapConverter.ToBitmap(result);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error in enhanced preprocessing: {ex.Message}");
            //        return original;
            //    }
            //}

            //// --- CẢI TIẾN: Phân loại vân tay ---
            //private enum FingerprintClass
            //{
            //    Arch,
            //    LeftLoop,
            //    RightLoop,
            //    Whorl,
            //    Unknown
            //}

            //private FingerprintClass ClassifyFingerprint(Bitmap fingerprint)
            //{
            //    try
            //    {
            //        using (Mat src = BitmapConverter.ToMat(fingerprint))
            //        {
            //            // Convert to grayscale if needed
            //            Mat gray = new Mat();
            //            if (src.Channels() == 3)
            //                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            //            else
            //                src.CopyTo(gray);

            //            // Calculate orientation field
            //            Mat orientationMap = CalculateOrientationField(gray);

            //            // Analysis of orientation field
            //            int whorls = CountWhorls(orientationMap);
            //            int leftLoops = CountLeftLoops(orientationMap);
            //            int rightLoops = CountRightLoops(orientationMap);
            //            int arches = CountArches(orientationMap);

            //            // Determine class based on counts
            //            if (whorls > 1)
            //                return FingerprintClass.Whorl;
            //            else if (leftLoops > rightLoops && leftLoops > arches)
            //                return FingerprintClass.LeftLoop;
            //            else if (rightLoops > leftLoops && rightLoops > arches)
            //                return FingerprintClass.RightLoop;
            //            else if (arches > 0)
            //                return FingerprintClass.Arch;
            //            else
            //                return FingerprintClass.Unknown;
            //        }
            //    }
            //    catch
            //    {
            //        return FingerprintClass.Unknown;
            //    }
            //}

            //// --- CẢI TIẾN: Tính toán chất lượng ảnh vân tay ---
            //private double CalculateImageQuality(byte[] imageData)
            //{
            //    using (MemoryStream ms = new MemoryStream(imageData))
            //    using (Bitmap bitmap = new Bitmap(ms))
            //    {
            //        return CalculateImageQuality(bitmap);
            //    }
            //}

            //private double CalculateImageQuality(Bitmap bitmap)
            //{
            //    try
            //    {
            //        using (Mat src = BitmapConverter.ToMat(bitmap))
            //        {
            //            // Chuyển sang ảnh xám
            //            Mat gray = new Mat();
            //            if (src.Channels() == 3)
            //                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            //            else
            //                src.CopyTo(gray);

            //            // Tính độ tương phản
            //            Cv2.MeanStdDev(gray, out Scalar mean, out Scalar stddev);
            //            double contrast = stddev[0];

            //            // Tính độ sắc nét
            //            Mat edges = new Mat();
            //            Cv2.Laplacian(gray, edges, MatType.CV_64F);
            //            Cv2.MeanStdDev(edges, out _, out Scalar edgeStddev);
            //            double sharpness = edgeStddev[0];

            //            // Tính độ phân biệt giữa các đường vân
            //            Mat binary = new Mat();
            //            Cv2.AdaptiveThreshold(gray, binary, 255, AdaptiveThresholdTypes.GaussianC,
            //                ThresholdTypes.Binary, 11, 2);
            //            double ridgeSeparation = CalculateRidgeSeparation(binary);

            //            // Kết hợp các yếu tố để tính điểm chất lượng (0-100)
            //            double contrastScore = Math.Min(100, contrast * 2);
            //            double sharpnessScore = Math.Min(100, sharpness);
            //            double separationScore = Math.Min(100, ridgeSeparation * 20);

            //            return (contrastScore * 0.4 + sharpnessScore * 0.4 + separationScore * 0.2);
            //        }
            //    }
            //    catch
            //    {
            //        return 50; // Giá trị mặc định
            //    }
            //}

            //// --- CẢI TIẾN: Tính toán độ tương tự mẫu vân tay ---
            //private double CalculatePatternSimilarity(Fingerprint fp1, Fingerprint fp2)
            //{
            //    // Giả lập tính toán mật độ vân tay và so sánh
            //    try
            //    {
            //        // Phân tích hình dạng toàn cục
            //        double[] pattern1 = AnalyzeGlobalPattern(fp1);
            //        double[] pattern2 = AnalyzeGlobalPattern(fp2);

            //        // Tính toán tương quan
            //        return CalculateCorrelation(pattern1, pattern2);
            //    }
            //    catch
            //    {
            //        return 0.5; // Giá trị mặc định
            //    }
            //}

            //// --- CẢI TIẾN: Tính toán độ tương tự hướng vân tay ---
            //private double CalculateOrientationSimilarity(Fingerprint fp1, Fingerprint fp2)
            //{
            //    // Giả lập tính toán hướng vân tay và so sánh
            //    try
            //    {
            //        // Phân tích hướng toàn cục
            //        double[] orientation1 = AnalyzeOrientation(fp1);
            //        double[] orientation2 = AnalyzeOrientation(fp2);

            //        // Tính toán tương quan
            //        return CalculateCorrelation(orientation1, orientation2);
            //    }
            //    catch
            //    {
            //        return 0.5; // Giá trị mặc định
            //    }
            //}

            //// --- CẢI TIẾN: Phương thức ghi log nâng cao ---
            //private void LogFingerprintVerification(string fingerprintID, string testImagePath, bool result, float score, string additionalInfo = "")
            //{
            //    try
            //    {
            //        string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            //        if (!Directory.Exists(logFolder))
            //            Directory.CreateDirectory(logFolder);

            //        string logFile = Path.Combine(logFolder, "FingerprintVerification.log");
            //        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - FingerprintID: {fingerprintID}, " +
            //                          $"TestImage: {Path.GetFileName(testImagePath)}, Result: {result}, " +
            //                          $"Score: {score}, {additionalInfo}";

            //        File.AppendAllText(logFile, logEntry + Environment.NewLine);
            //    }
            //    catch
            //    {
            //        // Bỏ qua lỗi ghi log
            //    }
            //}

            //// Các phương thức phụ trợ (giả lập)
            //private Mat CalculateOrientationField(Mat image) => new Mat();
            //private int CountWhorls(Mat orientationMap) => 0;
            //private int CountLeftLoops(Mat orientationMap) => 0;
            //private int CountRightLoops(Mat orientationMap) => 0;
            //private int CountArches(Mat orientationMap) => 0;
            //private double CalculateRidgeSeparation(Mat binary) => 1.0;
            //private double[] AnalyzeGlobalPattern(Fingerprint fp) => new double[10];
            //private double[] AnalyzeOrientation(Fingerprint fp) => new double[10];
            //private double CalculateCorrelation(double[] a, double[] b) => 0.8;
            //private void ApplyZhangSuenThinning(Mat image) { }
            //private void RemoveBoundaryNoise(Mat image, int borderWidth) { }
            //private void SaveDebugImages(byte[] storedData, string testPath) { }















            /// <summary>
            /// Cải thiện chất lượng hình ảnh vân tay để tăng độ chính xác khi xác thực
            /// </summary>
            //private Bitmap EnhanceFingerprintImage(Bitmap original)
            //{
            //    try
            //    {
            //        // Tạo bản sao của hình ảnh gốc
            //        Bitmap enhanced = new Bitmap(original);

            //        // 1. Chuyển đổi sang ảnh xám
            //        for (int y = 0; y < enhanced.Height; y++)
            //        {
            //            for (int x = 0; x < enhanced.Width; x++)
            //            {
            //                Color pixel = enhanced.GetPixel(x, y);
            //                int grayValue = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
            //                enhanced.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
            //            }
            //        }

            //        // 2. Tăng cường tương phản
            //        // Tìm giá trị nhỏ nhất và lớn nhất
            //        int min = 255, max = 0;
            //        for (int y = 0; y < enhanced.Height; y++)
            //        {
            //            for (int x = 0; x < enhanced.Width; x++)
            //            {
            //                Color pixel = enhanced.GetPixel(x, y);
            //                if (pixel.R < min) min = pixel.R;
            //                if (pixel.R > max) max = pixel.R;
            //            }
            //        }

            //        // Áp dụng cân bằng histogram đơn giản
            //        if (max > min) // Tránh chia cho 0
            //        {
            //            for (int y = 0; y < enhanced.Height; y++)
            //            {
            //                for (int x = 0; x < enhanced.Width; x++)
            //                {
            //                    Color pixel = enhanced.GetPixel(x, y);
            //                    int newValue = (pixel.R - min) * 255 / (max - min);
            //                    enhanced.SetPixel(x, y, Color.FromArgb(newValue, newValue, newValue));
            //                }
            //            }
            //        }

            //        // 3. Binarization (phân ngưỡng nhị phân)
            //        int threshold = 128;
            //        for (int y = 0; y < enhanced.Height; y++)
            //        {
            //            for (int x = 0; x < enhanced.Width; x++)
            //            {
            //                Color pixel = enhanced.GetPixel(x, y);
            //                int newValue = (pixel.R > threshold) ? 255 : 0;
            //                enhanced.SetPixel(x, y, Color.FromArgb(newValue, newValue, newValue));
            //            }
            //        }

            //        return enhanced;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error enhancing fingerprint: {ex.Message}");
            //        // Trả về ảnh gốc nếu xảy ra lỗi
            //        return original;
            //    }
            //}



            //private Bitmap EnhanceFingerprintImage(Bitmap original)
            //{
            //    try
            //    {
            //        // Chuyển đổi sang ảnh xám sử dụng thư viện có sẵn
            //        Bitmap grayImage = new Bitmap(original.Width, original.Height);
            //        using (Graphics g = Graphics.FromImage(grayImage))
            //        {
            //            // Tạo ma trận màu để chuyển đổi sang ảnh xám
            //            ColorMatrix colorMatrix = new ColorMatrix(
            //                new float[][]
            //                {
            //            new float[] {0.299f, 0.299f, 0.299f, 0, 0},
            //            new float[] {0.587f, 0.587f, 0.587f, 0, 0},
            //            new float[] {0.114f, 0.114f, 0.114f, 0, 0},
            //            new float[] {0, 0, 0, 1, 0},
            //            new float[] {0, 0, 0, 0, 1}
            //                });

            //            using (ImageAttributes attributes = new ImageAttributes())
            //            {
            //                attributes.SetColorMatrix(colorMatrix);
            //                g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
            //                    0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            //            }
            //        }

            //        // Chuyển đổi sang BitmapData để xử lý nhanh hơn
            //        BitmapData data = grayImage.LockBits(
            //            new Rectangle(0, 0, grayImage.Width, grayImage.Height),
            //            ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            //        int bytes = Math.Abs(data.Stride) * data.Height;
            //        byte[] pixels = new byte[bytes];
            //        System.Runtime.InteropServices.Marshal.Copy(data.Scan0, pixels, 0, bytes);

            //        // 1. Cân bằng histogram cải tiến (CLAHE - Contrast Limited Adaptive Histogram Equalization)
            //        // Chia ảnh thành các block nhỏ và cân bằng histogram từng block
            //        int tileSize = 16; // Kích thước tile (có thể điều chỉnh)
            //        int clipLimit = 3; // Giới hạn clip (có thể điều chỉnh)
            //        ApplyCLAHE(pixels, data.Width, data.Height, data.Stride, tileSize, clipLimit);

            //        // 2. Lọc Gabor - phát hiện đường vân tay
            //        ApplyGaborFilter(pixels, data.Width, data.Height, data.Stride);

            //        // 3. Khử nhiễu bằng lọc trung vị
            //        ApplyMedianFilter(pixels, data.Width, data.Height, data.Stride, 3); // Kernel size 3x3

            //        // 4. Nhị phân hóa thích nghi (không dùng ngưỡng cố định)
            //        AdaptiveThreshold(pixels, data.Width, data.Height, data.Stride, 15, 5);

            //        // 5. Phép toán hình thái học (Morphological operations)
            //        // Thinning - làm mỏng các đường vân
            //        ApplyThinning(pixels, data.Width, data.Height, data.Stride);

            //        // Cập nhật lại bitmap
            //        System.Runtime.InteropServices.Marshal.Copy(pixels, 0, data.Scan0, bytes);
            //        grayImage.UnlockBits(data);

            //        return grayImage;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error enhancing fingerprint: {ex.Message}");
            //        return original;
            //    }
            //}
        private Bitmap EnhanceFingerprintImage(Bitmap original)
        {
            try
            {
                // Chuyển đổi sang ảnh xám sử dụng thư viện có sẵn
                Bitmap grayImage = new Bitmap(original.Width, original.Height);
                using (Graphics g = Graphics.FromImage(grayImage))
                {
                    // Tạo ma trận màu để chuyển đổi sang ảnh xám
                    ColorMatrix colorMatrix = new ColorMatrix(
                        new float[][]
                        {
                    new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                    new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                    new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                        });

                    using (ImageAttributes attributes = new ImageAttributes())
                    {
                        attributes.SetColorMatrix(colorMatrix);
                        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                            0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                    }
                }

                // Chuyển đổi sang BitmapData để xử lý nhanh hơn
                BitmapData data = grayImage.LockBits(
                    new Rectangle(0, 0, grayImage.Width, grayImage.Height),
                    ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                int bytes = Math.Abs(data.Stride) * data.Height;
                byte[] pixels = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(data.Scan0, pixels, 0, bytes);

                // 1. Cân bằng histogram cải tiến (CLAHE - Contrast Limited Adaptive Histogram Equalization)
                // Chia ảnh thành các block nhỏ và cân bằng histogram từng block
                int tileSize = 16; // Kích thước tile (có thể điều chỉnh)
                int clipLimit = 3; // Giới hạn clip (có thể điều chỉnh)
                ApplyCLAHE(pixels, data.Width, data.Height, data.Stride, tileSize, clipLimit);

                // 2. Lọc Gabor - phát hiện đường vân tay
                ApplyGaborFilter(pixels, data.Width, data.Height, data.Stride);

                // 3. Khử nhiễu bằng lọc trung vị
                ApplyMedianFilter(pixels, data.Width, data.Height, data.Stride, 3); // Kernel size 3x3

                // 4. Nhị phân hóa thích nghi (không dùng ngưỡng cố định)
                AdaptiveThreshold(pixels, data.Width, data.Height, data.Stride, 15, 5);

                // 5. Phép toán hình thái học (Morphological operations)
                // Thinning - làm mỏng các đường vân
                ApplyThinning(pixels, data.Width, data.Height, data.Stride);

                // Cập nhật lại bitmap
                System.Runtime.InteropServices.Marshal.Copy(pixels, 0, data.Scan0, bytes);
                grayImage.UnlockBits(data);

                return grayImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enhancing fingerprint: {ex.Message}");
                return original;
            }
        }
        // CLAHE - Contrast Limited Adaptive Histogram Equalization
        private void ApplyCLAHE(byte[] pixels, int width, int height, int stride, int tileSize, int clipLimit)
        {
            // Khai báo các biến làm việc
            int bytesPerPixel = 4; // Format32bppArgb
            int tilesX = (width + tileSize - 1) / tileSize;
            int tilesY = (height + tileSize - 1) / tileSize;

            // Tạo histogram và LUT cho mỗi tile
            int[,,] histograms = new int[tilesY, tilesX, 256];
            int[,,] mappings = new int[tilesY, tilesX, 256];

            // Tính histogram cho mỗi tile
            for (int y = 0; y < height; y++)
            {
                int ty = Math.Min(y / tileSize, tilesY - 1);
                for (int x = 0; x < width; x++)
                {
                    int tx = Math.Min(x / tileSize, tilesX - 1);
                    int offset = y * stride + x * bytesPerPixel;
                    byte pixelValue = pixels[offset]; // B channel (grayscale)
                    histograms[ty, tx, pixelValue]++;
                }
            }

            // Clip histogram và tạo mapping
            for (int ty = 0; ty < tilesY; ty++)
            {
                for (int tx = 0; tx < tilesX; tx++)
                {
                    // Đếm số pixel trong tile
                    int pixelCount = 0;
                    for (int i = 0; i < 256; i++)
                        pixelCount += histograms[ty, tx, i];

                    if (pixelCount == 0) continue;

                    // Clip histogram
                    int clipped = 0;
                    for (int i = 0; i < 256; i++)
                    {
                        if (histograms[ty, tx, i] > clipLimit)
                        {
                            clipped += histograms[ty, tx, i] - clipLimit;
                            histograms[ty, tx, i] = clipLimit;
                        }
                    }

                    // Phân phối lại giá trị clipped
                    int redistBatch = clipped / 256;
                    for (int i = 0; i < 256; i++)
                        histograms[ty, tx, i] += redistBatch;

                    // Tính CDF và mapping
                    int sum = 0;
                    for (int i = 0; i < 256; i++)
                    {
                        sum += histograms[ty, tx, i];
                        mappings[ty, tx, i] = Math.Min(255, sum * 255 / pixelCount);
                    }
                }
            }

            // Áp dụng mapping với nội suy bilinear
            for (int y = 0; y < height; y++)
            {
                float ty = (float)y / tileSize;
                int ty1 = Math.Min((int)ty, tilesY - 1);
                int ty2 = Math.Min(ty1 + 1, tilesY - 1);
                float wy2 = ty - ty1;
                float wy1 = 1 - wy2;

                for (int x = 0; x < width; x++)
                {
                    float tx = (float)x / tileSize;
                    int tx1 = Math.Min((int)tx, tilesX - 1);
                    int tx2 = Math.Min(tx1 + 1, tilesX - 1);
                    float wx2 = tx - tx1;
                    float wx1 = 1 - wx2;

                    int offset = y * stride + x * bytesPerPixel;
                    byte pixelValue = pixels[offset];

                    // Nội suy bilinear
                    float newValue =
                        wy1 * (wx1 * mappings[ty1, tx1, pixelValue] + wx2 * mappings[ty1, tx2, pixelValue]) +
                        wy2 * (wx1 * mappings[ty2, tx1, pixelValue] + wx2 * mappings[ty2, tx2, pixelValue]);

                    byte result = (byte)Math.Min(255, Math.Max(0, (int)newValue));

                    // Cập nhật tất cả các kênh để giữ ảnh xám
                    pixels[offset] = result;     // B
                    pixels[offset + 1] = result; // G
                    pixels[offset + 2] = result; // R
                }
            }
        }

        // Lọc Gabor - giúp phát hiện các đường vân tay
        private void ApplyGaborFilter(byte[] pixels, int width, int height, int stride)
        {
            const int kernelSize = 9;
            const double sigma = 4.0;
            const double lambda = 10.0;
            const double gamma = 0.5;
            const double psi = 0.0;

            // Tạo bản sao để xử lý
            byte[] result = new byte[pixels.Length];
            Array.Copy(pixels, result, pixels.Length);

            // Tạo 8 kernel Gabor với các hướng khác nhau
            double[][,] kernels = new double[8][,];
            for (int i = 0; i < 8; i++)
            {
                double theta = i * Math.PI / 8;
                kernels[i] = CreateGaborKernel(kernelSize, sigma, theta, lambda, gamma, psi);
            }

            int bytesPerPixel = 4; // Format32bppArgb
            int radius = kernelSize / 2;

            // Xử lý song song các dòng của ảnh
            Parallel.For(radius, height - radius, y =>
            {
                for (int x = radius; x < width - radius; x++)
                {
                    double[] responses = new double[8];

                    // Áp dụng 8 kernel Gabor
                    for (int k = 0; k < 8; k++)
                    {
                        double sum = 0;
                        for (int ky = -radius; ky <= radius; ky++)
                        {
                            for (int kx = -radius; kx <= radius; kx++)
                            {
                                int pixelOffset = (y + ky) * stride + (x + kx) * bytesPerPixel;
                                sum += pixels[pixelOffset] * kernels[k][ky + radius, kx + radius];
                            }
                        }
                        responses[k] = sum;
                    }

                    // Lấy giá trị phản hồi lớn nhất
                    double maxResponse = responses.Max();
                    byte pixelValue = (byte)Math.Min(255, Math.Max(0, maxResponse));

                    int offset = y * stride + x * bytesPerPixel;
                    result[offset] = pixelValue;     // B
                    result[offset + 1] = pixelValue; // G
                    result[offset + 2] = pixelValue; // R
                }
            });

            // Cập nhật pixels gốc
            Array.Copy(result, pixels, pixels.Length);
        }

        // Hàm tạo kernel Gabor
        private double[,] CreateGaborKernel(int size, double sigma, double theta, double lambda, double gamma, double psi)
        {
            double[,] kernel = new double[size, size];
            int radius = size / 2;
            double sigmaX = sigma;
            double sigmaY = sigma / gamma;

            double sum = 0;
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    double xPrime = x * Math.Cos(theta) + y * Math.Sin(theta);
                    double yPrime = -x * Math.Sin(theta) + y * Math.Cos(theta);

                    double exponent = -(Math.Pow(xPrime, 2) / (2 * Math.Pow(sigmaX, 2)) +
                                       Math.Pow(yPrime, 2) / (2 * Math.Pow(sigmaY, 2)));

                    double gaussian = Math.Exp(exponent);
                    double cos = Math.Cos(2 * Math.PI * xPrime / lambda + psi);

                    kernel[y + radius, x + radius] = gaussian * cos;
                    sum += kernel[y + radius, x + radius];
                }
            }

            // Chuẩn hóa kernel (tổng = 1)
            if (sum != 0)
            {
                for (int y = 0; y < size; y++)
                    for (int x = 0; x < size; x++)
                        kernel[y, x] /= sum;
            }

            return kernel;
        }

        // Lọc trung vị để khử nhiễu đốm
        private void ApplyMedianFilter(byte[] pixels, int width, int height, int stride, int kernelSize)
        {
            byte[] result = new byte[pixels.Length];
            Array.Copy(pixels, result, pixels.Length);

            int bytesPerPixel = 4; // Format32bppArgb
            int radius = kernelSize / 2;
            byte[] values = new byte[kernelSize * kernelSize];

            // Xử lý song song
            Parallel.For(radius, height - radius, y =>
            {
                for (int x = radius; x < width - radius; x++)
                {
                    // Thu thập giá trị pixel trong vùng lân cận
                    int index = 0;
                    for (int ky = -radius; ky <= radius; ky++)
                    {
                        for (int kx = -radius; kx <= radius; kx++)
                        {
                            int pixelOffset = (y + ky) * stride + (x + kx) * bytesPerPixel;
                            values[index++] = pixels[pixelOffset];
                        }
                    }

                    // Sắp xếp và lấy giá trị trung vị
                    Array.Sort(values);
                    byte medianValue = values[values.Length / 2];

                    // Cập nhật tất cả các kênh
                    int offset = y * stride + x * bytesPerPixel;
                    result[offset] = medianValue;     // B
                    result[offset + 1] = medianValue; // G
                    result[offset + 2] = medianValue; // R
                }
            });

            Array.Copy(result, pixels, pixels.Length);
        }

        // Nhị phân hóa thích nghi
        private void AdaptiveThreshold(byte[] pixels, int width, int height, int stride, int blockSize, int c)
        {
            byte[] result = new byte[pixels.Length];
            Array.Copy(pixels, result, pixels.Length);

            int bytesPerPixel = 4; // Format32bppArgb
            int radius = blockSize / 2;

            // Tính tổng tích lũy tích phân hình ảnh (integral image) để tối ưu hóa
            int[,] integral = new int[height + 1, width + 1];

            for (int y = 1; y <= height; y++)
            {
                for (int x = 1; x <= width; x++)
                {
                    int offset = (y - 1) * stride + (x - 1) * bytesPerPixel;
                    integral[y, x] = pixels[offset] +
                                     integral[y - 1, x] +
                                     integral[y, x - 1] -
                                     integral[y - 1, x - 1];
                }
            }

            // Xử lý song song
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    int x1 = Math.Max(0, x - radius);
                    int y1 = Math.Max(0, y - radius);
                    int x2 = Math.Min(width - 1, x + radius);
                    int y2 = Math.Min(height - 1, y + radius);

                    int count = (x2 - x1 + 1) * (y2 - y1 + 1);
                    int sum = integral[y2 + 1, x2 + 1] -
                              integral[y2 + 1, x1] -
                              integral[y1, x2 + 1] +
                              integral[y1, x1];

                    int threshold = sum / count - c;

                    int offset = y * stride + x * bytesPerPixel;
                    byte value = (pixels[offset] > threshold) ? (byte)255 : (byte)0;

                    result[offset] = value;     // B
                    result[offset + 1] = value; // G
                    result[offset + 2] = value; // R
                }
            });

            Array.Copy(result, pixels, pixels.Length);
        }

        // Thuật toán Zhang-Suen thinning
        private void ApplyThinning(byte[] pixels, int width, int height, int stride)
        {
            const int bytesPerPixel = 4;
            byte[] result = new byte[pixels.Length];
            bool hasChange;

            // Tạo ma trận binary 2D để dễ xử lý
            bool[,] binary = new bool[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int offset = y * stride + x * bytesPerPixel;
                    binary[y, x] = pixels[offset] != 0;
                }
            }

            do
            {
                hasChange = false;
                bool[,] toDelete = new bool[height, width];

                // Pass 1
                for (int y = 1; y < height - 1; y++)
                {
                    for (int x = 1; x < width - 1; x++)
                    {
                        if (!binary[y, x]) continue;

                        // Lấy 8 điểm lân cận
                        bool p2 = binary[y - 1, x];
                        bool p3 = binary[y - 1, x + 1];
                        bool p4 = binary[y, x + 1];
                        bool p5 = binary[y + 1, x + 1];
                        bool p6 = binary[y + 1, x];
                        bool p7 = binary[y + 1, x - 1];
                        bool p8 = binary[y, x - 1];
                        bool p9 = binary[y - 1, x - 1];

                        // Đếm số láng giềng
                        int A = (p2 ? 0 : 1) + (p3 ? 0 : 1) + (p4 ? 0 : 1) + (p5 ? 0 : 1) +
                               (p6 ? 0 : 1) + (p7 ? 0 : 1) + (p8 ? 0 : 1) + (p9 ? 0 : 1);

                        // Đếm chuyển đổi từ 0 -> 1
                        int B = 0;
                        if (!p2 && p3) B++;
                        if (!p3 && p4) B++;
                        if (!p4 && p5) B++;
                        if (!p5 && p6) B++;
                        if (!p6 && p7) B++;
                        if (!p7 && p8) B++;
                        if (!p8 && p9) B++;
                        if (!p9 && p2) B++;

                        // Điều kiện Zhang-Suen (Pass 1)
                        if (B == 1 && A >= 2 && A <= 6 && (!p2 && !p4 && !p6) == false && (!p4 && !p6 && !p8) == false)
                        {
                            toDelete[y, x] = true;
                            hasChange = true;
                        }
                    }
                }

                // Xóa các pixel đã đánh dấu
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (toDelete[y, x])
                            binary[y, x] = false;
                    }
                }

                toDelete = new bool[height, width];

                // Pass 2
                for (int y = 1; y < height - 1; y++)
                {
                    for (int x = 1; x < width - 1; x++)
                    {
                        if (!binary[y, x]) continue;

                        // Lấy 8 điểm lân cận
                        bool p2 = binary[y - 1, x];
                        bool p3 = binary[y - 1, x + 1];
                        bool p4 = binary[y, x + 1];
                        bool p5 = binary[y + 1, x + 1];
                        bool p6 = binary[y + 1, x];
                        bool p7 = binary[y + 1, x - 1];
                        bool p8 = binary[y, x - 1];
                        bool p9 = binary[y - 1, x - 1];

                        // Đếm số láng giềng
                        int A = (p2 ? 0 : 1) + (p3 ? 0 : 1) + (p4 ? 0 : 1) + (p5 ? 0 : 1) +
                               (p6 ? 0 : 1) + (p7 ? 0 : 1) + (p8 ? 0 : 1) + (p9 ? 0 : 1);

                        // Đếm chuyển đổi từ 0 -> 1
                        int B = 0;
                        if (!p2 && p3) B++;
                        if (!p3 && p4) B++;
                        if (!p4 && p5) B++;
                        if (!p5 && p6) B++;
                        if (!p6 && p7) B++;
                        if (!p7 && p8) B++;
                        if (!p8 && p9) B++;
                        if (!p9 && p2) B++;

                        // Điều kiện Zhang-Suen (Pass 2)
                        if (B == 1 && A >= 2 && A <= 6 && (!p2 && !p4 && !p8) == false && (!p2 && !p6 && !p8) == false)
                        {
                            toDelete[y, x] = true;
                            hasChange = true;
                        }
                    }
                }

                // Xóa các pixel đã đánh dấu
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (toDelete[y, x])
                            binary[y, x] = false;
                    }
                }

            } while (hasChange);

            // Cập nhật lại mảng pixels
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int offset = y * stride + x * bytesPerPixel;
                    byte value = binary[y, x] ? (byte)255 : (byte)0;
                    pixels[offset] = value;     // B
                    pixels[offset + 1] = value; // G
                    pixels[offset + 2] = value; // R
                }
            }
        }











        /// <summary>
        /// Ghi nhật ký kiểm tra vân tay
        /// </summary>
        private void LogFingerprintVerification(string fingerprintID, string testImagePath, bool result, float score)
        {
            try
            {
                string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                if (!Directory.Exists(logFolder))
                    Directory.CreateDirectory(logFolder);

                string logFile = Path.Combine(logFolder, "FingerprintVerification.log");
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - FingerprintID: {fingerprintID}, TestImage: {Path.GetFileName(testImagePath)}, Result: {result}";

                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch
            {
                // Bỏ qua lỗi ghi log
          
            }
        }

        /// <summary>
        /// Ghi nhật ký lỗi
        /// </summary>
        private void LogError(string method, string errorMessage)
        {
            try
            {
                string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                if (!Directory.Exists(logFolder))
                    Directory.CreateDirectory(logFolder);

                string logFile = Path.Combine(logFolder, "Errors.log");
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Method: {method}, Error: {errorMessage}";

                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch
            {
                // Bỏ qua lỗi ghi log
            }
        }






       

        // Phương thức bổ sung: Đăng ký vân tay với trích xuất đặc trưng
        public string EnrollFingerprintWithExtraction(string username, string tenantID,
                                           string areaPermission, string fingerprintImagePath)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(tenantID))
                    return "Thông tin không hợp lệ";

                if (string.IsNullOrEmpty(fingerprintImagePath) || !File.Exists(fingerprintImagePath))
                    return "Không tìm thấy ảnh vân tay";

                // Tiền xử lý và trích xuất đặc trưng
                byte[] imageData;
                byte[] templateData;

                // Tạo đối tượng vân tay từ hình ảnh
                using (Bitmap fingerprintBitmap = new Bitmap(fingerprintImagePath))
                {
                    // Tiền xử lý hình ảnh để cải thiện chất lượng
                    Bitmap enhancedBitmap = EnhanceFingerprintImage(fingerprintBitmap);

                    // Trích xuất đặc trưng
                    Fingerprint templateFingerprint = new Fingerprint();
                    templateFingerprint.AsBitmap = enhancedBitmap;

                    Person person = new Person();
                    person.Fingerprints.Add(templateFingerprint);

                    AfisEngine afis = new AfisEngine();
                    afis.Extract(person);

                    // Chuyển đổi hình ảnh và template thành byte array
                    using (MemoryStream ms = new MemoryStream())
                    {
                        enhancedBitmap.Save(ms, ImageFormat.Png);
                        imageData = ms.ToArray();
                    }

                    // Lưu template đặc trưng (nếu cần)
                    templateData = templateFingerprint.Template != null ? templateFingerprint.Template : new byte[0];
                }

                // Tạo đối tượng FingerprintDTO với dữ liệu đã xử lý
                FingerprintDTO fingerprintDTO = new FingerprintDTO
                {
                    Username = username,
                    TenantID = tenantID,
                    AreaPermission = areaPermission,
                    EnrollmentDate = DateTime.Now,
                    FingerprintImage = imageData,
                    FingerprintTemplate = templateData,
                    ImageName = Path.GetFileName(fingerprintImagePath)
                };

                // Lưu thông tin vân tay vào database
                bool result = FingerprintAccess.AddFingerprint(fingerprintDTO);

                if (!result)
                    return "Đã xảy ra lỗi khi lưu thông tin vân tay";

                return "Đăng ký vân tay thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        

    }
}