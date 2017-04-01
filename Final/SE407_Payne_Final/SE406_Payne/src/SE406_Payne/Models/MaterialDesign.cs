using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class MaterialDesign
    {
        [Required(ErrorMessage = "Material Design ID is required")]
        public Guid MaterialDesignId { get; set; }

        [Required(ErrorMessage = "Material Design Type is required")]
        [MinLength(5, ErrorMessage = "Minimum length of Material Design Type is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length of Material Design Type is 50 characters")]
        public string MaterialDesignType { get; set; }
    }
}
