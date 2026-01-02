using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Infrastructure.Identity;

namespace UserService.Persistence
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>(options)
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
