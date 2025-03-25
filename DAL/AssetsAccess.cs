using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class AssetsAccess: DatabaseAccess
    {
        private DatabaseAccess database = new DatabaseAccess();
        public DataTable getAssets()
        {
            return database.LoadAssets();
        }

        public DataTable GetRoomID()
        {
            return database.LoadRoomID();
        }

        public string addAsset(Assets asset)
        {
            return addAssetsDatabase(asset);
        }

    }
}
