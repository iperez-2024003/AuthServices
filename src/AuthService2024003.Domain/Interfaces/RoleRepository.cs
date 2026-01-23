using AuthService2024003.Domain.Entities;
namespace AuthService2024003.Domain.Interfaces;

public  interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string name);
    Task<int> CountUsersInRoleAsync(string rolename);
    Task<IReadOnlyCollection<User>> GetUsersByRoleAsync(string rolename);
    Task<IReadOnlyCollection<string>> GetUserRoleNameAsync(string userId);
    

}