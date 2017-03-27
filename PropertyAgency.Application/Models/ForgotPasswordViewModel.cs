using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyAgency.Application.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}