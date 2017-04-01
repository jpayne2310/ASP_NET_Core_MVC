using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SE406_Payne.Models
{
    public class MaintenanceActionViewModel
    {
        public List<MaintenanceAction> MaintenanceActionList { get; set; }
        public MaintenanceAction NewMaintenanceAction { get; set; }
    }
}
