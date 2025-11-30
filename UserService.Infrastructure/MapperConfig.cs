using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs.User;
using UserService.Infrastructure.Identity;

namespace UserService.Infrastructure
{
    public static class MapperConfig
    {
        public static UserDto UserToUserDto(this ApplicationUser user) =>
            new(user.Id, user.Email!, user.IsAdmin);

    }
}
