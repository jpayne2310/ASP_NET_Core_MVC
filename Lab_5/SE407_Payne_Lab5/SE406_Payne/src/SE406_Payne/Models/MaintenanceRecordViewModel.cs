using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Payne.Models
{
    public class MaintenanceRecordViewModel
    {
        public List<MaintenanceRecord> MaintenanceRecordList { get; set; }
        public MaintenanceRecord NewMaintenanceRecord { get; set; }
    }
}
