using AuthService2024003.Domain.Entities;
namespace AuthService2024003.Domain.Interfaces;

public  interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string name);
    Task<int> CountUsersInRoleAsync(string rolename);
    Task<IReadOnlyList<User>> GetUsersByRoleAsync(string rolename);
    Task<IReadOnlyList<string>> GetUserRoleNameAsync(string userId);
    

}