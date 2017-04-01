using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class User
    {
        [Required(ErrorMessage = "User ID is an Required Field")]
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "First Name is an Required Field")]
        [MinLength(5, ErrorMessage = "Minimum length of First Name is 5 characters")]
        [MaxLength(25, ErrorMessage = "Max length of First Name is 25 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is an Required Field")]
        [MinLength(5, ErrorMessage = "Minimum length of Last Name is 5 characters")]
        [MaxLength(25, ErrorMessage = "Max length of Last Name is 25 characters")]
        public string LastName{ get; set; }

        [Required(ErrorMessage = "Email is an Required Field")]
        [MinLength(5, ErrorMessage = "Minimum length of an Email is 5 characters")]
        [MaxLength(100, ErrorMessage = "Max length of an Email is 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "Minimum length for a Password is 5 characters")]
        [MaxLength(255, ErrorMessage = "Max length for a Password is 255 characters")]
        public string Password { get; set; }

    }
}
