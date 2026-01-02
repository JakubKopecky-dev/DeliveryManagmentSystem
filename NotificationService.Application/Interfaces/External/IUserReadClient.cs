using NotificationService.Application.DTOs.External;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.Interfaces.External
{
    public interface IUserReadClient
    {
        Task<IsUserExistDto> IsUserExistsByEmailAsync(string email, CancellationToken ct = default);
    }
}
