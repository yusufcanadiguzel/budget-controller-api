﻿using Microsoft.AspNetCore.Identity;

namespace BudgetControllerApi.Entities.Concrete
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
    }
}
