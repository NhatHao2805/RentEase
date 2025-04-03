using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.dto_service
{
    public class ElectricWaterServiceDTO
    {
        public string FigureID { get; set; }
        public string TenantID { get; set; }
        public int OldFigure { get; set; }
        public int NewFigure { get; set; }
        public string Unit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RecordDate { get; set; }
        public string Type { get; set; }
    }

}
