using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class ConstructionDesign
    {
        [Required(ErrorMessage = "Construction Design ID is required")]
        public Guid ConstructionDesignId { get; set; }

        [Required(ErrorMessage = "Construction Design Type is a required field")]
        [MinLength(5, ErrorMessage = "Minimum length of Name is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length of Name is 50 characters")]
        public string ConstructionDesignType { get; set; }       
    }
}
