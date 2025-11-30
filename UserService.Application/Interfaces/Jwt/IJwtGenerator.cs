using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.Interfaces.Jwt
{
    public interface IJwtGenerator
    {
        string GenerateToken(Guid userId, string email, string userName, IEnumerable<string> roles);
    }
}
