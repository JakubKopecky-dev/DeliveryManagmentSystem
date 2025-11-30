using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserService.Application.DTOs.Auth
{
    public sealed record  AuthLoginDto( [EmailAddress ] string Email, string Password);
        
}
