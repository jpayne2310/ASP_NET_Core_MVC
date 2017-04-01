using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class Inspector
    {
        [Required(ErrorMessage = "Inspector ID is required")]
        public Guid InspectorId { get; set; }

        [Required(ErrorMessage = "Inspector's First Name is required")]
        [MinLength(5, ErrorMessage = "Minimum length of Inspector's First Name is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length of the Inspector's First Name is 50 characters")]
        public string InspectorFirst { get; set; }

        [Required(ErrorMessage = "Inspector's Last Name is required")]
        [MinLength(5, ErrorMessage = "Minimum length of the Inspector's Last Name is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length of the Inspector's Last Name is 50 characters")]
        public string InspectorLast { get; set; }

        [Required(ErrorMessage = " Inspector's Organization is required")]
        [MinLength(5, ErrorMessage = "Minimum length of the Inspector's Organization is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length of Inspector's Organization is 50 characters")]
        public string InspectorOrg { get; set; }

        
        public DateTime InspectorCertEffective { get; set; }

        public DateTime InspectorCertExpires { get; set; }
    }
}
