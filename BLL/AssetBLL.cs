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
    public class AssetBLL
    {
        public static DataTable AssetsBLL_load_Assets(string Username)
        {
            return AssetAccess.LoadAssetsByUser(Username);
        }

        public static (bool success, string message) DeleteAssets(string assetid)
        {
            return AssetAccess.DeleteAssets(assetid);
        }
    }
}
