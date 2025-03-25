using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class RoomBLL
    {
        public static DataTable RoomBLL_load_Room(string Username)
        {
            return RoomAccess.LoadRoomByUser(Username);
        }
    }
}
