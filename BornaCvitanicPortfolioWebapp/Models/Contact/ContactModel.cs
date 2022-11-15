﻿using System.ComponentModel.DataAnnotations;

namespace BornaCvitanicPortfolioWebapp.Models.Contact
{
    public class ContactModel
    {
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }

        [Required]
        public string Message { get; set; }

    }
}
