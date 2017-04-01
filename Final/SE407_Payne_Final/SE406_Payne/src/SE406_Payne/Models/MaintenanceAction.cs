using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class MaintenanceAction
    {
        [Required(ErrorMessage = "Maintenance Action ID is required")]
        public Guid MaintenanceActionId { get; set; }

        [Required(ErrorMessage = "Maintenance Action name is required")]
        [MinLength(5, ErrorMessage = "Minimum length of Maintenance Action Id is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length of Maintenance Action ID is 50 characters")]
        public string MaintenanceActionName { get; set; }  
    }
}
