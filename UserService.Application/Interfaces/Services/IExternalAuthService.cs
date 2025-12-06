using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs.Auth;

namespace UserService.Application.Interfaces.Services
{
    public interface IExternalAuthService
    {
        Task<AuthResponseDto?> LoginWithGoogleAsync(string idToken);
    }
}
