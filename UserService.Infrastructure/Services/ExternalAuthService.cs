using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs.Auth;
using UserService.Application.DTOs.User;
using UserService.Application.Interfaces.Jwt;
using UserService.Application.Interfaces.Services;
using UserService.Domain.Types;
using UserService.Infrastructure.Auth;
using UserService.Infrastructure.Identity;
using UserService.Infrastructure.Interfaces.Repositories;

namespace UserService.Infrastructure.Services
{
    public  class ExternalAuthService(UserManager<ApplicationUser> userManger, IJwtGenerator jwtGenerator, ILogger<ExternalAuthService> logger, IRefreshTokecRepository refreshTokecRepository) : IExternalAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManger;
        private readonly IJwtGenerator _jwtGenerator = jwtGenerator;
        private readonly ILogger<ExternalAuthService> _logger = logger;
        private readonly IRefreshTokecRepository _refreshTokecRepository = refreshTokecRepository;


        public async Task<AuthResponseDto?> LoginWithGoogleAsync(string idToken)
        {
            _logger.LogInformation("Validating Google ID token...");

            GoogleJsonWebSignature.Payload payload;

            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Invalid Google token.");
                return null;
            }

            string email = payload.Email;
            string googleId = payload.Subject;

            _logger.LogInformation("Google login for email {Email}, GoogleId {GoogleId}", email, googleId);

            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                user = new()
                {
                    Email = email,
                    UserName = email
                };

                await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, UserRoles.User);

                _logger.LogInformation("Created new user {UserId} from Google login.", user.Id);
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token = _jwtGenerator.GenerateToken(user.Id, user.Email!, user.UserName!, roles);

            string refreshToken = RefreshTokenHelper.Generate();

            await _refreshTokecRepository.InsertAsync(new()
            {
                UserId = user.Id,
                TokenHash = RefreshTokenHelper.Hash(refreshToken),
                ExpiresAt = DateTime.UtcNow.AddDays(14)
            });

            return new(user.UserToUserDto(), token,refreshToken);

        }




    }
}
