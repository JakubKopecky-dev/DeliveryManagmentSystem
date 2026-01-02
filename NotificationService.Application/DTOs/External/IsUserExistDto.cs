using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.DTOs.External
{
    public sealed record IsUserExistDto(bool IsUserExist, string? UserId);


}
