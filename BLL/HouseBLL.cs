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
    public class HouseBLL
    {
        HouseAccess houseAccess = new HouseAccess();

        public DataTable LoadHouse()
        {
            return houseAccess.getHouse();
        }

        public string CheckLogic(House house)
        {
            // Kiểm tra nghiệp vụ
            if (string.IsNullOrWhiteSpace(house.houseID) || house.houseID == "  ID nhà")
            {
                return "required_houseid";
            }

            if (string.IsNullOrWhiteSpace(house.address) || house.address == "  Địa chỉ nhà")
            {
                return "required_address";
            }

            if (string.IsNullOrWhiteSpace(house.price) || house.price == "  Giá")
            {
                return "required_price";
            }

            if (string.IsNullOrWhiteSpace(house.area) || house.area == "  Diện tích")
            {
                return "required_area";
            }

            if (string.IsNullOrWhiteSpace(house.lastMaintenanceDate))
            {
                return "required_last_maintenance_date";
            }

            string info = houseAccess.addHouse(house);
            return info;
        }

        public DataTable FilterHouseByStatus(string status)
        {
            DataTable allHouses = houseAccess.getHouse();

            string[] statuses = status.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            DataTable filteredTable = allHouses.Clone();
            foreach (DataRow row in allHouses.Rows)
            {
                string houseStatus = row["STATUS"].ToString();

                bool isMatch = true;
                foreach (var s in statuses)
                {
                    if (!houseStatus.Contains(s.Trim()))
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
