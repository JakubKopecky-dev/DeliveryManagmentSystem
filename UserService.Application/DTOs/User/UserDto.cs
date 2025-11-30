using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.DTOs.User
{
    public sealed record UserDto(Guid Id, string Email, bool IsAdmin);

}
