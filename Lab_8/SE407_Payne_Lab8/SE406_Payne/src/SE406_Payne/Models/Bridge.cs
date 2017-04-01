using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class Bridge
    {
        [Required(ErrorMessage = "Bridge ID is required")]
        public Guid Bridgeid { get; set; }

        [Required(ErrorMessage = "Material Design ID is required")]
        public Guid MaterialDesignId { get; set; }

        [Required(ErrorMessage = "Construction Design ID is required")]
        public Guid ConstructionDesignId { get; set; }

        [Required(ErrorMessage = "Functional Class ID is required")]
        public Guid FunctionalClassId { get; set; }

        [Required(ErrorMessage = "Status ID is required")]
        public Guid StatusId { get; set; }

        [Required(ErrorMessage = "County ID  is required")]
        public Guid CountyId { get; set; }

        [Required(ErrorMessage = "Nbi Number is a required field")]
        [MinLength(5, ErrorMessage = "Minimum length of Nbi is 5 characters")]
        [MaxLength(100, ErrorMessage = "Max length of Nbi is 100 characters")]
        public string NbiNumber { get; set; }

        public decimal? Rating { get; set; }
        public string RouteNumber { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Intersecting Feature is a required field")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 characters")]
        [MaxLength(255, ErrorMessage = "Max length is 255 characters")]
        public string IntersectingFeature { get; set; }

        [Required(ErrorMessage = "Carried Feature is a required field")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 characters")]
        [MaxLength(255, ErrorMessage = "Max length of is 255 characters")]
        public string CarriedFeature { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 characters")]
        [MaxLength(255, ErrorMessage = "Max length of is 255 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Built is required")]
        [Range(1600, 2025, ErrorMessage = "Year out of range")]
        public int Built { get; set; }

        [Range(1600, 2025, ErrorMessage = "Year out of range")]
        public int? Reconstructed { get; set; }

        [Required(ErrorMessage = "Total Length is a required field")]
        public decimal TotalLength { get; set; }

        
    }
}
