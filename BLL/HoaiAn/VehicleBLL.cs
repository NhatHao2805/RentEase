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
        public static DataTable LoadVehicle(string areaId, List<string> tenantIds)
        {
            string tenantIdsString = null;
            if (tenantIds != null && tenantIds.Count > 0)
            {
                tenantIdsString = "('" + string.Join("'),('", tenantIds) + "')";
            }
            return VehicleAccess.LoadVehicle(areaId, tenantIds);
        }
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

        //public static DataTable FilterVehicle(string username, string priceSort, string nameSort, string buildingid)
        //{
        //    if (string.IsNullOrEmpty(priceSort) && string.IsNullOrEmpty(nameSort))
        //    {
        //        return VehicleAccess.LoadVehicle(username, buildingid);
        //    }

        //    return VehicleAccess.FilterVehicle(username, priceSort, nameSort, buildingid);
        //}
    }
}
