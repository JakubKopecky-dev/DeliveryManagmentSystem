using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserService.Application.DTOs.User
{
    public sealed record CreateUserDto([EmailAddress] string Email, string Password, bool IsAdmin);

}
