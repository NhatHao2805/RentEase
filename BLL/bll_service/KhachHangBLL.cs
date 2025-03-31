using DAL.DAL_Service;
using DTO.DTO_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Service
{
    public class KhachHangBLL
    {
        public List<object> GetKhachHangForComboBox()
        {
            var list = new List<object>();
            foreach (var kh in KhachHangAccess.Load_KhachHang())
            {

                list.Add(new
                {
                    ID = kh.ID,
                    Name = $"{kh.FullName} - {kh.ID}" // Hiển thị cả Tên và ID
                });
            }
            return list;
        }
    }
    public class PhongBLL
    {
        public List<object> GetPhongForComboBox()
        {
            var list = new List<object>();
            foreach (var phong in PhongAccess.Load_Phong())
            {
                list.Add(new { ID = phong.ID, Name = $"Phòng {phong.ID}" });
            }
            return list;
        }
        public List<PhongDTO> GetPhongByTenantID(string tenantID)
        {
            return PhongAccess.GetPhongByTenantID(tenantID);
        }

    }
    public class DichVuBLL
    {
        public List<object> GetDichVuForComboBox()
        {
            var list = new List<object>();
            foreach (var dv in DichVuAccess.Load_DichVu())
            {
                list.Add(new { ID = dv.ID, Name = dv.TenDichVu });
            }
            return list;
        }

        public Boolean AddService(string tenantID, string roomID, string serviceID, int price)
        {
            return DichVuAccess.AddService(tenantID, roomID, serviceID, price);
        }
    }

}
