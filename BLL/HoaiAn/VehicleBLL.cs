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
    public class VehicleBLL
    {
        public static string CheckLogic(Vehicle vehicle, string areaid)
        {
            if (string.IsNullOrEmpty(vehicle.TenantID))
            {
                return "required_tenantid";
            }

            if (string.IsNullOrEmpty(vehicle.Type))
            {
                return "required_type";
            }

            if (string.IsNullOrEmpty(vehicle.LicensePlate))
            {
                return "required_licenseplate";
            }

            return VehicleAccess.addVehicle(vehicle, areaid);
        }

        public static string UpdateVehicle(Vehicle vehicle, string areaid)
        {

            if (string.IsNullOrEmpty(vehicle.TenantID))
            {
                return "required_tenantid";
            }

            if (string.IsNullOrEmpty(areaid))
            {
                return "required_areaid";
            }

            if (string.IsNullOrEmpty(vehicle.Type))
            {
                return "required_type";
            }

            if (string.IsNullOrEmpty(vehicle.LicensePlate))
            {
                return "required_licenseplate";
            }

            return VehicleAccess.updateVehicle(vehicle, areaid);
        }

        public static (bool success, string message) DeleteVehicle(string vehicleid)
        {
            return VehicleAccess.DeleteVehicle(vehicleid);
        }

        public static DataTable GetVehicleUnitPriceByType(string type)
        {
            return VehicleAccess.GetVehicleUnitPriceByType(type);
        }

        public static DataTable GetAllVehicleUnitPrices()
        {
            return VehicleAccess.GetAllVehicleUnitPrices();
        }
        public static float GetVehicleUnitPriceById(string unitprice_id)
        {
            DataTable dt = VehicleAccess.GetVehicleUnitPriceById(unitprice_id);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToSingle(dt.Rows[0]["UNITPRICE"]);
            }
            return 0;
        }
        public static DataTable GetAllVehicle()
        {
            return VehicleAccess.GetAllVehicle();
        }
        public static DataTable GetVehicleUnitPriceIdByType(string type)
        {
            return VehicleAccess.GetVehicleUnitPriceIdByType(type);
        }

        public static DataTable FilterVehicle(string buildingid, string type)
        {
            return VehicleAccess.FilterVehicle(buildingid, type);
        }
    }
}
