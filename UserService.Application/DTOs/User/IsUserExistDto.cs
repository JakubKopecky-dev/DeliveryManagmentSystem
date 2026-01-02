using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.DTOs.User
{
    public sealed record IsUserExistDto(bool IsUserExist, Guid? UserId);


}
