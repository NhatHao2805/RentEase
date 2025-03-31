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

        public static string CheckLogic(Assets assets)
        {
            if (string.IsNullOrEmpty(assets.RoomId))
            {
                return "required_roomid";
            }

            if (string.IsNullOrEmpty(assets.AssetName))
            {
                return "required_assetname";
            }

            if (string.IsNullOrEmpty(assets.Price))
            {
                return "required_price";
            }
            else
            {
                if (!decimal.TryParse(assets.Price, out decimal priceValue) || priceValue <= 0)
                {
                    return "invalid_price_format";
                }
            }
            if (string.IsNullOrEmpty(assets.Status))
            {
                return "required_status";
            }

            return AssetAccess.addAsset(assets);
        }

        public static string UpdateAsset(Assets assets)
        {

            if (string.IsNullOrEmpty(assets.AssetName))
            {
                return "required_assetname";
            }

            if (string.IsNullOrEmpty(assets.Price))
            {
                return "required_price";
            }
            else
            {
                if (!decimal.TryParse(assets.Price, out decimal priceValue) || priceValue <= 0)
                {
                    return "invalid_price_format";
                }
            }

            return AssetAccess.updateAsset(assets);
        }

        public static DataTable LoadBuildingID(string username)
        {
            return AssetAccess.LoadBuildingID(username);
        }

        public static DataTable LoadRoomID(string buildingid)
        {
            return AssetAccess.LoadRoomID(buildingid);
        }

        public static (bool success, string message) DeleteAssets(string assetid)
        {
            return AssetAccess.DeleteAssets(assetid);
        }

        public static DataTable LoadAssetDetail(string assetid)
        {
            return AssetAccess.LoadAssetDetail(assetid);
        }
    }
}
