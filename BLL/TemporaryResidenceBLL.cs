using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class TemporaryResidenceBLL
    {
        public List<TemporaryResidenceDTO> GetAllTemporaryResidences()
        {
            // Gọi DAL để lấy dữ liệu
            return DatabaseAccess.GetAllTemporaryResidences();
        }
        public bool AddTemporaryResidence(TemporaryResidenceDTO residence)
        {
            return DatabaseAccess.SaveTemporaryResidence(residence);
        }
    }
}