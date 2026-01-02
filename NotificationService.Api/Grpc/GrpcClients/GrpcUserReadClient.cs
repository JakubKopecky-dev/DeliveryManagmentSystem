using NotificationService.Application.DTOs.External;
using NotificationService.Application.Interfaces.External;
using UserService.Grpc;
using GrpcUserClient = UserService.Grpc.UserService.UserServiceClient;

namespace NotificationService.Api.Grpc.GrpcClients
{
    public class GrpcUserReadClient(GrpcUserClient client) : IUserReadClient
    {
        private readonly GrpcUserClient _client = client;



        public async Task<IsUserExistDto> IsUserExistsByEmailAsync(string email, CancellationToken ct = default)
        {
            IsUserExistRequest request = new() { Email = email };

            IsUserExistResponse response = await _client.IsUserExistAsync(request,cancellationToken: ct);

            return new(response.UserExist, response.UserId);
        }



    }
}
