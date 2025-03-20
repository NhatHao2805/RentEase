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
        RoomAccess roomAccess = new RoomAccess();

        public DataTable LoadRoom()
        {
            return roomAccess.getRoom();
        }

        public string CheckLogic(Room room)
        {
            // Kiểm tra nghiệp vụ
            if (string.IsNullOrWhiteSpace(room.roomID) || room.roomID == "  ID phòng")
            {
                return "required_roomid";
            }

            if (string.IsNullOrWhiteSpace(room.price) || room.price == "  Giá")
            {
                return "required_price";
            }

            if (string.IsNullOrWhiteSpace(room.area) || room.area == "  Diện tích")
            {
                return "required_area";
            }

            if (string.IsNullOrWhiteSpace(room.lastMaintenanceDate))
            {
                return "required_last_maintenance_date";
            }

            string info = roomAccess.addRoom(room);
            return info;
        }

        public DataTable FilterRoomByStatus(string status)
        {
            DataTable allRooms = roomAccess.getRoom();

            string[] statuses = status.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            DataTable filteredTable = allRooms.Clone();
            foreach (DataRow row in allRooms.Rows)
            {
                string roomStatus = row["STATUS"].ToString();

                bool isMatch = true;
                foreach (var s in statuses)
                {
                    if (!roomStatus.Contains(s.Trim()))
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    filteredTable.ImportRow(row);
                }
            }

            return filteredTable;
        }

    }
}
