using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.honhathao;
using System.Data;
using DTO;
namespace BLL.honhathao

{
    public class BuildingBLL
    {
        public static string BuildingBLL_add_building( string buildingKey, string username, string address)
        {
            return BuildingAccess.add_building( buildingKey, username, address);
        }
        public static DataTable BuildingBLL_load_Building_By_User(string usern)
        {
            return BuildingAccess.load_building_by_user(usern);
        }

        public static void BuildingBLL_change_building_key(string buidingid, string buidlingKey)
        {
            BuildingAccess.change_building_key(buidingid, buidlingKey);
        }

        public static DataTable LoadBuilding(string username)
        {
            return BuildingAccess.LoadBuilding(username);
        }

        public static string addBuilding(Building building)
        {
            if (string.IsNullOrEmpty(building.BuildingKey))
            {
                return "required_buildingkey";
            }

            if (building.BuildingKey.Length > 20)
            {
                return "buildingkey_too_long";
            }

            if (string.IsNullOrEmpty(building.Address))
            {
                return "required_address";
            }

            if (building.NumOfFloors <= 0 || building.NumOfFloors > int.MaxValue)
            {
                return "invalid_floors";
            }

            if (building.NumOfRooms <= 0 || building.NumOfRooms > int.MaxValue)
            {
                return "invalid_rooms";
            }

            return BuildingAccess.addBuilding(building);
        }
    }
}
