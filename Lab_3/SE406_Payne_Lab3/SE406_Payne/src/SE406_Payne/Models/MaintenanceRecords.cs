﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Payne.Models
{
    public class MaintenanceRecords
    {
        public Guid MaintenanceId { get; set; }
        public Guid MaintenanceActionId { get; set; }
        public Guid InspectorId { get; set; }
        public DateTime MaintenanceProjectedStart { get; set; }
        public DateTime MaintenanceProjectedEnd { get; set; }
        public DateTime MaintenanceActualStart { get; set; }
        public DateTime MaintenanceenanceActualEnd { get; set; }
        public decimal MaintenanceProjectedCost { get; set; }
        public decimal MaintenanceActualCost { get; set; }
        public string MaintenanceNotes { get; set; }
        public string InspectorNotes { get; set; }
    }
}
