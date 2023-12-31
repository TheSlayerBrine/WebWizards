﻿using System.ComponentModel.DataAnnotations;

namespace WebWizards.WebApi.Models.Auth
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set;}
        [Required]
        public string Email { get; set;}
        [Required]
        public string Password { get; set;}
    }
}
