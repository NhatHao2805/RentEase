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

        public static List<string> RoomBLL_Load_RoomAddress(string Username)
        {
            return RoomAccess.RoomAccess_Load_RoomAddress(Username);
        }
        public static List<string> RoomBLL_Load_RoomInBuilding(string Address)
        {
            return RoomAccess.RoomAccess_Load_RoomInBuilding(Address);
        }

        public static string RoomBLL_TakePrice(string roomid)
        {
            return RoomAccess.RoomAccess_TakePrice(roomid);
        }
    }
}
