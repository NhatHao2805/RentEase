using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.gui_service
{
    public partial class Form_ManageAreas : Form
    {
        private void LoadAreaList()
        {
            try
            {
                List<AreaPermissionDTO> areas = fingerprintBLL.GetAvailableAreas(buildingID);
                dgvAreas.Rows.Clear();
                foreach (var area in areas)
                {
                    int rowIndex = dgvAreas.Rows.Add();
                    dgvAreas.Rows[rowIndex].Cells["AreaID"].Value = area.AreaID;
                    dgvAreas.Rows[rowIndex].Cells["AreaName"].Value = $"{area.AreaID} - {area.AreaName}";
                    dgvAreas.Rows[rowIndex].Cells["Description"].Value = area.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khu vực: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 