using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Payne.Models
{
    public class MaintenanceActionViewModel
    {
        public List<MaintenanceAction> MaintenanceActionList { get; set; }
        public MaintenanceAction NewMaintenanceAction { get; set; }
    }
}
