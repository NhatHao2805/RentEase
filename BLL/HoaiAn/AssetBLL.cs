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
        public static string CheckLogic(Assets assets, string buildingid)
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
                // Xóa định dạng tiền tệ để kiểm tra
                string cleanPrice = assets.Price.Replace("VND", "").Replace(",", "").Trim();
                if (!decimal.TryParse(cleanPrice, out decimal priceValue))
                {
                    return "invalid_price_format";
                }
                
                // Kiểm tra giới hạn giá trị (1,000 VND đến 1,000,000,000 VND)
                if (priceValue < 1000 || priceValue > 1000000000)
                {
                    return "price_out_of_range";
                }
            }
            if (string.IsNullOrEmpty(assets.Status))
            {
                return "required_status";
            }

            return AssetAccess.addAsset(assets, buildingid);
        }

        public static string UpdateAsset(Assets assets, string buildingid)
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
                // Xóa định dạng tiền tệ để kiểm tra
                string cleanPrice = assets.Price.Replace("VND", "").Replace(",", "").Trim();
                if (!decimal.TryParse(cleanPrice, out decimal priceValue))
                {
                    return "invalid_price_format";
                }
                
                // Kiểm tra giới hạn giá trị
                if (priceValue < 1000 || priceValue > 1000000000)
                {
                    return "price_out_of_range";
                }
            }

            return AssetAccess.updateAsset(assets, buildingid);
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
                return AssetAccess.FilterAssets(username, null, null, buildingid);
            }

            return AssetAccess.FilterAssets(username, priceSort, nameSort, buildingid);
        }
    }
}
