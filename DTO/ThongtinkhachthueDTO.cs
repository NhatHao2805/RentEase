using System;

namespace DTO
{
    public class ThongtinkhachthueDTO
    {
        public string TenantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }

        public ThongtinkhachthueDTO(string tenantID, string firstName, string lastName, DateTime birthday,
            string gender, string phoneNumber, string email, string profilePicture)
        {
            TenantID = tenantID;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            ProfilePicture = profilePicture;
        }
    }
}