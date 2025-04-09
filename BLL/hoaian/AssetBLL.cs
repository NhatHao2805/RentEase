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
        public static DataTable LoadAssets(string Username, string buildingid)
        {
            return AssetAccess.LoadAssets(Username, buildingid);
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

        public static DataTable LoadRoomID(string buildingid)
        {
            return AssetAccess.LoadRoomID(buildingid);
        }

        public static (bool success, string message) DeleteAssets(string assetid)
        {
            return AssetAccess.DeleteAssets(assetid);
        }

        public static DataTable LoadAssetDetail(string username, string buildingid)
        {
            return AssetAccess.LoadAssetDetail(username, buildingid);
        }

        public static DataTable FilterAssets(string username, string priceSort, string nameSort, string buildingid)
        {
            if(string.IsNullOrEmpty(priceSort) && string.IsNullOrEmpty(nameSort))
            {
                return AssetAccess.LoadAssets(username, buildingid);
            }

            return AssetAccess.FilterAssets(username, priceSort, nameSort, buildingid);
        }
    }
}
