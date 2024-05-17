﻿using Microsoft.AspNetCore.Identity;

namespace Medico.Models
{
    public class User:IdentityUser
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
