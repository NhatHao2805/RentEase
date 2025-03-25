using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DAL;
using DTO;
namespace BLL
{
    public class AssetsBLL
    {
        private AssetsAccess assetAccess = new AssetsAccess();
        public DataTable LoadAsset()
        {
            return assetAccess.getAssets();
        }

        public DataTable GetRoomID()
        {
            return assetAccess.GetRoomID();
        }

        public string CheckLogic(Assets asset)
        {
            if (asset.assetID == "")
            {
                return "required_assetid";
            }

            if (asset.roomID == "")
            {
                return "required_roomid";
            }

            if (asset.assetName == "")
            {
                return "required_assetname";
            }

            if (asset.price == "")
            {
                return "required_price";
            }

            string info = assetAccess.addAsset(asset);
            return info;
        }
    }
}
