using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class ThongtinkhachthueBLL
    {
        public List<ThongtinkhachthueDTO> GetAllTenants()
        {
            return DatabaseAccess.GetAllTenants();
        }
    }
}