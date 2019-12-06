namespace UthTripProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserViewModel
    {
        public int User_ID { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "Ім'я має містити принаймні 4 символи.")]
        [DisplayName("Ім'я")]
        [Required(ErrorMessage = "Обов'язкове поле.")]
        public string First_Name { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Прізвище має містити принаймні 3 символи.")]
        [DisplayName("Прізвище")]
        [Required(ErrorMessage = "Обов'язкове поле.")]
        public string Last_Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Обов'язкове поле.")]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "Ім'я коростувача має містити принаймні 4 символи.")]
        [Required(ErrorMessage = "Обов'язкове поле.")]
        public string Username { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Пароль має містити принаймні 4 символи.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Дата народження")]
        [DataType(DataType.Date)]
        ////[Required(ErrorMessage = "This field is required.")]
        public System.DateTime Birthday { get; set; }

        ////[StringLength(30, MinimumLength = 5, ErrorMessage = "Photo URL must have at least 5 char.")]
        [DisplayName("URL фото")]
        ////[Required(ErrorMessage = "This field is required.")]
        public string Photo_Url { get; set; }

        ////[StringLength(30, MinimumLength = 10, ErrorMessage = "Info must have at least 3 char.")]
        [DisplayName("Трохи інформації про тебе")]
        [DataType(DataType.MultilineText)]
        ////[Required(ErrorMessage = "This field is required.")]
        public string Info { get; set; }
    }
}
