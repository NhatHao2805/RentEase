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
    public class RoomBLL
    {
        
        public static List<string> RoomBLL_Load_RoomInBuilding_2(string buildingid)
        {
            return RoomAccess.RoomAccess_Load_RoomInBuilding_2(buildingid);
        }
        public static List<string> RoomBLL_Load_RoomAddress(string buildingid)
        {
            return RoomAccess.RoomAccess_Load_RoomAddress(buildingid);
        }
        public static List<string> RoomBLL_Load_RoomInBuilding(string Address)
        {
            return RoomAccess.RoomAccess_Load_RoomInBuilding(Address);
        }
        public static string RoomBLL_TakePrice(string roomid)
        {
            return RoomAccess.RoomAccess_TakePrice(roomid);
        }
        public static DataTable RoomBLL_load_Room(string Username)
        {
            return RoomAccess.LoadRoomByUser(Username);
        }

        //1
        public static DataTable LoadRoom(string username, string buildingid)
        {
            return RoomAccess.LoadRoom(username, buildingid);
        }

        public string CheckLogic(Room room)
        {
            if (string.IsNullOrEmpty(room.BuildingId))
            {
                return "required_buildingid";
            }

            if (string.IsNullOrEmpty(room.Floor))
            {
                return "required_floor";
            }

            if (string.IsNullOrEmpty(room.Type))
            {
                return "required_type";
            }

            if (string.IsNullOrEmpty(room.Area))
            {
                return "required_area";
            }
            else
            {
                if (!decimal.TryParse(room.Area, out decimal areaValue) || areaValue <= 0)
                {
                    return "invalid_area_format";
                }
                if (areaValue > 1000) // Giới hạn diện tích tối đa 1000m2
                {
                    return "area_too_large";
                }
            }

            if (string.IsNullOrEmpty(room.Price))
            {
                return "required_price";
            }
            else
            {
                if (!decimal.TryParse(room.Price, out decimal priceValue) || priceValue <= 0)
                {
                    return "invalid_price_format";
                }
                if (priceValue > 1000000000) // Giới hạn giá thuê tối đa 1 tỷ
                {
                    return "price_too_large";
                }
            }

            if (string.IsNullOrEmpty(room.Status))
            {
                return "required_status";
            }

            string infor = RoomAccess.AddRoom(room);
            return infor;
        }

        public static string UpdateRoom(Room room)
        {
            if (string.IsNullOrEmpty(room.Area))
            {
                return "required_area";
            }
            else
            {
                if (!decimal.TryParse(room.Area, out decimal areaValue) || areaValue <= 0)
                {
                    return "invalid_area_format";
                }
                if (areaValue > 1000) // Giới hạn diện tích tối đa 1000m2
                {
                    return "area_too_large";
                }
            }

            if (string.IsNullOrEmpty(room.Price))
            {
                return "required_price";
            }

            else
            {
                if (!decimal.TryParse(room.Price, out decimal priceValue) || priceValue <= 0)
                {
                    return "invalid_price_format";
                }
                if (priceValue > 1000000000) // Giới hạn giá thuê tối đa 1 tỷ
                {
                    return "price_too_large";
                }
            }

            if (string.IsNullOrEmpty(room.Status))
            {
                return "required_status";
            }

            string infor = RoomAccess.UpdateRoom(room);
            return infor;
        }

        public static (bool success, string message) DeleteRoom(string roomId, string buildingid)
        {
            return RoomAccess.DeleteRoom(roomId, buildingid);
        }
        public static DataTable FilterRoomByStatus(string status, string userName, string buildingid)
        {
            if (string.IsNullOrEmpty(status))
            {
                return LoadRoom(userName, buildingid);
            }

            return RoomAccess.FilterRoomByStatus(status, userName, buildingid);
        }

        public static int LoadFloorByBuildingID(string buildingID)
        {
            return RoomAccess.LoadFloorByBuildingID(buildingID);
        }
        public static DataTable LoadRoomIdByBuildingID(string buildingID)
        {
            return RoomAccess.LoadRoomIdByBuildingID(buildingID);
        }

    }
}
