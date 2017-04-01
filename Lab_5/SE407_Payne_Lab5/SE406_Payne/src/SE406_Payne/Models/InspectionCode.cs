using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class InspectionCode
    {
        [Required(ErrorMessage = "Inspection Code ID is required")]
        public Guid InspectionCodeId { get; set; }

        [Required(ErrorMessage = "Inspection Code Name is required")]
        [MinLength(5, ErrorMessage = "Minimum length of Inspection Code Name is 5 characters")]
        [MaxLength(50, ErrorMessage = "Maximum length of Inspection Code Name is 50 characters")]
        public string InspectionCodeName { get; set; }

        [Required(ErrorMessage = "Inspection Code Description is required")]
        [MinLength(5, ErrorMessage = "Minimum length of Inspection Code Description is 5 characters")]
        [MaxLength(400, ErrorMessage = "Maximum length of Inspection Code Description is 400 characters")]
        public string InspectionCodeDesc { get; set; }   
    }
}
