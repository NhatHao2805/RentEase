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

        //public List<ContractDTO> GetAllContracts(string status)
        //{
        //    return DatabaseAccess.GetAllContracts(status);
        //}

        public bool SaveContract(ContractDTO contract)
        {
            // Validate contract data
            if (string.IsNullOrEmpty(contract.ContractID) ||
                string.IsNullOrEmpty(contract.HouseID) ||
                string.IsNullOrEmpty(contract.TenantID))
            {
                return false;
            }

            // Save to database
            return DatabaseAccess.SaveContract(contract);
        }
    }

}
