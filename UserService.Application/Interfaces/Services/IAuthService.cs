using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using UserService.Application.DTOs.Auth;
using UserService.Application.DTOs.User;

namespace UserService.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserDto?> GetCurrentUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<AuthResponseDto?> LoginUserAsync(AuthLoginDto authLoginDto);
        Task<AuthResponseDto?> RegisterUserAsync(AuthRegisterDto authRegisterDto);
    }
}
