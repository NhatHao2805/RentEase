using DAL.honhathao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.honhathao
{
    public class KeyBLL
    {
        public static String add_Key(string usern, string key)
        {
            return KeyAccess.add_Key(usern, key);
        }
        public static void reload_key()
        {
            KeyAccess.reload_key();
        }

        public static DataTable load_building_by_key(string usern)
        {
            return KeyAccess.load_building_by_key(usern);
        }
    }
}
