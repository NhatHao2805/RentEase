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
            }

            if (string.IsNullOrEmpty(room.Status))
            {
                return "required_status";
            }

            if (room.Status.Contains("Đang ở") && room.Status.Contains("Đang trống") && room.Status.IndexOf("Đang ở") < room.Status.IndexOf("Đang trống"))
            {
                return "Không thể vừa 'Đang ở' vừa 'Đang trống'.";
            }

            if (room.Status.Contains("Đang ở") && room.Status.Contains("Đang trống") && room.Status.IndexOf("Đang ở") > room.Status.IndexOf("Đang trống"))
            {
                return "Không thể vừa 'Đang trống' vừa 'Đang ở'.";
            }

            if (room.Status.Contains("Đang cọc giữ chỗ") && room.Status.Contains("Đang báo kết thúc") && room.Status.IndexOf("Đang cọc giữ chỗ") < room.Status.IndexOf("Đang báo kết thúc"))
            {
                return "Không thể vừa 'Đang cọc giữ chỗ' vừa 'Đang báo kết thúc'.";
            }

            if (room.Status.Contains("Đang cọc giữ chỗ") && room.Status.Contains("Đang báo kết thúc") && room.Status.IndexOf("Đang cọc giữ chỗ") > room.Status.IndexOf("Đang báo kết thúc"))
            {
                return "Không thể vừa 'Đang báo kết thúc' vừa 'Đang cọc giữ chỗ'.";
            }

            if (room.Status.Contains("Đã quá hạn hợp đồng") && room.Status.Contains("Sắp hết hạn hợp đồng") && room.Status.IndexOf("Đã quá hạn hợp đồng") < room.Status.IndexOf("Sắp hết hạn hợp đồng"))
            {
                return "Không thể vừa 'Đã quá hạn hợp đồng' vừa 'Sắp hết hạn hợp đồng'.";
            }

            if (room.Status.Contains("Đã quá hạn hợp đồng") && room.Status.Contains("Sắp hết hạn hợp đồng") && room.Status.IndexOf("Đã quá hạn hợp đồng") > room.Status.IndexOf("Sắp hết hạn hợp đồng"))
            {
                return "Không thể vừa 'Sắp hết hạn hợp đồng' vừa 'Đã quá hạn hợp đồng'.";
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
            }

            if (string.IsNullOrEmpty(room.Status))
            {
                return "required_status";
            }

            if (room.Status.Contains("Đang ở") && room.Status.Contains("Đang trống") && room.Status.IndexOf("Đang ở") < room.Status.IndexOf("Đang trống"))
            {
                return "Không thể vừa 'Đang ở' vừa 'Đang trống'.";
            }

            if (room.Status.Contains("Đang ở") && room.Status.Contains("Đang trống") && room.Status.IndexOf("Đang ở") > room.Status.IndexOf("Đang trống"))
            {
                return "Không thể vừa 'Đang trống' vừa 'Đang ở'.";
            }

            if (room.Status.Contains("Đang cọc giữ chỗ") && room.Status.Contains("Đang báo kết thúc") && room.Status.IndexOf("Đang cọc giữ chỗ") < room.Status.IndexOf("Đang báo kết thúc"))
            {
                return "Không thể vừa 'Đang cọc giữ chỗ' vừa 'Đang báo kết thúc'.";
            }

            if (room.Status.Contains("Đang cọc giữ chỗ") && room.Status.Contains("Đang báo kết thúc") && room.Status.IndexOf("Đang cọc giữ chỗ") > room.Status.IndexOf("Đang báo kết thúc"))
            {
                return "Không thể vừa 'Đang báo kết thúc' vừa 'Đang cọc giữ chỗ'.";
            }

            if (room.Status.Contains("Đã quá hạn hợp đồng") && room.Status.Contains("Sắp hết hạn hợp đồng") && room.Status.IndexOf("Đã quá hạn hợp đồng") < room.Status.IndexOf("Sắp hết hạn hợp đồng"))
            {
                return "Không thể vừa 'Đã quá hạn hợp đồng' vừa 'Sắp hết hạn hợp đồng'.";
            }

            if (room.Status.Contains("Đã quá hạn hợp đồng") && room.Status.Contains("Sắp hết hạn hợp đồng") && room.Status.IndexOf("Đã quá hạn hợp đồng") > room.Status.IndexOf("Sắp hết hạn hợp đồng"))
            {
                return "Không thể vừa 'Sắp hết hạn hợp đồng' vừa 'Đã quá hạn hợp đồng'.";
            }

            string infor = RoomAccess.UpdateRoom(room);
            return infor;
        }

        public static (bool success, string message) DeleteRoom(string roomId)
        {
            return RoomAccess.DeleteRoom(roomId);
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
