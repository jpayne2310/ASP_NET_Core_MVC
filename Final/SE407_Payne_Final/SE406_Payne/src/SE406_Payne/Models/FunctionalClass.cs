using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class FunctionalClass
    {
        [Required(ErrorMessage = "Functional Class ID is a required field")]
        public Guid FunctionalClassId { get; set; }

        [Required(ErrorMessage = "Functional Class Type is a required Field")]
        [MinLength(5, ErrorMessage = "Minimum length of Functional Class Type is 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length of Functional Class Type is 50 characters")]
        public string FunctionalClassType { get; set; }  
    }
}
