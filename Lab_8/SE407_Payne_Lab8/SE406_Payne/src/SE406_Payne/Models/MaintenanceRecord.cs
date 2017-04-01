using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class MaintenanceRecord
    {
        [Required(ErrorMessage = "Maintenance Record ID is required")]
        public Guid MaintenanceRecordId { get; set; }

        [Required(ErrorMessage = "Maintenance Action ID is required")]
        public Guid MaintenanceActionId { get; set; }

        [Required(ErrorMessage = "Inspector ID is required")]
        public Guid InspectorId { get; set; }

        [Required(ErrorMessage = "Maintenance Projected Start is required")]
        public DateTime MaintenanceProjectedStart { get; set; }

        [Required(ErrorMessage = "Maintenance Projected End is required")]
        public DateTime MaintenanceProjectedEnd { get; set; }

        public DateTime? MaintenanceActualStart { get; set; }
        public DateTime? MaintenanceActualEnd { get; set; }

        [Required(ErrorMessage = "Maintenance Projected Cost is required")]
        public decimal MaintenanceProjectedCost { get; set; }

        public decimal? MaintenanceActualCost { get; set; }
        public string MaintenanceNotes { get; set; }
        public string InspectorNotes { get; set; }
    }
}
