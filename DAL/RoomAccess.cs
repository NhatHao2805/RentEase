using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class RoomAccess: DatabaseAccess
    {
        private DatabaseAccess databaseAccess = new DatabaseAccess();

        public DataTable getRoom()
        {
            return databaseAccess.LoadRoom();
        }

        public string addRoom(Room room)
        {
            return addRoomDatabase(room);
        }
    }
}
