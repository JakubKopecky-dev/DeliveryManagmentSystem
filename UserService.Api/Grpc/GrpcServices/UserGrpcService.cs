using Grpc.Core;
using UserService.Application.DTOs.User;
using UserService.Application.Interfaces.Services;
using UserService.Grpc;
using UserGrpcBase = UserService.Grpc.UserService.UserServiceBase;

namespace UserService.Api.Grpc.GrpcServices
{
    public class UserGrpcService(IApplicationUserService userService) : UserGrpcBase
    {
        private readonly IApplicationUserService _userService = userService;



        public override async Task<IsUserExistResponse> IsUserExist(IsUserExistRequest request, ServerCallContext context)
        {
            IsUserExistDto result = await _userService.IsUserExistByEmailAsync(request.Email);

            return new()
            {
                UserExist = result.IsUserExist,
                UserId = result.UserId?.ToString() ?? ""
            };
        }



    }
}
