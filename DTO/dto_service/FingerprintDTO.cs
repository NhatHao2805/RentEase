// DTO/FingerprintDTO.cs
using System;

namespace DTO
{
    // DTO/FingerprintDTO.cs
    public class FingerprintDTO
    {
        public string FingerprintID { get; set; }
        public string Username { get; set; }
        public string TenantID { get; set; }
        public string AreaPermission { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public byte[] FingerprintImage { get; set; }
        public byte[] FingerprintTemplate { get; set; } // Thêm trường mới này
        public string ImageName { get; set; }
    }

    public class AreaPermissionDTO
    {
        public string AreaID { get; set; }
        public string AreaName { get; set; }
        public string Description { get; set; }
    }

    public class TenantDTO
    {
        public string TenantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}