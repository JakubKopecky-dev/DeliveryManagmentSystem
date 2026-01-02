using HotChocolate.Authorization;
using NotificationService.Api.Auth;
using NotificationService.Application.DTOs.Notification;
using NotificationService.Application.Interfaces.Services;
using System.Security.Claims;

namespace NotificationService.Api.GraphQL
{
    public class Query(INotificationService notificationService, IHttpContextAccessor httpContextAccessor)
    {
        private readonly INotificationService _notificationService = notificationService;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;



        [Authorize(Roles = [UserRoles.User])]
        public async Task<IReadOnlyList<NotificationDto>> GetNotificationsByCustomerEmail(CancellationToken ct)
        {
            string customerEmail = (_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email)) 
                ?? throw new GraphQLException("Unauthorized");

            return await _notificationService.GetNotificationsByCustomerEmailAsync(customerEmail, ct);
        }


    }
}
