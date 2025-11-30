using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs.User;

namespace UserService.Application.DTOs.Auth
{
    public sealed record AuthResponseDto(UserDto User, string Token);

}
