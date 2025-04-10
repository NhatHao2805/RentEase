using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.honhathao;
using DTO;
namespace BLL
{
    public class ParkingAreaBLL
    {
        public static List<string> LoadAreaID()
        {
            return  ParkingAreaAccess.LoadAreaID();
        }
        public static string CheckLogic(ParkingArea area)
        {
            if (string.IsNullOrEmpty(area.Address))
            {
                return "required_address";
            }

            if (string.IsNullOrEmpty(area.Type))
            {
                return "required_type";
            }

            if (string.IsNullOrEmpty(area.Capacity))
            {
                return "required_capacity";
            }
            else
            {
                if (!int.TryParse(area.Capacity, out int capacityValue) || capacityValue <= 0)
                {
                    return "invalid_capacity_format";
                }
            }

            return ParkingAreaAccess.addParkingArea(area);
        }

        public static string UpdateArea(ParkingArea area)
        {

            if (string.IsNullOrEmpty(area.Address))
            {
                return "required_assetname";
            }

            if (string.IsNullOrEmpty(area.Capacity))
            {
                return "required_capacity";
            }
            else
            {
                if (!decimal.TryParse(area.Capacity, out decimal priceValue) || priceValue <= 0)
                {
                    return "invalid_capacity_format";
                }
            }

            return ParkingAreaAccess.updateParkingArea(area);
        }

        public static (bool success, string message) DeleteArea(string areaId)
        {
            return ParkingAreaAccess.DeleteParkingArea(areaId);
        }

        public static DataTable GetAreaId(string type, string buildingid)
        {
            return ParkingAreaAccess.GetAreaId(type, buildingid);
        }
        public static DataTable FilterParkingArea(string buildingid, string type, string status)
        {
            return ParkingAreaAccess.FilterParkingArea(buildingid, type, status);
        }
    }
}
