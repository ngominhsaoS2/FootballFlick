using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballFlick.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "Please enter UserName")]
        public string UserName { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password length must be more than 6 characters")]
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirmed password is not correct")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please use a real Email")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

    }
}