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
        public static string CheckLogic(Vehicle vehicle)
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

            return VehicleAccess.addVehicle(vehicle);
        }

        public static string UpdateVehicle(Vehicle vehicle)
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

            return VehicleAccess.updateVehicle(vehicle);
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

        public static DataTable FilterVehicle(string buildingid, string type, string status)
        {
            return VehicleAccess.FilterVehicle(buildingid, type, status);
        }
    }
}
