using System;
using System.Data;
using MySql.Data.MySqlClient;
using DTO;
using System.Collections.Generic;

namespace DAL
{
    public class MySqlConnectionData
    {
        // Connection string for MySQL
        private static readonly string connectString = "server=localhost;port=3306;database=rentease;user=root;password=;";

        public static MySqlConnection Connect()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectString);
                connection.Open();
                Console.WriteLine("Connected to MySQL successfully!");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Connection error: " + e.Message);
            }
            return connection;
        }


        public List<ContractDTO> GetAllContracts(String required)
        {
            List<ContractDTO> contractList = new List<ContractDTO>();
            string query = "SELECT * FROM CONTRACT";
            if (required == "All")
            {
                query = "SELECT * FROM CONTRACT"; ;
            }
            else if (required == "Active")
            {
                query = "SELECT * FROM CONTRACT WHERE STATUS = 'Đang hiệu lực'";
            }
            else if (required == "Inactive")
            {
                query = "SELECT * FROM CONTRACT WHERE STATUS = 'Đã chấm dứt'";
            }
            else if (required == "Ending")
            {
                query = "SELECT * FROM CONTRACT WHERE STATUS = 'Đang kết thúc'";
            }
            else if (required == "Expire Soon")
            {
                query = "SELECT * FROM CONTRACT WHERE STATUS = 'Sắp hết hạn'";
            }
            else
            {

            }
                using (MySqlConnection conn = Connect())
                {
                    if (conn == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractDTO contract = new ContractDTO(
                                    reader.GetString("CONTRACTID"),
                                    reader.GetString("HOUSEID"),
                                    reader.GetString("TENANTID"),
                                    reader.GetDateTime("CREATEDATE"),
                                    reader.GetDateTime("STARTDATE"),
                                    reader.GetDateTime("ENDDATE"),
                                    reader.GetFloat("MONTHLYRENT"),
                                    reader.GetString("PAYMENTSCHEDULE"),
                                    reader.GetFloat("DEPOSIT"),
                                    reader.GetString("STATUS"),
                                    reader.GetString("NOTES"),
                                    reader.GetBoolean("AUTO_RENEW"),
                                    reader.IsDBNull(reader.GetOrdinal("TERMINATION_REASON")) ? "" : reader.GetString("TERMINATION_REASON"),
                                    reader.IsDBNull(reader.GetOrdinal("CONTRACT_FILE_PATH")) ? "" : reader.GetString("CONTRACT_FILE_PATH")
                                );

                                // In ra console để kiểm tra
                                Console.WriteLine($"Contract ID: {contract.ContractID}, House ID: {contract.HouseID}, Tenant ID: {contract.TenantID}");

                                contractList.Add(contract);
                            }
                        }
                    }
                }
            return contractList;
        }
    }

    public partial class DatabaseAccess
    {
        public static List<ThongtinkhachthueDTO> GetAllTenants()
        {
            List<ThongtinkhachthueDTO> tenantList = new List<ThongtinkhachthueDTO>();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return tenantList;

                string query = "SELECT * FROM TENANT";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThongtinkhachthueDTO tenant = new ThongtinkhachthueDTO(
                                reader.GetString("TENANTID"),
                                reader.GetString("FIRSTNAME"),
                                reader.GetString("LASTNAME"),
                                reader.GetDateTime("BIRTHDAY"),
                                reader.GetString("GENDER"),
                                reader.GetString("PHONENUMBER"),
                                reader.GetString("EMAIL"),
                                reader.IsDBNull(reader.GetOrdinal("PROFILE_PICTURE")) ? "" : reader.GetString("PROFILE_PICTURE")
                            );
                            tenantList.Add(tenant);
                        }
                    }
                }
            }
            return tenantList;
        }

        public static bool SaveTenant(ThongtinkhachthueDTO tenant)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return false;

                string query = @"INSERT INTO TENANT 
                    (TENANTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, PHONENUMBER, EMAIL, PROFILE_PICTURE) 
                    VALUES (@TenantId, @FirstName, @LastName, @Birthday, @Gender, @PhoneNumber, @Email, @ProfilePicture)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenantId", tenant.TenantID);
                    cmd.Parameters.AddWithValue("@FirstName", tenant.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", tenant.LastName);
                    cmd.Parameters.AddWithValue("@Birthday", tenant.Birthday);
                    cmd.Parameters.AddWithValue("@Gender", tenant.Gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", tenant.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", tenant.Email);
                    cmd.Parameters.AddWithValue("@ProfilePicture", tenant.ProfilePicture ?? (object)DBNull.Value);

                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error saving tenant: {ex.Message}");
                        return false;
                    }
                }
            }
        }
        // Thêm vào lớp DatabaseAccess trong file DatabaseAccess.cs
        public static List<TemporaryResidenceDTO> GetAllTemporaryResidences()
        {
            List<TemporaryResidenceDTO> residenceList = new List<TemporaryResidenceDTO>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return residenceList;

                string query = "SELECT * FROM TEMPORARY_RESIDENCE";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TemporaryResidenceDTO residence = new TemporaryResidenceDTO(
                                reader.GetString("TENANTID"),
                                reader.GetString("FIRSTNAME"),
                                reader.GetString("LASTNAME"),
                                reader.GetDateTime("BIRTHDAY"),
                                reader.GetString("GENDER"),
                                reader.GetString("PHONENUMBER"),
                                reader.IsDBNull(reader.GetOrdinal("EMAIL")) ? "" : reader.GetString("EMAIL"),
                                reader.GetString("PERMANENTADDRESS"),
                                reader.GetString("REGISTEDADDRESS"),
                                reader.GetDateTime("STARTDATE"),
                                reader.IsDBNull(reader.GetOrdinal("NOTES")) ? "" : reader.GetString("NOTES"),
                                reader.GetDateTime("EXPIRY_DATE"),
                                reader.IsDBNull(reader.GetOrdinal("REGISTRATION_FILE_PATH")) ? "" : reader.GetString("REGISTRATION_FILE_PATH")
                            );

                            residenceList.Add(residence);
                        }
                    }
                }
            }

            return residenceList;
        }
        public static bool SaveContract(ContractDTO contract)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return false;

                string query = @"INSERT INTO CONTRACT 
                    (CONTRACTID, HOUSEID, TENANTID, CREATEDATE, STARTDATE, ENDDATE, 
                    MONTHLYRENT, PAYMENTSCHEDULE, DEPOSIT, STATUS, NOTES, AUTO_RENEW, 
                    TERMINATION_REASON, CONTRACT_FILE_PATH) 
                    VALUES 
                    (@ContractId, @HouseId, @TenantId, @CreateDate, @StartDate, @EndDate, 
                    @MonthlyRent, @PaymentSchedule, @Deposit, @Status, @Notes, @AutoRenew, 
                    @TerminationReason, @ContractFilePath)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@ContractId", contract.ContractID);
                        cmd.Parameters.AddWithValue("@HouseId", contract.HouseID);
                        cmd.Parameters.AddWithValue("@TenantId", contract.TenantID);
                        cmd.Parameters.AddWithValue("@CreateDate", contract.CreateDate);
                        cmd.Parameters.AddWithValue("@StartDate", contract.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", contract.EndDate);
                        cmd.Parameters.AddWithValue("@MonthlyRent", contract.MonthlyRent);
                        cmd.Parameters.AddWithValue("@PaymentSchedule", contract.PaymentSchedule);
                        cmd.Parameters.AddWithValue("@Deposit", contract.Deposit);
                        cmd.Parameters.AddWithValue("@Status", contract.Status);
                        cmd.Parameters.AddWithValue("@Notes", contract.Notes ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AutoRenew", contract.AutoRenew);
                        cmd.Parameters.AddWithValue("@TerminationReason", contract.TerminationReason ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ContractFilePath", contract.ContractFilePath ?? (object)DBNull.Value);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error saving contract: {ex.Message}");
                        return false;
                    }
                }
            }
        }
        public static bool SaveTemporaryResidence(TemporaryResidenceDTO residence)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return false;

                string query = @"INSERT INTO TEMPORARY_RESIDENCE 
            (TENANTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, PHONENUMBER, EMAIL, 
             PERMANENTADDRESS, REGISTEDADDRESS, STARTDATE, NOTES, EXPIRY_DATE, REGISTRATION_FILE_PATH) 
            VALUES (@TenantId, @FirstName, @LastName, @Birthday, @Gender, @PhoneNumber, @Email, 
                    @PermanentAddress, @RegisteredAddress, @StartDate, @Notes, @ExpiryDate, @RegistrationFilePath)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenantId", residence.TenantID);
                    cmd.Parameters.AddWithValue("@FirstName", residence.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", residence.LastName);
                    cmd.Parameters.AddWithValue("@Birthday", residence.Birthday);
                    cmd.Parameters.AddWithValue("@Gender", residence.Gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", residence.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", residence.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PermanentAddress", residence.PermanentAddress);
                    cmd.Parameters.AddWithValue("@RegisteredAddress", residence.RegisteredAddress);
                    cmd.Parameters.AddWithValue("@StartDate", residence.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", residence.Notes ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ExpiryDate", residence.ExpiryDate);
                    cmd.Parameters.AddWithValue("@RegistrationFilePath", residence.RegistrationFilePath ?? (object)DBNull.Value);

                    try
                    {
                        int result = cmd.ExecuteNonQuery();
                        Console.WriteLine($"SaveTemporaryResidence result: {result}");
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error saving temporary residence: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }

}
