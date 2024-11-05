﻿using System.ComponentModel.DataAnnotations;

namespace BudgetControllerApi.Shared.Dtos.User
{
    public record UserDtoForRegistration
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        public string? Email { get; set; }
    }
}
