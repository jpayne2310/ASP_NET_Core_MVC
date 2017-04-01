using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class County
    {
        [Required(ErrorMessage = "County ID is required")]
        public Guid CountyId { get; set; }

        [MinLength(5, ErrorMessage = "Minimum length of County Name is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length of County Name is 50 characters")]
        [Required(ErrorMessage = "County Name is required")]
        public string CountyName { get; set; }       
    }
}
