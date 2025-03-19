using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public string username { get; set; }
        public string fullname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string birth { get; set; }
        public string gender { get; set; }
        public string phonenumber { get; set; }
        public string address { get; set; }
    }

    public class House
    {
        public string houseID { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string convenient { get; set; }
        public string area { get; set; }
        public string price { get; set; }
        public string status { get; set; }
        public string lastMaintenanceDate { get; set; }
    }

}
