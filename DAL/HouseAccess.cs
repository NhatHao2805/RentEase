using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class HouseAccess: DatabaseAccess
    {
        private DatabaseAccess databaseAccess = new DatabaseAccess();

        public DataTable getHouse()
        {
            return databaseAccess.LoadHouse();
        }

        public string addHouse(House house)
        {
            return addHouseDatabase(house);
        }
    }
}
