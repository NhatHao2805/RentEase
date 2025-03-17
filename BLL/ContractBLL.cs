using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{


    public class ContractBLL
    {
        private MySqlConnectionData contractDAL = new MySqlConnectionData();

        public List<ContractDTO> GetContractList(String required)
        {
            return contractDAL.GetAllContracts(required);
        }
    }

}
