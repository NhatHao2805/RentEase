using System;

namespace DTO
{
    public class TemporaryResidenceDTO
    {
        public string TenantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PermanentAddress { get; set; }
        public string RegisteredAddress { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RegistrationFilePath { get; set; }

        public TemporaryResidenceDTO(string tenantID, string firstName, string lastName,
            DateTime birthday, string gender, string phoneNumber, string email,
            string permanentAddress, string registeredAddress, DateTime startDate,
            string notes, DateTime expiryDate, string registrationFilePath)
        {
            TenantID = tenantID;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            PermanentAddress = permanentAddress;
            RegisteredAddress = registeredAddress;
            StartDate = startDate;
            Notes = notes;
            ExpiryDate = expiryDate;
            RegistrationFilePath = registrationFilePath;
        }
    }
}