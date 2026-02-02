using AuthService2024003.Domain.Entities;
using AuthService2024003.Application.Services;
using AuthService2024003.Domain.Contants;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using AuthService2024003.Application.ServicesM;
using System.Reflection.Metadata.Ecma335;

namespace AuthService2024003.Persistence.Data;

public static class DataSeeder
{
    public static async Task seedAsync(ApplicationDbContext context)
    {
        if (!context.Roles.Any())
        {
            var roles = new List<Role>
            {
                new()
                {
                    Id = UuIdGenerator.GenerateRoleId(),
                        Name = RoleConstants.ADMIN_ROLE
                },
                new()
                {
                    Id = UuIdGenerator.GenerateRoleId(),
                        Name = RoleConstants.USER_ROLE
                }
            };
            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();

        }
        if(!await context.Users.AnyAsync())
        {
            var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == RoleConstants.ADMIN_ROLE);
            if(adminRole != null)
            {
                var passwordHasher = new PasswordHashService();
                var userId = UuIdGenerator.GenerateUserId();
                var profileId = UuIdGenerator.GenerateUserId();
                var userRoleId = UuIdGenerator.GenerateUserId();
                var emailId = UuIdGenerator.GenerateUserId();
                var adminUser = new User
                {
                    Id = userId,
                    Name = "Admin",
                    Surname = "User",
                    Username = "admin",
                    Email = "admin@sports.local",
                    Password = passwordHasher.HashPassword("Admin1234!"),
                    Status = true,
                    UserProfile = new UserProfile
                    {
                        Id = profileId, 
                        UserId = userId,
                        ProfilePicture = string.Empty,
                        Phone = string.Empty
                    },
                    UserEmail = new UserEmail
                    {
                        Id = emailId,
                        UserId = userId,
                        EmailVerified = true,
                        EmailVerificationToken = null,
                        EmailVerificationTokenExpiry = null
                    },
                    UserRoles =
                    {
                        new UserRole
                        {
                            Id = userRoleId,
                            UserId = userId,
                            RoleId = adminRole.Id
                        }
                    }
                };
                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();
            }
        }


    }
}