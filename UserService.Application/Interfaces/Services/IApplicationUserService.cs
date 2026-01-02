using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs.User;

namespace UserService.Application.Interfaces.Services
{
    public interface IApplicationUserService
    {
        Task<UserDto?> ChangeIsAdminAsync(Guid userId, ChangeIsAdminDto changeDto);
        Task<UserDto?> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto?> DeleteUserAsync(Guid userId);
        Task<IReadOnlyList<UserDto>> GetAllUsersAsync(CancellationToken ct = default);
        Task<UserDto?> GetUserAsync(Guid userId);
        Task<IsUserExistDto> IsUserExistByEmailAsync(string email);
    }
}
