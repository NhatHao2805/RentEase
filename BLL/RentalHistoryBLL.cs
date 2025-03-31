using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class RentalHistoryBLL
    {
        public static DataTable LoadRentalHistory(string username)
        {
            return RentalHistoryAccess.LoadRentalHistoryByUser(username);
        }
    }
}