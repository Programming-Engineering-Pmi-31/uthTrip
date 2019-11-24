namespace uthTripProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class UserViewModel
    {
        public int User_ID { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "First name must have at least 4 chars.")]
        [DisplayName("First name")]
        [Required(ErrorMessage = "This field is required.")]
        public string First_Name { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last name must have at least 3 chars.")]
        [DisplayName("Last name")]
        [Required(ErrorMessage = "This field is required.")]
        public string Last_Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "User name must have at least 4 chars.")]
        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Password must have at least 5 char.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Birthday date")]
        [DataType(DataType.Date)]
        ////[Required(ErrorMessage = "This field is required.")]
        public System.DateTime Birthday { get; set; }


        ////[StringLength(30, MinimumLength = 5, ErrorMessage = "Photo URL must have at least 5 char.")]
        [DisplayName("Your photo URL")]
        ////[Required(ErrorMessage = "This field is required.")]
        public string Photo_Url { get; set; }

        ////[StringLength(30, MinimumLength = 10, ErrorMessage = "Info must have at least 3 char.")]
        [DisplayName("Some information about you")]
        [DataType(DataType.MultilineText)]
        ////[Required(ErrorMessage = "This field is required.")]
        public string Info { get; set; }
    }

}
