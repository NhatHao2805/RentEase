using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.honhathao;
using System.Data;
namespace BLL.honhathao

{
    public class BuildingBLL
    {
        public static DataTable BuildingBLL_load_Building_By_User(string usern)
        {
            return BuildingAccess.load_building_by_user(usern);
        }

        public static void BuildingBLL_change_building_key(string buidingid, string buidlingKey)
        {
            BuildingAccess.change_building_key(buidingid, buidlingKey);
        }
    }
}
