using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class StatusCode
    {
        [Required(ErrorMessage = "Status Code Id is required")]
        public Guid StatusCodeId { get; set; }

        [Required(ErrorMessage = "Status Name is required")]
        [MinLength(5, ErrorMessage = "Minimum length of Status Name is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length of Status Name is 50 characters")]
        public string StatusName { get; set; }
    }
}
