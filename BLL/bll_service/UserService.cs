using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAL_Service;
using DTO.DTO_Service;
namespace BLL.BLL_Service
{
    using DAL.DAL_Service;
    using System.Data;

    public class UserService
    {
        private UserServiceDAL dal = new UserServiceDAL();

        public List<UserServiceDTO> GetServiceUsage(string filter, string buildingID)
        {
            return dal.GetServiceUsage(filter, buildingID);
        }
    }

}
